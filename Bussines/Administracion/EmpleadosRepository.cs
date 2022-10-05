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

        // funcion para conseguir el listado de los servicios publicados
        public async Task<IEnumerable<EmpleadosResult>> getServicios(int id)
        {
            using (var db = Connection)
            {
                List<string> sWhere = new List<string>();

                sWhere = new List<string>
                {
                    $"{EmpleadosSchema.intIdUser} = {id}",
                    "1=1"
                };

                return await db.Query<EmpleadosResult>($"SELECT * FROM { EmpleadosSchema.Table } WHERE " + string.Join(" AND ", sWhere) +
                $" ORDER BY {EmpleadosSchema.intIdServicio}", id
                );
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
        public async Task<IEnumerable<EmpleadorsViewResult>> GetPostulaciones(int id)
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
        }
    }
}
