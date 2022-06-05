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
    public class ClienteService : IClienteService
    {
        //Connecction Sql Server
        private readonly SqlConnectionConfiguration _configuration;

        public ClienteService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ClienteInsert(Cliente cliente)
        {

            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Nombre_Cliente", cliente.Nombre_Cliente, DbType.String);
                parameters.Add("Apellido_Cliente", cliente.Apellido_Cliente, DbType.String);
                parameters.Add("Tipo_Documento", cliente.Tipo_Documento, DbType.String);
                parameters.Add("Cedula_Cliente", cliente.Cedula_Cliente, DbType.Int32);
                parameters.Add("Telefono_Cliente", cliente.Telefono_Cliente, DbType.Int32);
                parameters.Add("Correo_Cliente", cliente.Correo_Cliente, DbType.String);
                parameters.Add("Direccion_Cliente", cliente.Direccion_Cliente, DbType.String);

                const string query = @"INSERT INTO Cliente (Nombre_Cliente, Apellido_Cliente, Tipo_Documento,Cedula_Cliente,Telefono_Cliente,Correo_Cliente,Direccion_Cliente) VALUES (@Nombre_Cliente,@Apellido_Cliente, @Tipo_Documento,@Cedula_Cliente,@Telefono_Cliente,@Correo_Cliente,@Direccion_Cliente)";
                await conn.ExecuteAsync(query, new { cliente.Nombre_Cliente, cliente.Apellido_Cliente, cliente.Tipo_Documento, cliente.Cedula_Cliente, cliente.Telefono_Cliente, cliente.Correo_Cliente, cliente.Direccion_Cliente }, commandType: CommandType.Text);
            }

            return true;
        }
    }
}
