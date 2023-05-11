using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace capaDatos
{
   public class CD_Factura: CD_Connection
    {

        public DataTable ListarFacturas()
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_factura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "L");
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable table = new DataTable();
                    table.Load(reader);
                    return table;
                }
            }
        }

        public void InsertarFacturas(int paciente, int usuario, int personal, decimal descuento,  decimal subTotal, decimal total, DataTable detalleFactura)
        {
            using (var sql = GetConnection())
            {
                sql.Open();
                using (var cmd = new SqlCommand("sp_factura", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@op", "I");
                    cmd.Parameters.AddWithValue("@paciente", paciente);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@personal", personal);
                    cmd.Parameters.AddWithValue("@descuento", descuento);
                    cmd.Parameters.AddWithValue("@subTotal", subTotal);
                    cmd.Parameters.AddWithValue("@total", total);
                    cmd.Parameters.AddWithValue("@detalleFactura", detalleFactura);
                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
