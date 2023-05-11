using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
   public class CN_Proveedores
    {
        CD_Proveedores objProveedores = new CD_Proveedores();

        public System.Data.DataTable ListarProveedores()
        {
            return objProveedores.ListarProveedores();
        }

        public void InsertarProveedores(string nombre, string telefono, string direccion)
        {
            objProveedores.InsertarProveedores(nombre, telefono, direccion);
        }

        public void ActualizarProveedores(string nombre, string telefono, string direccion, string id)
        {
            objProveedores.ActualizarProveedores(nombre, telefono, direccion, int.Parse(id));
        }
    }
}
