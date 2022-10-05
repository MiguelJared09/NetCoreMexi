using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Models
{
    public class Usuario : IdentityUser<int>
    {
        public string passMovil { get; set; }
        public string code { get; set; }

        public string Nombre { get; set; }

        public int IntIdTipoUsuario { get; set; }

        //public int Codigo { get; set; }
    }
    public class Cuentas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public int intIdTipoUser { get; set; }
    }
    public class CuentasView
    {

    }
}
