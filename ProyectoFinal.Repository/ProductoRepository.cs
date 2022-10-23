using Microsoft.Extensions.Configuration;
using ProyectoFinal.Model;
using System;
using System.Collections.Generic;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly string _connectionString;

        public ProductoRepository(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }

        public async Task<int> Create(Producto producto)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Nombre", producto.Nombre);
            parameters.Add("@Stock", producto.Stock);
            parameters.Add("@Precio", producto.Precio);
            parameters.Add("@idCategoria", producto.idCategoria);
            parameters.Add("@idMarca", producto.idMarca);
            parameters.Add("@FechaVencimiento", producto.FechaVencimiento);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Usp_Ins_Producto]", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<int> Delete(int id)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Usp_Del_Producto]", parameters, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public async Task<int> Update(Producto producto)
        {
            int result;
            var parameters = new DynamicParameters();
            parameters.Add("@Id", producto.Id);
            parameters.Add("@Nombre", producto.Nombre);
            parameters.Add("@Stock", producto.Stock);
            parameters.Add("@Precio", producto.Precio);
            parameters.Add("@idCategoria", producto.idCategoria);
            parameters.Add("@idMarca", producto.idMarca);
            parameters.Add("@FechaVencimiento", producto.FechaVencimiento);

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.ExecuteAsync("[dbo].[Usp_Upd_Producto]", parameters, commandType: CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
