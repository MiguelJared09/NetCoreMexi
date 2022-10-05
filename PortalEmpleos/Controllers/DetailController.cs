using Bussines.Administracion;
using Objects.Administracion;
using Objects.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussines.Auth;
using Objects.Accounts;
using Db.Models;

namespace PortalEmpleos.Controllers
{
    /// <summary>
    /// Servicio para registro detalle y modificaciones
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DetailController : Controller
    {
        public DetailController(DetailReository repository)
        {
            this.repository = repository;
        }
        public readonly DetailReository repository;
        //<summary>
        // Obtener el detalle del empleado
        //</summary>
        //<returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetalleRegistro(int id)
        {
            try
            {
                return Ok(new ResultViewModel<IEnumerable<Detail>>(await repository.GetDetalleRegistro(id)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }

        [HttpPost("crear")]
        public async Task<IActionResult> CreateDetail([FromBody] DetailModel model)
        {
            try
            {
                return Ok(new ResultViewModel<DetailModel>(await repository.Create(model)));
            }
            catch (Exception e)
            {
                return Ok(new ResultViewModel(e));
            }
        }
        [HttpPost("actualizar")]
        public async Task<IActionResult> UpdateDetail([FromBody] DetailModel model)
        {
            try
            {
                return Ok(new ResultViewModel<DetailModel>(await repository.UpdateDetail(model)));
            }
            catch(Exception e)
            {
                return Ok(new ResultViewModel(e));
            }

        }
       
    }
}
