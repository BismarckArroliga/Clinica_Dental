using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;

namespace capaNegocios
{
    public class CN_Productos
    {
        CD_Productos objProductos = new CD_Productos();

        public System.Data.DataTable ListarProductos()
        {
            return objProductos.ListarProductos();
        }

        public System.Data.DataTable ListaCategorias()
        {
            return objProductos.ListarCategorias();
        }

        public void InsertarProductos(string codigo, string nombre, string categoria,string descripcion)
        {
            objProductos.InsertarProductos(codigo, nombre,int.Parse(categoria), descripcion);
        }

        public void ActualizarProductos(string codigo, string nombre, string categoria, string descripcion)
        {
            objProductos.ActualizarProductos(codigo, nombre, int.Parse(categoria), descripcion);
        }

        public void RestarExistencias(string existencias, string codigo)
        {
            objProductos.RestarStock(int.Parse(existencias), codigo);
        }

        public void SumarExistencias(string existencias, string codigo)
        {
            objProductos.SumarStock(int.Parse(existencias), codigo);
        }
    }
}
