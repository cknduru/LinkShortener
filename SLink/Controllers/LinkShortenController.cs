using System;
using Microsoft.AspNetCore.Mvc;
using SLink.Utilities;
using SLink.Model;
using Microsoft.AspNetCore.WebUtilities;
using ShortenLink.Model;
using Newtonsoft.Json;

namespace SLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkShortenController : ControllerBase
    {
        readonly LinkGenerator _lg = new LinkGenerator();

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
                return new ResolvedURL(ex.Message, null, null);
            }
        }

        [HttpPost("submit")]
        public ActionResult<ResolvedURL> Submit()
        {
            using (var streamReader = new HttpRequestStreamReader(Request.Body, System.Text.Encoding.UTF8))
            {
                // deserialize JSON
                URLContainer urlObj = JsonConvert.DeserializeObject<URLContainer>(streamReader.ReadToEnd());
                ResolvedURL randomUrl = _lg.AddURL(urlObj.url);

                return randomUrl;
            }
        }
    }
}