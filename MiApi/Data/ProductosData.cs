using MiApi.Connection;
using MiApi.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace MiApi.Data
{
    public class ProductosData
    {
        ConnectionBD conexion = new ConnectionBD();

        /*
         * Manera como me enseñó Sebastian
         */
        //Mostrar todos los productos
        public async Task<List<ProductosModel>> ListaProductos()
        {
            try
            {
                List<ProductosModel> lst = (await conexion.db.QueryAsync<ProductosModel>("sp_listarProductos", commandType: CommandType.StoredProcedure)).ToList();

                return lst;
            }
            catch (Exception ex)
            {
                //return ex.ToString();
                throw;
            }
        }

        //Listar por ID
        public async Task<List<ProductosModel>> ListaProductoID(int id)
        {
            
            try
            {
                List<ProductosModel> lst = (await conexion.db.QueryAsync<ProductosModel>("sp_listarProductoID", new { id = id }, commandType: CommandType.StoredProcedure)).ToList();
                return lst;
            }
            catch (Exception ex)
            {
                //return ex.ToString();
                throw;
            }
        }

        //Guardar productos
        public async Task<bool> GuardarProductos(ProductosModel productos)
        {
            try
            {
                //Cuando le manda el objeto directamente tiene que ser en el mismo orden que el procedure
                //asi como lo tiene en el procedure y en el modelo esta bien, pero para que lo tenga en cuenta
                //siempre el mismo orden y el mismo tipo de dato den ambos R  corralo haber
                await conexion.db.QueryAsync<ProductosModel>("sp_guardarProductos", productos, commandType: CommandType.StoredProcedure);
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        //Editar productos
        public async Task<bool> EditarProductos(ProductosModel productos)
        {
            try
            {

                await conexion.db.QueryAsync<ProductosModel>("sp_editarProductos", productos, commandType: CommandType.StoredProcedure);
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        //Eliminar productos
        public async Task<bool> EliminarProductos(int id)
        {
            try
            {
                await conexion.db.QueryAsync<ProductosModel>("sp_eliminarProductos", new { id = id }, commandType: CommandType.StoredProcedure);
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        /*
         * Manera de hacerlo como el video
         */

        //public async Task <List<ProductosModel>> mostrarProductos() 
        //{ 
        //    var lista = new List<ProductosModel>();
        //    using (var sql = new SqlConnection(cn.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("sp_listarProductos", sql))
        //        {
        //            await sql.OpenAsync();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            using (var reader = await cmd.ExecuteReaderAsync())
        //            {
        //                while(await reader.ReadAsync())
        //                {
        //                    var ProductosModel = new ProductosModel();
        //                    ProductosModel.id = reader.GetInt32("id");
        //                    ProductosModel.descripcion = reader.GetString("description");
        //                    ProductosModel.precio = reader.GetDecimal("precio");
        //                    lista.Add(ProductosModel);
        //                }
        //            }
        //        }
        //    }
        //    return lista;
        //}
    }
}
