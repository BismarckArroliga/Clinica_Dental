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
    public partial class frmCitas : Form
    {
        public frmCitas()
        {
            InitializeComponent();
        }

        private void ListarCitas()
        {
            CN_Citas objCitas = new CN_Citas();
            dgvCitas.DataSource = objCitas.ListarCitas();
        }

        private void frmCitas_Load(object sender, EventArgs e)
        {
            ListarCitas();
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            using (var Modal = new md_Pacientes())
            {
                var resultado = Modal.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    txtIdPaciente.Text = Modal._pacientes.Id;
                    txtNombre.Text = Modal._pacientes.Nombre;
                }
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            CN_Citas objCitas = new CN_Citas();
            string hora = txtHora.Text + " " + cmbFormato.Text;
            objCitas.InsertarCitas(txtIdPaciente.Text, Convert.ToDateTime(txtFecha.Text), hora);
            MessageBox.Show("Cita registrada correctamente");
            ListarCitas();
            limpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("El campo id es obligatorio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CN_Citas objCitas = new CN_Citas();
            string hora = txtHora.Text + " " + cmbFormato.Text;
            objCitas.ActualizarCitas(txtId.Text, txtIdPaciente.Text, Convert.ToDateTime(txtFecha.Text), hora);
            MessageBox.Show("Cita actualizada correctamente");
            ListarCitas();
            limpiarCampos();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }


        private void limpiarCampos()
        {
            txtNombre.Clear();
            txtHora.Clear();
            txtId.Clear();
            txtFecha.Text = DateTime.Now.ToString();
        }

        private void dgvCitas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row >= 0)
            {
                txtId.Text = dgvCitas.Rows[row].Cells["Id"].Value.ToString();
                txtNombre.Text = dgvCitas.Rows[row].Cells["Paciente"].Value.ToString();
                txtFecha.Text = dgvCitas.Rows[row].Cells["Fecha"].Value.ToString();
                txtHora.Text = dgvCitas.Rows[row].Cells["Hora"].Value.ToString();
                txtIdPaciente.Text = dgvCitas.Rows[row].Cells["IdPaciente"].Value.ToString();
            }
        }
    }
}

