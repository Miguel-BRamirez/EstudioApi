using MiApi.Models.Custom;

namespace MiApi.Business
{
    public interface IAutorizacion
    {
        Task<AutorizacionResponse> DevolverToken(AutorizacionRequest autorizacion);
    }
}
