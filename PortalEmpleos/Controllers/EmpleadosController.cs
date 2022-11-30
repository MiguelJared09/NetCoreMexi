using Bussines.Administracion;
using Microsoft.AspNetCore.Mvc;
using Objects.Administracion;
using Objects.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PortalEmpleos.Controllers
{


    /// <summary>
    /// Servicio para registro detalle y modificaciones
    // </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : Controller
    {
        public EmpleadosController(EmpleadosRepository repository)
        {
            this.repository = repository;
        }
       
        public readonly EmpleadosRepository repository;
        //<summary>
        // Obtener el detalle del empleado
        //</summary>
        //<returns></returns>
        [HttpGet("Busqueda/{value}")]
        public async Task<IActionResult> GetServiciosEmpleados(string value, int id, int genero)
        {
            try
            {

                return Ok(new ResultViewModel<IEnumerable<EmpeladosViewResult>>(await repository.GetServiciosEmpleados(value, id, genero)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
        /// <summary>
        /// activar o desactivar servicios
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("desactivarservicios/")]
        public async Task<IActionResult> DesactivarServicios([FromBody]ServiciosD model) 
        { 
            try
            {

                return Ok(new ResultViewModel<IEnumerable<ServiciosD>>(await repository.DesactivarServicios(model)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
        //<summary>
        // Obtener el las ofertas laborales
        //</summary>
        //<returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfertasLaborales(int id)
        {
            try
            {
                return Ok(new ResultViewModel<IEnumerable<EmpleadosResult>>(await repository.getServicios(id)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
        /// <summary>
        /// obtener solicitudes de servicios
        /// </summary>
        
        /// <returns></returns>
        [HttpGet("solicitudes/{id}")]
        public async Task<IActionResult> GetSolicitudes(int id, int idEmpleador)
        {
            try
            {
                return Ok(new ResultViewModel<IEnumerable<SolicitudesViewResult>>(await repository.GetSolicitudes(id, idEmpleador)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
        /// <summary>
        /// obtener las solicitudes de un usuario especifico
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idEmpleador"></param>
        /// <returns></returns>
        [HttpGet("MisSolicitudes/{id}")]
        public async Task<IActionResult> getMisSolicitudes(int id)
        {
            try
            {
                return Ok(new ResultViewModel<IEnumerable<SolicitudesViewResult>>(await repository.getMisSolicitudes(id)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }   
            //<summary>
            // publicar servicios
            //</summary>
            //<returns></returns>
            [HttpPost("CrearServicio")]
        public async Task<IActionResult> CreateService([FromBody] EmpleadosModel model)
        {
            try
            {
                return Ok(new ResultViewModel<EmpleadosModel>(await repository.CreateService(model)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
        //<summary>
        // actualizar servicios
        //</summary>
        //<returns></returns>
        [HttpPost("actualizar")]
        public async Task<IActionResult> UpdateService([FromBody] EmpleadosModel model)
        {
            try
            {
                return Ok(new ResultViewModel<EmpleadosModel>(await repository.UpdateService(model)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }

        }
        //<summary>
        // Postular a alguna oferta laboral
        //</summary>
        //<returns></returns>
        [HttpPost("Postulacion")]
        public async Task<IActionResult> createPostulacion([FromBody] EmpleadosModelPostulacion model)
        {
            try
            {
                return Ok(new ResultViewModel<EmpleadosModelPostulacion>(await repository.CreatePostulacion(model)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }

        }
        
    }
}

