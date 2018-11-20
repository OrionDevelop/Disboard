using System.Collections.Generic;
using System.Linq;

using Disboard.Models;

namespace Disboard.Utils
{
    public static class SimpleWebLinkParser
    {
        public static List<WebLink> Parse(string linkHeader)
        {
            var links = new List<WebLink>();
            foreach (var line in linkHeader.Split(','))
            {
                var link = new WebLink();
                var attributes = line.Split(';').Select(w => w.Trim()).ToList();
                var uri = attributes[0]; // first element is URI-Reference
                link.Uri = uri.Substring(1, uri.Length - 2);
                foreach (var attribute in attributes.Skip(1))
                {
                    // key=value
                    var kv = attribute.Split('=');
                    var (key, value) = (kv[0], kv.Length == 2 ? Normalize(kv[1]) : "");

                    switch (key)
                    {
                        case "rel":
                            link.Rel = value;
                            break;

                        case "anchor":
                            link.Anchor = value;
                            break;

                        case "rev":
                            link.Rev = value.Split(' ').Where(w => !string.IsNullOrWhiteSpace(w)).ToList();
                            break;

                        case "hreflang":
                            link.HrefLang = value;
                            break;

                        case "title":
                            link.Title = value;
                            break;

                        case "title*":
                            link.TitleExt = value;
                            break;

                        case "type":
                            link.Type = value;
                            break;

                        // https://www.iana.org/assignments/link-relations/link-relations.xhtml
                        default:
                            link.Extensions.Add(key, value);
                            break;
                    }
                }
                links.Add(link);
            }
            return links;
        }

        private static string Normalize(string value)
        {
            if (value.StartsWith("\""))
                value = value.Substring(1, value.Length - 2);
            return value;
        }
    }
}