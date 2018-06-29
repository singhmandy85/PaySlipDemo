using System;
using System.Linq;
using Autofac;

namespace PaySlipDemo.Services.Infrastructure
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