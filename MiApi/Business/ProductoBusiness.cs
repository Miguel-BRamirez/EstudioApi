using MiApi.Data;
using MiApi.Models;

namespace MiApi.Business
{
    public class Productobusiness : IProductos
    {
        public ProductosData data = new ProductosData();
        
        //Capa de logica

        //Listar todos los productos
        public async Task<List<ProductosModel>> ListaProductos()
        {
            try
            {
                List<ProductosModel> result = await data.ListaProductos();
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Listar un producto por id
        public async Task<List<ProductosModel>> ListaProductoID(int id)
        {
            try
            {
                List<ProductosModel> result = await data.ListaProductoID(id);
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //Guardar productos
        public async Task<bool> GuardarProductos(ProductosModel producto)
        {
            try
            {
                // Llama directamente al método de datos para agregar el producto
                bool success = await data.GuardarProductos(producto);
                return success;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Editar productos
        public async Task<bool> EditarProductos(ProductosModel producto)
        {
            try
            {
                // Llama directamente al método de datos para agregar el producto
                bool success = await data.EditarProductos(producto);
                return success;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Eliminar productos por el ID
        public async Task<bool> EliminarProductos(int id)
        {
            try
            {
                // Llama directamente al método de datos para agregar el producto
                bool success = await data.EliminarProductos(id);
                return success;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
