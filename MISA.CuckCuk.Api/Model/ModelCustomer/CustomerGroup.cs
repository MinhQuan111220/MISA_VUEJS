using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CuckCuk.Api.Model
{
    public class CustomerGroup : BaseEnity
    {
        #region Property
        /// <summary>
        /// Khóa Chính
        /// </summary>
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Ten
        /// </summary>
        public String CustomerGroupName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String Description { get; set; }


        #endregion


    }
}
