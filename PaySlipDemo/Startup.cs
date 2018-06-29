using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataHandler.Serializer;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.OAuth;
using Owin;
using PaySlipDemo.Utilities;

[assembly: OwinStartup(typeof(PaySlipDemo.Startup))]

namespace PaySlipDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureDi(app);
        }

        private static void ConfigureDi(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            // REGISTER CONTROLLERS SO DEPENDENCIES ARE CONSTRUCTOR INJECTED
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
           
            builder.RegisterModule(new ServiceModule());

            // BUILD THE CONTAINER
            var container = builder.Build();
            
            // Set the dependency resolver for Web API.
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
            
            IocManager.Instance.IocContainer = container;
        }
    }
}
