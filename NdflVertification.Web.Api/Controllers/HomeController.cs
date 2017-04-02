using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NdflVertification.Web.Api.App_Start;

namespace NdflVertification.Web.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITest _test;

        public HomeController(ITest test)
        {
            _test = test;
        }


        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
