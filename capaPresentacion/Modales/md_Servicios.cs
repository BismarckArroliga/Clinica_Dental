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
    public partial class md_Servicios : Form
    {

        public Servicios _servicios { get; set; }

        public md_Servicios()
        {
            InitializeComponent();
        }

        private void listarServicios()
        {
            CN_Servicios objServicios = new CN_Servicios();
            dgvServicios.DataSource = objServicios.ListarServicios();   
        }

        private void md_Pacientes_Load(object sender, EventArgs e)
        {
            listarServicios();
        }
 
        private void dgvServicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                _servicios = new Servicios()
                {
                    Id = dgvServicios.Rows[row].Cells["Id"].Value.ToString(),
                    Nombre = dgvServicios.Rows[row].Cells["Nombre"].Value.ToString(),
                    Precio = dgvServicios.Rows[row].Cells["Costo"].Value.ToString()
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}





