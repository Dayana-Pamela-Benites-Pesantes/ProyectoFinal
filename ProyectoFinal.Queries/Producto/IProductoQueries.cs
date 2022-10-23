using ProyectoFinal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Queries.Producto
{
    public interface IProductoQueries
    {
        Task<ProductoByIdViewModel> GetById(int id);
        Task<IEnumerable<ProductoViewModel>> GetAll();
    }
}
