using Bussines.DB;
using Db.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Objects.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Auth
{
    public class ProfileRepository: ConnectionDB
    {
        public ProfileRepository(IConfiguration configuration,
                                 UserManager<Usuario> manager) : base(configuration)
        {
            userManager = manager;
        }

        private readonly UserManager<Usuario> userManager;

        /// <summary>
        /// Obtener perfil del usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserProfileViewModel> Get(int id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            if (user == null) throw new Exception("Ha ocurrido un error. Vuelve a iniciar sesión");

            using (var db = Connection)
            {
                // TODO: Agregar mas campos
                return new UserProfileViewModel()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.UserName,
                    intIdTipoUsuario = user.IntIdTipoUsuario
                    //Dependencia = user.IdDireccion
                };

            }



        }
    }
}
