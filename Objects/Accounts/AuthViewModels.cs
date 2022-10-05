using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Accounts
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }

    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "Nombre obligatorio")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Correo electrónico obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Contraseña obligatoria")]
        public string Password { get; set; }

        public int IntIdTipoUsuario { get; set; }

        public List<string> Roles { get; set; }
        /// <summary>
        /// campos agregados eliminar si no funciona xd
        /// </summary>
        public string passMovil { get; set; }
        public string code { get; set; }
        /// <summary>
        /// aqui terminan xd
        /// </summary>
        public string Nombre { get; set; }
        public string Respuesta { get; set; }

    }

    public class UpdateUser
    {
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<string> Roles { get; set; }

        public int? IdDireccion { get; set; }

        public string Nombre { get; set; }

    }

    public class ConfirmEmailViewModel
    {

        [Required(ErrorMessage = "Correo electrónico obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Token obligatorio")]
        public string Token { get; set; }
    }


    public class RequestPasswordReset
    {
        [Required(ErrorMessage = "Correo electrónico obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Contraseña obligatoria")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Token obligatorio")]
        public string Token { get; set; }
    }

    public class RequestPassword
    {
        [Required(ErrorMessage = "Correo electrónico obligatorio")]
        public string Email { get; set; }
    }
}
