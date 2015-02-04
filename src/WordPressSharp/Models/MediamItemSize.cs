using CookComputing.XmlRpc;

namespace WordPressSharp.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class MediaItemSize
    {
        [XmlRpcMember("file")]
        public string File { get; set; }
        
        [XmlRpcMember("width")]
        public int Width { get; set; }
        
        [XmlRpcMember("height")]
        public int Height { get; set; }
        
        [XmlRpcMember("mime_type")]
        public string MimeType { get; set; }
    }
}
