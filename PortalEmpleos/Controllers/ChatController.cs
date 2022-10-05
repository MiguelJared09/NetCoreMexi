using Bussines.Administracion;
using Objects.Administracion;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Objects.Shared;
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
    public class ChatController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="profileRepository"></param>
        public ChatController(ChatRepository profileRepository)
        {
            this.chatRepository = profileRepository;
        }

        private readonly ChatRepository chatRepository;

        /// <summary>
        /// Obtener el listado de Personas
        /// </summary>
        /// <returns></returns>
        [HttpGet("Mensajes/{id}")]
        public async Task<IActionResult> GetPersonas(int id)
        {
            try
            {
                return Ok(new ResultViewModel<IEnumerable<ChatMensajes>>(await chatRepository.GetMensajes(id)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
        [HttpPost("RegistroMensaje")]
        public async Task<IActionResult> CreateMensaje([FromBody] ChatMensajes model)
        {
            try
            {
                return Ok(new ResultViewModel<ChatMensajes>(await chatRepository.CreateMesaje(model)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
        [HttpPost("RegistroChat")]
        public async Task<IActionResult> CreateChat([FromBody] Chat model)
        {
            try
            {
                return Ok(new ResultViewModel<Chat>(await chatRepository.CrearChat(model)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
    }
}
