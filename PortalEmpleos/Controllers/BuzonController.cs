using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussines.Administracion;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Objects.Administracion;
using Objects.Shared;

namespace PortalEmpleos.Controllers
{
    /// <summary>
    /// Servicio para administrar la tabla de personas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BuzonController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="profileRepository"></param>
        public BuzonController(BuzonRepository buzonRepository)
        {
            this.buzonRepository = buzonRepository;
        }

        private readonly BuzonRepository buzonRepository;

        [HttpPost("CrearBuzon")]
        public async Task<IActionResult> CreateBuzon([FromBody] Buzon model)
        {
            try
            {
                return Ok(new ResultViewModel<Buzon>(await buzonRepository.CreateBuzon(model)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }

        [HttpPost("CrearBuzonMensaje")]
        public async Task<IActionResult> CreateBuzonMensaje([FromBody] BuzonMensajes model)
        {
            try
            {
                return Ok(new ResultViewModel<BuzonMensajes>(await buzonRepository.CreateBuzonMensaje(model)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
        /// <summary>
        /// Obtener el listado de mensajes del administrador
        /// </summary>
        /// <returns></returns>
        [HttpGet("BuzonAdmin/{id}/{usuario}")]
        public async Task<IActionResult> GetBuzonAdmin(int id,string usuario)
        {
            try
            {
                return Ok(new ResultViewModel<IEnumerable<BuzonResult>>(await buzonRepository.GetBuzonAdmin(id,usuario)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
        /// <summary>
        /// Obtener el listado de Mensajes del empleado
        /// </summary>
        /// <returns></returns>
        [HttpGet("BuzonUsuario/{id}")]
        public async Task<IActionResult> GetbuzonEmpleado(int id)
        {
            try
            {
                return Ok(new ResultViewModel<IEnumerable<BuzonResult>>(await buzonRepository.GetBuzonEmpleado(id)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
        /// <summary>
        /// Obtener el listado de mensajes del buzon
        /// </summary>
        /// <returns></returns>
        [HttpGet("BuzonMensajes/{id}")]
        public async Task<IActionResult> GetBuzonMensajez(int id)
        {
            try
            {
                return Ok(new ResultViewModel<IEnumerable<BuzonMensajes>>(await buzonRepository.GetDetalleMensaje(id)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
    }
}
