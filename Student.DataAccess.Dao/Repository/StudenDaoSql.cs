using Autofac;
using Autofac.Core;
using Student.Common.Logic.Log4net;
using Student.Common.Logic.Model;
using Student.DataAccess.Dao.Interfaces;
using Student.DataAccess.Dao.Modules;
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
            connectionString = "Data Source=.;Initial Catalog=Curso;"
                                + "Integrated Security=true";
        }

        public Alumno Create(Alumno alumno)
        {
            alumno.Registro = DateTime.Now;
            alumno.Guid = Guid.NewGuid();

            Alumno alumnoInsert;
            try
            {
                var sql = "Insert into dbo.Alumno (RowGuid,Nombre,Apellidos,Dni,Nacimiento,Registro,Edad)" +
                    "Values(@RowGuid,@Nombre,@Apellidos,@DNI,@Registro,@Nacimiento,@Edad);";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        _conn.Open();
                        _cmd.Parameters.AddWithValue("@RowGuid", alumno.Guid);
                        _cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                        _cmd.Parameters.AddWithValue("@Apellidos", alumno.Apellidos);
                        _cmd.Parameters.AddWithValue("@DNI", alumno.Dni);
                        _cmd.Parameters.AddWithValue("@Registro", alumno.Registro);
                        _cmd.Parameters.AddWithValue("@Nacimiento", alumno.Nacimiento);
                        _cmd.Parameters.AddWithValue("@Edad", alumno.Edad);
                        _cmd.ExecuteNonQuery();
                        _cmd.Parameters.Clear();

                        _cmd.CommandText = "SELECT @@Identity FROM dbo.Alumno";

                        int id = Convert.ToInt32(_cmd.ExecuteNonQuery());

                        alumnoInsert = GetAlumnoById(id);

                        return alumno;
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

        public List<Alumno> GetAlumnos()
        {
            List<Alumno> alumnos = new List<Alumno>();
            var sql = "usp_GetAllAlumnos";

            using (SqlConnection _conn = new SqlConnection(connectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                {
                    _conn.Open();
                    SqlDataReader reader = _cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var alumno = StudentContainer.Resolve();
                        alumno.Id = reader.GetInt32(0);
                        alumno.Dni = reader.GetString(1);
                        alumno.Nombre = reader.GetString(2);
                        alumno.Apellidos = reader.GetString(3);
                        alumno.Edad = reader.GetInt32(4);
                        alumno.Nacimiento = reader.GetDateTime(5);
                        alumno.Registro = reader.GetDateTime(6);
                        alumno.Guid = reader.GetGuid(7);

                        alumnos.Add(alumno);

                    }
                    return alumnos;
                }
            }
        }
        public Alumno GetAlumnoById(int id)
        {
            var sql = "usp_GetAlumnoByID @id";

            var alumno = StudentContainer.Resolve();
            using (SqlConnection _conn = new SqlConnection(connectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                {
                    _conn.Open();
                    _cmd.Parameters.AddWithValue("@id", id);

                    SqlDataReader reader = _cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        alumno.Id = reader.GetInt32(0);
                        alumno.Dni = reader.GetString(1);
                        alumno.Nombre = reader.GetString(2);
                        alumno.Apellidos = reader.GetString(3);
                        alumno.Edad = reader.GetInt32(4);
                        alumno.Nacimiento = reader.GetDateTime(5);
                        alumno.Registro = reader.GetDateTime(6);
                        alumno.Guid = reader.GetGuid(7);
                    }
                }
            }
            return alumno;
        }
        public bool DeleteAlumnoById(int id)
        {
            var sql = " usp_DeleteAlumnoByID @id";

            var alumno = StudentContainer.Resolve();
            using (SqlConnection _conn = new SqlConnection(connectionString))
            {
                using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                {
                    _conn.Open();
                    _cmd.Parameters.AddWithValue("@id", id);
                    _cmd.ExecuteNonQuery();
                }
            }
            bool IsDelete = GetAlumnoById(id).Id == 0;
            return IsDelete;
        }
        public Alumno UpdateAlumno(Alumno alumno, int id)
        {
            alumno.Registro = DateTime.Now;

            try
            {
                var sql = "usp_UpdateAlumnoByID @id, @Nombre, @Apellidos, @DNI, " +
                           "@Registro, @Nacimiento, @Edad";

                using (SqlConnection _conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand _cmd = new SqlCommand(sql, _conn))
                    {
                        _conn.Open();
                        _cmd.Parameters.AddWithValue("@id", id);
                        _cmd.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                        _cmd.Parameters.AddWithValue("@Apellidos", alumno.Apellidos);
                        _cmd.Parameters.AddWithValue("@DNI", alumno.Dni);
                        _cmd.Parameters.AddWithValue("@Registro", alumno.Registro);
                        _cmd.Parameters.AddWithValue("@Nacimiento", alumno.Nacimiento);
                        _cmd.Parameters.AddWithValue("@Edad", alumno.Edad);
                        _cmd.ExecuteNonQuery();
                        _cmd.Parameters.Clear();

                        return alumno;
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