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
    }
}
