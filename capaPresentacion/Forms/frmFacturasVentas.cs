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
    public partial class frmFacturasVentas : Form
    {
        public frmFacturasVentas()
        {
            InitializeComponent();
        }

        private void ListarFacturasVentas()
        {
            CN_Ventas objVentas = new CN_Ventas();
            dgvFacturaVentas.DataSource = objVentas.ListarVentas();
        }

        private void frmFacturasVentas_Load(object sender, EventArgs e)
        {
            ListarFacturasVentas();
        }

        private void btnDetalleVentas_Click(object sender, EventArgs e)
        {
            if (dgvFacturaVentas.Rows.Count == 0)
            {
                MessageBox.Show("Primero debes facturar una Venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (var modalDetalleVentas = new md_DetalleVentas())
            {
                modalDetalleVentas._IdVenta = Convert.ToInt32(this.dgvFacturaVentas.CurrentRow.Cells["Id"].Value);
                modalDetalleVentas.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
