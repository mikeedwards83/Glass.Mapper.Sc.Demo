using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Glass.Mapper.Sc.Demo.App_Start;
using StackExchange.Profiling;

namespace Glass.Mapper.Sc.Demo
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : Sitecore.Web.Application
    {
        protected void Application_Start()
        {
            var container = GlassMapperSc.Resolver.Container;
            GlobalConfiguration.Configuration.Services.Replace(typeof (IHttpControllerActivator),
                new WindowsControllerActivator(container));
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));

            container.Register(
                Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient(),
                Component.For<ISitecoreContext>().ImplementedBy<SitecoreContext>().LifestylePerWebRequest(),
                Component.For<ISitecoreService>().ImplementedBy<SitecoreService>()
                    .DependsOn(new { databaseName = "master" })
                );


            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest()
        {
            if (Request.RawUrl.EndsWith(".aspx") && !Request.RawUrl.Contains("sitecore") && Request.IsLocal)
            {
                MiniProfiler.Start();
            }
        }

        protected void Application_EndRequest()
        {
            
            MiniProfiler.Stop();
        }
    }
}