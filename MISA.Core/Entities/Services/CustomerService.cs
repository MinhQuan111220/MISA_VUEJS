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
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using System.IO;
using OfficeOpenXml;

namespace MISA.Core.Entities.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {

        #region DECLARE
        ICustomerRepository _customerRepository;
        IBaseRepository<Customer> _baseRepository;
        #endregion

        #region Constructor

        public CustomerService(IBaseRepository<Customer> baseRepository, IConfiguration configuration, ICustomerRepository customerRepository) : base(baseRepository, configuration)

        {
            _customerRepository = customerRepository;
            _baseRepository = baseRepository;
        }

        #endregion
        #region Validate
        /// <summary>
        /// Import dữ liệu khách hàng từ file 
        /// </summary>
        /// <returns>Danh sách khách hàng hợp lệ </returns>
        public ServiceResult Import(IFormFile formFile)
        {
            // 1. Kiểm tra xem file gửi lên có bị rỗng hay không 
            if (formFile == null)
            {
                var erroObject = new
                {
                    devMsq = Properties.ResourceVN.DevNullFile,
                    userMsg = Properties.ResourceVN.UserNullFile,
                    erorrCode = "misa-001",
                };
                _serviceResult.Data = erroObject;
                _serviceResult.isValid = false;
            }
            else
            {
                var customers = new List<Customer>();
                var newCustomers = new List<Customer>();
                var arrCustomerCode = new List<string>();
                var arrPhoneNumber = new List<string>();
                // Thực hiện đọc dữ liệu trong tệp excel
                using (var stream = new MemoryStream())
                {
                    formFile.CopyToAsync(stream);

                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;

                        for (int row = 3; row <= rowCount; row++)
                        {
                            var customerCode = (worksheet.Cells[row, 1].Value == null ? "" : worksheet.Cells[row, 1].Value.ToString().Trim());
                            var fullName = (worksheet.Cells[row, 2].Value == null ? "" : worksheet.Cells[row, 2].Value.ToString().Trim());
                            var memberCardCode = (worksheet.Cells[row, 3].Value == null ? "" : worksheet.Cells[row, 3].Value.ToString().Trim());
                            var customerGroupName = (worksheet.Cells[row, 4].Value == null ? "" : worksheet.Cells[row, 4].Value.ToString().Trim());
                            var phoneNumber = (worksheet.Cells[row, 5].Value == null ? "" : worksheet.Cells[row, 5].Value.ToString().Trim());
                            var dateOfBirth = ConvertDate(worksheet.Cells[row, 6].Value);
                            var companyName = (worksheet.Cells[row, 7].Value == null ? "" : worksheet.Cells[row, 7].Value.ToString().Trim());
                            var taxCode = (worksheet.Cells[row, 8].Value == null ? "" : worksheet.Cells[row, 8].Value.ToString().Trim());
                            var email = (worksheet.Cells[row, 9].Value == null ? "" : worksheet.Cells[row, 9].Value.ToString().Trim());
                            var address = (worksheet.Cells[row, 10].Value == null ? "" : worksheet.Cells[row, 10].Value.ToString().Trim());
                            var customer = new Customer {
                                CustomerCode = customerCode,
                                FullName = fullName,
                                MemberCardCode = memberCardCode,
                                CustomerGroupName = customerGroupName,
                                PhoneNumber = phoneNumber,
                                DateOfBirth = dateOfBirth,
                                CompanyName = companyName,
                                TaxCode = taxCode,
                                Email = email,
                                Address = address,
                                CustomerGroupId = _customerRepository.getCustomerGroupId(customerGroupName),
                            };
                            arrCustomerCode.Add(customerCode);
                            arrPhoneNumber.Add(phoneNumber);
                            customers.Add(customer);
                        }
                        foreach(var customer in customers)
                        {
                            // 1. Kiểm tra mã khách hàng 
                            if (customer.CustomerCode == "")
                            {
                                customer.ImportError.Add("Mã khách hàng không đươc để trống ");
                            }
                            if (Checkduplicates(arrCustomerCode, customer.CustomerCode) == false )
                            {
                                customer.ImportError.Add("Mã khách hàng đã trùng với mã  khách hàng khác trong tệp nhập khẩu.");
                            }
                            if(_baseRepository.checkDuplicateCode(customer.CustomerCode)== false)
                            {
                                customer.ImportError.Add("Mã khách hàng đã tồn tại trong hệ thống");
                            }

                            //2. Kiểm tra số điện thoại 
                            if (Checkduplicates(arrPhoneNumber, customer.PhoneNumber) == false)
                            {
                                customer.ImportError.Add("Số điện thoại đã trùng với số điện thoại  khác trong tệp nhập khẩu.");
                            }
                            if (_customerRepository.checkDuplicateCode(customer.PhoneNumber,"PhoneNumber") == false)
                            {
                                customer.ImportError.Add("Số điện thoại  đã tồn tại trong hệ thống");
                            }
                            // 3 .Kiểm tra nhóm khách hàng 
                            if(customer.CustomerGroupId == null)
                            {
                                customer.ImportError.Add("Nhóm khách hàng không có trong hệ thống");
                            }
                        }
                        // Tạo mảng mới lưu trữ thông tin để thêm mới 
                        foreach(var customer in customers)
                        {
                            if(customer.ImportError.Count == 0)
                            {
                                newCustomers.Add(customer);
                            }
                        }
                    }
                }
                _serviceResult.Data = customers;
            }
                return _serviceResult;
            }

        /// <summary>
        /// Convert dữ liệu date lấy được từ 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
            private DateTime ConvertDate(object date)
            {
                if(date != null)
                {
                string value = date.ToString().Trim();
                    if(Regex.IsMatch(value, @"^([0-2][0-9]|(3)[0-1])(\/)(((0)[0-9])|((1)[0-2]))(\/)\d{4}$"))
                    {
                        return DateTime.ParseExact(value, "dd/MM/yyyy", null);
                    }
                    if (Regex.IsMatch(value, @"^([0-2][0-9]|(3)[0-1])(\/)\d{4}$"))
                    {
                        return DateTime.ParseExact("01/", "dd/MM/yyyy", null);
                    }
                    if (Regex.IsMatch(value, @"^\d{4}$"))
                    {
                        return DateTime.ParseExact("01/01", "dd/MM/yyyy", null);
                    }
                }
                return DateTime.Parse("01/01/1960");
            }

            private bool Checkduplicates(List<string> array, string value)
                {
            var index = 0;
                    foreach (var item in array)
                    {
                        if(value == item)
                        {
                            index++;
                           
                        }
                    }
                    if (index > 1)
                    {
                         return false;
                    }
                    return true;
                }
            #endregion


    }

    }
