using CookComputing.XmlRpc;

namespace WordPressSharp.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class MediaItemSize
    {
        [XmlRpcMember("file")]
        public string File { get; set; }
        
        [XmlRpcMember("width")]
        public string Width { get; set; }
        
        [XmlRpcMember("height")]
        public string Height { get; set; }
        
        [XmlRpcMember("mime-type")]
        public string MimeType { get; set; }
    }
}
