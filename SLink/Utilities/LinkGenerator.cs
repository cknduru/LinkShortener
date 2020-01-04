using System;
using System.Collections.Generic;
using ShortenLink.Utilities;
using SLink.Model;

namespace SLink.Utilities
{
    public static class LinkGenerator
    {
        static readonly List<ResolvedURL> _fakedb = new List<ResolvedURL>();

        public static ResolvedURL GenerateRandomURL(String resolvedUrl)
        {
            // begin with server address
            String randomUrl = "";
            
            // generate a random hex string of fixed length
            for (int i = 0; i < Constants.RANDOM_LINK_LENGTH; i++)
            {
                randomUrl += new Random().Next(0, 16).ToString("X");
            }


            return new ResolvedURL(randomUrl, Constants.SERVER_ADDRESS + randomUrl, resolvedUrl);
        }

        public static ResolvedURL ResolveURL(String unresolved_url)
        {
            foreach(var u in _fakedb)
            {
                // find resolved url matching random url
                if (u.unresolved_url == unresolved_url)
                {
                    return u;
                }
            }

            throw new System.ArgumentException("Random URL was not valid");
        }

        public static ResolvedURL AddURL(String url)
        {
            ResolvedURL resolvedUrl = GenerateRandomURL(url);
            _fakedb.Add(resolvedUrl);

            return resolvedUrl;
        }
    }
}
