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
        /// <summary>
        /// crear nueva oferta laboral
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<OfertasLaborales> Create(OfertasLaborales model)
        {
            using (var db = Connection)
            {
                db.Add(model);
                await db.SaveChangesAsync();
                return model;
            }
        }
        /// <summary>
        /// crear solicitud de servicio 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Servicios> CreateSolicitudService(Servicios model)
        {
            using (var db = Connection)
            {
                db.Add(model);
                await db.SaveChangesAsync();
                return model;
            }
        }
        /// <summary>
        /// actualizar oferta laboral
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<OfertasLaborales> Update(OfertasLaborales model)
        {
            using (var db = Connection)
            {
                db.Update(model);
                await db.SaveChangesAsync();
                return model;
            }
        }
        /// <summary>
        /// obtener las ofertas laborales del empleador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<OfertasLaborales>> GetOfertasLaborales(int id)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();

                sWhere = new List<string>
                {
                    $"{OfertasLaboralesSchema.IntEstatus} = 1",
                    "1=1"
                };
                if(id != 0)
                {
                    sWhere.Add($"{OfertasLaboralesSchema.IntIdEmpresa} = {id}");
                }

                return await db.Query<OfertasLaborales>($"SELECT * FROM { OfertasLaboralesSchema.Table } WHERE " + string.Join(" AND ", sWhere) +
                $" ORDER BY {OfertasLaboralesSchema.IntIdOfertaLaboral}", id
                );
                //generar conteo de postulantes a la vacante
            }
        }
        /// <summary>
        /// busqueda de ofertas laborales general
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<OfertasViewResult>> GetOfertasLaboralesBusqueda(string valor, int id)
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
                return await db.Query<OfertasViewResult>($"SELECT * FROM { OfertasLaboralesSchema.View } WHERE " + string.Join(" AND ", sWhere) +
                $" ORDER BY {OfertasLaboralesSchema.IntIdOfertaLaboral}"
                );
            }
        }
        /// <summary>
        /// obtener postulantes a una oferta laboral especifica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PostulacionV>> GetPostulaciones(int idOferta, int idUser)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();

                sWhere = new List<string>
                {

                    $"1 = 1",
                };
                if (idUser != 0)
                {
                    sWhere.Add($"{PostulacionesOfertasSchema.intIdUser} = {idUser}");
                }
                if(idOferta != 0)
                {
                    sWhere.Add($"{PostulacionesOfertasSchema.intIdOfertaLaboral} = {idOferta}");
                }
                return await db.Query<PostulacionV>($"SELECT * FROM { PostulacionesOfertasSchema.View } WHERE " + string.Join(" AND ", sWhere) +
                    $" ORDER BY {PostulacionesOfertasSchema.intId}");


            }
        }
        /// <summary>
        ///  desactivar postulaciones
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<postulacionD>> desactivarPostulacion(postulacionD model)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();

                sWhere = new List<string>
                {

                    $"{OfertasLaboralesSchema.IntEstatus} = {model.intEstatus}",
                };
                return await db.Query<postulacionD>($"update  { OfertasLaboralesSchema.Table } set " + string.Join(" AND ", sWhere) +
                    $" where {OfertasLaboralesSchema.IntIdOfertaLaboral}= {model.intIdOfertaLaboral}");


            }
        }
    }
}
