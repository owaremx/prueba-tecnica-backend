using data_access.model;
using data_access.repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Authorization;

namespace prueba_tecnica_gonet.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IHostEnvironment _hostingEnvironment;
        private readonly IEmpleadosRepository repository;
        public EmpleadosController(
            IEmpleadosRepository empleadosRepository,
            IHostEnvironment hostingEnvironment)
        {
            this.repository = empleadosRepository;
            this._hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public Empleados Detalles(int id)
        {
            return this.repository.Detalles(id);
        }

        [HttpGet]
        public IEnumerable<Empleados> Buscar([FromQuery]Empleados parametros)
        {
            IEnumerable<Empleados> empleados = this.repository.Buscar(parametros);

            return empleados;
        }

        [HttpPost]
        public IActionResult Guardar(Empleados empleado)
        {
            try
            {
                this.repository.Guardar(empleado);

                return Ok(empleado);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Actualizar(Empleados empleado)
        {
            try
            {
                this.repository.Actualizar(empleado);
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Eliminar([FromQuery]Empleados e)
        {
            try
            {
                this.repository.Eliminar(e.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
