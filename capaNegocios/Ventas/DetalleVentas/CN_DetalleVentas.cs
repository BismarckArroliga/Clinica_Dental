using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
    public class CN_DetalleVentas
    {
        CD_DetalleVentas objDetalleVentas = new CD_DetalleVentas();

        public System.Data.DataTable ListarDetalleVentas(string idVenta)
        {
            return objDetalleVentas.ListarDetalleVentas(int.Parse(idVenta));
        }
    }
}
