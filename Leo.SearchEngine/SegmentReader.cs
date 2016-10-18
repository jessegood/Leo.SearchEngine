namespace Leo.SearchEngine
{
    using Sdl.LanguagePlatform.Core;
    using System.Collections.Generic;
    using System.Linq;

    internal class SegmentReader : ISegmentReader
    {
        public IEnumerable<TranslationSegment> ReadSegments(string filePath, LanguagePair[] languagePairs)
        {
            return Enumerable.Empty<TranslationSegment>();
        }
    }
}