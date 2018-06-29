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
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            //builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            //builder.RegisterModule(new EfModule());
            
            //builder.Register<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication)
            //    .InstancePerRequest();
            //builder.Register<IDataProtectionProvider>(c => app.GetDataProtectionProvider()).InstancePerRequest();

            //builder.RegisterType<TicketDataFormat>().As<ISecureDataFormat<AuthenticationTicket>>();

            //builder.RegisterType<TicketSerializer>().As<IDataSerializer<AuthenticationTicket>>();
            //builder.Register(c => new DpapiDataProtectionProvider("TrueForm").Create("ASP.NET Identity"))
            //    .As<IDataProtector>();

            // BUILD THE CONTAINER
            var container = builder.Build();

            // REPLACE THE MVC DEPENDENCY RESOLVER WITH AUTOFAC
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Set the dependency resolver for Web API.
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            // Set the dependency resolver for MVC.
            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);

            //app.UseCors(CorsOptions.AllowAll);

            // Register the Autofac middleware FIRST, then the Autofac MVC middleware.
            app.UseAutofacMiddleware(container);
           // app.UseAutofacMvc().UseCors(CorsOptions.AllowAll);
            //app.UseAutofacWebApi(GlobalConfiguration.Configuration).UseCors(CorsOptions.AllowAll);

            IocManager.Instance.IocContainer = container;
        }
    }
}
