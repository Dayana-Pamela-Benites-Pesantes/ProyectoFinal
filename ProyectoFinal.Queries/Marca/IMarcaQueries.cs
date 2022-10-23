using ProyectoFinal.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Queries.Marca
{
    public interface IMarcaQueries
    {
        Task<IEnumerable<MarcaViewModel>> GetAll();
    }
}
