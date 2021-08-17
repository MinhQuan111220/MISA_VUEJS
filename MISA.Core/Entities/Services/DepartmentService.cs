using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities.Interfaces.Repository;
using MISA.Core.Entities.Interfaces.Services;
using MISA.Core.Entities.ModelDepartment;

namespace MISA.Core.Entities.Services
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        ServiceResult _serviceResult;

        public DepartmentService(IBaseRepository baseRepository) : base(baseRepository)

        {
            _serviceResult = new ServiceResult();
        }

    }
}
