namespace Leo.SearchEngine
{
    using Sdl.LanguagePlatform.Core;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;

    internal class TmxReader : ISegmentReader
    {
        public IEnumerable<TranslationSegment> ReadSegments(string filePath, LanguagePair[] languagePairs)
        {
            using (var reader = XmlReader.Create(filePath))
            {
                reader.MoveToContent();

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.LocalName == "tu")
                        {
                            var element = XElement.Load(reader.ReadSubtree()) as XElement;

                            var segment = new TranslationSegment();
                            var tuvs = element.Descendants("tuv");

                            var firstLang = tuvs.First().Attribute(XNamespace.Xml + "lang");
                            var secondLang = tuvs.Last().Attribute(XNamespace.Xml + "lang");

                            if (languagePairs.First().SourceCulture.IetfLanguageTag == firstLang.Value)
                            {
                                segment.Source = tuvs.First().Element("seg").Value;
                                segment.Target = tuvs.Last().Element("seg").Value;
                            }
                            else
                            {
                                segment.Source = tuvs.Last().Value;
                                segment.Target = tuvs.First().Value;
                            }

                            yield return segment;
                        }
                    }
                }
            }
        }
    }
}