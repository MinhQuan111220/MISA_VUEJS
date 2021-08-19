using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities.Interfaces.Repository;
using MISA.Core.Entities.Interfaces.Services;
using MISA.Core.Entities.ModelDepartment;

namespace MISA.Core.Entities.Services
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        #region DECLARE

       
        #endregion

        #region Constructor

        public DepartmentService(IBaseRepository<Department> baseRepository, IConfiguration configuration) : base(baseRepository,  configuration)

        {
        
        }
        #endregion

    }
}
