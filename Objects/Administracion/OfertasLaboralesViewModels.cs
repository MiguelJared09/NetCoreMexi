using System;
using System.Collections.Generic;
using System.Text;

namespace Objects.Administracion
{
    public class OfertasLaborales : Db.Models.OfertasLaborales
    {
    }
    public class OfertasLaboralesResult : OfertasLaborales
    {
        public string Empresa { get; set; }
    }
    public class OfertasViewResult : Db.Models.OfertasLaboralesVIew
    {

    }
    public class Postulacion : Db.Models.PostulacionOferta
    {

    }
    public class PostulacionResult : Postulacion
    {

    }
    public class PostulacionV : Db.Models.Postulacionview
    {

    }
    public class Servicios : Db.Models.SolicitarServicio
    {

    }
    public class postulacionD : Db.Models.DesactivarOferta
    {

    }
}
