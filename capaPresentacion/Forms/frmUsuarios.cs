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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void listarUsuarios()
        {
            CN_Usuarios objUsuarios = new CN_Usuarios();
            dgvUsuarios.DataSource = objUsuarios.ListarUsuarios();
        }


        private void Cargos()
        {
            CN_Usuarios objUsuarios = new CN_Usuarios();
            cmbCargos.DataSource = objUsuarios.Cargos();
            cmbCargos.DisplayMember = "Cargo";
            cmbCargos.ValueMember = "Id";
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            Application.EnableVisualStyles();
            listarUsuarios();
            Cargos();
            btnIngresar.Enabled = false;
            btnActualizar.Enabled = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            CN_Usuarios objUsuarios = new CN_Usuarios();
            objUsuarios.InsertarUsuarios(txtNombre.Text, txtCorreo.Text, txtTelefono.Text, txtContrasena.Text, cmbCargos.SelectedValue.ToString());
            MessageBox.Show("Usuario registrado correctamente");
            listarUsuarios();
            limpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CN_Usuarios objUsuarios = new CN_Usuarios();
            objUsuarios.ActualizarUsuarios(txtNombre.Text, txtCorreo.Text, txtTelefono.Text, txtContrasena.Text, cmbCargos.SelectedValue.ToString(), txtId.Text);
            MessageBox.Show("Usuario actualizado correctamente");
            listarUsuarios();
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
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtContrasena.Clear();
            cmbCargos.SelectedValue = 1;
            txtId.Clear();
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row >= 0)
            {
                txtNombre.Text = dgvUsuarios.Rows[row].Cells["Nombre"].Value.ToString();
                txtCorreo.Text = dgvUsuarios.Rows[row].Cells["Correo"].Value.ToString();
                txtTelefono.Text = dgvUsuarios.Rows[row].Cells["Telefono"].Value.ToString();
                txtContrasena.Text = dgvUsuarios.Rows[row].Cells["Contrasena"].Value.ToString();
                cmbCargos.SelectedValue = dgvUsuarios.Rows[row].Cells["IdCargo"].Value.ToString();
                txtId.Text = dgvUsuarios.Rows[row].Cells["Id"].Value.ToString();

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
            var res = !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtCorreo.Text) &&
            !string.IsNullOrEmpty(txtContrasena.Text) && !string.IsNullOrEmpty(txtTelefono.Text);
            btnIngresar.Enabled = res;
        }

        private void validarActualizar()
        {
            var res = !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtCorreo.Text) &&
            !string.IsNullOrEmpty(txtContrasena.Text) && !string.IsNullOrEmpty(txtTelefono.Text) && 
            !string.IsNullOrEmpty(txtId.Text);
            btnActualizar.Enabled = res;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validarInsertar();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            validarInsertar();
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            validarInsertar();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            validarActualizar();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            validarInsertar();
        }
    }
}


















