using System;
using System.Web;

//using Microsoft.Web.Infrastr;

using Ninject;
using Ninject.Web.Common;
using Ninject.Modules;
//using Ninject.Extensions.Logging.Log4net;
using Ninject.Web.WebApi;
using Event.Core;
using Event.Business;
using Event.Web.App_Start;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Event.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Event.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Event.Web.App_Start
{
   

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
            var settings = new NinjectSettings { LoadExtensions = false };
            var kernel = new StandardKernel(settings, new INinjectModule[] {  });

            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                // ControllerBuilder.Current.SetControllerFactory(new ControllerFactory(kernel)); <-- used that until WebApi entered the solution\

                System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel); // webApi controller
                System.Web.Mvc.DependencyResolver.SetResolver(new NinjectMvcDependencyResolver(kernel)); // mvc controller

                return kernel;
            }
            catch(Exception ex)
            {
                var foo = ex.Message;
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
            // Services ------------------

            kernel.Bind<IEventManager>()
                .To<EventManager>()
                .InTransientScope();

            }
    }
}
