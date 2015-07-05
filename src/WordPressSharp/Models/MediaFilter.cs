using CookComputing.XmlRpc;

namespace WordPressSharp.Models
{
  [XmlRpcMissingMapping(MappingAction.Ignore)]
  public class MediaFilter : FilterBase
  {
    [XmlRpcMember("offset")]
    public int Offset { get; set; }

    [XmlRpcMember("number")]
    public int Number { get; set; }

    [XmlRpcMember("parent_id")]
    public int ParentId { get; set; }

    [XmlRpcMember("mime_type")]
    public string MimeType { get; set; }
  }
}
