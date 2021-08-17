using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class ServiceResult
    {
        /// <summary>
        /// 
        /// </summary>
        public bool isValid { get; set; } = true;

        /// <summary>
        /// 
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Messenger { get; set; }
    }
}
