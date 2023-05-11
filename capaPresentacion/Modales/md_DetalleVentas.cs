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
    public partial class md_DetalleVentas : Form
    {
        public md_DetalleVentas()
        {
            InitializeComponent();
        }

        public int _IdVenta { get; set; }

        private void ListarDetalleVentas()
        {
            CN_DetalleVentas objDetalleVentas = new CN_DetalleVentas();
            dgvDetalleVentas.DataSource = objDetalleVentas.ListarDetalleVentas(_IdVenta.ToString());
        }


        private void md_DetalleVentas_Load(object sender, EventArgs e)
        {
            ListarDetalleVentas();
        }
    }
}





