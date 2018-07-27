using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Student.Business.Logic.BusinessLogic;
using Student.Common.Logic.Log4net;
using Student.Business.Logic.Modules;

namespace Studen_Business.Facade.Modules
{
    public class StudentApiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder
                .RegisterType<StudentBL>()
                .As<IBusiness>()
                .InstancePerRequest();

            builder
                .RegisterType<Log4netAdapter>()
                .As<ILogger>()
                .InstancePerRequest();


            builder.RegisterModule(new BusinessModule());

            base.Load(builder);
        }
    }
}