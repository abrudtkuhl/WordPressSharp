using System;
using CookComputing.XmlRpc;

namespace WordPressSharp.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Comment
    {
        [XmlRpcMember("comment_id")]
        public string Id { get; set; }

        [XmlRpcMember("parent")]
        public string Parent { get; set; }

        [XmlRpcMember("user_id")]
        public string UserId { get; set; }

        [XmlRpcMember("date_created_gmt")]
        public DateTime DateCreated { get; set; }

        [XmlRpcMember("status")]
        public string Status { get; set; }

        [XmlRpcMember("content")]
        public string Content { get; set; }

        [XmlRpcMember("link")]
        public string Link { get; set; }

        [XmlRpcMember("post_id")]
        public string PostId { get; set; }

        [XmlRpcMember("post_title")]
        public string PostTitle { get; set; }

        [XmlRpcMember("author")]
        public string Author { get; set; }

        [XmlRpcMember("author_url")]
        public string AuthorUrl { get; set; }

        [XmlRpcMember("author_email")]
        public string AuthorEmail { get; set; }

        [XmlRpcMember("author_ip")]
        public string AuthorIp { get; set; }

        [XmlRpcMember("type")]
        public string Type { get; set; }

    }
}
