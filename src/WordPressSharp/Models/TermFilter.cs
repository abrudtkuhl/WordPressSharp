using CookComputing.XmlRpc;

namespace WordPressSharp.Models
{
    public class TermFilter : FilterBase
    {
        [XmlRpcMember("offset")]
        public int Offset { get; set; }

        [XmlRpcMember("orderby")]
        public string OrderBy { get; set; }

        [XmlRpcMember("order")]
        public string Order { get; set; }

        [XmlRpcMember("hide_empty")]
        public bool HideEmpty { get; set; }

        [XmlRpcMember("search")]
        public string Search { get; set; }

        public TermFilter()
        {
            Order = "ASC";
            OrderBy = "Title";
            Search = string.Empty;
        }
    }
}
