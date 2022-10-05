using System;
using System.Collections.Generic;
using System.Text;

namespace Objects.Administracion
{
    public class Buzon : Db.Models.Buzon
    {

    }

    public class BuzonMensajes : Db.Models.BuzonMensajes { }

    public class BuzonResult : Buzon{ 

        public string Administrador { get; set; }
        public string Empleado { get; set; }
    }
}
