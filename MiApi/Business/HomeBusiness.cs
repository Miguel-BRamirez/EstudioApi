using MiApi.Data;
using MiApi.Models;
using Microsoft.VisualBasic;

namespace MiApi.Business
{
    public class HomeBusiness : IHome
    {
        public HomeData data = new HomeData();

        public async Task<HomeModel> Login(string correo, string password)
        {
            try
            {
                //Que esta funcion retorne el id de la persona y el idEstado de la persona
                HomeModel result = await data.Login(correo, password);


                if (result != null)
                {
                    if (result.esActivo == false)
                    {
                        //aqui le retorna el mensaje de cajero inactivo, no puede iniciar sesion
                        throw new Exception("El usuario está inactivo y no puede iniciar sesión.");
                    }
                    else
                    {
                        //Modelo
                        List<DetallePersona> info = await data.ConsultarDetallePersona(result.idPersona);
                        
                     }
                    //Aqui va agregando la logica, esa es la logica que tiene que tener en esta capa
                }
                else
                {
                    //Mensaje de que no existe persona en el sistema
                     throw new Exception("No se encontró la persona en el sistema.");
                }
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
