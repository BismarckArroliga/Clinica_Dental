using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaNegocios;

namespace capaPresentacion
{
    public partial class md_Productos : Form
    {
        public Productos _productos { get; set; }

        public md_Productos()
        {
            InitializeComponent();
        }

        private void listarProductos()
        {
            CN_Productos objPrductos = new CN_Productos();
            dgvProductos.DataSource = objPrductos.ListarProductos();
        }

        private void md_Productos_Load(object sender, EventArgs e)
        {
            listarProductos();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row >= 0)
            {
                _productos = new Productos()
                {
                    Codigo = dgvProductos.Rows[row].Cells["Codigo"].Value.ToString(),
                    Producto = dgvProductos.Rows[row].Cells["Nombre"].Value.ToString(),
                    PrecioVenta = dgvProductos.Rows[row].Cells["PrecioVenta"].Value.ToString(),
                    Existencias = dgvProductos.Rows[row].Cells["Existencias"].Value.ToString(),
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}














