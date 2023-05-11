using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
   public class CN_Personal
    {

        CD_Personal objPersonal = new CD_Personal();

        public System.Data.DataTable ListarMedicos()
        {
            return objPersonal.ListarMedicos();
        }

        public System.Data.DataTable Especialidades()
        {
            return objPersonal.Especialidades();
        }

        public void InsertarMedicos(string nombre, string telefono, string direccion, string cedula, string especialidad)
        {
            objPersonal.InsertarMedicos(nombre, telefono, direccion, cedula, int.Parse(especialidad));
        }

        public void ActualizarMedicos(string nombre, string telefono, string direccion, string cedula, string especialidad, string id)
        {
            objPersonal.ActualizarMedicos(nombre, telefono, direccion, cedula, int.Parse(especialidad), int.Parse(id));
        }
    }
}
