using CookComputing.XmlRpc;

namespace WordPressSharp.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Term
    {
        [XmlRpcMember("term_id")]
        public string Id { get; set; }

        [XmlRpcMember("name")]
        public string Name { get; set; }

        [XmlRpcMember("slug")]
        public string Slug { get; set; }

        [XmlRpcMember("term_group")]
        public string TermGroup { get; set; }

        [XmlRpcMember("term_taxonomy_id")]
        public string TermTaxonomyId { get; set; }

        [XmlRpcMember("taxonomy")]
        public string Taxonomy { get; set; }

        [XmlRpcMember("description")]
        public string Description { get; set; }

        [XmlRpcMember("parent")]
        public string Parent { get; set; }

        [XmlRpcMember("count")]
        public int Count { get; set; }
    }
}
