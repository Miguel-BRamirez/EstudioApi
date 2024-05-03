using Dapper;
using MiApi.Connection;
using MiApi.Models;
using System.Data;

namespace MiApi.Data
{
    public class HomeData
    {
        ConnectionBD Conexion = new ConnectionBD();

        //Login que retorna el id
        public async Task<HomeModel> Login(string correo, string password)
        {
            try
            {
                var parameters = new { correo, password };
                HomeModel result = await Conexion.db.QuerySingleOrDefaultAsync<HomeModel>("SELECT * FROM dbo.ufn_Login(@correo, @password)", parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Retorna los detalles del usuario
        public async Task<List<DetallePersona>> ConsultarDetallePersona(int id) 
        {
            try
            {
                List<DetallePersona> lst = (await Conexion.db.QueryAsync<DetallePersona>("sp_detallePersona",new { id = id },commandType:CommandType.StoredProcedure)).ToList();
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
