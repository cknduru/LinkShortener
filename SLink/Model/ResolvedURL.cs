using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SLink.Model
{
    public class ResolvedURL
    {
        public String unresolved_url { get; set; }
        public String resolved_url { get; set; }

        public ResolvedURL(String unresolved, String resolved)
        {
            unresolved_url = unresolved;
            resolved_url = resolved;
        }
    }
}
