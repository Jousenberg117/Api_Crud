using Autofac;
using Student.Common.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Dao.Modules
{
    public class StudentContainer
    {
        private static IContainer Container { get; set; }
        private static void ConfigureContainer()
        {
            var builderAlumno = new ContainerBuilder();

            builderAlumno
                .RegisterType<Alumno>()
                .InstancePerDependency();
            Container = builderAlumno.Build();
        }

        public static Alumno Resolve()
        {
            ConfigureContainer();
            var scope = Container;
            {
                var alumno = scope.Resolve<Alumno>();
                return alumno;
            }
        }
    }
}
