namespace Leo.SearchEngine
{
    using Lucene.Net.Analysis.Standard;
    using Lucene.Net.Documents;
    using Lucene.Net.Index;
    using Lucene.Net.QueryParsers;
    using Lucene.Net.Search;
    using Lucene.Net.Store;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Version = Lucene.Net.Util.Version;
    using Sdl.LanguagePlatform.Core;

    public static class LuceneSearch
    {
        private static FSDirectory directoryTemp;

        public static string IndexDirectory { get; set; }

        public static LanguagePair LanguageDirection { get; internal set; }

        public static void Optimize()
        {
            var analyzer = new StandardAnalyzer(Version.LUCENE_30);

            using (var writer = new IndexWriter(GetDirectory(), analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                analyzer.Close();
                writer.Optimize();
            }
        }

        public static IEnumerable<TranslationSegment> Search(string input)
        {
            return SearchInternal(input);
        }

        public static void UpdateLuceneIndex(IEnumerable<TranslationSegment> segments)
        {
            var analyzer = new StandardAnalyzer(Version.LUCENE_30);

            using (var writer = new IndexWriter(GetDirectory(), analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                foreach (var segment in segments)
                {
                    AddToLuceneIndex(segment, writer);
                }
            }
        }

        internal static void UpdateLuceneIndex(TranslationSegment segment)
        {
            var analyzer = new StandardAnalyzer(Version.LUCENE_30);

            using (var writer = new IndexWriter(GetDirectory(), analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                AddToLuceneIndex(segment, writer);
            }
        }

        private static void AddToLuceneIndex(TranslationSegment segment, IndexWriter writer)
        {
            var document = new Document();

            document.Add(new Field("Source", segment.Source, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Target", segment.Target, Field.Store.YES, Field.Index.ANALYZED));

            writer.AddDocument(document);
        }

        private static FSDirectory GetDirectory()
        {
            if (directoryTemp == null)
            {
                directoryTemp = FSDirectory.Open(new DirectoryInfo(IndexDirectory));
            }

            if (IndexWriter.IsLocked(directoryTemp))
            {
                IndexWriter.Unlock(directoryTemp);
            }

            var lockFilePath = Path.Combine(IndexDirectory, "write.lock");

            if (File.Exists(lockFilePath))
            {
                File.Delete(lockFilePath);
            }

            return directoryTemp;
        }

        private static IEnumerable<TranslationSegment> MapDocumentsToSegmentList(IEnumerable<ScoreDoc> hits, IndexSearcher searcher)
        {
            return hits.Select(hit => MapDocumentToSegment(searcher.Doc(hit.Doc), hit.Score)).ToList();
        }

        private static TranslationSegment MapDocumentToSegment(Document document, float score)
        {
            return new TranslationSegment()
            {
                Source = document.Get("Source"),
                Target = document.Get("Target"),
                MatchPercentage = score
            };
        }

        private static Query ParseQuery(string searchQuery, QueryParser parser)
        {
            Query query;

            try
            {
                query = parser.Parse(searchQuery);
            }
            catch (ParseException)
            {
                query = parser.Parse(QueryParser.Escape(searchQuery));
            }

            return query;
        }

        private static IEnumerable<TranslationSegment> SearchInternal(string searchQuery)
        {
            using (var searcher = new IndexSearcher(GetDirectory(), true))
            {
                var hitLimit = 10;
                var analyzer = new StandardAnalyzer(Version.LUCENE_30);

                var parser = new QueryParser(Version.LUCENE_30, "Source", analyzer);
                var query = ParseQuery(searchQuery, parser);
                var hits = searcher.Search(query, hitLimit).ScoreDocs;
                var results = MapDocumentsToSegmentList(hits, searcher);

                analyzer.Close();

                return results;
            }
        }
    }
}