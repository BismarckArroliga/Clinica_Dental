using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
   public class CN_Pacientes
    {
        CD_Pacientes objPacientes = new CD_Pacientes();
        public System.Data.DataTable ListarPacientes()
        {
            return objPacientes.ListarPacientes();
        }

        public void InsertarPacientes(string nombre, string telefono, string direccion)
        {
            objPacientes.InsertarPacientes(nombre, telefono, direccion);
        }

        public void ActualizarPacientes(string nombre, string telefono, string direccion, string id)
        {
          objPacientes.ActualizarPacientes(nombre, telefono, direccion,  int.Parse(id));
        }
    }
}

