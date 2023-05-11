using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using System.Data;

namespace capaNegocios
{
   public class CN_Factura
    {

        CD_Factura objFactura = new CD_Factura();

        public DataTable ListarFacturas()
        {
            return objFactura.ListarFacturas();
        }

        public void InsertarFacturas(string paciente, string usuario, string personal, string descuento, string subTotal, string total, DataTable detalleFactura)
        {
            objFactura.InsertarFacturas(int.Parse(paciente), int.Parse(usuario), int.Parse(personal), decimal.Parse(descuento), decimal.Parse(subTotal), decimal.Parse(total), detalleFactura);
        }
    }
}
