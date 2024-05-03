using MiApi.Models;

namespace MiApi.Business
{
    public interface IPersona
    {
        Task<bool> InsertarPersona(PersonaModel persona);

    }
}
