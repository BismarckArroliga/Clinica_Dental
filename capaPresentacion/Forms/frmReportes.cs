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
    public partial class frmReportes: Form
    {

        public frmReportes()
        {
            InitializeComponent();
             
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            CN_DetalleFactura objDetalleFactura = new CN_DetalleFactura();
            dgvReportesPacientes.DataSource = objDetalleFactura.Search(txtFechaInicio.Text, txtFechaFin.Text);
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            CN_Compras objCompras = new CN_Compras();
            dgvReportesCompras.DataSource = objCompras.reportesCompras(txtFechaInicio.Text, txtFechaFin.Text);
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            CN_Ventas objVentas = new CN_Ventas();
            dgvReportesVentas.DataSource = objVentas.reportesVentas(txtFechaInicio.Text, txtFechaFin.Text);
        }
    }
}





