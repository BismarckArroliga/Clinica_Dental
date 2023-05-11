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
    public partial class frmInventario : Form
    {
        public frmInventario()
        {
            InitializeComponent();
        }

        private void listarInventarioProductos()
        {
            CN_Invenatario objInventario = new CN_Invenatario();
            dgvInventario.DataSource = objInventario.listarInventarioProductos();
        }

        private void frmInventario_Load(object sender, EventArgs e)
        {
            listarInventarioProductos();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvInventario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvInventario.Columns[e.ColumnIndex].Name == "Stock")
            {
                try
                {
                    if (e.Value.GetType() != typeof(System.DBNull))
                    {
                        if (Convert.ToInt32(e.Value) < 20)
                        {
                            e.CellStyle.BackColor = Color.Red;
                        }
                        if (Convert.ToInt32(e.Value) > 20)
                        {
                            e.CellStyle.BackColor = Color.Green;
                        }
                    }
                }
                catch (NullReferenceException ex)
                {

                    MessageBox.Show(" " + ex.Message);
                }
            }
        }

        private void dgvInventario_SelectionChanged(object sender, EventArgs e)
        {
            this.dgvInventario.ClearSelection();
        }
    }
}


















