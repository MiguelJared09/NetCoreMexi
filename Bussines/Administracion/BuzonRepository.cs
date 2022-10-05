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
    public class BuzonRepository : ConnectionDB
    {
        public BuzonRepository(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }
        private new readonly IConfiguration configuration;
        public async Task<IEnumerable<BuzonResult>> GetBuzonAdmin(int id,string usuario)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();

                sWhere = new List<string>
                {
                    $"({BuzonSchema.IntIdUsuario} = {id} OR {BuzonSchema.IntIdUsuario } IS NULL )",

                    "1=1"
                };
                if (!string.IsNullOrEmpty(usuario) )
                {
                    if (usuario != "----------")
                    {
                        sWhere.Add($"{BuzonSchema.Usuario} = '{ usuario}'");
                    }
                }
                return await db.Query<BuzonResult>($"SELECT * FROM { BuzonSchema.View } WHERE " + string.Join(" AND ", sWhere) +
                $" ORDER BY {BuzonSchema.IntIdBuzon}", id
                );
            }
        }
        public async Task<IEnumerable<BuzonResult>> GetBuzonEmpleado(int id)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();

                sWhere = new List<string>
                {
                    $"{BuzonSchema.IntIdEmpleado} = {id}",
                    "1=1"
                };

                return await db.Query<BuzonResult>($"SELECT * FROM { BuzonSchema.View } WHERE " + string.Join(" AND ", sWhere) +
                $" ORDER BY {BuzonSchema.IntIdBuzon}", id
                );
            }
        }
        public async Task<IEnumerable<BuzonMensajes>> GetDetalleMensaje(int id)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();

                sWhere = new List<string>
                {
                    $"{BuzonMensajesSchema.IntIdBuzon} = {id}",

                    "1=1"
                };

                return await db.Query<BuzonMensajes>($"SELECT * FROM { BuzonMensajesSchema.View } WHERE " + string.Join(" AND ", sWhere) +
                $" ORDER BY {BuzonMensajesSchema.IntIdBuzon}", id
                );
            }
        }
        public async Task<Buzon> CreateBuzon(Buzon model)
        {
            using (var db = Connection)
            {
                db.Add(model);
                await db.SaveChangesAsync();
                return model;
            }
        }
        public async Task<BuzonMensajes> CreateBuzonMensaje(BuzonMensajes model)
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
