using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressSharp;
using WordPressSharp.Models;

namespace WordPressSharpTest
{
    [TestClass]
    public class WordPressClientTest
    {
        /// <summary>
        /// Creates the default client.
        /// </summary>
        /// <returns></returns>
        private static WordPressClient CreateDefaultClient()
        {
            return new WordPressClient();
        }

        /// <summary>
        /// Tests the default configuration. Note: settings must be present is App.config.
        /// </summary>
        [TestMethod]
        public void TestDefaultConfiguration()
        {
            //if settings are wrong - CreateDefaultClient will throw an error
            using (var client = CreateDefaultClient())
            {
                Assert.IsNotNull(client.WordPressService, "WordPressService is null.");
            }
        }

        /// <summary>
        /// Tests the get posts.
        /// </summary>
        [TestMethod]
        public void TestGetPosts()
        {
            using (var client = CreateDefaultClient())
            {
                //if something is wrong - GetPosts will throw an error
                var posts = client.GetPosts(new PostFilter());
            }
        }

        /// <summary>
        /// Test Create Post
        /// </summary>
        [TestMethod]
        public void CreatePost()
        {
            using (var client = CreateDefaultClient())
            {
                var post = new Post
                {
                    PostType = "post", // "post" or "page"
                    Title = "Test Title",
                    Content = "Test",
                    PublishDateTime = DateTime.Now,
                    Status = "publish" // "draft" or "publish"
                };

                var id = client.NewPost(post);

                Assert.IsFalse(String.IsNullOrEmpty(id));

                client.DeletePost(Convert.ToInt32(id));
            }
        }

        /// <summary>
        /// Creates a post and a comment.
        /// </summary>
        [TestMethod]
        public void CreatePostAndComment()
        {
            using (var client = CreateDefaultClient())
            {
                var post = new Post
                {
                    PostType = "post", // "post" or "page"
                    Title = "Test CreatePostAndComment",
                    Content = "Testing CreatePostAndComment",
                    Status = "draft" // "draft" or "publish"
                };

                var postId = Convert.ToInt32(client.NewPost(post));

                //test id
                Assert.IsTrue(postId > 0);

                var comment = new Comment
                {
                    PostId = postId.ToString(),
                    Author = "WordPressSharpTestPilot",
                    Content = "Hello world!"
                };

                var commentId = client.NewComment(comment);

                //test comment id
                Assert.IsTrue(commentId > 0);

                //clean up
                client.DeletePost(Convert.ToInt32(postId));
            }
        }
    }
}