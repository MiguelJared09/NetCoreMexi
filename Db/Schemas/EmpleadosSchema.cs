using System;
using System.Collections.Generic;
using System.Text;

namespace Db.Schemas
{
   public  class EmpleadosSchema
    {
        public static string Table = "serviciosempleados";
        public static string intIdServicio = "intIdServicio";
        public static string intIdUser = "intIdUser";
        public static string varNombre = "varNombre";
        public static string varNombreTrabahjo = "varNombreTrabahjo";
        public static string varDescripcion = "varDescripcion";
        public static string varHabilidades = "varHabilidades";
        public static string varHorario = "varHorario";
        public static string decSalario = "decSalario";
        public static string intStatus = "intStatus";
        public static string intTipoTrabajo = "intTipoTrabajo";
        public static string intgenero = "intgenero";
        public static string View = "vwservices";

    }
    public class PostulacionSchema
    {
        public static string Table = "postulacionvacante";
        public static string intId = "intId";
        public static string intIdOfertaLab = "intIdOfertaLab";
        public static string intIdUser = "intIdUser";
        public static string dtFechaPostulacion = "dtFechaPostulacion";
        public static string View = "vwpostulaciones";
    }
}
