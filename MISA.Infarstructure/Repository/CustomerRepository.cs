using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities.Interfaces.Repository;
using MISA.Core.Entities.ModelCustomer;
using MySqlConnector;
using OfficeOpenXml;

namespace MISA.Infarstructure.Repository
{

    public class CustomerRepository : ICustomerRepository
    {
        #region DECLARE

        // 1. Khai báo thông tin kết nối với database
        public readonly string connectionString;

        #endregion
        #region Constructor
        public CustomerRepository(IConfiguration configuration)
        {

            connectionString = configuration.GetConnectionString("CukCukDataBase");

        }


        #endregion
        #region Validate
        /// <summary>
        /// Kiểm tra  bị trùng 
        /// </summary>
        /// <param name="value">Dữ liệu kiểm tra </param>
        /// <param name="name">Tên chứa dữ liệu  </param>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns> 
        /// CreatBy : PVM.Quan (18/08/2021)
        public Boolean checkDuplicateCode(String value, String name)
        {
            // 2. Khởi tạo đối tượng kết nối với database
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                // 3. Lấy dữ liệu 
                string sqlCommand = $"SELECT * FROM Customer WHERE {name} = @entityParam";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@entityParam", value);
                var res = dbConnection.QueryFirstOrDefault(sqlCommand, param: parameters);
                if (res != null)
                {
                    return false;
                }
                return true;
            }
        }
        /// <summary>
        /// Lấy Id nhóm khách hàng bằng tên nhóm khách hàng 
        /// </summary>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns> 
        /// CreatBy : PVM.Quan (18/08/2021)
        public Guid? getCustomerGroupId(String CustomerGroupName)
        {
            // 2. Khởi tạo đối tượng kết nối với database
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                // 3. Lấy dữ liệu 
                string sqlCommand = $"SELECT * FROM CustomerGroup WHERE CustomerGroupName = @CustomerGroupNameParam";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerGroupNameParam", CustomerGroupName);
                var res = dbConnection.QueryFirstOrDefault<CustomerGroup>(sqlCommand, param: parameters);
                if (res != null)
                {
                    return res.CustomerGroupId;
                }
                return null;
            }
        }
        #endregion
    }
}
