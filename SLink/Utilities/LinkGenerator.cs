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
            String randomIdentifier = "";
            
            // generate a random hex string of fixed length
            // this is used as the random part of the shortned address
            for (int i = 0; i < Constants.RANDOM_LINK_LENGTH; i++)
            {
                randomIdentifier += new Random().Next(0, 16).ToString("X");
            }

            return new ResolvedURL(randomIdentifier, Constants.SERVER_ADDRESS + randomIdentifier, resolvedUrl);
        }

        public static ResolvedURL ResolveURL(String randomIdentifier)
        {
            foreach(var url in _fakedb)
            {
                // find resolved url matching random url
                if (url.random_identifier == randomIdentifier)
                {
                    return url;
                }
            }

            // throw exception if the random identifier does not match any known identifier
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
