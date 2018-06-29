using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using PaySlipDemo.Services.Infrastructure;

namespace PaySlipDemo.Services.Utilities
{
    public class AutofacConsoleHelper
    {
        private IContainer container;

        public AutofacConsoleHelper()
        {
            var builder = new ContainerBuilder();
            
            builder.RegisterModule(new ServiceModule());
            
            // BUILD THE CONTAINER
            container = builder.Build();
            
            IocManager.Instance.IocContainer = container;
            IocManager.Instance.PlatformExecutionType = PlatformExecutionType.Console;
            
        }
      
        public TEntity Resolve<TEntity>()
        {
            return container.Resolve<TEntity>();
        }

        public void ShutdownIoC()
        {
            container.Dispose();
        }
        

    }
}
