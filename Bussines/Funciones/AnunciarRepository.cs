using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Funciones
{
    public class AnunciarRepository : DB.ConnectionDB
    {
        //Configuracion de coneccion a Bd
        public AnunciarRepository(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }
        private new readonly IConfiguration configuration;

        //Funciones de la clase


    }
}
