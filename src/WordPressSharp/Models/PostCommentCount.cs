using CookComputing.XmlRpc;

namespace WordPressSharp.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class PostCommentCount
    {
        [XmlRpcMember("approved")]
        public string Approved { get; set; }

        [XmlRpcMember("awaiting_moderation")]
        public int TotalAwaitingModeration { get; set; }

        [XmlRpcMember("spam")]
        public int TotalSpam { get; set; }

        [XmlRpcMember("total_comments")]
        public int TotalComments { get; set; }
    }
}
