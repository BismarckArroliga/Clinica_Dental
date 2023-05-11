using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos; 

namespace capaNegocios
{
    public class CN_Citas
    {
        CD_Citas objCitas = new CD_Citas();

        public System.Data.DataTable ListarCitas()
        {
            return objCitas.ListarCitas();
        }

        public void InsertarCitas(string idPaciente, DateTime fecha, string hora)
        {
            objCitas.InsertarCitas(int.Parse(idPaciente), fecha, hora);
        }

        public void ActualizarCitas(string idCita, string idPaciente, DateTime fecha, string hora)
        {
            objCitas.ActualizarCitas(int.Parse(idCita), int.Parse(idPaciente), fecha, hora);
        }
    }
}
