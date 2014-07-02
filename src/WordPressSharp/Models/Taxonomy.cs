using CookComputing.XmlRpc;

namespace WordPressSharp.Models
{
    public class Taxonomy
    {
        [XmlRpcMember("name")]
        public string Name { get; set; }

        [XmlRpcMember("label")]
        public string Label { get; set; }

        [XmlRpcMember("hierarchical")]
        public string Hierarchical { get; set; }

        [XmlRpcMember("show_ui")]
        public bool ShowUi { get; set; }

        [XmlRpcMember("_builtin")]
        public bool BuiltIn { get; set; }
    }
}
