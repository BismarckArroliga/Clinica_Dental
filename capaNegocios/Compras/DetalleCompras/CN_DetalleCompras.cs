using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
    public class CN_DetalleCompras
    {
        CD_DetalleCompras objCompras = new CD_DetalleCompras();

        public System.Data.DataTable ListarDetalleCompra( string idCompra)
        {
            return objCompras.ListarDetalleVentas(int.Parse(idCompra));
        }
    }
}
