using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db.Schemas
{
    public class ChatSchema
    {
        public static string Table = "chat";
        public static string IntIdChat = "IntIdChat";
        public static string IntIdEmpleado = "IntIdEmpleado";
        public static string DtFecha = "DtFecha";
    }
    public class ChatMensajesSchema {
        public static string Table = "chatMensajes";
        public static string IntIdMensajeChat = "IntIdMensajeChat";
        public static string IntIdChat = "IntIdChat";
        public static string VarMensaje = "VarMensaje";
        public static string DtFecha = "DtFecha";
        public static string View = "wv_MensajesChat";
    }
}
