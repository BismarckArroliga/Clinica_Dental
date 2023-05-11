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
    public partial class frmFacturasCompras : Form
    {
        public frmFacturasCompras()
        {
            InitializeComponent();
        }

        private void ListarCompras()
        {
            CN_Compras objCompras = new CN_Compras();
            dgvFacturaCompras.DataSource = objCompras.ListarCompras();
        }

        private void frmFacturasCompras_Load(object sender, EventArgs e)
        {
            ListarCompras();
        }

        private void btnDetalleCompras_Click(object sender, EventArgs e)
        {

            if (dgvFacturaCompras.Rows.Count == 0)
            {
                MessageBox.Show("Primero debes facturar una Compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (var modalDetalleCompras = new md_DetalleCompras())
            {
                modalDetalleCompras._idCompra = Convert.ToInt32(this.dgvFacturaCompras.CurrentRow.Cells["Id"].Value);
                modalDetalleCompras.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
