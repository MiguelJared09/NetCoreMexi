using Bussines.DB;
using Db.Models;
using Db.Schemas;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Objects.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Auth
{
    public class DetailReository : ConnectionDB
    {
        public DetailReository(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }
        private new readonly IConfiguration configuration;

        //funcion para crear registroDetalle del usuario
        public async Task<DetailModel> Create(DetailModel model)
        {
            using (var db = Connection)
            {
                db.Add(model);
                await db.SaveChangesAsync();
                return model;
            }
        }
        //Funcion para Actualizar RegistroDetalle
        public async Task<DetailModel> UpdateDetail(DetailModel model
            )
        {
            using (var db = Connection)
            {
                db.Update(model);
                await db.SaveChangesAsync();
                return model;
                
            }
        }

        // funcion para conseguir el detalle del usuario
        public async Task<IEnumerable<Detail>> GetDetalleRegistro(int id)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();

                sWhere = new List<string>
                {
                    $"{DetailSchema.IntIdUser} = {id}",
                    "1=1"
                };

                return await db.Query<Detail>($"SELECT * FROM { DetailSchema.Table } WHERE " + string.Join(" AND ", sWhere) +
                $" ORDER BY {DetailSchema.IntidDetalle}", id
                );
            }
        }

    }
}
