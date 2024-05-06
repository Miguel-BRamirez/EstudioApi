using MiApi.Models;

namespace MiApi.Business
{
    public interface IPersona
    {
        Task<bool> InsertarPersona(PersonaModel persona);
        Task<List<DetallePersona>> ListarPersonas();
        Task<List<DetallePersona>> EditarPersona(DetallePersona persona);
        Task<bool> EliminarPersona(int id);

    }
}
