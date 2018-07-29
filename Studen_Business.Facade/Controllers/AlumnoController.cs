using Student.Business.Logic.BusinessLogic;
using Student.Common.Logic.Log4net;
using Student.Common.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Studen_Business.Facade.Controllers
{
    public class AlumnoController : ApiController
    {
        private readonly ILogger Log;
        private readonly IBusiness studenBl;

        public AlumnoController(ILogger Log, IBusiness business)
        {
            this.Log = Log;
            this.studenBl = business;
        }

        // GET: api/Alumno
        [HttpGet()]
        public IHttpActionResult GetAll()
        {
            Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Alumno> alumnos = studenBl.GetAlumnos();

            return Ok(alumnos);
        }

        // GET: api/Alumno/5
        [HttpGet()]
        public IHttpActionResult Get(int id)
        {
            Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);

            Alumno alumno = studenBl.GetAlumnoById(id);

            return Ok(alumno);
        }

        // POST: api/Alumno

        [HttpPost()]
        [ResponseType(typeof(Alumno))]
        public IHttpActionResult Post(Alumno alumno)
        {

            try
            {
                Alumno alumnoInset = studenBl.Create(alumno);
                return CreatedAtRoute("DefaultApi",
                    new { id = alumnoInset.Id }, alumnoInset);
            }
            catch (Exception ex)
            {
                Log.Error(ex + System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        // PUT: api/Alumno/5
        [HttpPut()]
        [ResponseType(typeof(Alumno))]
        public IHttpActionResult Put(int id, Alumno alumno)
        {

            try
            {
                Alumno alumnoInset = studenBl.UpDateAlumno(alumno, id);
                return Ok(alumnoInset);
            }
            catch (Exception ex)
            {
                Log.Error(ex + System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete()]
        // DELETE: api/Alumno/5
        public IHttpActionResult Delete(int id)
        {

            Log.Debug("" + System.Reflection.MethodBase.GetCurrentMethod().Name);

            bool IsDelete = studenBl.DeleteAlumnoById(id);

            return Ok(IsDelete);
        }
    }
}
