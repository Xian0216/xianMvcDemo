using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NLog;
using Xian.Lib.Core.Dto;
using Xian.Lib.Core.Extension;
using Xian.Lib.Core.Utility;
using Xian.Lib.Data;
using Xian.Lib.Data.Model;
using xianMvcDemo.Models;

namespace xianMvcDemo.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        [Authorize()]
        public ActionResult Index()
        {
            return View();
        }
    }
}