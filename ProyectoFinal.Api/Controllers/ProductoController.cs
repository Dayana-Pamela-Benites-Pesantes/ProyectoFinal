 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Model;
using ProyectoFinal.Repository;
using ProyectoFinal.Queries.Producto;
using Dapper;

using System.Reflection;

namespace ProyectoFinal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IProductoQueries _productoQueries;
        public ProductoController(IProductoRepository productoRepository, IProductoQueries productoQueries)
        {
            _productoRepository = productoRepository;
            _productoQueries = productoQueries;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            Console.Write("Hola Mundo Sobre Linea" + id);
            var result = await _productoQueries.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]

        public async Task<ActionResult> GetAll()
        {
            var result = await _productoQueries.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Model.Producto producto)
        {
            var result = await _productoRepository.Create(producto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Model.Producto producto)
        {
            var result = await _productoRepository.Update(producto);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var result = await _productoRepository.Delete(id);
            return Ok(result);
        }
    }
}
