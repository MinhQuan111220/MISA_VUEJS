﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities.Interfaces.Repository
{
    public interface IBaseRepository 
     {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns>
        /// CreatBy : PVM.Quan (13/08/2021)
        List<MISAEntity> GetAll<MISAEntity>();

        /// <summary>
        /// Thêm mới 
        /// </summary>
        /// <param name="entity">Thông tin </param>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns>
        /// CreatBy : PVM.Quan (13/08/2021)
        int Add<MISAEntity>(MISAEntity entity);

        /// <summary>
        /// Cập nhật thông tin theo Id
        /// </summary>
        /// <param name="entity">Thông tin </param>
        /// <param name="entityId">Id </param>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns>
        /// CreatBy : PVM.Quan (13/08/2021)
        int Update<MISAEntity>(MISAEntity entity, Guid entityId);

        /// <summary>
        /// Xóa  theo Id
        /// </summary>
        /// <param name="entityId">Id khách hàng</param>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns>
        /// CreatBy : PVM.Quan (13/08/2021)
        int Delete<MISAEntity>(Guid entityId);

        /// <summary>
        /// Lấy dữ liệu khách  Id
        /// </summary>
        /// <param name="entityId">Id khách hàng</param>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns> 
        /// CreatBy : PVM.Quan (13/08/2021)
        Object GetById<MISAEntity>(Guid entityId);

    }
}
