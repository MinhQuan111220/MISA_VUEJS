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

        #region Constructor
        public EmployeeRepository(IConfiguration configuration)
        {
           
            connectionString = configuration.GetConnectionString("CukCukDataBase");

        }
        #endregion
        #endregion
        #region Method
        /// <summary>
        /// Lấy danh sách nhân viên 
        /// </summary>
        /// <param name="PositionId">Vị tí </param>
        /// <param name="DepartmentId"> Phòng ban</param>
        /// <returns>Danh sach nhân viên </returns>
        public List<Employee> GetDeAndPo(string PositionId, string DepartmentId)
        {
            
            // Truy cập vào database 
            
            // 2. Khởi tạo đối tượng kết nối với database
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            // 3. Lấy dữ liệu 
            var sqlCommand = "";
            if (PositionId != null && DepartmentId != null)
            {
                 sqlCommand += $"SELECT * FROM Employee WHERE (PositionId =  @PositionIdParam AND DepartmentId = @DepartmentIdParam ) ";

            }
            else
            {

                sqlCommand += $"SELECT * FROM Employee WHERE  (PositionId = @PositionIdParam ) OR(DepartmentId = @DepartmentIdParam ) ";
            }

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@PositionIdParam", PositionId);
            parameters.Add("@DepartmentIdParam", DepartmentId);
            var entities = dbConnection.Query<Employee>(sqlCommand, param: parameters);
            return (List<Employee>)entities;

        }

        public List<Employee> GetEmployeesFilterPaging(String EmployeeFilter, Guid? DepartmentId, Guid? PositionId, Int32 pageIndex, Int32 pageSize)
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


            return (List<Employee>)data;
        }
        #endregion
    }
}
