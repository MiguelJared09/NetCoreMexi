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
    public class ExperienciaLaboralRepository : ConnectionDB
    {
        public ExperienciaLaboralRepository(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }
        private new readonly IConfiguration configuration;

        public async Task<ExperienciaLaboral> Create(ExperienciaLaboral model)
        {
            using (var db = Connection)
            {
                db.Add(model);
                await db.SaveChangesAsync();
                return model;
            }
        }
        public async Task<ExperienciaLaboral> Update(ExperienciaLaboral model)
        {
            using (var db = Connection)
            {
                db.Update(model);
                await db.SaveChangesAsync();
                return model;
            }
        }

        public async Task<IEnumerable<ExperienciaLaboral>> GetExperienciaLaboralEmpleado(int id)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();

                sWhere = new List<string>
                {
                    $"{ExperienciaLaboralSchema.IntIdEmpleado} = {id}",
                    "1=1"
                };

                return await db.Query<ExperienciaLaboral>($"SELECT * FROM { ExperienciaLaboralSchema.Table } WHERE " + string.Join(" AND ", sWhere) +
                $" ORDER BY {ExperienciaLaboralSchema.IntIdExperienciaLaboral}", id
                );
            }
        }
    }
}
