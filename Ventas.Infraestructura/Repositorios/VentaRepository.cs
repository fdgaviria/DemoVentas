using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient; 
using Ventas.Infraestructura.Entidades;

namespace Ventas.Infraestructura.Repositorios
{
    public class VentaRepository : IVentaRepository
    {
        private readonly string _connectionString;

        public VentaRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<Venta> GetByCodigoAsync(string codigo)
        {
            var sql = "EXEC consultar_venta_codigo @codigo";
            using (var connection = CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<Venta>(sql, new { codigo });
            }
        }

        public async Task<IEnumerable<Venta>> GetAllAsync()
        {
            var sql = "EXEC consultar_ventas";
            using (var connection = CreateConnection())
            {
                return await connection.QueryAsync<Venta>(sql);
            }
        }

        public async Task<bool> AddAsync(Venta venta)
        {
            var sql = "EXEC registrar_venta @ven_codigo, @ven_fecha, @ven_cli_identificacion, @ven_punven_nit, @ven_producto, @ven_total";
            using (var connection = CreateConnection())
            {
                var rowsAffected = await connection.ExecuteAsync(sql, venta);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> UpdateAsync(Venta venta)
        {
            var sql = "EXEC actualizar_venta @ven_codigo, @ven_fecha, @ven_cli_identificacion, @ven_punven_nit, @ven_producto, @ven_total";
            using (var connection = CreateConnection())
            {
                var rowsAffected = await connection.ExecuteAsync(sql, venta);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteAsync(string codigo)
        {
            var sql = "EXEC eliminar_venta @ven_codigo";
            using (var connection = CreateConnection())
            {
                var rowsAffected = await connection.ExecuteAsync(sql, new { ven_codigo = codigo });
                return rowsAffected > 0;
            }
        }
    }
}
