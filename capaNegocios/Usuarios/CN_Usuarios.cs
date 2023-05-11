using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
    public class CN_Usuarios
    {
        CD_Usuarios objUsuarios = new CD_Usuarios();

        public bool Login(string usuario, string contrasena)
        {
            return objUsuarios.Login(usuario, contrasena);
        }

        public System.Data.DataTable ListarUsuarios()
        {
            return objUsuarios.List();
        }

        public System.Data.DataTable Cargos()
        {
            return objUsuarios.Cargos();
        }

        public void InsertarUsuarios(string nombre, string correo, string telefono, string contrasena, string cargo)
        {
            objUsuarios.InsertarUsuarios(nombre, correo, telefono, contrasena, int.Parse(cargo));
        }

        public void ActualizarUsuarios(string nombre, string correo, string telefono, string contrasena, string cargo, string id)
        {
            objUsuarios.ActualizarUsuarios(nombre, correo, telefono, contrasena, int.Parse(cargo), int.Parse(id));
        }
    }
}
