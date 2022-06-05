using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MueblesApp.Data.Model
{
    public class Cliente
    {
        public string Nombre_Cliente{ get; set; }
        public string Apellido_Cliente { get; set; }
        public string Tipo_Documento { get; set; }
        public int Cedula_Cliente { get; set; }
        public int Telefono_Cliente { get; set; }
        public string Correo_Cliente { get; set; }
        public string Direccion_Cliente { get; set; }
    }
}
