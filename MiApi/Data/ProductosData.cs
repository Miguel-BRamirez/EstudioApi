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

        public async Task<List<ProductosModel>> ListaProductoID(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            try
            {
                List<ProductosModel> lst = (await conexion.db.QueryAsync<ProductosModel>("sp_listarProductoID", parameters, commandType: CommandType.StoredProcedure)).ToList();

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
                var parameters = new DynamicParameters();
                parameters.Add("@descripcion", productos.descripcion);
                parameters.Add("@precio", productos.precio);

                await conexion.db.QueryAsync<ProductosModel>("sp_guardarProductos", parameters, commandType: CommandType.StoredProcedure);
                return true;

            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> EditarProductos(ProductosModel productos)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", productos.id);
                parameters.Add("@descripcion", productos.descripcion);
                parameters.Add("@precio", productos.precio);

                await conexion.db.QueryAsync<ProductosModel>("sp_editarProductos", parameters, commandType: CommandType.StoredProcedure);
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
