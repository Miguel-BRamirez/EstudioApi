using MiApi.Data;
using MiApi.Models;
using System.Threading.Tasks;

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

        //Listar todas las personas
        public async Task<List<DetallePersona>> ListarPersonas()
        {
            try
            {
                List<DetallePersona> lst = await data.ListarPersonas();
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Editar persona
        public async Task<List<DetallePersona>> EditarPersona(DetallePersona persona)
        {
            try
            {
                List<DetallePersona> lst = await data.EditarPersona(persona);
                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Eliminar persona
        public async Task<bool> EliminarPersona(int id)
        {
            try
            {
                bool success = await data.EliminarPersona(id);
                return success;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
