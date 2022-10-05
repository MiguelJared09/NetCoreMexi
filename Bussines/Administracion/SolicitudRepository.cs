using Bussines.DB;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Administracion
{
    public class SolicitudRepository : ConnectionDB
    {
        public SolicitudRepository(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }
        private new readonly IConfiguration configuration;

    }
}
