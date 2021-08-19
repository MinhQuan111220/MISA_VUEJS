using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Core.Entities;
using System.Data;
using MySqlConnector;
using Dapper;
using MISA.Core.Entities.Interfaces.Services;
using MISA.Core.Entities.Services;
using MISA.Core.Entities.Interfaces.Repository;
using MISA.Core.Entities.ModelEmployee;

namespace MISA.CuckCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseEntityController<Employee>
    {
        #region DECLARE

        IEmployeeService _employeeService;
        IEmployeeRepository _employeeRepository;
        IBaseRepository<Employee> _baseRepository;
        IBaseService<Employee> _baseService;
        #endregion

        #region Constructor
        public EmployeesController(IEmployeeService employeeService, IEmployeeRepository employeeRepository, IBaseRepository<Employee> baseRepository, IBaseService<Employee> baseService) : base(employeeService, baseRepository)
        {
            _employeeService = employeeService;
            _employeeRepository = employeeRepository;
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
        #endregion

        #region Method

        /// <summary>
        /// Lấy danh sách nhân viên 
        /// </summary>
        /// <param name="PositionId">Vị tí </param>
        /// <param name="DepartmentId"> Phòng ban</param>
        /// <returns>Danh sach nhân viên </returns>

        public override IActionResult Get([FromQuery] string PositionId, [FromQuery] string DepartmentId)
        {
            try
            {
                var employees = _baseRepository.GetAll();

                if (PositionId == "" || PositionId == null && DepartmentId == null || DepartmentId == "")
                {
                    employees = _baseRepository.GetAll();
                }
                else
                {
                    employees = _employeeRepository.GetDeAndPo(PositionId, DepartmentId);

                }
                // 4. Trả về cho client
                if (employees != null)
                {
                    var response = StatusCode(200, employees);
                    return response;
                }
                else
                {
                    return StatusCode(204, employees);
                }


            }
            catch (Exception ex)
            {
                var erroObject = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.Erro500,
                    erorrCode = "misa-001",
                };
                return StatusCode(500, erroObject);
            }
        }

        [HttpGet("filter")]
        public IActionResult GetEmployeesFilterPaging([FromQuery] string EmployeeFilter, [FromQuery] Guid? DepartmentId, [FromQuery] Guid? PositionId, [FromQuery]  Int32 pageIndex, [FromQuery]  Int32 pageSize)
        {
            try
            {
                var employees = _employeeRepository.GetEmployeesFilterPaging(EmployeeFilter, DepartmentId, PositionId, pageIndex, pageSize);

                var response = StatusCode(200, employees);
                return response;
            }
            catch (Exception ex)
            {
                var erroObject = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.Erro500,
                    erorrCode = "misa-001",
                };
                return StatusCode(500, erroObject);
            }
        }
        #endregion
       
    }

}

