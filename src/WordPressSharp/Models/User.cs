using System;
using CookComputing.XmlRpc;

namespace WordPressSharp.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class User
    {
        [XmlRpcMember("user_id")]
        public string Id { get; set; }

        [XmlRpcMember("username")]
        public string Username { get; set; }

        [XmlRpcMember("first_name")]
        public string FirstName { get; set; }

        [XmlRpcMember("last_name")]
        public string LastName { get; set; }

        [XmlRpcMember("bio")]
        public string Bio { get; set; }

        [XmlRpcMember("email")]
        public string Email { get; set; }

        [XmlRpcMember("nickname")]
        public string Nickname { get; set; }

        [XmlRpcMember("nicename")]
        public string Nicename { get; set; }

        [XmlRpcMember("url")]
        public string Url { get; set; }

        [XmlRpcMember("display_name")]
        public string DisplayName { get; set; }

        [XmlRpcMember("registered")]
        public DateTime RegisteredDate { get; set; }

        [XmlRpcMember("roles")]
        public string[] roles { get; set; }
    }
}
