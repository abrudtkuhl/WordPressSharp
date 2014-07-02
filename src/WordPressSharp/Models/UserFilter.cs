using CookComputing.XmlRpc;

namespace WordPressSharp.Models
{
    public class UserFilter : FilterBase
    {
        [XmlRpcMember("role")]
        public string Role { get; set; }

        [XmlRpcMember("who")]
        public string Who { get; set; }

        [XmlRpcMember("offset")]
        public int Offset { get; set; }

        [XmlRpcMember("orderby")]
        public string OrderBy { get; set; }

        [XmlRpcMember("order")]
        public string Order { get; set; }
    }
}
