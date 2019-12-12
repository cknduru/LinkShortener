using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SLink.Utilities;
using SLink.Model;
using Microsoft.AspNetCore.WebUtilities;

namespace SLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkShortenController : ControllerBase
    {
        readonly LinkGenerator _lg;

        public LinkShortenController()
        {
            _lg = new LinkGenerator();
        }

        [HttpGet("resolve/{url}")]
        public ActionResult<ResolvedURL> Get(String url)
        {
            Console.WriteLine("resolve received URL: {0}", url);

            try
            {
                return _lg.ResolveURL(url);
            } catch (System.ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return new ResolvedURL(ex.Message, ex.Message);
            }
        }

        [HttpPost("submit")]
        public  IActionResult Submit()
        {
            using (var streamReader = new HttpRequestStreamReader(Request.Body, System.Text.Encoding.UTF8))
            {
                using (var jsonReader = new Newtonsoft.Json.JsonTextReader(streamReader))
                {
                    Console.WriteLine("submit received URL:{0}", jsonReader.Value);
                    _lg.AddURL(jsonReader.Value.ToString());
                    return Accepted();
                }
            }
        }
    }
}