using MiApi.Models;

namespace MiApi.Business
{
    public interface IProductos
    {
        Task<List<ProductosModel>> ListaProductos();
        Task<List<ProductosModel>> ListaProductoID(int id);
        Task<bool> GuardarProductos(ProductosModel productos);
        Task<bool> EditarProductos(ProductosModel productos);
        Task<bool> EliminarProductos(int id);
    }
}
