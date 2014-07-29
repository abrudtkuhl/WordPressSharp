using CookComputing.XmlRpc;

namespace WordPressSharp.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class MediaFilter : FilterBase
    {
        [XmlRpcMember("offset")]
        public string Offset { get; set; }

        [XmlRpcMember("parent_id")]
        public string ParentId { get; set; }

        [XmlRpcMember("mime_type")]
        public string MimeType { get; set; }
    }
}
