using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
   public class CN_Especialidades
    {
        CD_Especialidades objEspecialidades = new CD_Especialidades();

        public System.Data.DataTable ListarEspecialidades()
        {
            return objEspecialidades.ListarEspecialidades();
        }

        public void InsertarEspecialidad(string nombre)
        {
            objEspecialidades.InsertarEspecialidades(nombre);
        }

        public void ActualizarEspecialidades(string id, string nombre)
        {
            objEspecialidades.ActualizarEspecialidades(int.Parse(id), nombre);
        }
    }
}
