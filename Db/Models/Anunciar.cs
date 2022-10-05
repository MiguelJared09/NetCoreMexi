using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Db.Models
{
    public class Anunciar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntIdExperienciaLaboral { get; set; }
        public int IntIdEmpleado { get; set; }
        public string VarCargo { get; set; }
        public string VarLugar { get; set; }
        public string VarDescripcion { get; set; }
        public DateTime DtFechaIngreso { get; set; }
        public DateTime? DtFechaEgreso { get; set; }
        public bool BtAunTrabajoAqui { get; set; }
    }
}
