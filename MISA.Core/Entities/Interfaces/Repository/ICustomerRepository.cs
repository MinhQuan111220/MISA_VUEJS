using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MISA.Core.Entities.ModelCustomer;

namespace MISA.Core.Entities.Interfaces.Repository
{
    public interface ICustomerRepository
    {
        /// <summary>
        /// Kiểm tra  bị trùng 
        /// </summary>
        /// <param name="value">Dữ liệu kiểm tra </param>
        /// <param name="name">Tên chứa dữ liệu  </param>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns> 
        /// CreatBy : PVM.Quan (18/08/2021)
        public bool checkDuplicateCode(string value, string name);

        /// <summary>
        /// Lấy Id nhóm khách hàng bằng tên nhóm khách hàng 
        /// </summary>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns> 
        /// CreatBy : PVM.Quan (18/08/2021)
        public Guid? getCustomerGroupId(string CustomerGroupName);

    }
}
