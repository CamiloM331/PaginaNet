using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using MueblesApp.Data.Model;


namespace MueblesApp.Data.Service
{
    public class ComentarioService : IComentarioService
    {
        //Connecction Sql Server
        private readonly SqlConnectionConfiguration _configuration;

        public ComentarioService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ComentarioInsert(Comentario comentario)
        {

            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("Calificacion", comentario.Calificacion, DbType.Int32);
                parameters.Add("Id_Factura", comentario.Id_Factura, DbType.Int32);
                parameters.Add("Comentario_Cliente", comentario.Comentario_Cliente, DbType.String);

                const string query = @"INSERT INTO Comentario (Calificacion, Id_Factura, Comentario_Cliente) VALUES (@Calificacion, @Id_Factura, @Comentario_Cliente)";
                await conn.ExecuteAsync(query, new { comentario.Calificacion, comentario.Id_Factura, comentario.Comentario_Cliente }, commandType: CommandType.Text);
            }

            return true;
        }




    }
}
