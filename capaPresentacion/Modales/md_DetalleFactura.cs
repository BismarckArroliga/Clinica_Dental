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
    public partial class md_DetalleFactura : Form
    {
        public md_DetalleFactura()
        {
            InitializeComponent();
        }

        private int _IdFacturas;

        public int IdFacturas
        {
            get
            {
                return _IdFacturas;
            }

            set
            {
                _IdFacturas = value;
            }
        }


        private void listarDetalle()
        {
            CN_DetalleFactura objDetalleFactura = new CN_DetalleFactura();

            dgvDetalleFactura.DataSource = objDetalleFactura.ListarDetalleFactura(IdFacturas.ToString());
        }


        private void md_DetalleFactura_Load(object sender, EventArgs e)
        {
            listarDetalle();
        }
    }
}





