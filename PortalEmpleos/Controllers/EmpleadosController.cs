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
        
        //<summary>
        // publicar servicios
        //</summary>
        //<returns></returns>
        [HttpPost("Crear")]
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
        //<summary>
        // Obtener el listado de postulaciones del usuario
        //</summary>
        //<returns></returns>
        [HttpGet("Postulacion/{id}")]
        public async Task<IActionResult> GetPostulacionesUser(int id)
        {
            try
            {
                return Ok(new ResultViewModel<IEnumerable<EmpleadorsViewResult>>(await repository.GetPostulaciones(id)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
    }
}

