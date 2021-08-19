using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities.Interfaces.Repository;
using MISA.Core.Entities.Interfaces.Services;
using MISA.Core.Entities.ModelPosition;

namespace MISA.Core.Entities.Services
{
    public class PositionService : BaseService<Position>, IPositionService
    {
        #region DECLARE

      
        #endregion

        #region Constructor

        public PositionService(IBaseRepository<Position> baseRepository, IConfiguration configuration) : base(baseRepository,  configuration)

        {
           
        }

        #endregion
    }
}
