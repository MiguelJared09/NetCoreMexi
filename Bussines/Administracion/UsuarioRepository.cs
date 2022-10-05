using Bussines.DB;
using Db.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Administracion
{
    public class UsuarioRepository : ConnectionDB
    {
        public UsuarioRepository(IConfiguration configuration, UserManager<Usuario> userManager,
                              RoleManager<Rol> rolManager) : base(configuration) {

            this.configuration = configuration;
            this.userManager = userManager;
            this.rolManager = rolManager;
        }
        private new readonly IConfiguration configuration;
        private readonly UserManager<Usuario> userManager;
        private readonly RoleManager<Rol> rolManager;


       

    }
}
