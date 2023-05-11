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
    public partial class md_Medicos : Form
    {
        public Medicos _medicos { get; set; }

        public md_Medicos()
        {
            InitializeComponent();
        }


        private void listarMedicos()
        {
            CN_Personal objMedicos = new CN_Personal();
            dgvMedicos.DataSource = objMedicos.ListarMedicos();
        }

        private void md_Medicos_Load(object sender, EventArgs e)
        {
            listarMedicos();
        }

       
        private void dgvMedicos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row >= 0)
            {
                _medicos = new Medicos()
                {
                    Id = dgvMedicos.Rows[row].Cells["Id"].Value.ToString(),
                    Nombre = dgvMedicos.Rows[row].Cells["Nombre"].Value.ToString()
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}