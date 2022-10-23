using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Queries.Categoria;

namespace ProyectoFinal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaQueries _categoriaQueries;

        public CategoriaController(ICategoriaQueries categoriaQueries)
        {
            _categoriaQueries = categoriaQueries ?? throw new ArgumentNullException(nameof(categoriaQueries));
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _categoriaQueries.GetAll();
            return Ok(result);
        }
    }
}
