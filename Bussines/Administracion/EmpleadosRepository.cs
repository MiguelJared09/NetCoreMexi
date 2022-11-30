using Bussines.DB;
using Db.Models;
using Db.Schemas;
using Microsoft.Extensions.Configuration;
using Objects.Accounts;
using Objects.Administracion;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Administracion
{
    public class EmpleadosRepository : ConnectionDB
    {
        public EmpleadosRepository(IConfiguration configuration) : base(configuration)
        {
            this.configuration = configuration;
        }
        private new readonly IConfiguration configuration;

        /// <summary>
        /// funcion para conseguir el listado de los servicios publicados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<IEnumerable<EmpleadosResult>> getServicios(int id)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();
                sWhere = new List<string>
                {

                     $"{EmpleadosSchema.intStatus} = 1",

                };
                if (id != 0)
                {
                    sWhere.Add($"{EmpleadosSchema.intIdUser} = {id}");
                }
               

                return await db.Query<EmpleadosResult>($"SELECT * FROM { EmpleadosSchema.Table } WHERE " + string.Join(" AND ", sWhere) +
                $" ORDER BY {EmpleadosSchema.intIdServicio}", id
                );
                //agregar ubicacion del trabajador
                
            }
        }
        
        public async Task<IEnumerable<SolicitudesViewResult>> getMisSolicitudes(int id)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();

                sWhere = new List<string>
                {

                    $"1=1",
                };
                if (id != 0)
                {
                    sWhere.Add($"{SolicitudServiciosSchema.idEmp} = {id}");
                }
               
                return await db.Query<SolicitudesViewResult>($"SELECT * FROM { SolicitudServiciosSchema.View } WHERE " + string.Join(" AND ", sWhere) +
                    $" ORDER BY {SolicitudServiciosSchema.Solicitud}");


            }
        }
        /// <summary>
        /// desactivar o activar servicios
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ServiciosD>> DesactivarServicios(ServiciosD model)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();

                sWhere = new List<string>
                {
                    $"{EmpleadosSchema.intStatus} = {model.intStatus}",
                    "1=1"
                };

                return await db.Query<ServiciosD>($"Update { EmpleadosSchema.Table } set " + string.Join(" AND ", sWhere) +
                $" where {EmpleadosSchema.intIdServicio} = {model.intIdServicio}"
                );
                //agregar ubicacion del trabajador

            }
        }
        //funcion para buscar todos los empleados que han publicado servicios
        public async Task<IEnumerable<EmpeladosViewResult>> GetServiciosEmpleados(string valor, int id, int genero)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();
                sWhere = new List<string>
                {

                     $"{EmpleadosSchema.intStatus} = 1",
                    
                };
                if (valor != "-1" )
                {
                    sWhere.Add($"{EmpleadosSchema.varNombreTrabahjo} like '%{valor}%'"); 
                }
                if (id !=0)
                {
                    sWhere.Add($"{EmpleadosSchema.intTipoTrabajo} = {id} ");
                }
                if (genero != 0)
                {
                    sWhere.Add($"{EmpleadosSchema.intgenero} = {genero} ");
                }

                return await db.Query<EmpeladosViewResult>($"SELECT * FROM { EmpleadosSchema.View } WHERE " + string.Join(" AND ", sWhere) +
                $" ORDER BY {EmpleadosSchema.intIdServicio}"
                );
                
            }
        }
        //public async Task<IEnumerable<EmpleadosResult>> GetServiciosEmpleados(string valor)
        //{
        //    using (var db = Connection)
        //    {
        //        List<string> sWhere = new List<string>();

        //        sWhere = new List<string>
        //        {

        //             $"{EmpleadosSchema.intStatus} = 1",

        //        };
        //        if (valor != "-1")
        //        {
        //            sWhere.Add($"{EmpleadosSchema.varNombreTrabahjo} like '%{valor}%'");
        //        }

        //        return await db.Query<EmpleadosResult>($"SELECT * FROM { EmpleadosSchema.View } WHERE " + string.Join(" AND ", sWhere) +
        //        $" ORDER BY {EmpleadosSchema.intIdServicio}"
        //        );

        //    }
        //}
        //funcion para ofrecer servicios

        public async Task<IEnumerable<SolicitudesViewResult>> GetSolicitudes(int id,int idEmpleador)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();

                sWhere = new List<string>
                {

                    $"1=1",
                };
                if(id != 0)
                {
                    sWhere.Add($"{SolicitudServiciosSchema.Servicio} = {id}");
                }
                if(idEmpleador != 0)
                {
                    sWhere.Add($"{SolicitudServiciosSchema.idEmpleador} = {idEmpleador}");
                }
                return await db.Query<SolicitudesViewResult>($"SELECT * FROM { SolicitudServiciosSchema.View } WHERE " + string.Join(" AND ", sWhere) +
                    $" ORDER BY {SolicitudServiciosSchema.Solicitud}");


            }
        }
        public async Task<EmpleadosModel> CreateService(EmpleadosModel model)
        {
            using (var db = Connection)
            {
                db.Add(model);
                await db.SaveChangesAsync();
                return model;
            }
        }
        //funcion para actualizar publicacion de servicios
        public async Task<EmpleadosModel> UpdateService(EmpleadosModel model)
        {
            using (var db = Connection)
            {
                db.Update(model);
                await db.SaveChangesAsync();
                return model;
            }
        }

        //funcion para postularse a alguna oferta laboral
        public async Task<EmpleadosModelPostulacion> CreatePostulacion(EmpleadosModelPostulacion model)
        {
            using (var db = Connection)
            {
                db.Add(model);
                await db.SaveChangesAsync();
                return model;
            }

        }
        //funcion para conseguir las postulaciones activas
        /*public async Task<IEnumerable<EmpleadorsViewResult>> GetPostulaciones(int id)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();

                sWhere = new List<string>
                {
                    $"{PostulacionSchema.intIdUser} = {id}",
                    "1=1"
                };

                return await db.Query<EmpleadorsViewResult>($"SELECT * FROM { PostulacionSchema.View } WHERE " + string.Join(" AND ", sWhere) +
                $" ORDER BY {PostulacionSchema.intId}", id
                );
            }
        }*/
    }
}
