using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using System.Data;
namespace capaNegocios
{
   public class CN_Ventas
    {
        CD_Ventas objVentas = new CD_Ventas();

        public System.Data.DataTable ListarTipoDocumentos()
        {
            return objVentas.ListarTipoDocumentos();
        }

        public void InsertarVenta(string tipoDocumento, string idUsuario, string idPaciente, string subTotal, string total, DataTable detalleVenta)
        {
            objVentas.InsertarVenta(int.Parse(tipoDocumento), int.Parse(idUsuario), int.Parse(idPaciente), decimal.Parse(subTotal), decimal.Parse(total), detalleVenta);
        }

        public System.Data.DataTable ListarVentas()
        {
            return objVentas.ListarVentas();
        }

        public System.Data.DataTable reportesVentas(string fechaInicio, string fechaFin)
        {
            return objVentas.reportesVentas( fechaInicio, fechaFin);
        }
    }
}
