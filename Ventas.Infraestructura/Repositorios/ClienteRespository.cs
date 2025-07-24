using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using Ventas.Infraestructura.Entidades;

namespace Ventas.Infraestructura.Repositorios
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<bool> AddAsync(Cliente cliente)
        {
            var sql = "EXEC registrar_cliente @identificacion, @nombre, @telefono, @direccion";
            using (var connection = CreateConnection())
            {
                var rowsAffected = await connection.ExecuteAsync(sql, new
                {
                    identificacion = cliente.cli_identificacion,
                    nombre = cliente.cli_nombre,
                    telefono = cliente.cli_telefono,
                    direccion = cliente.cli_direccion
                });
                return rowsAffected > 0;
            }
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            var sql = "EXEC consultar_cliente";
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<Cliente>(sql);
            }
        }

        public async Task<Cliente> GetByIdentificacionAsync(string identificacion)
        {
            var sql = "SELECT cli_identificacion, cli_nombre, cli_telefono, cli_direccion FROM Cliente WHERE cli_identificacion = @identificacion";
            using (var connection = CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Cliente>(sql, new { identificacion });
            }
        }
    }
}
