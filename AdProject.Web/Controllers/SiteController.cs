using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdProject.Web.Models;

namespace AdProject.Web.Controllers
{

    public class SiteController : Controller
    {
        [Route("/")]
        [Route(nameof(Index))]
        public IActionResult Index()
        {

            return View();
        }

        [Route(nameof(Dashboard))]
        public IActionResult Dashboard()
        {
            return View();
        }

        [Route(nameof(About))]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Route(nameof(Contact))]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Route(nameof(Error))]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
