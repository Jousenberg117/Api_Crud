using Student.Common.Logic.Log4net;
using Student.Common.Logic.Model;
using Student.DataAccess.Dao.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Dao.Repository
{
    public class StudenDaoSql : IRepository
    {
        private readonly ILogger log;
        private readonly string connectionString;
        public StudenDaoSql(ILogger log)
        {
            this.log = log;
            connectionString = "Data Source=.; Inital Catalg= AlumnosCrud; Integrated Security= true";
        }

        public int Create(Alumno alumno)
        {
            try
            {
                var sql = "insert into dbo.Alumnos (UUID, Nombre,Apellido,Dni,DataRegistry,DataBorn,Edad)" +
                    "values(@UUID,@Nombre,@Apellidos,@DNI,@Registro,@Nacimiento,@Edad); ";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        _conn.Open();
                        _cmd.Parameters.AddWithValue("@UUID", alumno.Guid.ToString());
                        _cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                        _cmd.Parameters.AddWithValue("@Nombre", alumno.Apellidos);
                        _cmd.Parameters.AddWithValue("@Apellidos", alumno.Dni);
                        _cmd.Parameters.AddWithValue("@Registro", alumno.Registro);
                        _cmd.Parameters.AddWithValue("@Nacimiento", alumno.Nacimiento);
                        _cmd.Parameters.AddWithValue("@Edad", alumno.Edad);
                        _cmd.ExecuteNonQuery();
                        _cmd.Parameters.Clear();

                        _cmd.CommandText = "Select @@Identity";

                        var id = Convert.ToInt32(_cmd.ExecuteNonQuery());
                        return id;


                    }


                }

            }

            catch (SqlException ex)
            {
                log.Error(ex + System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                log.Error(ex + System.Reflection.MethodBase.GetCurrentMethod().Name);
                throw ex;
            }
        }
    }
}
