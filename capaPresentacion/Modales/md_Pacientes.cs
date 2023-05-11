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
    public partial class md_Pacientes : Form
    {

        public Pacientes _pacientes { get; set; }

        public md_Pacientes()
        {
            InitializeComponent();
        }


        private void listarPaceintes()
        {
            CN_Pacientes objPacientes = new CN_Pacientes();
            dvgPacientes.DataSource = objPacientes.ListarPacientes();
        }

        private void md_Pacientes_Load(object sender, EventArgs e)
        {
            listarPaceintes();
        }

        private void dvgPacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (row >= 0 && col >= 0)
            {
                _pacientes = new Pacientes()
                {
                    Id = dvgPacientes.Rows[row].Cells["Id"].Value.ToString(),
                    Nombre = dvgPacientes.Rows[row].Cells["Nombre"].Value.ToString()
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}





