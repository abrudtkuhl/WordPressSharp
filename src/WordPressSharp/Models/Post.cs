using System;
using CookComputing.XmlRpc;
using System.Diagnostics;

using WordPressSharp.Extensions;

namespace WordPressSharp.Models
{
    [DebuggerDisplay("{GetType().Name,nq}: Id={Id, nq}, Title={Title}")]
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Post
    {
        [XmlRpcMember("post_id")]
        public string Id { get; set; }

        [XmlRpcMember("post_type")]
        public string PostType { get; set; }

        [XmlRpcMember("post_title")]
        public string Title { get; set; }

        [XmlRpcMember("post_status")]
        public string Status { get; set; }

        [XmlRpcMember("post_date")]
        public DateTime PublishDateTime { get; set; }

        [XmlRpcMember("post_modified")]
        public DateTime ModifiedDateTime { get; set; }

        [XmlRpcMember("post_content")]
        public string Content { get; set; }

        [XmlRpcMember("post_author")]
        public string Author { get; set; }
        
        [XmlRpcMember("post_name")]
        public string Name { get; set; }

        [XmlRpcMember("link")]
        public string Link { get; set; }

        [XmlRpcMember("terms")]
        public Term[] Terms { get; set; }

        [XmlRpcMember("custom_fields")]
        public CustomField[] CustomFields { get; set; }

        [XmlRpcMember("enclosure")]
        public Enclosure Enclosure { get; set; }

        [XmlRpcMember("media_items")]
        public MediaItem[] MediaItems { get; set; }

        [XmlRpcMember("post_parent")]
        public string ParentId { get; set; }

        public string FeaturedImageId { get; set; }

        [XmlRpcMember("post_thumbnail")]
        public object FeaturedImage { get; set; }

        [XmlRpcMember("post_excerpt")]
        public string Exerpt { get; set; }

		[XmlRpcMember("comment_status")]
		public string CommentStatus { get; set; }


        MediaItem _parsedFeaturedImage;
        public bool HasFeaturedImage()
        {
            if (this._parsedFeaturedImage != null)
            {
                return true;
            }

            return this.GetFeaturedImage() != null;
        }

        public MediaItem GetFeaturedImage()
        {
            var image = this.FeaturedImage as XmlRpcStruct;
            if (image != null)
            {
                this._parsedFeaturedImage = image.ToObject<MediaItem>();
                return this._parsedFeaturedImage;
            }

            return null;
        }
    }
}
