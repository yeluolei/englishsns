using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Spring.Web.Mvc;
using Spring.Context.Support;
using Spring.Context;

namespace englishsnsVS10
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    //public class MvcApplication : System.Web.HttpApplication
    //{
    //    public static void RegisterRoutes(RouteCollection routes)
    //    {
    //        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

    //        routes.MapRoute(
    //            "Default", // Route name
    //            "{controller}/{action}/{id}", // URL with parameters
    //            new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
    //        );

    //    }

    //    protected void Application_Start()
    //    {
    //        AreaRegistration.RegisterAllAreas();

    //        RegisterRoutes(RouteTable.Routes);
    //    }
    //}
    public class SpringControllerFactory : IControllerFactory
    {
        /// <summary>
        /// Default ControllerFactory
        /// </summary>
        private static DefaultControllerFactory defalutf = null;

        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            //get spring context
            IApplicationContext ctx = ContextRegistry.GetContext();
            string controller = controllerName + "Controller";
            //查找是否配置该Controller
            if (ctx.ContainsObject(controller))
            {
                object controllerf = ctx.GetObject(controller);
                return (IController)controllerf;

            }
            else
            {
                if (defalutf == null)
                {
                    defalutf = new DefaultControllerFactory();
                }

                return defalutf.CreateController(requestContext, controllerName);

            }

        }

        public void ReleaseController(IController controller)
        {
            //get spring context
            IApplicationContext ctx = ContextRegistry.GetContext();
            if (!ctx.ContainsObject(controller.GetType().Name))
            {
                if (defalutf == null)
                {
                    defalutf = new DefaultControllerFactory();
                }

                defalutf.ReleaseController(controller);
            }
        }

    }
    public class MvcApplication : SpringMvcApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected override void Application_Start(object sender, EventArgs e)
        {
            base.Application_Start(sender, e);

            RegisterAreas();
            //AreaRegistration.RegisterAllAreas();
            ControllerBuilder.Current.SetControllerFactory(typeof(SpringControllerFactory));

            // RegisterRoutes(RouteTable.Routes);
        }
    }
}