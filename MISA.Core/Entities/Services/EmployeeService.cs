using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities.Interfaces.Repository;
using MISA.Core.Entities.Interfaces.Services;
using MISA.Core.Entities.ModelEmployee;

namespace MISA.Core.Entities.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region DECLARE
        IEmployeeRepository _employeeRepository;
       
        #endregion

        #region Constructor

        public EmployeeService(IBaseRepository<Employee> baseRepository, IConfiguration configuration, IEmployeeRepository employeeRepository) : base(baseRepository,  configuration)

        {
            _employeeRepository = employeeRepository;
            
        }
        #endregion

        #region Validate
        /// <summary>
        /// Kiêm tra dữ liệu 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>0-dữ liệu hợp lệ , !0 dữ liệu không hợp lệ</returns>
        /// creatBy : PVMQuan(18/08/2021)  
        protected override bool ValidateCustom(Employee entity)
        {
            
            //1 . Sai định dạng  email 
            var validate = Regex.IsMatch(entity.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (validate == false)
            {
                _serviceResult.Messenger = Properties.ResourceVN.FormatEmail;
                 return false;
                
            }
            // 2. Trùng chứng minh thư 
            if (_employeeRepository.checkDuplicateIdentityNumber(entity.IdentityNumber) == false)
            {
                _serviceResult.Messenger = Properties.ResourceVN.MathIdentityNumber;
                return false;
            }
            //// 2 . Sai định dạng tiền 
            //var monney =  Regex.IsMatch(employee.Salary, @"^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,4})?))\)?$");
            //if (money == false)
            //{
            //    check = 2;
            //    _serviceResult.Messenger = Properties.ResourceVN.FormatEmail;

            //}
           return  true;
        }
        #endregion
    }
}
