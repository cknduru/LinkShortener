using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SLink.Model;
using SLink.Utilities;

namespace ShortenLink.Controllers
{
    public class MainPageController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            // display front page, this returns the view matching MainPage/Index.cshtml
            return View();
        }

        [HttpGet("/web/{unresolved_url}")]
        public IActionResult RedirectToResolvedURL(String unresolved_url)
        {
            // redirect user to resolved URL
            ResolvedURL resolvedURL = LinkGenerator.ResolveURL(unresolved_url);
            return Redirect(resolvedURL.resolved_url);
        }
    }
}