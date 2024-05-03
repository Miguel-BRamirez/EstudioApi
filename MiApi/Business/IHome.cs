using MiApi.Models;

namespace MiApi.Business
{
    public interface IHome
    {
        Task<HomeModel> Login(string correo, string password);
    }
}
