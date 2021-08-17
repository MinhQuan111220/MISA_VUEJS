using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities.Interfaces.Repository;
using MISA.Core.Entities.Interfaces.Services;
using MISA.Core.Entities.ModelPosition;

namespace MISA.Core.Entities.Services
{
    public class PositionService : BaseService<Position>, IPositionService
    {
        ServiceResult _serviceResult;

    public PositionService(IBaseRepository baseRepository) : base(baseRepository)

    {
        _serviceResult = new ServiceResult();
    }

    }
}
