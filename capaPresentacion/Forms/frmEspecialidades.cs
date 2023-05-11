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
    public partial class frmEspecialidades : Form
    {
        public frmEspecialidades()
        {
            InitializeComponent();
        }

        public void ListarEspecialidades()
        {
            CN_Especialidades objEspecialidades = new CN_Especialidades();
            dgvEspecialidades.DataSource = objEspecialidades.ListarEspecialidades();
        }

        private void frmEspecialidades_Load(object sender, EventArgs e)
        {
            ListarEspecialidades();
            btnActualizar.Enabled = false;
            btnIngresar.Enabled = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            CN_Especialidades objEspecialidades = new CN_Especialidades();
            objEspecialidades.InsertarEspecialidad(txtNombre.Text);
            MessageBox.Show("Especialidad registrada correctamente");
            ListarEspecialidades();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CN_Especialidades objEspecialidades = new CN_Especialidades();
            objEspecialidades.ActualizarEspecialidades(txtId.Text,txtNombre.Text);
            MessageBox.Show("Especialidad actualizada correctamente");
            ListarEspecialidades();
        }

        private void txtLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtId.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvEspecialidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row >= 0)
            {
                txtNombre.Text = dgvEspecialidades.Rows[row].Cells["Nombre"].Value.ToString();
                txtId.Text = dgvEspecialidades.Rows[row].Cells["Id"].Value.ToString();
            }
        }


        private void validarInsertar()
        {
            var res = !string.IsNullOrEmpty(txtNombre.Text);
            btnIngresar.Enabled = true;
        }

        private void validarActualizar()
        {
            var res = !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtId.Text);
            btnActualizar.Enabled = true;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validarInsertar();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            validarActualizar();
        }
    }
}
