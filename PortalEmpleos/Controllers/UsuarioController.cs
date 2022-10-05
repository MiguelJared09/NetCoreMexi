using Bussines.Administracion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Objects.Administracion;
using Objects.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalEmpleos.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public UsuarioController(UsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            this.repository = usuarioRepository;
            this.configuration = configuration;
        }

        private readonly UsuarioRepository repository;
        private readonly IConfiguration configuration;


      
    }
}
