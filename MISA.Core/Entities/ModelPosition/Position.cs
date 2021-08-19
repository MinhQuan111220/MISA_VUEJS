using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities.ModelPosition
{
    public class Position : BaseEntity
    {
        #region Property 
        
        /// <summary>
        /// Khóa Chính
        /// </summary>
        public Guid? PositionId { get; set; }

        /// <summary>
        /// Mã chức vụ 
        /// </summary>
        
        public string PositionCode { get; set; }

        /// <summary>
        /// Chức vụ 
        /// </summary>
        public string PositionName { get; set; }

        

        #endregion
    }
}
