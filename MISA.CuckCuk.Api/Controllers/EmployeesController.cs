using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.CuckCuk.Api.Model.ModeelEmployee;
using System.Data;
using MySqlConnector;
using Dapper;

namespace MISA.CuckCuk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        /// Get , Post, Put , Delete
        /// Lấy ra tất cả nhân vien
        [HttpGet]
        public IActionResult GetEmployees(string name, int? age)
        {
            // Truy cập vào database 
            // 1. Khai báo thông tin kết nối với database
            var connectionString = "Host = 47.241.69.179;" +
                "Database = MISA.CukCuk_Demo_NVMANH;" +
                "User Id  = dev;" +
                "Password = 12345678";

            // 2. Khởi tạo đối tượng kết nối với database
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            // 3. Lấy dữ liệu 
            var sqlCommand = "SELECT * FROM Employee";
            var employees = dbConnection.Query<Employee>(sqlCommand);

            // 4. Trả về cho client
            var response = StatusCode(200, employees);
            return response;

            
        }

        /// <summary>
        /// Lấy ra nhân viên theo id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpGet("{employeeId}")]
        public IActionResult GetById(Guid employeeId)
        {
            // Truy cập vào database 
            // 1. Khai báo thông tin kết nối với database
            var connectionString = "Host = 47.241.69.179;" +
                "Database = MISA.CukCuk_Demo_NVMANH;" +
                "User Id  = dev;" +
                "Password = 12345678";

            // 2. Khởi tạo đối tượng kết nối với database
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            // 3. Lấy dữ liệu 
            string sqlCommand = $"SELECT * FROM Employee WHERE employeeId = @employeeIdParam";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@employeeIdParam", employeeId);
            var employee = dbConnection.QueryFirstOrDefault<Employee>(sqlCommand, param: parameters);

            // 4. Trả về cho client
            var response = StatusCode(200, employee);
            return response;
        }
        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insertemployee(Employee employee)
        {
            //Sinh mã Guid cho employeeId
            employee.EmployeeId = Guid.NewGuid();
            // Truy cập vào database 
            // 1. Khai báo thông tin kết nối với database
            var connectionString = "Host = 47.241.69.179;" +
                "Database = MISA.CukCuk_Demo_NVMANH;" +
                "User Id  = dev;" +
                "Password = 12345678";

            // 2. Khởi tạo đối tượng kết nối với database
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            // Khai báo dynamicParam
            var dynamicParam = new DynamicParameters();

            // 3. Thêm mới dữ liệu 
            var columsName = string.Empty;
            var columsParam = string.Empty;
            // Đọc từng property của object
            var properties = employee.GetType().GetProperties();
            // Duyệt từng property
            foreach (var prop in properties)
            {
                // Lấy tên của prop :
                var propName = prop.Name;
                // Lấy ra value của prop :
                var propValue = prop.GetValue(employee);
                // Lấy kiểu dữ liệu của prop :
                var propType = prop.PropertyType;

                // Them param tương ứng với mỗi property
                dynamicParam.Add($"@{propName}", propValue);

                columsName += $"{propName},";
                columsParam += $"@{propName},";
            }
            columsName = columsName.Remove(columsName.Length - 1, 1);
            columsParam = columsParam.Remove(columsParam.Length - 1, 1);

            var sqlComand = $"INSERT INTO Employee({columsName}) VALUES({columsParam})";
            var rowEffects = dbConnection.Execute(sqlComand, param: dynamicParam);
            var response = StatusCode(200, rowEffects);
            return response;
        }

        /// <summary>
        /// Sửa nhân viên theo id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut("{employeeId}")]
        public IActionResult Updateemployee(Guid employeeId, Employee employee)
        {
            // Truy cập vào database 
            // 1. Khai báo thông tin kết nối với database
            var connectionString = "Host = 47.241.69.179;" +
                "Database = MISA.CukCuk_Demo_NVMANH;" +
                "User Id  = dev;" +
                "Password = 12345678";

            // 2. Khởi tạo đối tượng kết nối với database
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            // Khai báo dynamicParam
            var dynamicParam = new DynamicParameters();
            // 3. Sửa dữ liệu 
            var columsName = string.Empty;
            var columsParam = string.Empty;
            // Đọc từng property của object
            var properties = employee.GetType().GetProperties();
            // Duyệt từng property
            var index = 0;
            foreach (var prop in properties)
            {
                index++;
                // Lấy tên của prop :
                var propName = prop.Name;
                // Lấy ra value của prop :
                var propValue = prop.GetValue(employee);
                // Lấy kiểu dữ liệu của prop :
                var propType = prop.PropertyType;

                // Them param tương ứng với mỗi property
                dynamicParam.Add($"@{propName}", propValue);

                columsName += $" {propName} = @{propName},";

            }

            columsName = columsName.Remove(columsName.Length - 1, 1);
            var sqlComand = $"UPDATE Employee SET {columsName} WHERE employeeId = @employeeIdParam";

            dynamicParam.Add("@employeeIdParam", employeeId);

            var rowEffects = dbConnection.Execute(sqlComand, param: dynamicParam);

            var response = StatusCode(200, rowEffects);
            return response;
        }

        /// <summary>
        /// Xóa nhân viên theo id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpDelete("{employeeId}")]
        public IActionResult Deleteemployee(Guid employeeId)
        {
            // Truy cập vào database 
            // 1. Khai báo thông tin kết nối với database
            var connectionString = "Host = 47.241.69.179;" +
                "Database = MISA.CukCuk_Demo_NVMANH;" +
                "User Id  = dev;" +
                "Password = 12345678";

            // 2. Khởi tạo đối tượng kết nối với database
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            // 3. Xoá dữ liệu theo id
            string sqlCommand = $"DELETE FROM Employee WHERE employeeId = @employeeIdParam";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@employeeIdParam", employeeId);
            var employee = dbConnection.Execute(sqlCommand, param: parameters);

            // 4. Trả về cho client
            var response = StatusCode(200, employee);
            return response;
        }
    }

}

