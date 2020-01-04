using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLink.Model
{
    public class ResolvedURL
    {
        public String random_identifier { get; set; }
        public String short_url { get; set; }
        public String resolved_url { get; set; }

        public ResolvedURL(String randomIdentifier, String shortUrl, String resolved)
        {
            random_identifier = randomIdentifier;
            short_url = shortUrl;
            resolved_url = resolved;
        }
    }
}
