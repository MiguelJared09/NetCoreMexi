using Bussines.Administracion;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Objects.Administracion;
using Objects.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PortalEmpleos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OfertasLaboralesController : Controller
    {
        public OfertasLaboralesController(OfertasLaboralesRepository repository)
        {
            this.repository = repository;
        }
        public readonly OfertasLaboralesRepository repository;

        [HttpPost("Crear")]
        public async Task<IActionResult> CreateOfertaLaboral([FromBody] OfertasLaborales model)
        {
            try
            {
                return Ok(new ResultViewModel<OfertasLaborales>(await repository.Create(model)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
        /// <summary>
        ///  Proceso para actualizar experiencia laboral del empleado
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        public async Task<IActionResult> UpdateExperienciaLaboral([FromBody] OfertasLaborales model)
        {
            try
            {
                return Ok(new ResultViewModel<OfertasLaborales>(await repository.Update(model)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
        /// <summary>
        /// Obtener el listado de  laboral del empleado
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfertasLaborales(int id)
        {
            try
            {
                return Ok(new ResultViewModel<IEnumerable<OfertasLaborales>>(await repository.GetOfertasLaborales(id)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
        /// <summary>
        /// Obtener el listado de experiencia laboral del empleado
        /// </summary>
        /// <returns></returns>
        [HttpGet("Busqueda/{value}")]
        public async Task<IActionResult> GetOfertasLaboralesBusqueda(string value, int id)
        {
            try
            {
                
                return Ok(new ResultViewModel<IEnumerable<OfertasLaboralesResult>>(await repository.GetOfertasLaboralesBusqueda(value, id)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
    }
}
