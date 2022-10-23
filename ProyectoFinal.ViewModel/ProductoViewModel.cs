using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.ViewModel
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
        
        public string Marca { get; set; }
       
        public  DateTime FechaVencimiento { get; set; }
    }
    public class ProductoByIdViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
        public int idCategoria { get; set; }
        public string Marca { get; set; }
        public int idMarca { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
