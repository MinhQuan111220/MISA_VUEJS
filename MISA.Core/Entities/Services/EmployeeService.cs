using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities.Interfaces.Repository;
using MISA.Core.Entities.Interfaces.Services;
using MISA.Core.Entities.ModelEmployee;

namespace MISA.Core.Entities.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        ServiceResult _serviceResult;

        public EmployeeService(IBaseRepository baseRepository) : base(baseRepository)

        {
            _serviceResult = new ServiceResult();
        }

        protected override Boolean ValidateCustom(Employee entity)
        {
            return true;
        }
    }
}
