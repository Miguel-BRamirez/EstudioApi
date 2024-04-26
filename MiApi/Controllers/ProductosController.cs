using MiApi.Business;
using MiApi.Data;
using MiApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MiApi.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController
    {

        private readonly IProductos _productos; //Interfaz

        //Constructor para heredar la interfaz

        public ProductosController(IProductos productos)
        {
            _productos = productos;
        }

        [HttpGet]
        public async Task <ActionResult<List<ProductosModel>>> Get()
        {
            //var Consume mucho recurso
            List<ProductosModel> lista = await _productos.ListaProductos();
            return lista;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Add(ProductosModel producto)
        {
            bool succes = await _productos.GuardarProductos(producto);
            return succes;
        }
    }
}
