using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities.Interfaces.Repository;
using MISA.Core.Entities.ModelEmployee;
using MySqlConnector;

namespace MISA.Infarstructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region DECLARE
       
        // 1. Khai báo thông tin kết nối với database
        public readonly string connectionString;

        #endregion
        #region Constructor
        public EmployeeRepository(IConfiguration configuration)
        {
           
            connectionString = configuration.GetConnectionString("CukCukDataBase");

        }

        
        #endregion
        #region Method

        /// <summary>
        /// Phân trang 
        /// </summary>
        /// <param name="EmployeeFilter"></param>
        /// <param name="DepartmentId"></param>
        /// <param name="PostitionId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalPage"></param>
        /// <returns>Mảng chứa thông tin</returns>
        /// creatBy : PVM Quân(19/08/2021)
        public object GetEmployeesFilterPaging(String EmployeeFilter, Guid? DepartmentId, Guid? PositionId, Int32 pageIndex, Int32 pageSize)
        {
            // 2.Khởi tạo đối tượng kết nối với database
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            // 3. Lấy dữ liệu 
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@PositionId", PositionId);
            parameters.Add("@DepartmentId", DepartmentId);
            parameters.Add("@EmployeeFilter", EmployeeFilter== null ? string.Empty : EmployeeFilter);
            parameters.Add("@pageIndex", pageIndex);
            parameters.Add("@pageSize", pageSize);
            parameters.Add("@TotalRecord", dbType : DbType.Int32, direction: ParameterDirection.Output);
            parameters.Add("@TotalPage", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var data = dbConnection.Query<Employee>($"Proc_GetEmployeesFilterPaging", param: parameters, commandType: CommandType.StoredProcedure);

            var totalPage = parameters.Get<Int32>("@TotalPage");
            var totalRecord = parameters.Get<Int32>("@TotalRecord");

            var pagingData = new
            {
                totalPage,
                totalRecord,
                data
            };

            return pagingData;
        }
        #endregion

        #region validate
        /// <summary>
        /// Kiểm tra chứng minh thư bị trùng 
        /// </summary>
        /// <param name="IdentityNumber">Id khách hàng</param>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns> 
        /// CreatBy : PVM.Quan (18/08/2021)
        public Boolean checkDuplicateIdentityNumber(String IdentityNumber)
        {
            // 2. Khởi tạo đối tượng kết nối với database
            using (IDbConnection dbConnection = new MySqlConnection(connectionString))
            {
                // 3. Lấy dữ liệu 
                string sqlCommand = $"SELECT * FROM Employee WHERE IdentityNumber = @IdentityNumberParam";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@IdentityNumberParam", IdentityNumber);
                var res = dbConnection.QueryFirstOrDefault(sqlCommand, param: parameters);
                if (res != null)
                {
                    return false;
                }
                return true;
            }
        }
        #endregion
    }
}
