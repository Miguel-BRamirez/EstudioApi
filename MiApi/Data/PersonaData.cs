using Dapper;
using MiApi.Connection;
using MiApi.Models;
using System.Data;

namespace MiApi.Data
{
    public class PersonaData
    {
        ConnectionBD conexion = new ConnectionBD();

        //Insertar nueva persona
        public async Task<bool> InsertarPersona(PersonaModel persona)
        {
            try
            {
                await conexion.db.QueryAsync<PersonaModel>("sp_InsertarPersona", persona, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        //Consultar personas
        public async Task<List<DetallePersona>> ListarPersonas()
        {
            try
            {
                List<DetallePersona> rspt = (await conexion.db.QueryAsync<DetallePersona>("sp_listarPersonas", commandType: CommandType.StoredProcedure)).ToList();
                return rspt;

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
                List<DetallePersona> lst = (await conexion.db.QueryAsync<DetallePersona>("sp_editarPersona", persona, commandType: CommandType.StoredProcedure)).ToList();
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
                await conexion.db.QueryAsync<PersonaModel>("sp_eliminarPersona", new {id = id}, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
    }
}
