namespace Leo.SearchEngine
{
    using Sdl.LanguagePlatform.Core;
    using Sdl.LanguagePlatform.TranslationMemoryApi;
    using System;

    public class SearchEngineTranslationProvider : ITranslationProvider
    {
        ///<summary>
        /// This string needs to be a unique value.
        /// This is the string that precedes the plug-in URI.
        ///</summary>
        public const string SearchEngineProviderScheme = "lucenesearchengine";

        public SearchEngineTranslationProvider(SearchEngineTranslationOptions options)
        {
            this.Options = options;
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public string Name
        {
            get { return PluginResources.Plugin_Name; }
        }

        public SearchEngineTranslationOptions Options { get; set; }

        public ProviderStatusInfo StatusInfo
        {
            get { return new ProviderStatusInfo(true, null); }
        }

        public bool SupportsConcordanceSearch
        {
            get { return true; }
        }

        public bool SupportsDocumentSearches
        {
            get { return false; }
        }

        public bool SupportsFilters
        {
            get { return false; }
        }

        public bool SupportsFuzzySearch
        {
            get { return false; }
        }

        public bool SupportsMultipleResults
        {
            get { return true; }
        }

        public bool SupportsPenalties
        {
            get { return true; }
        }

        public bool SupportsPlaceables
        {
            get { return false; }
        }

        public bool SupportsScoring
        {
            get { return false; }
        }

        public bool SupportsSearchForTranslationUnits
        {
            get { return true; }
        }

        public bool SupportsSourceConcordanceSearch
        {
            get { return true; }
        }

        public bool SupportsStructureContext
        {
            get { return false; }
        }

        public bool SupportsTaggedInput
        {
            get { return false; }
        }

        public bool SupportsTargetConcordanceSearch
        {
            get { return true; }
        }

        public bool SupportsTranslation
        {
            get { return true; }
        }

        public bool SupportsUpdate
        {
            get { return true; }
        }

        public bool SupportsWordCounts
        {
            get { return false; }
        }

        public TranslationMethod TranslationMethod
        {
            get { return TranslationMethod.TranslationMemory; }
        }

        public Uri Uri
        {
            get { return Options.Uri; }
        }

        public ITranslationProviderLanguageDirection GetLanguageDirection(LanguagePair languageDirection)
        {
            return new SearchEngineProviderLanguageDirection(this, languageDirection);
        }

        public void LoadState(string translationProviderState)
        {
        }

        public void RefreshStatusInfo()
        {
        }

        public string SerializeState()
        {
            return null;
        }

        public bool SupportsLanguageDirection(LanguagePair languageDirection)
        {
            // TODO: Perhaps we should verify the language direction
            return true;
        }
    }
}