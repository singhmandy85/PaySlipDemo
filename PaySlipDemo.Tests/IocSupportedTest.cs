using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaySlipDemo.Services.Utilities;

namespace PaySlipDemo.Tests
{
    public class IoCSupportedTest
    {
        private AutofacConsoleHelper helper;

        public IoCSupportedTest()
        {
            helper = new AutofacConsoleHelper();
        }

        protected TEntity Resolve<TEntity>()
        {
            return helper.Resolve<TEntity>();
        }

        protected void ShutdownIoC()
        {
            helper.ShutdownIoC();
        }
    }
}
