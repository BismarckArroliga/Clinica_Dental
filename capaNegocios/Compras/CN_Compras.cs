using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using System.Data;

namespace capaNegocios
{
    public class CN_Compras
    {
        CD_Compras objCompras = new CD_Compras();

        public DataTable ListarCompras()
        {
            return objCompras.ListarCompras();
        }

        public void RealizarCompra(string documento, string usuario, string proveedor, string subTotal, string total, DataTable detalleCompra)
        {
            objCompras.RealizarCompra(int.Parse(documento), int.Parse(usuario), int.Parse(proveedor), decimal.Parse(subTotal), decimal.Parse(total), detalleCompra);
        }

        public DataTable reportesCompras(string fechaInicio, string fechaFin)
        {
            return objCompras.reportesCompras(fechaInicio, fechaFin);
        }

    }
}
