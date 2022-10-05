using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Db.Models
{
    public class Suscripcion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int intIdSuscription { get; set; }
        public int intIdUser { get; set; }
        public int intIdSuscripcion { get; set; }
        public DateTime dtFecha { get; set; }
    }
}
