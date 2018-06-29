using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using PaySlipDemo.Services.Infrastructure;

namespace PaySlipDemo.Utilities
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            var serviceAssembly = AppDomain
                         .CurrentDomain
                         .GetAssemblies()
                         .FirstOrDefault(a => !a.IsDynamic && a.GetName()
                             .Name
                             .Contains("PaySlipDemo.Services"));

            builder.RegisterAssemblyTypes(serviceAssembly)
                    .Where(t => t.GetInterfaces().Any(i => i == typeof(IPaySlipDemoService)))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope()
                    .PropertiesAutowired();
        }
    }
}