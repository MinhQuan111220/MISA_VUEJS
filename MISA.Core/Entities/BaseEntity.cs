using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class BaseEntity
    {
        #region Property

        /// <summary>
        /// Thời gian tạo 
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// Người tạo 
        /// </summary>
        public String createdBy { get; set; }

        /// <summary>
        /// Thời gian sửa đổi
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa đổi
        /// </summary>
        public String ModifiedBy { get; set; }
        #endregion
    }
}
