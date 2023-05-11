using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using capaComun;

namespace capaDatos
{
    public class CD_Usuarios : CD_Connection
    {

        //------------------------------------------MÉTODO LOGIN
        public bool Login(string usuario, string contrasena)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_usuarios", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "L");
                    cmd.Parameters.AddWithValue("@nombre", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            UserCache.Id = reader.GetInt32(0);
                            UserCache.Nombre = reader.GetString(1);
                            UserCache.Cargo = reader.GetString(3);
                            UserCache.Correo = reader.GetString(2);

                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }


        //------------------------------------------MÉTODO LISTAR USUARIOS
        public DataTable List()
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_usuarios", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("op", "R");
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }


        //------------------------------------------MÉTODO LISTAR CARGOS
        public DataTable Cargos()
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_usuarios", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("op", "C");
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }


        //------------------------------------------MÉTODO INSERTAR
        public void InsertarUsuarios(string nombre, string correo, string telefono, string contrasena, int cargo)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_usuarios", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "I");
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);
                    cmd.Parameters.AddWithValue("@cargo", cargo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //------------------------------------------MÉTODO ACTUALIZAR
        public void ActualizarUsuarios(string nombre, string correo, string telefono, string contrasena, int cargo, int id)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_usuarios", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "U");
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);
                    cmd.Parameters.AddWithValue("@cargo", cargo);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}









