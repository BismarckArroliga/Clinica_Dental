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
    public partial class frmPacientes : Form
    {
        public frmPacientes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void ListarPacientes()
        {
            CN_Pacientes objPacientes = new CN_Pacientes();
            dvgPacientes.DataSource = objPacientes.ListarPacientes();
        }

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            ListarPacientes();
            btnActualizar.Enabled = false;
            btnIngresar.Enabled = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            CN_Pacientes objPacientes = new CN_Pacientes();
            objPacientes.InsertarPacientes(txtNombre.Text, txtTelefono.Text, txtDireccion.Text);
            MessageBox.Show("Paciente ingresado correctamente");
            ListarPacientes();
            limpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CN_Pacientes objPacientes = new CN_Pacientes();
            objPacientes.ActualizarPacientes(txtNombre.Text, txtTelefono.Text, txtDireccion.Text, txtId.Text);
            MessageBox.Show("Paciente actaulizado correctamente");
            ListarPacientes();
            limpiarCampos();
        }


        private void txtLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtId.Clear();
        }

        private void dvgPacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row >= 0)
            {
                txtNombre.Text = dvgPacientes.Rows[row].Cells["Nombre"].Value.ToString();
                txtTelefono.Text = dvgPacientes.Rows[row].Cells["Telefono"].Value.ToString();
                txtDireccion.Text = dvgPacientes.Rows[row].Cells["Direccion"].Value.ToString();
                txtId.Text = dvgPacientes.Rows[row].Cells["Id"].Value.ToString();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            } else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                } else
                {
                    e.Handled = true;
                }
            }
        }

        private void validarInsertar()
        {
            var res = !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtTelefono.Text) &&
           !string.IsNullOrEmpty(txtDireccion.Text);
            btnIngresar.Enabled = res;
        }

        private void validarActualizar()
        {
            var res = !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtTelefono.Text) &&
           !string.IsNullOrEmpty(txtDireccion.Text) && !string.IsNullOrEmpty(txtId.Text);
            btnActualizar.Enabled = res;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validarInsertar();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            validarInsertar();
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            validarInsertar();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            validarActualizar();
        }
    }
}


















