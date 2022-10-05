using Db.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.DB
{
    public class ConnectionDB
    {
        public ConnectionDB(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public readonly IConfiguration configuration;

        public PortalEmpleoDbContext Connection { get { return new PortalEmpleoDbContext(configuration); } }
    }
}
