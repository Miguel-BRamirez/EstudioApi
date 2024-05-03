using MiApi.Data;
using MiApi.Models;

namespace MiApi.Business
{
    public class PersonaBusiness : IPersona
    {
        public PersonaData data = new PersonaData();

        //Guardar productos
        public async Task<bool> InsertarPersona(PersonaModel persona)
        {
            try
            {
                bool success = await data.InsertarPersona(persona);
                return success;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
