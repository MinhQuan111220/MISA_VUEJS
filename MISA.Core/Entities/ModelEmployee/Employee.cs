using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities.ModelEmployee
{
    public class Employee : BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa Chính
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên 
        /// </summary>
        public String EmployeeCode { get; set; }

        /// <summary>
        /// Họ và đệm
        /// </summary>
        public String FirstName { get; set; }

        /// <summary>
        /// Tên
        /// </summary>
        public String LastName { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        public String FullName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public String Address { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public String PhoneNumber { get; set; }

        /// <summary>
        /// Số chứng minh thư
        /// </summary>
        public String IdentityNumber { get; set; }

        /// <summary>
        /// Ngày tạo chứng minh thư
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi tạo cmt
        /// </summary>
        public String IdentityPlace { get; set; }

        /// <summary>
        /// Tiền lương
        /// </summary>
        public double? Salary { get; set; }

        /// <summary>
        /// Trạng thái công việc 
        /// </summary>
        public double? WorkStatus { get; set; }

        /// <summary>
        /// Phòng ban 
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// Vị trí
        /// </summary>
        public Guid DepartmentId { get; set; }

        #endregion
    }
}
