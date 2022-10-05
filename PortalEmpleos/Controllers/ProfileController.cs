using Bussines.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Objects.Accounts;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProfileController : AuthorizedControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="profileRepository"></param>
        public ProfileController(
            ProfileRepository profileRepository
            )
        {
            this.profileRepository = profileRepository;
        }

        private readonly ProfileRepository profileRepository;


        /// <summary>
        /// Obtener perfil del usuario
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(new ResultViewModel<UserProfileViewModel>(await profileRepository.Get(UserId)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
    }
}
