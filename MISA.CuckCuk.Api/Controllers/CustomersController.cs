using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.CuckCuk.Api.Model;
using System.Data;
using MySqlConnector;
using Dapper;

namespace MISA.CuckCuk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        /// Get , Post, Put , Delete
        [HttpGet]
        public IActionResult GetCustomers(string name, int? age)
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
            var sqlCommand = "SELECT * FROM Customer";
            var customers = dbConnection.Query<Customer>(sqlCommand);

            // 4. Trả về cho client
            var response = StatusCode(200, customers);
            return response;
        }

        [HttpGet("{customerId}")]
        public IActionResult GetById(Guid customerId)
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
            string sqlCommand = $"SELECT * FROM Customer WHERE CustomerId = @CustomerIdParam";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerIdParam", customerId);
            var customer = dbConnection.QueryFirstOrDefault<Customer>(sqlCommand, param: parameters);

            // 4. Trả về cho client
            var response = StatusCode(200, customer);
            return response;
        }

        [HttpPost]
        public IActionResult InsertCustomer(Customer customer)
        {
            //Sinh mã Guid cho CustomerId
            customer.CustomerId = Guid.NewGuid();
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
            var properties = customer.GetType().GetProperties();
            // Duyệt từng property
            foreach (var prop in properties)
            {
                // Lấy tên của prop :
                var propName = prop.Name;
                // Lấy ra value của prop :
                var propValue = prop.GetValue(customer);
                // Lấy kiểu dữ liệu của prop :
                var propType = prop.PropertyType;

                // Them param tương ứng với mỗi property
                dynamicParam.Add($"@{propName}", propValue);

                columsName += $"{propName},";
                columsParam += $"@{propName},";
            }
            columsName = columsName.Remove(columsName.Length - 1, 1);
            columsParam = columsParam.Remove(columsParam.Length - 1, 1);

            var sqlComand = $"INSERT INTO Customer({columsName}) VALUES({columsParam})";
            var rowEffects = dbConnection.Execute(sqlComand, param: dynamicParam);
            var response = StatusCode(200, rowEffects);
            return response;
        }


        [HttpPut("{customerId}")]
        public IActionResult UpdateCustomer(Guid customerId, Customer customer)
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
            var properties = customer.GetType().GetProperties();
            // Duyệt từng property
            var index = 0;
            foreach (var prop in properties)
            {
                index++;
                // Lấy tên của prop :
                var propName = prop.Name;
                // Lấy ra value của prop :
                var propValue = prop.GetValue(customer);
                // Lấy kiểu dữ liệu của prop :
                var propType = prop.PropertyType;

                // Them param tương ứng với mỗi property
                dynamicParam.Add($"@{propName}", propValue);

                columsName += $" {propName} = @{propName},";
               
            }

            columsName = columsName.Remove(columsName.Length - 1, 1);
            var sqlComand = $"UPDATE Customer SET {columsName} WHERE CustomerId = @CustomerIdParam";
            
            dynamicParam.Add("@CustomerIdParam", customerId);

            var rowEffects = dbConnection.Execute(sqlComand, param: dynamicParam);

            var response = StatusCode(200, rowEffects);
            return response;
        }

        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer(Guid customerId)
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
            string sqlCommand = $"DELETE FROM Customer WHERE CustomerId = @CustomerIdParam";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CustomerIdParam", customerId);
            var customer = dbConnection.Execute(sqlCommand, param: parameters);

            // 4. Trả về cho client
            var response = StatusCode(200, customer);
            return response;
        }
    }

    
}

