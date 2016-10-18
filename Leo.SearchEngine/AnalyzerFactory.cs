namespace Leo.SearchEngine
{
    using Lucene.Net.Analysis;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Globalization;

    public static class AnalyzerFactory
    {
        public static void GetAnalyzer(CultureInfo sourceCulture)
        {
            if (sourceCulture.Name.StartsWith("ar"))
            {

            }
        }
    }
}
