using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Common.Logic.Model
{
    public class Alumno : IVuelingObject
    {
        #region Propiedades
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public DateTime Nacimiento { get; set; }
        public DateTime Registro { get; set; }
        public Guid Guid { get; set; }

        #endregion
        public Alumno(int id, string dni, string nombre, string apellidos, int edad, DateTime nacimiento, DateTime registro, Guid guid)
        {
            Id = id;
            Dni = dni;
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            Nacimiento = nacimiento;
            Registro = registro;
            Guid = guid;
        }

        public Alumno()
        {
        }

        public override bool Equals(object obj)
        {
            var alumno = obj as Alumno;
            return alumno != null &&
                   Id == alumno.Id &&
                   Dni == alumno.Dni &&
                   Nombre == alumno.Nombre &&
                   Apellidos == alumno.Apellidos &&
                   Edad == alumno.Edad &&
                   Nacimiento == alumno.Nacimiento &&
                   Registro == alumno.Registro &&
                   Guid.Equals(alumno.Guid);
        }

        public override int GetHashCode()
        {
            var hashCode = -2054622973;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Dni);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            hashCode = hashCode * -1521134295 + Edad.GetHashCode();
            hashCode = hashCode * -1521134295 + Nacimiento.GetHashCode();
            hashCode = hashCode * -1521134295 + Registro.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Guid>.Default.GetHashCode(Guid);
            return hashCode;
        }
    }
}
