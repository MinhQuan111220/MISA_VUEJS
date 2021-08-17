using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;
using Dapper;
using System.Text.RegularExpressions;
using MISA.Core.Entities.ModelCustomer;
using MISA.Core.Entities.Interfaces.Services;
using MISA.Core.Entities.Services;
using MISA.Core.Entities.Interfaces.Repository;

namespace MISA.CuckCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;
        ICustomerRepository _customerRepository; 
        IBaseRepository _baseRepository; 
        
        
        public CustomersController(ICustomerService customerService, ICustomerRepository customerRepository,IBaseRepository baseRepository)
        {
            _customerService = customerService;
            _customerRepository = customerRepository;
            _baseRepository = baseRepository;
        }
        /// <summary>
        /// Lấy thông tin tất cả khách hàng
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCustomers(string name, int? age)
        {
            try
            {
                var customers = _baseRepository.GetAll<Customer>();
                // 4. Trả về cho client
                if (customers != null)
                {
                    var response = StatusCode(200, customers);
                    return response;
                }
                else
                {
                    return StatusCode(204, customers);
                }

            }
            catch (Exception )
            {
                var erroObject = new {
                    devMsg = Properties.Resources.DevMsg_Erro500,
                    userMsg = Properties.Resources.Erro500,
                    erorrCode = "misa-001",
                };
                return StatusCode(500, erroObject);
            }
        }
        /// <summary>
        /// Lấy thông tin khách hàng theo Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public IActionResult GetById(Guid customerId)
        {
            
            // Lấy thông tin theo id
            try
            {
                var customer = _baseRepository.GetById<Customer>(customerId);
                // 4. Tra ve cho client
                if (customer != null)
                {
                    return StatusCode(200, customer);

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
            catch (Exception )
            {
                var erroObject = new
                {
                    devMsg = Properties.Resources.DevMsg_Erro500,
                    userMsg = Properties.Resources.Erro500,
                    erorrCode = "misa-001",
                };
                return StatusCode(500, erroObject);
            }
        }
        /// <summary>
        /// Thêm mới một khách hàng
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertCustomer(Customer customer)
        {

            //Bắt đầu thêm mới
            try
            {
                
                var serviceResult = _customerService.Add(customer); 
                // 4. Tra ve cho client
                if (serviceResult.isValid == true)
                {
                   return  StatusCode(201, serviceResult.Data);

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
        /// Sửa dữ liệu cho một khách hàng
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut("{customerId}")]
        public IActionResult UpdateCustomer( Customer customer, Guid customerId)
        {

            try
            {

                var serviceResult = _customerService.Update(customer, customerId);
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
            catch (Exception)
            {
                var erroObject = new
                {
                    devMsg = Properties.Resources.DevMsg_Erro500,
                    userMsg = Properties.Resources.Erro500,
                    erorrCode = "misa-001",
                };
                return StatusCode(500, erroObject);
            }
        }

        /// <summary>
        /// Xóa thông tin khách hàng theo 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer(Guid customerId)
        {
            try
            {
                var customer = _baseRepository.Delete<Customer>(customerId);
                // 4. Tra ve cho client 
                if (customer == 1) 
                {
                    return StatusCode(200, customer);

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
            catch (Exception)
            {
                var erroObject = new
                {
                    devMsg = Properties.Resources.DevMsg_Erro500,
                    userMsg = Properties.Resources.Erro500,
                    erorrCode = "misa-001",
                };
                return StatusCode(500, erroObject);
            }
        }


    }

    
}

