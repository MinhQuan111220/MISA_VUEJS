using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities.ModelCustomer
{
    public class Customer : BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa Chính
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Mã Khách hàng
        /// </summary>
        public String CustomerCode { get; set; }

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
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public String PhoneNumber { get; set; }

        #endregion
    }
}
