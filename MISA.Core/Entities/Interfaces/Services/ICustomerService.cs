using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MISA.Core.Entities.ModelCustomer;

namespace MISA.Core.Entities.Interfaces.Services
{
    public interface ICustomerService : IBaseService<Customer>
    {
        #region Method
        /// <summary>
        /// Import dữ liệu khách hàng từ file 
        /// </summary>
        /// <returns>Danh sách khách hàng hợp lệ </returns>
        ServiceResult Import(IFormFile formFile);
        #endregion
    }
}
