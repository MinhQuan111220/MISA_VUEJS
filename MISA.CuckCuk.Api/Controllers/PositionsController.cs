using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities.Interfaces.Repository;
using MISA.Core.Entities.Interfaces.Services;
using MISA.Core.Entities.ModelPosition;

namespace MISA.CuckCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PositionsController : BaseEntityController<Position>
    {
        #region DECLARE

        IPositionService _PositionService;
        IPositionRepository _PositionRepository;
        IBaseRepository<Position> _baseRepository;
        IBaseService<Position> _baseService;
        #endregion

        #region Constructor

        public PositionsController(IPositionService PositionService, IPositionRepository PositionRepository, IBaseRepository<Position> baseRepository, IBaseService<Position> baseService) : base(PositionService, baseRepository)
        {
            _PositionService = PositionService;
            _PositionRepository = PositionRepository;
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
        #endregion

        #region Method

        #endregion


    }
}
