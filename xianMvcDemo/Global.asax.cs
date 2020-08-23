using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using xianMvcDemo.App_Start;

namespace xianMvcDemo
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.Run();
        }
    }
}
