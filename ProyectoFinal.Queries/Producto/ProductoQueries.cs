using Microsoft.Extensions.Configuration;
using ProyectoFinal.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ProyectoFinal.Queries.Producto
{
    public class ProductoQueries : IProductoQueries
    {
        private readonly string _connectionString;

        public ProductoQueries(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }
        public async Task<IEnumerable<ProductoViewModel>> GetAll()
        {
            IEnumerable<ProductoViewModel> result = new List<ProductoViewModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<ProductoViewModel>("[dbo].[Usp_Sel_Producto_All]", commandType: CommandType.StoredProcedure);
            }

            return result;
        }

        public async Task<ProductoByIdViewModel> GetById(int id)
        {
            var productoByIdViewModel = new ProductoByIdViewModel();

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (var connection = new SqlConnection(_connectionString))
            {
                productoByIdViewModel = await connection.QueryFirstOrDefaultAsync<ProductoByIdViewModel>("[dbo].[Usp_Sel_Producto_ById]", parameters, commandType: CommandType.StoredProcedure);
            }

            return productoByIdViewModel;
        }
    }
    
}
