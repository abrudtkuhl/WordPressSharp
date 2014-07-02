using CookComputing.XmlRpc;

namespace WordPressSharp
{
    public class WordPressSiteCredentials
    {
        [XmlRpcMember("blog_id")]
        public string BlogId { get; set; }

        [XmlRpcMember("username")]
        public string Username { get; set; }

        [XmlRpcMember("password")]
        public string Password { get; set; }
    }
}
