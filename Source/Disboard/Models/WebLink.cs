using System.Collections.Generic;

namespace Disboard.Models
{
    public class WebLink
    {
        // Uri
        public string Uri { get; set; }

        // rel
        public string Rel { get; set; }

        // anchor
        public string Anchor { get; set; }

        // rev
        public List<string> Rev { get; set; }

        // hreflang
        public string HrefLang { get; set; }

        // title
        public string Title { get; set; }

        // title*
        public string TitleExt { get; set; }

        // type
        public string Type { get; set; }

        // others (extensions)
        public Dictionary<string, string> Extensions { get; } = new Dictionary<string, string>();
    }
}