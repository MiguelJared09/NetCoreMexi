using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db
{
    /// <summary>
    /// Permite registrar las personas que usaran el sitio web portal empleos
    /// </summary>
    public class Persona
    {
        /// <summary>
        /// Id de la persona
        /// </summary>
        /// <value> El id se incrementa automáticamente</value>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntIdPersona { get; set; }
        /// <summary>
        /// nombre de usuario de la persona, sirve para iniciar sesión en el sitio web portal empleos
        /// </summary>
        /// <value> El valor es alfanumerico</value>
        [Column(TypeName = "VARCHAR(25)")]
        public string VarUsuario { get; set; }
        /// <summary>
        /// es la contraseña de la persona, sirve para iniciar sesión en el sitio web portal empleos
        /// </summary>
        /// <value> El valor es alfanumerico, minimo 8 caracteres</value>
        [Column(TypeName = "VARCHAR(25)")]
        public string VarPassword { get; set; }
    }
}
