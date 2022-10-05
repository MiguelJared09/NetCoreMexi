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
    public class OfertasLaboralesRepository : ConnectionDB
    {
        public OfertasLaboralesRepository(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }
        private new readonly IConfiguration configuration;

        public async Task<OfertasLaborales> Create(OfertasLaborales model)
        {
            using (var db = Connection)
            {
                db.Add(model);
                await db.SaveChangesAsync();
                return model;
            }
        }
        public async Task<OfertasLaborales> Update(OfertasLaborales model)
        {
            using (var db = Connection)
            {
                db.Update(model);
                await db.SaveChangesAsync();
                return model;
            }
        }
        public async Task<IEnumerable<OfertasLaborales>> GetOfertasLaborales(int id)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();

                sWhere = new List<string>
                {
                    $"{OfertasLaboralesSchema.IntIdEmpresa} = {id}",
                    "1=1"
                };

                return await db.Query<OfertasLaborales>($"SELECT * FROM { OfertasLaboralesSchema.Table } WHERE " + string.Join(" AND ", sWhere) +
                $" ORDER BY {OfertasLaboralesSchema.IntIdOfertaLaboral}", id
                );
            }
        }
        public async Task<IEnumerable<OfertasLaboralesResult>> GetOfertasLaboralesBusqueda(string valor, int id)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();

                sWhere = new List<string>
                {

                     $"{OfertasLaboralesSchema.IntEstatus} = 1",
                    "1=1"
                };
                if (valor != "-1")
                {
                    sWhere.Add($"{OfertasLaboralesSchema.VarPuesto} like '%{valor}%'");
                }
                if (id != 0)
                {
                    sWhere.Add($"{OfertasLaboralesSchema.IntTipoTrabajo} = {id}");
                }
                return await db.Query<OfertasLaboralesResult>($"SELECT * FROM { OfertasLaboralesSchema.View } WHERE " + string.Join(" AND ", sWhere) +
                $" ORDER BY {OfertasLaboralesSchema.IntIdOfertaLaboral}"
                );
            }
        }
    }
}
