using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using Ventas.Infraestructura.Entidades;

namespace Ventas.Infraestructura.Repositorios
{
    public class PuntoDeVentaRepository : IPuntoDeVentaRepository
    {
        private readonly string _connectionString;

        public PuntoDeVentaRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<IEnumerable<PuntoDeVenta>> GetAllAsync()
        {
            var sql = "SELECT punven_nit, punven_nombre FROM PuntoDeVenta";
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<PuntoDeVenta>(sql);
            }
        }
    }
}