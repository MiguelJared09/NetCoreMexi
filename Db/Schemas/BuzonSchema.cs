using System;
using System.Collections.Generic;
using System.Text;

namespace Db.Schemas
{
    public class BuzonSchema
    {
        public static string Table = "buzon";
        public static string IntIdBuzon = "IntIdBuzon";
        public static string IntIdUsuario = "IntIdUsuario";
        public static string IntIdEmpleado = "IntIdEmpleado";
        public static string DtFechaBuzon = "DtFechaBuzon";
        public static string View = "vw_Buzon";

        public static string Usuario = "empleado";
    }

    public class BuzonMensajesSchema {
        public static string Table = "buzonMensajes";
        public static string IntIdBuzonMensaje = "IntIdBuzonMenaje";
        public static string IntIdBuzon = "IntIdBuzon";
        public static string IntTipoMensaje = "IntTipoMensaje";
        public static string VarMensaje = "VarMensaje";
        public static string IntEsatus = "IntEstatus";
        public static string DtFechaBuzon = "DtFechaBuzon";
        public static string View = "vw_BuzonMensajes";
    }
}
