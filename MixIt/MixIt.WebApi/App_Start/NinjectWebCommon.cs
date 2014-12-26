[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MixIt.WebApi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MixIt.WebApi.App_Start.NinjectWebCommon), "Stop")]

namespace MixIt.WebApi.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using BrockAllen.MembershipReboot;
    using BrockAllen.MembershipReboot.WebHost;
    using MixIt.WebApi.Entities;
    using MixIt.WebApi.Customization;
    using MixIt.WebApi.Helper;
    using System.Web.Http;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
           

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var config = MembershipRebootConfig.Create();
            kernel.Bind<UserAccountService<CustomUserAccount>>().ToSelf();
            kernel.Bind<MembershipRebootConfiguration<CustomUserAccount>>().ToConstant(config);
            kernel.Bind<IUserAccountRepository<CustomUserAccount>>().To<CustomUserAccountRepository>().InRequestScope();
            kernel.Bind<CustomDb>().ToSelf().InRequestScope();
        }        
    }
}
