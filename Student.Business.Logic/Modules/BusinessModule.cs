using Autofac;
using Student.Common.Logic.Log4net;
using Student.Common.Logic.Model;
using Student.DataAccess.Dao.Interfaces;
using Student.DataAccess.Dao.Modules;
using Student.DataAccess.Dao.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Logic.Modules
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<StudenDaoSql>()
                .As<IRepository>()
                .InstancePerRequest();

            builder
                .RegisterType<Log4netAdapter>()
                .As<ILogger>()
                .InstancePerRequest();

            builder.RegisterModule(new StudentDaoModule());

            base.Load(builder);
        }
    }
}
