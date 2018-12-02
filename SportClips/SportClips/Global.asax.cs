using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common.WebHost;
using SportClips.DAL;

namespace SportClips
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            
            string connectionString = ConfigurationManager.ConnectionStrings["SportClips"].ConnectionString;
            kernel.Bind<ISportClipsDAL>().To<SportClipsDAL>().WithConstructorArgument("connectionString", connectionString);

            return kernel;
        }

    }
}
