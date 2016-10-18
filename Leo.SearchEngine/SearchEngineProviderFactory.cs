namespace Leo.SearchEngine
{
    using Sdl.LanguagePlatform.TranslationMemoryApi;
    using System;

    [TranslationProviderFactory(
        Id = "SearchEngineProviderFactory",
        Name = "SearchEngineProviderFactory",
        Description = "Index search engine using Lucene.Net")]
    public class SearchEngineProviderFactory : ITranslationProviderFactory
    {
        public ITranslationProvider CreateTranslationProvider(Uri translationProviderUri, string translationProviderState, ITranslationProviderCredentialStore credentialStore)
        {
            if (!SupportsTranslationProviderUri(translationProviderUri))
            {
                throw new ArgumentException("URI not supported");
            }

            return new SearchEngineTranslationProvider(new SearchEngineTranslationOptions(translationProviderUri));
        }

        public TranslationProviderInfo GetTranslationProviderInfo(Uri translationProviderUri, string translationProviderState)
        {
            var info = new TranslationProviderInfo();

            info.TranslationMethod = TranslationMethod.TranslationMemory;
            info.Name = "Lucene.Net Search Engine";

            return info;
        }

        public bool SupportsTranslationProviderUri(Uri translationProviderUri)
        {
            if (translationProviderUri == null)
            {
                throw new ArgumentNullException("URI not supported");
            }

            return String.Equals(translationProviderUri.Scheme, SearchEngineTranslationProvider.SearchEngineProviderScheme, StringComparison.OrdinalIgnoreCase);
        }
    }
}