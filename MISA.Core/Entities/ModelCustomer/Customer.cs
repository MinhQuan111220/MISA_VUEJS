using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities.Interfaces.MISAAttribute;

namespace MISA.Core.Entities.ModelCustomer
{
    public class Customer : BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa Chính
        /// </summary>
        public Guid? CustomerId { get; set; }

        /// <summary>
        /// Mã Khách hàng
        /// </summary>
        [MISARequired("Mã Khách Hàng ")]
        public string CustomerCode { get; set; }

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
        [MISARequired("Họ và tên Khách Hàng ")]
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
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [MISARequired("Email")]
        public string Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Tên nhóm khách hàng 
        /// </summary>
        public string CustomerGroupName { get; set; }

        /// <summary>
        /// Mã Id nhóm khách hàng 
        /// </summary>
        public Guid? CustomerGroupId { get; set; }

        /// <summary>
        /// Mã thẻ thành viên 
        /// </summary>
        public string MemberCardCode { get; set; }

        /// <summary>
        /// Tên công ty 
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Mã số thuế 
        /// </summary>
        public string TaxCode   { get; set; }

        /// <summary>
        /// Mảng chứa những lỗi sai khi import từ file 
        /// </summary>
        public List<string> ImportError { get; set; } = new List<string>();
        #endregion
    }
}
