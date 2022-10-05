﻿using Bussines.DB;
using Db.Schemas;
using Microsoft.Extensions.Configuration;
using Objects.Administracion;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Bussines.Administracion
{
    public class SuscripcionesRepository : ConnectionDB
    {
        public SuscripcionesRepository(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }
        public new readonly IConfiguration configuration;

        //funcion para el registro de suscripcion
        public async Task<Suscripcion> Create(Suscripcion model)
        {
            using (var db = Connection)
            {
                db.Add(model);
                await db.SaveChangesAsync();
                return model;
            }
        }

    }
    
   
        
}