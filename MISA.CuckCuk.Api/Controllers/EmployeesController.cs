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
    public class EmployeesController : ControllerBase
    {
        IEmployeeService _employeeService;
        IEmployeeRepository _employeeRepository;
        IBaseRepository _baseRepository;


        public EmployeesController(IEmployeeService employeeService, IEmployeeRepository employeeRepository, IBaseRepository baseRepository)
        {
            _employeeService = employeeService;
            _employeeRepository = employeeRepository;
            _baseRepository = baseRepository;
        }
        /// <summary>
        /// Lấy thông tin tất cả nhân viên
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetEmployees([FromQuery] string PositionId, [FromQuery] string DepartmentId)
        {
            try
            {
                var employees = _baseRepository.GetAll<Employee>();

                if (PositionId == ""|| PositionId == null && DepartmentId == null || DepartmentId == "")
                {
                    employees = _baseRepository.GetAll<Employee>();
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
        /// <summary>
        /// Lấy thông tin nhân viên theo Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet("{employeeId}")]
        public IActionResult GetById(Guid employeeId)
        {

            // Lấy thông tin theo id
            try
            {
                var employee = _baseRepository.GetById<Employee>(employeeId);
                // 4. Tra ve cho client
                if (employee != null)
                {
                    return StatusCode(200, employee);

                }
                else
                {
                    var erroObject = new
                    {
                        userMsg = Properties.Resources.UserMsg_Erro400,
                        erorrCode = "misa-001",
                    };
                    return StatusCode(400, erroObject);
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
        /// <summary>
        /// Thêm mới một nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insertemployee(Employee employee)
        {

            //Bắt đầu thêm mới
            try
            {

                var serviceResult = _employeeService.Add(employee);
                // 4. Tra ve cho client
                if (serviceResult.isValid == true)
                {
                    return StatusCode(201, serviceResult.Data);

                }
                else
                {
                    return BadRequest(serviceResult.Data);
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

        /// <summary>
        /// Sửa dữ liệu cho một nhân viên
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut("{employeeId}")]
        public IActionResult Updateemployee(Employee employee, Guid employeeId)
        {

            try
            {

                var serviceResult = _employeeService.Update(employee, employeeId);
                // 4. Tra ve cho client
                if (serviceResult.isValid == true)
                {
                    return StatusCode(200, serviceResult.Data);

                }
                else
                {
                    return BadRequest(serviceResult.Data);
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

        /// <summary>
        /// Xóa thông tin nhân viên theo 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpDelete("{employeeId}")]
        public IActionResult Deleteemployee(Guid employeeId)
        {
            try
            {
                var employee = _baseRepository.Delete<Employee>(employeeId);
                // 4. Tra ve cho client 
                if (employee == 1)
                {
                    return StatusCode(200, employee);

                }
                else
                {
                    var erroObject = new
                    {
                        userMsg = Properties.Resources.UserMsg_Erro400,
                        erorrCode = "misa-001",
                    };
                    return StatusCode(400, erroObject);
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
    }

}

