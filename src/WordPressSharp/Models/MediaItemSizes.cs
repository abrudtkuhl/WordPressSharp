using CookComputing.XmlRpc;

namespace WordPressSharp.Models
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class MediaItemSizes
    {
        [XmlRpcMember("medium")]
        public MediaItemSizes Medium { get; set; }

        [XmlRpcMember("large")]
        public MediaItemSizes Large { get; set; }

        [XmlRpcMember("thumbnail")]
        public MediaItemSizes Thumbnail { get; set; }

        [XmlRpcMember("post_thumbnail")]
        public MediaItemSizes PostThumbnail { get; set; }

        [XmlRpcMember("listing")]
        public MediaItemSizes Listing { get; set; }

        [XmlRpcMember("listing_small")]
        public MediaItemSizes ListingSmall { get; set; }
    }
}
