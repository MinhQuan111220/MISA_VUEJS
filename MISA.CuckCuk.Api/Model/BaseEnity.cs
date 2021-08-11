using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CuckCuk.Api.Model
{
    public class BaseEnity
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime? createdDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String createdBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String ModifiedBy { get; set; }
    }
}
