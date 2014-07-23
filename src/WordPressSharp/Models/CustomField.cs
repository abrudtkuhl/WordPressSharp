using System.Data.Common;
using CookComputing.XmlRpc;

namespace WordPressSharp.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class CustomField
    {
        [XmlRpcMember("id")]
        public string Id { get; set; }

        [XmlRpcMember("key")]
        public string Key { get; set; }

        [XmlRpcMember("value")]
        public string Value { get; set; }
    }
}
