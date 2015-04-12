using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordPressSharp.Models;

namespace WordPressSharpTest
{
	[TestClass]
	public class DataTest
	{
		[TestMethod]
		public void TestCreateFromUrl()
		{
			string url = "https://unsplash.imgix.net/photo-1423683249427-8ca22bd873e0";

			var data = Data.CreateFromUrl(url);

			Assert.AreEqual(data.Name,  "photo-1423683249427-8ca22bd873e0");
			Assert.AreEqual(data.Type, "image/jpeg");
			Assert.AreEqual(0, data.Bits.Length);
		}
	}
}
