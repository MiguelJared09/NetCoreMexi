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
}
