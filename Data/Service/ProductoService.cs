using Dapper;
using Microsoft.Data.SqlClient;
using MueblesApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MueblesApp.Data.Service
{
    public class ProductoService : IProductoService
    {
        //Connecction Sql Server
        private readonly SqlConnectionConfiguration _configuration;

        public ProductoService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ProductoInsert(Producto producto)
        {

            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Id_Producto", producto.Id_Producto, DbType.Int32);
                parameters.Add("Precio_Producto", producto.Precio_Producto, DbType.Double);
                parameters.Add("Disponibilidad_Producto", producto.Disponibilidad_Producto, DbType.String);
                parameters.Add("Proovedor_Producto", producto.Proovedor_Producto, DbType.String);
                parameters.Add("Cantidad_Producto", producto.Cantidad_Producto, DbType.Int32);
                parameters.Add("Nombre_Producto", producto.Nombre_Producto, DbType.String);
                parameters.Add("Garantia_Producto", producto.Garantia_Producto, DbType.String);
                parameters.Add("Descuento_Producto", producto.Descuento_Producto, DbType.String);


                const string query = @"INSERT INTO Producto (Id_Producto, Precio_Producto, Disponibilidad_Producto, Proovedor_Producto, Cantidad_Producto, Nombre_Producto, Garantia_Producto, Descuento_Producto) VALUES (@Id_Producto, @Precio_Producto, @Disponibilidad_Producto, @Proovedor_Producto, @Cantidad_Producto, @Nombre_Producto, @Garantia_Producto, @Descuento_Producto)";
                await conn.ExecuteAsync(query, new { producto.Id_Producto, producto.Precio_Producto, producto.Disponibilidad_Producto, producto.Proovedor_Producto, producto.Cantidad_Producto, producto.Nombre_Producto, producto.Garantia_Producto, producto.Descuento_Producto }, commandType: CommandType.Text);
            }

            return true;
        }
    }
}
