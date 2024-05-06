using MiApi.Models;

namespace MiApi.Business
{
    public interface IHome
    {
        Task<List<DetallePersona>> Login(string correo, string password);
    }
}
