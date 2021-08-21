using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities.ModelEmployee;

namespace MISA.Core.Entities.Interfaces.Repository
{
    public interface IEmployeeRepository
    {
        #region Method 
       
        /// <summary>
        /// Phân trang 
        /// </summary>
        /// <param name="EmployeeFilter"></param>
        /// <param name="DepartmentId"></param>
        /// <param name="PostitionId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalPage"></param>
        /// <returns>Mảng chứa thông tin</returns>
        /// creatBy : PVM Quân(19/08/2021)
        object GetEmployeesFilterPaging(string EmployeeFilter, Guid? DepartmentId, Guid? PositionId, int pageIndex, int pageSize);
        #endregion

        #region validate
        /// <summary>
        /// Kiểm tra chứng minh thư bị trùng 
        /// </summary>
        /// <param name="IdentityNumber">Id khách hàng</param>
        /// <returns>ServiceResult Kết quả xử lý nghiệp vụ</returns> 
        /// CreatBy : PVM.Quan (18/08/2021)
        public bool checkDuplicateIdentityNumber(string IdentityNumber);
        #endregion
    }
}
