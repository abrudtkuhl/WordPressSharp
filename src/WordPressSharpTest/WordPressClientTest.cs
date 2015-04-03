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
	}
}
