using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities.Interfaces.Repository;
using MISA.Core.Entities.Interfaces.Services;

namespace MISA.Core.Entities.Services
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        IBaseRepository _baseRepository;
        ServiceResult _serviceResult;

        public BaseService(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult();
        }


        /// <summary>
        /// Thêm mới 
        /// </summary>
        /// <param name="entity">Thông tin </param>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns>
        /// CreatBy : PVM.Quan (13/08/2021)
        public ServiceResult Add(MISAEntity entity)
        {
            var isValid = ValidateData(entity);
            if (isValid == true)
            {
                isValid = ValidateCustom(entity);
            }
            if (isValid == true)
            {
                _serviceResult.Data = _baseRepository.Add(entity);
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
        public ServiceResult Update(MISAEntity entity, Guid entityId)
        {
            _serviceResult.Data = _baseRepository.Update(entity, entityId);
            return _serviceResult;
        }

        private  bool ValidateData(MISAEntity entity)
        {
            var isValid = true;

            return isValid;
        }

        protected virtual bool ValidateCustom(MISAEntity entity)
        {
            return true;
        }
    }
}
