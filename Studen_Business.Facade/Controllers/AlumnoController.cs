using Student.Business.Logic.BusinessLogic;
using Student.Common.Logic.Log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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

            return Ok();
        }

        // GET: api/Alumno/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Alumno
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Alumno/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Alumno/5
        public void Delete(int id)
        {
        }
    }
}
