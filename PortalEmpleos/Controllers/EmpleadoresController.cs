
using Bussines.Administracion;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalEmpleos.Controllers
{
    /// <summary>
    /// Servicio para registro detalle y modificaciones
    // </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoresController
    {
        public EmpleadoresController(EmpleadosRepository repository)
        {
            this.repository = repository;
        }
        public readonly EmpleadosRepository repository;

    }
}
