namespace Leo.SearchEngine
{
    using Sdl.Core.Globalization;
    using Sdl.LanguagePlatform.Core;
    using Sdl.LanguagePlatform.TranslationMemory;
    using Sdl.LanguagePlatform.TranslationMemoryApi;
    using System;
    using System.Collections.Generic;

    public class SearchEngineProviderLanguageDirection : ITranslationProviderLanguageDirection
    {
        private readonly SearchEngineTranslationOptions options;
        private readonly SearchEngineTranslationProvider provider;
        private LanguagePair languageDirection;

        public SearchEngineProviderLanguageDirection(SearchEngineTranslationProvider provider, LanguagePair languageDirection)
        {
            this.provider = provider;
            this.options = provider.Options;
            this.languageDirection = languageDirection;
            LuceneSearch.IndexDirectory = this.options.IndexDirectory;
            LuceneSearch.LanguageDirection = languageDirection;
        }

        public bool CanReverseLanguageDirection
        {
            get { return true; }
        }

        public System.Globalization.CultureInfo SourceLanguage
        {
            get { return languageDirection.SourceCulture; }
        }

        public System.Globalization.CultureInfo TargetLanguage
        {
            get { return languageDirection.TargetCulture; }
        }

        public ITranslationProvider TranslationProvider
        {
            get { return provider; }
        }

        public ImportResult[] AddOrUpdateTranslationUnits(TranslationUnit[] translationUnits, int[] previousTranslationHashes, ImportSettings settings)
        {
            var results = new List<ImportResult>();

            foreach (var tu in translationUnits)
            {
                results.Add(AddTranslationUnit(tu, settings));
            }

            return results.ToArray();
        }

        public ImportResult[] AddOrUpdateTranslationUnitsMasked(TranslationUnit[] translationUnits, int[] previousTranslationHashes, ImportSettings settings, bool[] mask)
        {
            if (mask == null || translationUnits.Length != mask.Length)
            {
                throw new ArgumentException("mask in AddOrUpdateTranslationUnitsMasked");
            }

            ImportResult[] results = new ImportResult[translationUnits.Length];

            for (int i = 0; i < translationUnits.Length; ++i)
            {
                if (mask[i])
                {
                    results[i] = new ImportResult();
                    AddTranslationUnit(translationUnits[i], settings);
                }
                else
                {
                    results[i] = null;
                }
            }

            return results;
        }

        public ImportResult AddTranslationUnit(TranslationUnit translationUnit, ImportSettings settings)
        {
            var result = new ImportResult();
            result.Action = Sdl.LanguagePlatform.TranslationMemory.Action.Add;
            result.TuId = new PersistentObjectToken(translationUnit.GetHashCode(), Guid.Empty);

            var segment = new TranslationSegment();
            segment.Source = translationUnit.SourceSegment.ToPlain();
            segment.Target = translationUnit.TargetSegment.ToPlain();

            LuceneSearch.UpdateLuceneIndex(segment);

            return result;
        }

        public ImportResult[] AddTranslationUnits(TranslationUnit[] translationUnits, ImportSettings settings)
        {
            var results = new List<ImportResult>();

            foreach (var tu in translationUnits)
            {
                results.Add(AddTranslationUnit(tu, settings));
            }

            return results.ToArray();
        }

        public ImportResult[] AddTranslationUnitsMasked(TranslationUnit[] translationUnits, ImportSettings settings, bool[] mask)
        {
            throw new NotImplementedException();
        }

        public SearchResults SearchSegment(SearchSettings settings, Segment segment)
        {
            var searchResults = new SearchResults();
            searchResults.SourceSegment = segment.Duplicate();

            foreach (var result in LuceneSearch.Search(segment.ToPlain()))
            {
                var translation = new Segment(languageDirection.TargetCulture);
                translation.Add(result.Target);
                searchResults.Add(CreateSearchResult(translation, result.Source, result.MatchPercentage, false));
            }

            return searchResults;
        }

        public SearchResults[] SearchSegments(SearchSettings settings, Segment[] segments)
        {
            var results = new SearchResults[segments.Length];
            for (int p = 0; p < segments.Length; ++p)
            {
                results[p] = SearchSegment(settings, segments[p]);
            }

            return results;
        }

        public SearchResults[] SearchSegmentsMasked(SearchSettings settings, Segment[] segments, bool[] mask)
        {
            if (segments == null)
            {
                throw new ArgumentNullException("segments in SearchSegmentsMasked");
            }
            if (mask == null || mask.Length != segments.Length)
            {
                throw new ArgumentException("mask in SearchSegmentsMasked");
            }

            SearchResults[] results = new SearchResults[segments.Length];
            for (int p = 0; p < segments.Length; ++p)
            {
                if (mask[p])
                {
                    results[p] = SearchSegment(settings, segments[p]);
                }
                else
                {
                    results[p] = null;
                }
            }

            return results;
        }

        public SearchResults SearchText(SearchSettings settings, string segment)
        {
            var s = new Segment(languageDirection.SourceCulture);
            s.Add(segment);
            return SearchSegment(settings, s);
        }

        public SearchResults SearchTranslationUnit(SearchSettings settings, TranslationUnit translationUnit)
        {
            return SearchSegment(settings, translationUnit.SourceSegment);
        }

        public SearchResults[] SearchTranslationUnits(SearchSettings settings, TranslationUnit[] translationUnits)
        {
            SearchResults[] results = new SearchResults[translationUnits.Length];
            for (int p = 0; p < translationUnits.Length; ++p)
            {
                results[p] = SearchSegment(settings, translationUnits[p].SourceSegment);
            }
            return results;
        }

        public SearchResults[] SearchTranslationUnitsMasked(SearchSettings settings, TranslationUnit[] translationUnits, bool[] mask)
        {
            List<SearchResults> results = new List<SearchResults>();

            int i = 0;
            foreach (var tu in translationUnits)
            {
                if (mask == null || mask[i])
                {
                    var result = SearchTranslationUnit(settings, tu);
                    results.Add(result);
                }
                else
                {
                    results.Add(null);
                }

                i++;
            }

            return results.ToArray();
        }

        public ImportResult UpdateTranslationUnit(TranslationUnit translationUnit)
        {
            throw new NotImplementedException();
        }

        public ImportResult[] UpdateTranslationUnits(TranslationUnit[] translationUnits)
        {
            throw new NotImplementedException();
        }

        private SearchResult CreateSearchResult(Segment translation, string sourceSegment, float matchPercent, bool formattingPenalty)
        {
            var tu = new TranslationUnit();
            Segment orgSegment = new Segment();
            orgSegment.Add(sourceSegment);
            tu.SourceSegment = orgSegment;
            tu.TargetSegment = translation;

            tu.ResourceId = new PersistentObjectToken(tu.GetHashCode(), Guid.Empty);

            int score = (int)Math.Ceiling(10.0f * matchPercent);
            tu.Origin = TranslationUnitOrigin.TM;

            SearchResult searchResult = new SearchResult(tu);
            searchResult.ScoringResult = new ScoringResult();
            searchResult.ScoringResult.BaseScore = score;

            if (formattingPenalty)
            {
                tu.ConfirmationLevel = ConfirmationLevel.Draft;

                Penalty penalty = new Penalty(PenaltyType.TagMismatch, 1);
                searchResult.ScoringResult.ApplyPenalty(penalty);
            }
            else
            {
                tu.ConfirmationLevel = ConfirmationLevel.Translated;
            }

            return searchResult;
        }
    }
}