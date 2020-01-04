using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLink.Model
{
    public class ResolvedURL
    {
        public String randomIdentifier { get; set; }
        public String short_url { get; set; }
        public String resolved_url { get; set; }

        public ResolvedURL(String identifier, String shortUrl, String resolved)
        {
            randomIdentifier = identifier;
            short_url = shortUrl;
            resolved_url = resolved;
        }
    }
}
