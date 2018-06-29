using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace PaySlipDemo.Services.Infrastructure
{
    public enum PlatformExecutionType
    {
        Console,
        ASpNet
    }

    public class IocManager
    {
        static IocManager()
        {
            Instance = new IocManager();
        }

        private IocManager()
        {
        }

        /// <summary>
        ///     The Singleton instance.
        /// </summary>
        public static IocManager Instance { get; private set; }

        /// <summary>
        ///     use to determine which ioc container to use
        /// </summary>
        public PlatformExecutionType PlatformExecutionType { get; set; } = PlatformExecutionType.ASpNet;


        /// <summary>
        ///     Reference to the Autofac Container.
        /// </summary>
        public IContainer IocContainer { get; set; }

        /// <inheritdoc />
        public void Dispose()
        {
            IocContainer.Dispose();
        }

        public bool IsRegistered(Type type)
        {
            using (var scope = IocContainer.BeginLifetimeScope())
            {
                return scope.IsRegistered(type);
            }
        }

        public bool IsRegistered<T>()
        {
            using (var scope = IocContainer.BeginLifetimeScope())
            {
                return scope.IsRegistered(typeof(T));
            }
        }


        public static T Resolve<T>()
        {
            //try
            //{
            //    var t = (T)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(T));
            //    if (t != null)
            //        return t;
            //}
            //catch (Exception exx)
            //{

            //}

            try
            {
                var t2 = IocManager.Instance.IocContainer.Resolve<T>();
                if (t2 != null)
                    return t2;
            }
            catch (Exception ex)
            {

            }

            return default(T);
        }
    }
}
