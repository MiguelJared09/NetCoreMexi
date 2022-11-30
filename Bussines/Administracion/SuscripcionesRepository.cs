using Bussines.DB;
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

        public async Task<Suscripcion> UpdateSuscripcion (Suscripcion model)
        {
            using (var db = Connection)
            {
                db.Update(model);
                await db.SaveChangesAsync();
                return model;
            }
            
        }
        public async Task<IEnumerable<Suscripcion>> GetSuscripciones(int id)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();
                sWhere = new List<string>
                {
                    $"{SuscripcionSchema.intIdUser} = {id}",
                    "1=1"
                };

                return await db.Query<Suscripcion>($"SELECT * FROM { SuscripcionSchema.View } WHERE " + string.Join(" AND ", sWhere) +
                $" ORDER BY {SuscripcionSchema.intIdSuscription}", id
                );
            }
        }
    }
    
   
        
}
