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
    public partial class frmPersonal : Form
    {
        public frmPersonal()
        {
            InitializeComponent();
        }

        private void listarPersonal()
        {
            CN_Personal objPersonal = new CN_Personal();
            dvgPersonal.DataSource = objPersonal.ListarMedicos();
        }

        private void Especialidades()
        {
            CN_Personal objPersonal = new CN_Personal();
            cmbEspecialidad.DataSource = objPersonal.Especialidades();
            cmbEspecialidad.DisplayMember = "Nombre";
            cmbEspecialidad.ValueMember = "Id";
        }


        private void frmPersonal_Load(object sender, EventArgs e)
        {
            listarPersonal();
            Especialidades();
            btnActualizar.Enabled = false;
            btnIngresar.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            CN_Personal objPersonal = new CN_Personal();
            objPersonal.InsertarMedicos(txtNombre.Text, txtTelefono.Text, txtDireccion.Text, txtCedula.Text, cmbEspecialidad.SelectedValue.ToString());
            MessageBox.Show("Registro insertado correctamente");
            listarPersonal();
            limpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CN_Personal objPersonal = new CN_Personal();
            objPersonal.ActualizarMedicos(txtNombre.Text, txtTelefono.Text, txtDireccion.Text, txtCedula.Text, cmbEspecialidad.SelectedValue.ToString(), txtId.Text);
            MessageBox.Show("Registro actualizado correctamente");
            listarPersonal();
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
            txtCedula.Clear();
            cmbEspecialidad.SelectedValue = 1;
            txtId.Clear();
        }

        private void dvgPersonal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row >= 0)
            {
                txtNombre.Text = dvgPersonal.Rows[row].Cells["Nombre"].Value.ToString();
                txtTelefono.Text = dvgPersonal.Rows[row].Cells["Telefono"].Value.ToString();
                txtDireccion.Text = dvgPersonal.Rows[row].Cells["Direccion"].Value.ToString();
                txtCedula.Text = dvgPersonal.Rows[row].Cells["Cedula"].Value.ToString();
                cmbEspecialidad.SelectedValue = dvgPersonal.Rows[row].Cells["IdEspecialidad"].Value.ToString();
                txtId.Text = dvgPersonal.Rows[row].Cells["Id"].Value.ToString();

            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void validarInsertar()
        {
            var res = !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtTelefono.Text) &&
            !string.IsNullOrEmpty(txtDireccion.Text) && !string.IsNullOrEmpty(txtCedula.Text);
            btnIngresar.Enabled = res;
        }

        private void validarActualizar()
        {
            var res = !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtTelefono.Text) &&
            !string.IsNullOrEmpty(txtDireccion.Text) && !string.IsNullOrEmpty(txtCedula.Text) && !string.IsNullOrEmpty(txtId.Text);
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

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            validarInsertar();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            validarActualizar();
        }
    }
}


















