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
        [HttpGet("resolve/{url}")]
        public ActionResult<ResolvedURL> Resolve(String url)
        {
            try
            {
                return LinkGenerator.ResolveURL(url);
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
                ResolvedURL randomUrl = LinkGenerator.AddURL(urlObj.url);

                return randomUrl;
            }
        }
    }
}