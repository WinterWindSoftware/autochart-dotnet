using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoChart.Sdk;

namespace SampleWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var acContext = AutoChartHttpContext.Current();
            ViewBag.VisitorId = acContext.VisitorId;
            ViewBag.SessionId = acContext.SessionId;
            return View();
        }
    }
}