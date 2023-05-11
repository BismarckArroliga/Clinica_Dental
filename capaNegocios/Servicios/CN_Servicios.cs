using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
    public class CN_Servicios
    {
        CD_Servicios objServicios = new CD_Servicios();

        public System.Data.DataTable ListarServicios()
        {
            return objServicios.ListarServicios();
        }

        public void InsertarServicios(string nombre, string costo)
        {
            objServicios.InsertarServicios(nombre, decimal.Parse(costo));
        }

        public void ActualizarServicios(string nombre, string costo, string id)
        {
            objServicios.ActualizarServicios(nombre, decimal.Parse(costo), int.Parse(id));
        }
    }
}
