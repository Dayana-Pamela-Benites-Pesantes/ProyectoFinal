using System;
using ProyectoFinal.Model;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Repository
{
    public interface IProductoRepository
    {
        Task<int> Create (Producto producto);

        Task<int> Update(Producto producto);

       Task<int> Delete(int id);
    }
}
