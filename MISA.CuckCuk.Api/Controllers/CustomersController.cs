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
using System.Text.RegularExpressions;

namespace MISA.CuckCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        /// <summary>
        /// Lấy thông tin tất cả khách hàng
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCustomers(string name, int? age)
        {
            try
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
                if (customers.Count() > 0)
                {
                var response = StatusCode(200, customers);
                return response;
                }
                else
                {
                    return StatusCode(204, customers);
                }
            }catch (Exception )
            {
                var erroObject = new {
                    devMsg = Properties.Resources.DevMsg_Erro500,
                    userMsg = Properties.Resources.Erro500,
                    erorrCode = "misa-001",
                };
                return StatusCode(500, erroObject);
            }
        }
        /// <summary>
        /// Lấy thông tin khách hàng theo Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet("{customerId}")]
        public IActionResult GetById(string customerId)
        {
            
            // Lấy thông tin theo id
            try
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
                if (customer != null)
                {
                    var response = StatusCode(200, customer);
                    return response;
                }
                else
                {
                    return StatusCode(204, customer);
                }
            }
            catch (Exception )
            {
                var erroObject = new
                {
                    devMsg = Properties.Resources.DevMsg_Erro500,
                    userMsg = Properties.Resources.Erro500,
                    erorrCode = "misa-001",
                };
                return StatusCode(500, erroObject);
            }
        }
        /// <summary>
        /// Thêm mới một khách hàng
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertCustomer(Customer customer)
        {

            // Kiểm tra dữ liệu thông tin khách hàng đã hợp lệ hay chưa ?
            // 1 . Mã khách hàng bắt buộc phải có
            if (customer.CustomerCode == " " || customer.CustomerCode == null)
            {
                var erroObject = new
                {
                    userMsg = Properties.Resources.UserMsg_Erro400,
                    errorCode = "Misa001",
                    moreInfor = "google.com"
                };
                return BadRequest(erroObject);
            }
            // 2 . Email phải đúng định dạng
            var validate = Regex.IsMatch(customer.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (validate == false)
            {
                var erroObject = new
                {
                    userMsg = Properties.Resources.UserMsg_Erro400,
                    errorCode = "Misa001",
                    moreInfor = "google.com"
                };
                return StatusCode(400, erroObject);
            }
            // 3. Mã không được trùng
            try
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
                string sqlCommand = $"SELECT * FROM Customer WHERE CustomerCode = @CustomerCodeParam";
                DynamicParameters parameters = new DynamicParameters();
                var customerCode = customer.CustomerCode;
                parameters.Add("@CustomerCodeParam", customerCode);
                var res = dbConnection.QueryFirstOrDefault(sqlCommand, param: parameters);
                if (res != null)
                {

                }
                else
                {
                    var erroObject = new
                    {
                        userMsg = Properties.Resources.UserMsg_Erro400,
                        errorCode = "Misa001",
                        moreInfor = "google.com"
                    };
                    return StatusCode(400, erroObject);
                }
            }
            catch (Exception )
            {
                var erroObject = new
                {
                    devMsg = Properties.Resources.DevMsg_Erro500,
                    userMsg = Properties.Resources.Erro500,
                    erorrCode = "misa-001",
                };
                return StatusCode(500, erroObject);
            }

            //Bắt đầu thêm mới
            try
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

                // 4. Tra ve cho client
                if (rowEffects > 0)
                {
                   return  StatusCode(201, rowEffects);

                }
                else
                {
                    return StatusCode(204);
                }
            }
            catch (Exception)
            {
                var erroObject = new
                {
                    devMsg = Properties.Resources.DevMsg_Erro500,
                    userMsg = Properties.Resources.Erro500,
                    erorrCode = "misa-001",
                };
                return StatusCode(500, erroObject);
            }
        }

        /// <summary>
        /// Sửa dữ liệu cho một khách hàng
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut("{customerId}")]
        public IActionResult UpdateCustomer(Guid customerId, Customer customer)
        {

            // Kiểm tra dữ liệu thông tin khách hàng đã hợp lệ hay chưa ?
            // 1 . Mã khách hàng bắt buộc phải có
            if (customer.CustomerCode == " " || customer.CustomerCode == null)
            {
                var erroObject = new
                {
                    userMsg = Properties.Resources.UserMsg_Erro400,
                    errorCode = "Misa001",
                    moreInfor = "google.com"
                };
                return BadRequest(erroObject);
            }
            // 2 . Email phải đúng định dạng
            var validate = Regex.IsMatch(customer.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (validate == false)
            {
                var erroObject = new
                {
                    userMsg = Properties.Resources.UserMsg_Erro400,
                    errorCode = "Misa001",
                    moreInfor = "google.com"
                };
                return StatusCode(400, erroObject);
            }
            // 3. Mã không được trùng
            try
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
                string sqlCommand = $"SELECT * FROM Customer WHERE CustomerCode = @CustomerCodeParam";
                DynamicParameters parameters = new DynamicParameters();
                var customerCode = customer.CustomerCode;
                parameters.Add("@CustomerCodeParam", customerCode);
                var res = dbConnection.QueryFirstOrDefault(sqlCommand, param: parameters);
                if (res != null)
                {

                }
                else
                {
                    var erroObject = new
                    {
                        userMsg = Properties.Resources.UserMsg_Erro400,
                        errorCode = "Misa001",
                        moreInfor = "google.com"
                    };
                    return StatusCode(400, erroObject);
                }
            }
            catch (Exception)
            {
                var erroObject = new
                {
                    devMsg = Properties.Resources.DevMsg_Erro500,
                    userMsg = Properties.Resources.Erro500,
                    erorrCode = "misa-001",
                };
                return StatusCode(500, erroObject);
            }
            // Bắt đầu sửa 
            try
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

                // 4. Trả về cho client
                if (rowEffects > 0)
                {
                    return StatusCode(200, rowEffects);

                }
                else
                {
                    return StatusCode(204);
                }
            }
            catch (Exception)
            {
                var erroObject = new
                {
                    devMsg = Properties.Resources.DevMsg_Erro500,
                    userMsg = Properties.Resources.Erro500,
                    erorrCode = "misa-001",
                };
                return StatusCode(500, erroObject);
            }
        }

        /// <summary>
        /// Xóa thông tin khách hàng theo 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer(string customerId)
        {
            try
            {
                // Truy cập vào database 
                // 1. Khai báo thông tin kết nối với database
                var connectionString = "Host = 47.241.69.179;" +
                    "Database = MISA.CukCuk_Demo_NVMANH;" +
                    "User Id  = dev;" +
                    "Password = 12345678";

                // 2. Khởi tạo đối tượng kết nối với database
                IDbConnection dbConnection = new MySqlConnection(connectionString);

                // 3.  Kiểm tra xem có tồn tại id không 
                string sqlCommand = $"SELECT * FROM Customer WHERE CustomerId = @CustomerIdParam";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerIdParam", customerId);
                var res = dbConnection.QueryFirstOrDefault(sqlCommand, param: parameters);
                if (res != null)
                {
                    // 4. Xoá dữ liệu theo id
                    string sqlCommandDelete = $"DELETE FROM Customer WHERE CustomerId = @CustomerIdParam";
                    var customer = dbConnection.Execute(sqlCommandDelete, param: parameters);

                    // 5. Trả về cho client
                    var response = StatusCode(200, customer);
                    return response;
                }
                else
                {
                    var erroObject = new
                    {
                        userMsg = Properties.Resources.UserMsg_Erro400,
                        errorCode = "Misa001",
                        moreInfor = "google.com"
                    };
                    return StatusCode(400, erroObject);
                }
               
            }
            catch (Exception)
            {
                var erroObject = new
                {
                    devMsg = Properties.Resources.DevMsg_Erro500,
                    userMsg = Properties.Resources.Erro500,
                    erorrCode = "misa-001",
                };
                return StatusCode(500, erroObject);
            }
        }


    }

    
}

