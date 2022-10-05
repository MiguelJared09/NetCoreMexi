using Db;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalEmpleos.Controllers
{
    /// <summary>
    /// Servicio para administrar la tabla de personas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PersonaController : Controller
    {
        /// <summary>
        /// Obtener el listado de Personas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Persona> GetPersonas()
        {
            return null;
        }
    }
}
