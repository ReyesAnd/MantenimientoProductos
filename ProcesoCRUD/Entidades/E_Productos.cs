using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesoCRUD.Entidades
{
    public class E_Productos
    {
        public int Codigo_Producto { get; set; }
        public string Descripcion_Producto { get; set; }
        public string Marca_Producto { get; set; }
        public int Codigo_Medida { get; set; }
        public int Codigo_Categoria { get; set; }
        public decimal Stock_Actual { get; set; }
    }
}
