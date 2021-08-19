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

        #endregion


    }


}

