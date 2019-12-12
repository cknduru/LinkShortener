using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using SLink.Model;

namespace SLink.Utilities
{
    public class LinkGenerator
    {
        static readonly List<ResolvedURL> _fakedb = new List<ResolvedURL>();

        String GenerateRandomURL()
        {
            return "K3OFMA9V";
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

        public void AddURL(String url)
        {
            _fakedb.Add(new ResolvedURL(url, GenerateRandomURL()));
        }
    }
}
