using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities.Interfaces.Services
{
    public interface IBaseService<MISAEntity>
    {
        #region Method 

        /// <summary>
        /// Thêm mới 
        /// </summary>
        /// <param name="entity">Thông tin </param>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns>
        /// CreatBy : PVM.Quan (13/08/2021)
        ServiceResult Add(MISAEntity entity);

        /// <summary>
        /// Cập nhật thông tin theo Id
        /// </summary>
        /// <param name="entity">Thông tin </param>
        /// <param name="entityId">Id </param>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns>
        /// CreatBy : PVM.Quan (13/08/2021)
        ServiceResult Update(MISAEntity entity, Guid? entityId);
        #endregion
    }
}
