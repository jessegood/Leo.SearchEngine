namespace Leo.SearchEngine
{
    using Sdl.LanguagePlatform.Core;
    using Sdl.LanguagePlatform.TranslationMemoryApi;
    using System;
    using System.Windows.Forms;

    [TranslationProviderWinFormsUi(
        Id = "SearchEngineProviderWinFormsUI",
        Name = "SearchEngineProviderWinFormsUI",
        Description = "SearchEngineProviderWinFormsUI")]
    public class SearchEngineProviderWinFormsUI : ITranslationProviderWinFormsUI
    {
        public bool SupportsEditing
        {
            get { return true; }
        }

        public string TypeDescription
        {
            get { return PluginResources.Plugin_Description; }
        }

        public string TypeName
        {
            get { return PluginResources.Plugin_Name; }
        }

        public ITranslationProvider[] Browse(IWin32Window owner, LanguagePair[] languagePairs, ITranslationProviderCredentialStore credentialStore)
        {
            var dialog = new SearchEngineOptionDialog(languagePairs);

            if (dialog.ShowDialog(owner) == DialogResult.OK)
            {
                var provider = new SearchEngineTranslationProvider(dialog.Options);
                return new ITranslationProvider[] { provider };
            }

            return null;
        }

        public bool Edit(IWin32Window owner, ITranslationProvider translationProvider, LanguagePair[] languagePairs, ITranslationProviderCredentialStore credentialStore)
        {
            var provider = translationProvider as SearchEngineTranslationProvider;
            if (provider == null) { return false; }

            var dialog = new SearchEngineOptionDialog(languagePairs);
            dialog.Options = provider.Options;

            if (dialog.ShowDialog(owner) == DialogResult.OK)
            {
                provider.Options = dialog.Options;
                return true;
            }

            return false;
        }

        public bool GetCredentialsFromUser(IWin32Window owner, Uri translationProviderUri, string translationProviderState, ITranslationProviderCredentialStore credentialStore)
        {
            return true;
        }

        public TranslationProviderDisplayInfo GetDisplayInfo(Uri translationProviderUri, string translationProviderState)
        {
            TranslationProviderDisplayInfo info = new TranslationProviderDisplayInfo();
            info.Name = PluginResources.Plugin_Name;
            info.TranslationProviderIcon = PluginResources.searchIcon;
            info.SearchResultImage = PluginResources.searchPNG;

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