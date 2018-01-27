using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AdProject.Web.Controllers
{
    public class AdvertsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}