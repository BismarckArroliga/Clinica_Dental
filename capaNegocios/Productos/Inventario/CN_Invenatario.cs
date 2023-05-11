using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
   public class CN_Invenatario
    {
        CD_Inventario objInventario = new CD_Inventario();

        public System.Data.DataTable listarInventarioProductos()
        {
            return objInventario.listarInventarioProductos();
        }
    }
}
