using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.Common.Logic.Model;

namespace Student.DataAccess.Dao.Interfaces
{
    public interface IRepository
    {
        int Create(Alumno alumno);
    }
}
