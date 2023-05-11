using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
   public class CN_DetalleFactura
    {
        CD_DetalleFactura objDetalleFactura = new CD_DetalleFactura();

        public System.Data.DataTable ListarDetalleFactura(string idFactura)
        {
            return objDetalleFactura.ListarDetalleFactura(Convert.ToInt32(idFactura));
        }

        public System.Data.DataTable Search(string fechaInicio, string fechaFin)
        {
            return objDetalleFactura.Search(fechaInicio, fechaFin);
        }

    }
}
