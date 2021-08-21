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
    public class CustomersController : BaseEntityController<Customer>
    {
        #region DECLARE

        ICustomerService _customerService;
        ICustomerRepository _customerRepository; 
        IBaseRepository<Customer> _baseRepository;
        IBaseService<Customer> _baseService;
        #endregion

        #region Constructor

        public CustomersController(ICustomerService customerService, ICustomerRepository customerRepository,IBaseRepository<Customer> baseRepository,IBaseService<Customer> baseService):base(customerService,baseRepository)
        {
            _customerService = customerService;
            _customerRepository = customerRepository;
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
        #endregion

        #region Method
            [HttpPost("Import")]
            public IActionResult Import(IFormFile formFile)
        {
            try
            {
                var serviceResult = _customerService.Import(formFile);
                if(serviceResult.isValid == true)
                {
                    return StatusCode(200, serviceResult.Data);
                }
                else
                {
                    return StatusCode(500, serviceResult.Data);
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
        #endregion


    }


}

