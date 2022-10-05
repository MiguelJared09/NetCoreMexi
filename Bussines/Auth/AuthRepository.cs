using Bussines.DB;
using Bussines.Shared;
using Db.Models;
using Db.Schemas;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Objects.Accounts;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bussines.Auth
{
    public class AuthRepository : ConnectionDB
    {
        public AuthRepository(IConfiguration configuration,
                             SignInManager<Usuario> signInManager,
                             UserManager<Usuario> userManager,
                             RoleManager<Rol> rolManager,
                             IMailService mailService
                            ) : base(configuration)
        {
            this.configuration = configuration;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.rolManager = rolManager;
            this.mailService = mailService;
        }

        private new readonly IConfiguration configuration;
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;
        private readonly RoleManager<Rol> rolManager;
        private readonly IMailService mailService;


        /// <summary>
        /// Generar JWT
        /// </summary>
        /// <param name="user"></param>
        /// <param name="hoursToExpire"></param>
        /// <returns></returns>
        private async Task<string> GenerateToken(Usuario user, int hoursToExpire = 12)
        {
            using (var db = Connection)
            {

                bool isAdmin = await userManager.IsInRoleAsync(user, "Administrador");

                var currentUser = await userManager.FindByNameAsync(user.UserName);

                var permiso = await db.Query<string>(RolAccesoSchema.QueryListUniqueAccesosByUser, new { usuario = currentUser.Id });


                var claims = new[]
                {
                    new Claim("jti", Guid.NewGuid().ToString()),
                    new Claim("Id", user.Id.ToString()),
                    //new Claim("Name", user.Nombre ?? user.UserName),
                    new Claim(ClaimTypes.Role, isAdmin ? "Admin" : ""),
                    //new Claim("Dependencia", user.IdDireccion != null? user.IdDireccion?.ToString() : "1"),
                    new Claim("Permiso", string.Join(",", permiso))
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                      configuration["JWT:Issuer"],
                      configuration["JWT:Issuer"],
                      claims,
                      expires: DateTime.Now.AddHours(hoursToExpire),
                      signingCredentials: creds);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

        }

        /// <summary>
        /// Iniciar sesión
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<string> Login(LoginViewModel model)
        {
            if (model == null)
            {
                // vacio
                throw new Exception("No se proporcionaron datos");
            }

            if (model.UserName == null)
            {
                // sin email
                throw new Exception("No se proporciono el numero o nombre de usuario");
            }

            if (Regex.IsMatch(model.UserName, @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?"))
            {
                model.UserName = userManager.Users.Where(i => i.Email == model.UserName).Select(i => i.UserName).FirstOrDefault();
            }

            SignInResult result = null;

            try
            {
                result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.Remember, lockoutOnFailure: true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                string x = ex.Message;
            }

            if (result != null && result.Succeeded)
            {
                Usuario user = await userManager.FindByNameAsync(model.UserName);

                if (user == null)
                {
                    throw new Exception("No se encontró el usuario");
                }

                return await GenerateToken(user);
            }
            else if (result != null && result.RequiresTwoFactor)
            {
                throw new Exception("Requiere autentificación de dos pasos");
            }
            else if (result != null && result.IsLockedOut)
            {
                throw new Exception("Cuenta bloqueada");
            }
            else
            {
                throw new Exception("Datos incorrectos");
            }
        }
        //public async Task RequestAnswer(Objects.Accounts.RegisterUserViewModel respuesta)
        //{
        //    try
        //    {

        //    }
        //    catch
        //    {
        //        throw e;
        //    }
        //}
        public async Task Create(Objects.Accounts.RegisterUserViewModel user)
        {
            try
            {
                var result = await userManager.CreateAsync(new Usuario()
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    IntIdTipoUsuario = user.IntIdTipoUsuario,
                    passMovil = user.Password,
                    code = "MXT" + user.UserName 


                    //Codigo = 0
                }, user.Password);

                if (result.Succeeded)
                {
                    var us = await userManager.FindByEmailAsync(user.Email);

                    if (user.Roles != null && user.Roles.Count > 0)
                    {
                        foreach (var m in user.Roles)
                        {
                            await userManager.AddToRoleAsync(us, m.Trim());
                        }
                    }


                    // enviar token de confirmación
                    var generated = await userManager.FindByEmailAsync(user.Email);
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(generated);
                    //emailService.Send(@"
                    //                    <h3>Gracias por registrase<h3>
                    //                    <h4>Para completar tu registro por favor da clic en el siguiente enlace: 
                    //                        <a href=" + configuration["Urls:EmailConfirmationCallback"] + "?token=" + token + ">Da clic aquí</a> </h4>",
                    //                "Confirmación de registro", user.Email);
                }
                else
                {
                    this.ThrowError(result);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void ThrowError(IdentityResult result)
        {
            if (result.Errors.Any(x => x.Code == "DuplicateEmail"))
            {
                throw new Exception("El correo electrónico ya esta registrado");
            }
            else if (result.Errors.Any(x => x.Code == "DuplicateUserName"))
            {
                throw new Exception("El nombre de usuario ya esta registrado");
            }
            else if (result.Errors.Any(x => x.Code == "InvalidUserName"))
            {
                throw new Exception("El nombre de usuario solo debe contener letras y números. Evite usar caracteres especiales o espacios en blanco.");
            }
            else
            {
                throw new Exception(string.Join(", ", result.Errors.Select(x => x.Description)));
            }
        }
        /// <summary>
        /// Solicitar cambio de contraseña
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task RequestPasswordReset(string email)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null) throw new Exception("Correo no valido");

            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            MailRequest request = new MailRequest();
            request.Body = @"<h3>Hemos recibido tu solicitud de cambio de contraseña<h3><h4>Da clic en el siguiente enlace para cambiar tu contraseña:<a href=" + configuration["Urls:RequestResetPassword"] + "?token=" + token + ">Da clic aquí</a></h4>";
            request.Subject = "Solicitud de cambio de contraseña";
            request.ToEmail = user.Email;

            await this.mailService.SendEmailAsync(request);

        }

        /// <summary>
        /// Generar validación de dos pasos
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task ValidacionDosPasos(string email)
        {
           var user = await userManager.FindByEmailAsync(email);

            if (user == null) throw new Exception("Correo no valido");

            var seed = Environment.TickCount;
            var random = new Random(seed);

            string codigo = random.Next(100000, 999999).ToString();

            await this.RegistrarCodigoCorreo(int.Parse(codigo), email);

            MailRequest request = new MailRequest();
            request.Body = @"<h3>Se genero un codigo para incio de sesión de dos pasos<h3><h4>Por favor ingresa el siguiente código en la pagina de validación para continuar con el incio de sesión</h4><h1>" + codigo + "</h1>";
            request.Subject = "Solicitud de cambio de contraseña";
            request.ToEmail = user.Email;

            await this.mailService.SendEmailAsync(request);

        }

        /// <summary>
        /// Cambiar contraseña desde solicitud
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task RequestPasswordByCuestionSafe(string email, int pregunta, string respuesta)
        {
            var user = await userManager.FindByEmailAsync(email);
        }
        public async Task ResetPassword(RequestPasswordReset request)
        {

            var user = await userManager.FindByEmailAsync(request.Email);

            if (user == null) throw new Exception("La cuenta no existe");

            var result = await userManager.ResetPasswordAsync(user, request.Token.Replace(" ", "+"), request.Password);

            if (result.Errors.Count() > 0)
            {
                throw new Exception(string.Join(", ", result.Errors.Select(x => x.Description)));
            }
        }
      
        public async Task RegistrarCodigoCorreo(int codigo, string correo)
        {
            using (var db = Connection)
            {
                DosPasos model = new DosPasos();
                model = db.FirstOrDefault<DosPasos>($"Select * from DosPasos WHERE email = @correo", new { correo }).Result;
                if (model != null)
                {
                    model.Codigo = codigo;
                    db.Update(model);
                }
                else
                {
                    model = new DosPasos();
                    model.Codigo = codigo;
                    model.Email = correo;
                    db.Add(model);
                }
                await db.SaveChangesAsync();
            }
        }
        public async Task<DosPasos> ValidarDosPasos(DosPasos dosPasos)
        {
            using (var db = Connection)
            {
                DosPasos model = new DosPasos();
                model = db.FirstOrDefault<DosPasos>($"Select * from DosPasos WHERE email = @email AND codigo = @codigo", new { dosPasos.Email, dosPasos.Codigo }).Result;
                if (model != null)
                {
                    return model;
                }
                else
                {
                    return null;
                }
                
            }
        }
    }
}
