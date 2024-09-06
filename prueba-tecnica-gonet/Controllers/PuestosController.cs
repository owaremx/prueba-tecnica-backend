using data_access.model;
using data_access.repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace prueba_tecnica_gonet.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PuestosController : ControllerBase
    {
        private IPuestosRepository puestosRepository;
        public PuestosController(IPuestosRepository puestosRepository)
        {
            this.puestosRepository = puestosRepository;
        }

        [HttpGet]
        public IEnumerable<Puestos> Lista()
        {
            return puestosRepository.Lista();
        }
    }
}
