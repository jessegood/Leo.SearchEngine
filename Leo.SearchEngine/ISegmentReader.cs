namespace Leo.SearchEngine
{
    using Sdl.LanguagePlatform.Core;
    using System.Collections.Generic;

    internal interface ISegmentReader
    {
        IEnumerable<TranslationSegment> ReadSegments(string filePath, LanguagePair[] languagePairs);
    }
}