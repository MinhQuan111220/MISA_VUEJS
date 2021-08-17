using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities.ModelCustomer
{
    public class CustomerGroup : BaseEntity
    {
        #region Property
        /// <summary>
        /// Khóa Chính
        /// </summary>
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Tên nhóm khách hàng
        /// </summary>
        public String CustomerGroupName { get; set; }

        /// <summary>
        /// Miêu tả khách hàng
        /// </summary>
        public String Description { get; set; }


        #endregion


    }
}
