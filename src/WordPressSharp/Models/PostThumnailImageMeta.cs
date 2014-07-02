using CookComputing.XmlRpc;

namespace WordPressSharp.Models
{
    public class PostThumnailImageMeta
    {
        [XmlRpcMember("aperture")]
        public int Aperture { get; set; }

        [XmlRpcMember("credit")]
        public string Credit { get; set; }

        [XmlRpcMember("camera")]
        public string Camera { get; set; }

        [XmlRpcMember("caption")]
        public string Caption { get; set; }

        [XmlRpcMember("created_timestamp")]
        public int CreatedTimestamp { get; set; }

        [XmlRpcMember("copyright")]
        public string Copyright { get; set; }

        [XmlRpcMember("focal_length")]
        public int FocalLength { get; set; }

        [XmlRpcMember("iso")]
        public int Iso { get; set; }

        [XmlRpcMember("shutter_speed")]
        public int ShutterSpeed { get; set; }

        [XmlRpcMember("title")]
        public string Title { get; set; }
    }
}
