using CookComputing.XmlRpc;

namespace WordPressSharp.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class PostFilter
    {
        [XmlRpcMember("post_type")]
        public string PostType { get; set; }

        [XmlRpcMember("post_status")]
        public string PostStatus { get; set; }

        [XmlRpcMember("offset")]
        public string Offset { get; set; }

        [XmlRpcMember("orderby")]
        public string OrderBy { get; set; }

        [XmlRpcMember("order")]
        public string Order { get; set; }

        [XmlRpcMember("number")]
        public int Number { get; set; }
    }
}
