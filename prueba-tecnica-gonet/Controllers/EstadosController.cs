using data_access.model;
using data_access.repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace prueba_tecnica_gonet.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private IEstadosRepository estadosRepository;
        public EstadosController(IEstadosRepository estadosRepository)
        {
            this.estadosRepository = estadosRepository;
        }

        [HttpGet]
        public IEnumerable<Estados> Lista()
        {
            return estadosRepository.Lista();
        }
    }
}
