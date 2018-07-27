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
        int Create(Alumno alumno);
    }
}
