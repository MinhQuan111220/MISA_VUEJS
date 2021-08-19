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
        /// Lấy danh sách nhân viên 
        /// </summary>
        /// <param name="PositionId">Vị tí </param>
        /// <param name="DepartmentId"> Phòng ban</param>
        /// <returns>Danh sach nhân viên </returns>
        List<Employee> GetDeAndPo(string PositionId, string DepartmentId);

        /// <summary>
        /// Phân trang 
        /// </summary>
        /// <param name="EmployeeFilter"></param>
        /// <param name="DepartmentId"></param>
        /// <param name="PostitionId"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalPage"></param>
        /// <returns></returns>
        List<Employee> GetEmployeesFilterPaging(string EmployeeFilter, Guid? DepartmentId, Guid? PositionId, int pageIndex, int pageSize);
        #endregion

    }
}
