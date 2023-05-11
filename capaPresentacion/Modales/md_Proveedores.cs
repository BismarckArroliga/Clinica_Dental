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
    public partial class md_Proveedores : Form
    {

        public Proveedores _proveedores { get; set; }

        public md_Proveedores()
        {
            InitializeComponent();
        }


        private void listarProveedores()
        {
            CN_Proveedores objProveedores = new CN_Proveedores();
            dvgProveedores.DataSource = objProveedores.ListarProveedores();
        }

        private void md_Proveedores_Load(object sender, EventArgs e)
        {
            listarProveedores();
        }

        private void dvgProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row >= 0)
            {
                _proveedores = new Proveedores()
                {
                    Id = dvgProveedores.Rows[row].Cells["Id"].Value.ToString(),
                    Nombre = dvgProveedores.Rows[row].Cells["Nombre"].Value.ToString()
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}





