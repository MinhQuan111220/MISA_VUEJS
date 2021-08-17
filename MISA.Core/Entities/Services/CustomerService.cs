using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities.Interfaces.Services;
using MISA.Core.Entities.ModelCustomer;
using MISA.Core.Entities.Interfaces.Repository;
using System.Text.RegularExpressions;
using System.Data;
using MySqlConnector;
using Dapper;

namespace MISA.Core.Entities.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {


        ServiceResult _serviceResult;

        public CustomerService(IBaseRepository baseRepository):base(baseRepository)

        {
            _serviceResult = new ServiceResult();
        }

        
    }

}
