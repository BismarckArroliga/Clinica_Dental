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
    public partial class frmFacturas : Form
    {
        public frmFacturas()
        {
            InitializeComponent();
        }

        private void  listarFacturas()
        {
            CN_Factura objFacturas = new CN_Factura();
            dgvFactura.DataSource = objFacturas.ListarFacturas();
        }

        private void frmFacturas_Load(object sender, EventArgs e)
        {
            listarFacturas();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetalleFactura_Click(object sender, EventArgs e)
        {
            if (dgvFactura.Rows.Count == 0)
            {
                MessageBox.Show("Primero debes facturar un tratamiento", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (var ModalDetalleFactura = new md_DetalleFactura())
            {
                ModalDetalleFactura.IdFacturas = Convert.ToInt32(this.dgvFactura.CurrentRow.Cells["Id"].Value);
                ModalDetalleFactura.ShowDialog();
            }
        }
    }
}
