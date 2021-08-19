using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities.Interfaces.Services;
using MISA.Core.Entities.Interfaces.Repository;

namespace MISA.CuckCuk.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseEntityController<MISAEntity> : ControllerBase
    {
        #region DECLARE
        IBaseService<MISAEntity> _baseService;
        IBaseRepository<MISAEntity> _baseRepository;

        static string classNameId;
        #region Constructor
        public BaseEntityController(IBaseService<MISAEntity> baseService, IBaseRepository<MISAEntity> baseRepository )
        {
            _baseService = baseService;
            _baseRepository = baseRepository;

            classNameId = $"{typeof(MISAEntity).Name}Id";
        }
        #endregion

        #region Method

        /// <summary>
        /// Lấy thông tin tất cả 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public virtual IActionResult Get([FromQuery] string value1,[FromQuery] string value2)
        {
            try
            {
                var entites = _baseRepository.GetAll();
                // 4. Trả về cho client
                if (entites != null)
                {
                    var response = StatusCode(200, entites);
                    return response;
                }
                else
                {
                    return StatusCode(204, entites);
                }
            }
            catch(Exception ex)
            {
                var erroObject = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.Erro500,
                    erorrCode = "misa-001",
                };
                return StatusCode(500, erroObject);
            }
        }
        /// <summary>
        /// Lấy thông tin  theo Id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        [HttpGet("{entityId}")]
        public IActionResult GetById(Guid? entityId)
        {

            // Lấy thông tin theo id
            try
            {
                var entity = _baseRepository.GetById(entityId);
                // 4. Tra ve cho client
                if (entity != null)
                {
                    return StatusCode(200, entity);

                }
                else
                {
                    return StatusCode(204);
                }
            }
            catch (Exception ex)
            {
                var erroObject = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.Erro500,
                    erorrCode = "misa-001",
                };
                return StatusCode(500, erroObject);
            }
        }
        /// <summary>
        /// Thêm mới một 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insertentity(MISAEntity entity)
        {

            //Bắt đầu thêm mới
            try
            {

                var serviceResult = _baseService.Add(entity);
                // 4. Tra ve cho client
                if (serviceResult.isValid == true)
                {
                    if ( serviceResult.Data!=null)
                    {
                        return StatusCode(201, serviceResult.Data);
                    }
                    else
                    {
                        var erroObject = new
                        {
                            devMsg = Properties.Resources.Erro500,
                            userMsg = Properties.Resources.Erro500,
                            erorrCode = "misa-001",
                        };
                        return StatusCode(500, erroObject);
                    }

                }
                else
                {
                    return BadRequest(serviceResult.Data);
                }
            }
            catch (Exception ex)
            {
                var erroObject = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.Erro500,
                    erorrCode = "misa-001",
                };
                return StatusCode(500, erroObject);
            }
        }

        /// <summary>
        /// Sửa dữ liệu cho một 
        /// </summary>
        /// <param name="entityId"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("{entityId}")]
        public IActionResult Updateentity(MISAEntity entity, Guid? entityId)
        {

            try
            {

                var serviceResult = _baseService.Update(entity, entityId);
                // 4. Tra ve cho client
                if (serviceResult.isValid == true)
                {
                    return StatusCode(200, serviceResult.Data);

                }
                else
                {
                    return BadRequest(serviceResult.Data);
                }
            }
            catch (Exception ex)
            {
                var erroObject = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.Erro500,
                    erorrCode = "misa-001",
                };
                return StatusCode(500, erroObject);
            }
        }

        /// <summary>
        /// Xóa thông tin  theo 
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        [HttpDelete("{entityId}")]
        public IActionResult Deleteentity(Guid? entityId)
        {
            try
            {
                var entity = _baseRepository.Delete(entityId);
                // 4. Tra ve cho client 
                if (entity == 1)
                {
                    return StatusCode(200, entity);

                }
                else
                {
                    var erroObject = new
                    {
                        userMsg = Properties.Resources.UserMsg_Erro400,
                        erorrCode = "misa-001",
                    };
                    return StatusCode(400, erroObject);
                }

            }
            catch (Exception ex)
            {
                var erroObject = new
                {
                    devMsg = ex.Message,
                    userMsg = Properties.Resources.Erro500,
                    erorrCode = "misa-001",
                };
                return StatusCode(500, erroObject);
            }
        }

        #endregion
    }
    #endregion
}
