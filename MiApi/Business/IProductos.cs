using MiApi.Models;

namespace MiApi.Business
{
    public interface IProductos
    {
        Task<List<ProductosModel>> ListaProductos();

        Task<bool> GuardarProductos(ProductosModel productos);
    }
}
