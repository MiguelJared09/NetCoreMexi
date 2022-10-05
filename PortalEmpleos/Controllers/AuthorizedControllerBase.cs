using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalEmpleos.Controllers
{
    public class AuthorizedControllerBase : ControllerBase
    {

        internal int UserId
        {
            get
            {
                return int.Parse(User.Claims.Where(x => x.Type == "Id").Select(x => x.Value).FirstOrDefault());
            }
        }

        internal int Dependencia
        {
            get
            {
                return int.Parse(User.Claims.Where(x => x.Type == "Dependencia").Select(x => x.Value).FirstOrDefault());
            }
        }

        internal string Nombre
        {
            get
            {
                return User.Claims.Where(x => x.Type == "Name").Select(x => x.Value).FirstOrDefault();
            }
        }
    }
}
