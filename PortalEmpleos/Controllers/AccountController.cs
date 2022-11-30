using Bussines.Auth;
using Bussines.Shared;
using Db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Objects.Accounts;
using Objects.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalEmpleos.Controllers
{
    /// <summary>
    /// Servicio para administrar cuentas, inicio de sesión, etc.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authRepository"></param>
        /// <param name="configuration"></param>
        public AccountController(AuthRepository authRepository
            , IMailService mailService
            ,IConfiguration configuration)
        {
            repository = authRepository;
            this.mailService = mailService;
            this.configuration = configuration;
        }

        private readonly AuthRepository repository;
        private readonly IConfiguration configuration;
        private readonly IMailService mailService;
        /// <summary>
        /// Inicio de sesión
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel user)
        {
            try
            {
                await Task.Delay(1500);
                return Ok(new ResultViewModel<string>(await repository.Login(user)));

            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }

        /// <summary>
        /// Registro de usuario con contraseña
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("registro")]
        public async Task<IActionResult> Register([FromBody] RegisterUserViewModel user)
        {
            try
            {
                await repository.Create(user);
                return Ok(new ResultViewModel(true, "Se ha registrado exitosamente"));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }

        /// Registro de usuario con contraseña
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequest request)
        {
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Solicitar cambio de contraseña
        /// </summary>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        [HttpPost("requestPasswordReset")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] RequestPassword solicitud)
        {
            try
            {
                await Task.Delay(1500);
                await repository.RequestPasswordReset(solicitud.Email);
                return Ok(new ResultViewModel(true, "Se ha enviado un mensaje a su bandeja de entrada"));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }

        /// <summary>
        /// Solicitar cambio de contraseña
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("sendCodeTwoStep")]
        public async Task<IActionResult> EnviarCodigoDosPasos([FromBody] RequestPassword solicitud)
        {
            try
            {
                await Task.Delay(1500);
                await repository.ValidacionDosPasos(solicitud.Email);
                return Ok(new ResultViewModel(true, "Se ha enviado un mensaje a su bandeja de entrada"));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }

        /// <summary>
        /// Cambiar contraseña
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] RequestPasswordReset request)
        {
            try
            {
                await Task.Delay(1500);
                await repository.ResetPassword(request);
                return Ok(new ResultViewModel(true, "Contraseña cambiada"));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }


        /// <summary>
        /// Solicitar cambio de contraseña
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("validateSecondStep")]
        public async Task<IActionResult> ValidarSegundoPaso([FromBody] DosPasos solicitud)
        {
            try
            {
                
                return Ok(new ResultViewModel<DosPasos>(await repository.ValidarDosPasos(solicitud)));
                //return Ok(new ResultViewModel(true, "Se ha enviado un mensaje a su bandeja de entrada"));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }

    }
}
