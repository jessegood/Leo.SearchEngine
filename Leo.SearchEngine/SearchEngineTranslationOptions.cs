namespace Leo.SearchEngine
{
    using Sdl.LanguagePlatform.TranslationMemoryApi;
    using System;

    public class SearchEngineTranslationOptions
    {
        private readonly TranslationProviderUriBuilder uriBuilder;

        public SearchEngineTranslationOptions()
        {
            uriBuilder = new TranslationProviderUriBuilder(SearchEngineTranslationProvider.SearchEngineProviderScheme);
        }

        public SearchEngineTranslationOptions(Uri uri)
        {
            uriBuilder = new TranslationProviderUriBuilder(uri);
        }

        public string IndexDirectory
        {
            get { return GetStringParameter(nameof(IndexDirectory)); }
            set { SetStringParameter(nameof(IndexDirectory), value); }
        }

        public Uri Uri { get { return uriBuilder.Uri; } }

        private string GetStringParameter(string param)
        {
            string paramString = uriBuilder[param];
            return paramString;
        }

        private void SetStringParameter(string param, string value)
        {
            uriBuilder[param] = value;
        }
    }
}