using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities.Interfaces.Repository;
using MISA.Core.Entities.Interfaces.Services;
using MISA.Core.Entities.ModelDepartment;

namespace MISA.CuckCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartmentsController : BaseEntityController<Department>
    {
        #region DECLARE

        IDepartmentService _DepartmentService;
        IDepartmentRepository _DepartmentRepository;
        IBaseRepository<Department> _baseRepository;
        IBaseService<Department> _baseService;
        #endregion

        #region Constructor

        public DepartmentsController(IDepartmentService DepartmentService, IDepartmentRepository DepartmentRepository, IBaseRepository<Department> baseRepository, IBaseService<Department> baseService) : base(DepartmentService, baseRepository)
        {
            _DepartmentService = DepartmentService;
            _DepartmentRepository = DepartmentRepository;
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
        #endregion

        #region Method

        #endregion


    }
}
