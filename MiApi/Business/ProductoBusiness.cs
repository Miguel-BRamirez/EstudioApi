using MiApi.Data;
using MiApi.Models;

namespace MiApi.Business
{
    public class Productobusiness : IProductos
    {
        public ProductosData data = new ProductosData();
        
        //Capa de logica

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

    }
}
