using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MueblesApp.Data.Model
{
    public class Producto
    {
        public int Id_Producto { get; set; }
        public int Precio_Producto { get; set; }
        public string Disponibilidad_Producto { get; set; }
        public string Proovedor_Producto { get; set; }
        public string Cantidad_Producto { get; set; }
        public string Nombre_Producto { get; set; }
        public string Garantia_Producto { get; set; }
        public string Descuento_Producto { get; set; }
    }
}
