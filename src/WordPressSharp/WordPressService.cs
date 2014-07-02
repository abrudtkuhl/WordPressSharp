using System;

namespace WordPressSharp
{
    public class WordPressService : IDisposable
    {
        protected WordPressSiteCredentials WordPressSite { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
