using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Db.Models
{
    public class PortalEmpleoDbContext : IdentityDbContext<Usuario, Rol, int>
    {
        public PortalEmpleoDbContext(IConfiguration configuration)
        {
            _ConnectionString = configuration.GetConnectionString("Db");
        }
        internal readonly string _ConnectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString: _ConnectionString,
                new MySqlServerVersion(new Version(10, 4, 17)));
        }
        public DbSet<Empleados> serviciosempleados { get; set; }
        public DbSet<postulacion> postulacionvacante { get; set; }
        public DbSet<Detail> detalleuser { get; set; }
        public DbSet<Suscripcion> usuariosuscricion { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public DbSet<ChatMensajes> ChatMensajes { get; set; }
        public DbSet<Buzon> Buzon { get; set; }
        public DbSet<BuzonMensajes> BuzonMensajes { get; set; }
        public DbSet<ExperienciaLaboral> ExperienciaLaboral { get; set; }
        public DbSet<OfertasLaborales> OfertasLaborales { get; set; }
        public DbSet<DosPasos> DosPasos { get; set; }
        #region Dapper
        /// <summary>
        /// Ejecutar una consulta y esperar multiples resultados
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd"></param>
        /// <param name="param"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> Query<T>(string cmd, object param = null, System.Data.CommandType cmdType = System.Data.CommandType.Text)
        {
            using (var conn = new MySqlConnection(_ConnectionString))
            {
                using (System.Data.IDbConnection dbConnection = conn)
                {
                    dbConnection.Open();
                    return await dbConnection.QueryAsync<T>(cmd, param, commandType: cmdType);
                }
            }
        }


        /// <summary>
        /// Ejecutar una consulta y esperar un resultado
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd"></param>
        /// <param name="param"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public async Task<T> FirstOrDefault<T>(string cmd, object param = null, System.Data.CommandType cmdType = System.Data.CommandType.Text)
        {
            using (var conn = new MySqlConnection(_ConnectionString))
            {
                using (System.Data.IDbConnection dbConnection = conn)
                {
                    dbConnection.Open();
                    return await dbConnection.QueryFirstOrDefaultAsync<T>(cmd, param, commandType: cmdType);
                }
            }
        }

        /// <summary>
        /// Executar una consulta sin esperar resultado
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="param"></param>
        /// <param name="cmdType"></param>
        /// <returns></returns>
        public async Task Execute(string cmd, object param = null, System.Data.CommandType cmdType = System.Data.CommandType.Text)
        {
            using (var conn = new MySqlConnection(_ConnectionString))
            {
                using (System.Data.IDbConnection dbConnection = conn)
                {
                    dbConnection.Open();
                    await dbConnection.ExecuteAsync(cmd, param, commandType: cmdType);
                }
            }
        }

        public async Task Insert(string tabla, object aInsertar)
        {
            var campos = ObtenerPropiedades(aInsertar);
            await Execute($"INSERT INTO {tabla}({string.Join(",", campos)}) VALUES({string.Join(",", campos.Select(c => $"@{c}"))})", aInsertar);
        }

        public async Task Update(string tabla, object aActualizar, string where)
        {
            var campos = ObtenerPropiedades(aActualizar);
            await Execute($"UPDATE {tabla} SET {string.Join(",", campos.Select(c => $"{c} = @{c}"))} WHERE {where}", aActualizar);
        }

        internal IEnumerable<string> ObtenerPropiedades(object ob)
        {
            return ob.GetType().GetProperties().Where(a => !a.CustomAttributes.Any(c => c.AttributeType.Name == "JsonIgnoreAttribute")).Select(a => a.Name);
        }


        #endregion
    }
}
