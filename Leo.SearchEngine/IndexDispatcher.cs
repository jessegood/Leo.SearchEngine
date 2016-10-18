namespace Leo.SearchEngine
{
    using System;
    using System.IO;
    using Sdl.LanguagePlatform.Core;

    internal class IndexDispatcher
    {
        public static void AddToIndex(string filePath, LanguagePair[] languagePairs)
        {
            var ext = Path.GetExtension(filePath);

            ISegmentReader reader = new SegmentReader();

            if (ext == ".tmx")
            {
                reader = new TmxReader();
            }

            LuceneSearch.UpdateLuceneIndex(reader.ReadSegments(filePath, languagePairs));
        }
    }
}