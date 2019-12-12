using System;
using System.Collections.Generic;
using ShortenLink.Utilities;
using SLink.Model;

namespace SLink.Utilities
{
    public class LinkGenerator
    {
        static readonly List<ResolvedURL> _fakedb = new List<ResolvedURL>();

        String GenerateRandomURL()
        {
            // begin with server address
            String randomUrl = Constants.SERVER_ADDRESS;
            
            // generate a random hex string of fixed length
            for (int i = 0; i < Constants.RANDOM_LINK_LENGTH; i++)
            {
                randomUrl += new Random().Next(0, 16).ToString("X");
            }


            return randomUrl;
        }

        public ResolvedURL ResolveURL(String unresolved_url)
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

        public String AddURL(String url)
        {
            String randomUrl = GenerateRandomURL();
            _fakedb.Add(new ResolvedURL(url, randomUrl));

            return randomUrl;
        }
    }
}
