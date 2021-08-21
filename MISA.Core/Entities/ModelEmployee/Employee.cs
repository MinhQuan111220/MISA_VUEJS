﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities.Interfaces.MISAAttribute;

namespace MISA.Core.Entities.ModelEmployee
{
    public class Employee : BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa Chính
        /// </summary>
        public Guid? EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên 
        /// </summary>
        [MISARequired("Mã Nhân Viên")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ và đệm
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Tên
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        [MISARequired("Họ và tên nhân viên ")]
        public string FullName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }

        

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [MISARequired("Email")]
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        [MISARequired("Số điện thoại")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Số chứng minh thư
        /// </summary>
        [MISARequired("Số chứng minh thư")]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày tạo chứng minh thư
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// Nơi tạo cmt
        /// </summary>
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Tiền lương
        /// </summary>
        public double? Salary { get; set; }

        /// <summary>
        /// Trạng thái công việc 
        /// </summary>
        public double? WorkStatus { get; set; }

        /// <summary>
        /// ID Phòng ban  
        /// </summary>
        public Guid? PositionId { get; set; }

        /// <summary>
        /// ID Vị trí
        /// </summary>
        public Guid? DepartmentId { get; set; }

        // <summary>
        /// Phòng ban 
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// Vị trí
        /// </summary>
        public string DepartmentName { get; set; }

        #endregion
    }
}
