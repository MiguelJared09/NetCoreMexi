using Bussines.Administracion;
using Objects.Administracion;
using Microsoft.AspNetCore.Mvc;
using Objects.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalEmpleos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuscripcionController : Controller
    {
        public SuscripcionController(SuscripcionesRepository repository)
        {
            this.repository = repository;
        }
        public readonly SuscripcionesRepository repository;
        /// <summary>
        ///  proceso de suscripcion, pendiente de agregar paypal
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Suscribir")]
        public async Task<IActionResult> Suscribir([FromBody] Suscripcion model)
        {
            try
            {
                return Ok(new ResultViewModel<Suscripcion>(await repository.Create(model)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
    }
}
