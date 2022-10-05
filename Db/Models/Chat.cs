using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Models
{
    public class Chat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntIdChat { get; set; }
        public int IntIdEmpleado { get; set; }
        public int IntIdUsuario { get; set; }
        public DateTime DtFecha { get; set; }
    }
    public class ChatMensajes { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntIdMensajeChat { get; set; }
        public int IntIdChat { get; set; }
        public string VarMensaje { get; set; }
        public int IntIdTipoMensaje { get; set; }
        public DateTime DtFecha { get; set; }
    }
}
