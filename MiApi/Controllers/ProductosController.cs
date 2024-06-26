﻿using MiApi.Business;
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

        [HttpGet("ListarProductos")]
        public async Task <ActionResult<List<ProductosModel>>> Get()
        {
            //var Consume mucho recurso
            List<ProductosModel> lista = await _productos.ListaProductos();
            return lista;
        }

        [HttpGet("ListarIdProducto")]
        public async Task<ActionResult<List<ProductosModel>>> GetID(int id)
        {
            //var Consume mucho recurso
            List<ProductosModel> lista = await _productos.ListaProductoID(id);
            return lista;
        }

        [HttpPost]
        [Route("InsertarProducto")]
        public async Task<ActionResult<bool>> Add(ProductosModel producto)
        {
            bool succes = await _productos.GuardarProductos(producto);
            return succes;
        }

        [HttpPut]
        [Route("EditarProductos")]
        public async Task<ActionResult<bool>> EditarProductos(ProductosModel producto)
        {
            bool succes = await _productos.EditarProductos(producto);
            return succes;
        }

        [HttpDelete]
        [Route("EliminarProductos")]
        public async Task<ActionResult<bool>> EliminarProductos(int id)
        {
            bool succes = await _productos.EliminarProductos(id);
            return succes;
        }
    }
}
