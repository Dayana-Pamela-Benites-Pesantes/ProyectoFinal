using Dapper;
using Microsoft.Extensions.Configuration;
using ProyectoFinal.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Queries.Marca
{
    public class MarcaQueries : IMarcaQueries
    {
        private readonly string _connectionString;
        public MarcaQueries(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:SQL"];
        }
        public async Task<IEnumerable<MarcaViewModel>> GetAll()
        {
            IEnumerable<MarcaViewModel> result = new List<MarcaViewModel>();
            using (var connection = new SqlConnection(_connectionString))
            {
                result = await connection.QueryAsync<MarcaViewModel>("[dbo].[Usp_Sel_Marca]", commandType: System.Data.CommandType.StoredProcedure);
            }

            return result;
        }
    }
}
