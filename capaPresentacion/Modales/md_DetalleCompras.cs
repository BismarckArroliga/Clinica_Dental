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
    public partial class md_DetalleCompras : Form
    {
        public md_DetalleCompras()
        {
            InitializeComponent();
        }

        public int _idCompra { get; set; }


        private void listarDetalleCompra()
        {
            CN_DetalleCompras objDetalleCompras = new CN_DetalleCompras();
            dgvDetalleFactura.DataSource = objDetalleCompras.ListarDetalleCompra(_idCompra.ToString());
        }


        private void md_DetalleFactura_Load(object sender, EventArgs e)
        {
            listarDetalleCompra();
        }
    }
}





