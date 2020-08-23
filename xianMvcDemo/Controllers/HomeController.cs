using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using NLog;
using Xian.Lib.Core.Dto;
using Xian.Lib.Core.Extension;
using Xian.Lib.Data;
using Xian.Lib.Data.Model;

namespace xianMvcDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}