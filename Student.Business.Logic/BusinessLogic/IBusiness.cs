using Student.Common.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Business.Logic.BusinessLogic
{
    public interface IBusiness
    {
        Alumno Create(Alumno alumno);
        List<Alumno> GetAlumnos();
        Alumno GetAlumnoById(int id);
        bool DeleteAlumnoById(int id);
        Alumno UpDateAlumno(Alumno alumno, int id);
    }
}
