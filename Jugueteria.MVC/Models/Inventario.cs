using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jugueteria.MVC.Models
{
    public class Inventario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> RestriccionEdad { get; set; }
        public string Compania { get; set; }
        public Nullable<decimal> Precio { get; set; }
    }
}
