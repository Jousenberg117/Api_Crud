using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Common.Logic.Log4net;
using Student.Common.Logic.Model;
using Student.DataAccess.Dao.Interfaces;

namespace Student.Business.Logic.BusinessLogic
{
    public class StudentBL : IBusiness
    {
        private readonly ILogger Log;
        private readonly IRepository repository;

        public StudentBL(ILogger Logger, IRepository dao)
        {
            this.Log = Logger;
            this.repository = dao;
        }

        public Alumno Create(Alumno alumno)
        {
            Alumno alumnoInsert;
            try
            {
                Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);

                alumnoInsert = repository.Create(alumno);

                return alumnoInsert;
            }
            catch (Exception ex)
            {
                Log.Error(ex + System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
        }

        public bool DeleteAlumnoById(int id)
        {
                Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.DeleteAlumnoById(id);
        }

        public Alumno GetAlumnoById(int id)
        {
                Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.GetAlumnoById(id);
        }

        public List<Alumno> GetAlumnos()
        {
                Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.GetAlumnos();
        }

        public Alumno UpdateAlumno(Alumno alumno, int id)
        {
            try
            {
                Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);
                return repository.UpdateAlumno(alumno, id);
            }
            catch (Exception ex)
            {
                Log.Error(ex + System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
        }
    }
}
