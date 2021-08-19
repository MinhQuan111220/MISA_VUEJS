using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities.Interfaces.MISAAttribute;
using MISA.Core.Entities.Interfaces.Repository;
using MISA.Core.Entities.Interfaces.Services;
using MySqlConnector;

namespace MISA.Core.Entities.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        #region DECLARE
       
        IBaseRepository<MISAEntity> _baseRepository;
        protected ServiceResult _serviceResult;

        // 1. Khai báo thông tin kết nối với database
        public readonly string connectionString;
        #endregion

        #region Constructor
        public BaseService(IBaseRepository<MISAEntity> baseRepository, IConfiguration configuration)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
            connectionString = configuration.GetConnectionString("CukCukDataBase");
        }

        #endregion

        #region Method

        /// <summary>
        /// Thêm mới 
        /// </summary>
        /// <param name="entity">Thông tin </param>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns>
        /// CreatBy : PVM.Quan (13/08/2021)
        public ServiceResult Add(MISAEntity entity)
        {
            // Validate dữ liệu 
            var check = ValidateData(entity);
            
            var isValid = true;
            if (check != 0)
            {
                isValid = false;
                // 1 . Không được để trống 
                if(check == 1)
                {
                    var erroObject = new
                    {

                        userMsg = _serviceResult.Messenger,
                        erorrCode = "misa-001",
                    };
                    _serviceResult.Data = erroObject;
                    _serviceResult.isValid = isValid;
                }
                // 2. Trùng mã 
                if(check == 2)
                {
                    var erroObject = new
                    {

                        userMsg = Properties.ResourceVN.MatchCode,
                        erorrCode = "misa-001",
                    };
                    _serviceResult.Data = erroObject;
                    _serviceResult.isValid = isValid;
                }
            }
            else
            {
               // Validate dữ liệu từ con 
                isValid = ValidateCustom(entity);
                if(isValid == false)
                {
                   var erroObject = new
                       {

                            userMsg = _serviceResult.Messenger,
                            erorrCode = "misa-001",
                        };
                        _serviceResult.Data = erroObject;
                        _serviceResult.isValid = isValid;
                }
                else if (isValid == true)
                {
                    _serviceResult.Data = _baseRepository.Add(entity);
                    _serviceResult.isValid = isValid;

                }


            }

            return _serviceResult;
           
        }

        /// <summary>
        /// Cập nhật thông tin theo Id
        /// </summary>
        /// <param name="entity">Thông tin </param>
        /// <param name="entityId">Id </param>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns> 
        /// CreatBy : PVM.Quan (13/08/2021)
        public ServiceResult Update(MISAEntity entity, Guid? entityId)
        {
            // Validate dữ liệu 
            var check = ValidateData(entity);
            var isValid = true;
            if (check != 0)
            {
                isValid = false;
                // 1 . Không được để trống 
                if (check == 1)
                {
                    var erroObject = new
                    {

                        userMsg = _serviceResult.Messenger,
                        erorrCode = "misa-001",
                    };
                    _serviceResult.Data = erroObject;
                    _serviceResult.isValid = isValid;
                }
                // 2. Trùng mã 
                if (check == 2)
                {
                    var erroObject = new
                    {

                        userMsg = Properties.ResourceVN.MatchCode,
                        erorrCode = "misa-001",
                    };
                    _serviceResult.Data = erroObject;
                    _serviceResult.isValid = isValid;
                }
            }
            else
            {
                // Validate dữ liệu từ con 
                isValid = ValidateCustom(entity);
                if (isValid == false)
                {
                    var erroObject = new
                    {

                        userMsg = _serviceResult.Messenger,
                        erorrCode = "misa-001",
                    };
                    _serviceResult.Data = erroObject;
                    _serviceResult.isValid = isValid;
                }
                else if (isValid == true)
                {
                    _serviceResult.Data = _baseRepository.Add(entity);
                    _serviceResult.isValid = isValid;

                }


            }

            return _serviceResult;
        }
        #endregion

        #region Validate

        /// <summary>
        /// Kiêm tra dữ liệu chung
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>0-dữ liệu hợp lệ , !0 dữ liệu không hợp lệ</returns> 
        /// creatBy : PVMQuan(18/08/2021)
        private int ValidateData(MISAEntity entity)
        {
            // Lấy tên của class
            var className = typeof(MISAEntity).Name;
            // Đọc từng property của object
            var properties = entity.GetType().GetProperties();
            var check = 0;

            // Duyệt từng property
            foreach (var prop in properties)
            {
                // Lấy tên của prop :
                var propName = prop.Name;
                // Lấy ra value của prop :
                var propValue = prop.GetValue(entity);

                // 1. Kiểm tra xem property hiện tại có bắt buộc nhập hay không 
                var propMISARequireds = prop.GetCustomAttributes(typeof(MISARequired), true);

                if (propMISARequireds.Length > 0)
                {
                    var fieldName = (propMISARequireds[0] as MISARequired).FieldName;
                    if(prop.PropertyType == typeof(string) && (propValue==null || propValue.ToString() == string.Empty))
                    {
                        check = 1;
                        _serviceResult.Messenger =fieldName + " " +Properties.ResourceVN.Empty;
                        break;
                    }
                }
                // 2. Kiểm tra mã bị trùng
                 if(propName == $"{className}Code" && propValue.ToString() != string.Empty )
                {
                    if(_baseRepository.checkDuplicateCode(propValue.ToString()) == false)
                    {
                        check = 2;
                        break;
                    }
                  
                }
            }

            return check;
        }

        protected virtual bool ValidateCustom(MISAEntity entity)
        {
            return true;
        }
        #endregion
    }
}
