using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities.Interfaces.MISAAttribute
{
    #region Validate 

    [AttributeUsage(AttributeTargets.Property)]
    public class MISANotMap : Attribute
    {
    }

    /// <summary>
    /// Kiểm tra dữ liệu không để trống  
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired : Attribute
    {
        public string FieldName = string.Empty;

        public MISARequired(string fieldName)
        {
            FieldName = fieldName;
        }
    }
    #endregion
}
