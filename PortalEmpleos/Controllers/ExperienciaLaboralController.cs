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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ExperienciaLaboralController : Controller
    {
        public ExperienciaLaboralController(ExperienciaLaboralRepository experienciaLaboralRepository) {
            this.repository = experienciaLaboralRepository;
        }

        public readonly ExperienciaLaboralRepository repository;
        /// <summary>
        ///  Proceso para crear experiencia laboral del empleado
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Crear")]
        public async Task<IActionResult> CreateExperienciaLaboral([FromBody] ExperienciaLaboral model)
        {
            try
            {
                return Ok(new ResultViewModel<ExperienciaLaboral>(await repository.Create(model)));
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
        public async Task<IActionResult> UpdateExperienciaLaboral([FromBody] ExperienciaLaboral model)
        {
            try
            {
                return Ok(new ResultViewModel<ExperienciaLaboral>(await repository.Update(model)));
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExperienciaLaboralEmpleado(int id)
        {
            try
            {
                return Ok(new ResultViewModel<IEnumerable<ExperienciaLaboral>>(await repository.GetExperienciaLaboralEmpleado(id)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
    }
}
