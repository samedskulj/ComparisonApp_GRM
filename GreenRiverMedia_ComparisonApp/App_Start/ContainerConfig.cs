using Autofac;
using Autofac.Integration.Mvc;
using GreenRiverMedia_ComparisonApp.Repository;
using GreenRiverMedia_ComparisonApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GreenRiverMedia_ComparisonApp.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<ItemService>().As<ItemRepository>().SingleInstance(); //Zbog nedostataka baze podataka, korištenjem in-memory podataka, SingleInstance ce biti dovoljan

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}