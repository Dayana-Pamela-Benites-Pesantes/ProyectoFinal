using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Queries.Marca;

namespace ProyectoFinal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaQueries _marcaQueries;

        public MarcaController(IMarcaQueries marcaQueries)
        {
            _marcaQueries = marcaQueries ?? throw new ArgumentNullException(nameof(marcaQueries));
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _marcaQueries.GetAll();
            return Ok(result);
        }
    }
}
