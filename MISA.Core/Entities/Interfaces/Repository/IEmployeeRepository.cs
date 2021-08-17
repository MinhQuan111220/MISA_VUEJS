using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities.ModelEmployee;

namespace MISA.Core.Entities.Interfaces.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetDeAndPo(string PositionId, string DepartmentId);
    }
}
