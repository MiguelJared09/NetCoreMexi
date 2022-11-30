using System;
using System.Collections.Generic;
using System.Text;

namespace Db.Schemas
{
    public class OfertasLaboralesSchema
    {
        public static string Table = "OfertasLaborales";
        public static string IntIdOfertaLaboral = "IntIdOfertaLaboral";
        public static string IntIdEmpresa = "IntIdEmpresa";
        public static string VarPuesto = "VarPuesto";
        public static string VarDescripcion = "VarDescripcion";
        public static string VarUbicacion = "VarUbicacion";
        public static string DecSalario = "DecSalario";
        public static string IntEstatus = "IntEstatus";
        public static string DtFechaRegistro = "DtFechaRegistro";
        public static string intTurno = "intTurno";
        public static string varRequisitos = "varRequisitos";
        public static string dtFechaVigencia = "dtFechaVigencia";
        public static string IntTipoTrabajo = "IntTipoTrabajo";
        public static string View = "vwOfertasLaborales";
    }
    public class PostulacionesOfertasSchema
    {
        public static string Table = "postulacionvacante";
        public static string View = "vwpostulaciones";
        public static string intId = "intId";
        public static string intIdOfertaLaboral = "intIdOfertaLaboral";
        public static string intIdUser = "intIdUser";
        public static string UserName = "UserName";
        public static string varNombre = "varNombre";
        public static string intDisponibilidad = "Disponibilidad";
        public static string varPuesto = "varPuesto";
        public static string dtFechaPostulacion = "dtFechaPostulacion";
    }
}
