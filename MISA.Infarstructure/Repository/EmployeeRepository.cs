using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MISA.Core.Entities.Interfaces.Repository;
using MISA.Core.Entities.ModelEmployee;
using MySqlConnector;

namespace MISA.Infarstructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<Employee> GetDeAndPo(string PositionId, string DepartmentId)
        {
            
            // Truy cập vào database 
            // 1. Khai báo thông tin kết nối với database 
            var connectionString = "Host = 47.241.69.179;" +
                "Database = MF940_PVMQuan_CukCuk;" +
                "User Id  = dev;" +
                "Password = 12345678";

            // 2. Khởi tạo đối tượng kết nối với database
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            // 3. Lấy dữ liệu 

            var sqlCommand = $"SELECT * FROM Employee WHERE (PositionId = @PositionIdParam AND DepartmentId = @DepartmentIdParam ) OR (PositionId = @PositionIdParam) OR(DepartmentId = @DepartmentIdParam) ";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@PositionIdParam", PositionId);
            parameters.Add("@DepartmentIdParam", DepartmentId);
            var entities = dbConnection.Query<Employee>(sqlCommand, param: parameters);
            return (List<Employee>)entities;

        }
    }
}
