using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Common.WebHost;

using lb2mvc.DAL.Interfaces;
using lb2mvc.DAL.Entities;
using lb2mvc.DAL.Repositories;
using lb2mvc.Infrastructure.Binders;
using lb2mvc.Models;

namespace lb2mvc
{
    public class MvcApplication : NinjectHttpApplication//System.Web.HttpApplication
    {
        protected override IKernel CreateKernel()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IRepository<Notebook>>().To<EFNotebookRepository>().WithConstructorArgument("name", "NotebookConnection");
            return kernel;
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }

    }
}
