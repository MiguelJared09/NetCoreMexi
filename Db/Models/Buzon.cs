using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Db.Models
{
    public class Buzon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntIdBuzon { get; set; }
        public int IntIdUsuario { get; set; }
        public int IntIdEmpleado { get; set; }
        public DateTime DtFechaBuzon { get; set; }

    }

    public class BuzonMensajes { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntIdBuzonMensaje { get; set; }
        public int IntIdBuzon { get; set; }
        public int IntTipoMensaje { get; set; }
        public string VarMensaje { get; set; }
        public int intEstatus { get; set; }
        public DateTime DtFechaMensaje { get; set; }
    }
}
