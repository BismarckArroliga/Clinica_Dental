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
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void ListarProveedores()
        {
            CN_Proveedores objProveedores = new CN_Proveedores();
            dgvProveedores.DataSource = objProveedores.ListarProveedores();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            ListarProveedores();
            btnActualizar.Enabled = false;
            btnIngresar.Enabled = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            CN_Proveedores objProveedores = new CN_Proveedores();
            objProveedores.InsertarProveedores(txtNombre.Text, txtTelefono.Text, txtDireccion.Text);
            MessageBox.Show("Proveedor registrado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            ListarProveedores();
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CN_Proveedores objProveedores = new CN_Proveedores();
            objProveedores.ActualizarProveedores(txtNombre.Text, txtTelefono.Text, txtDireccion.Text, txtId.Text);
            MessageBox.Show("Proveedor actualizado Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            ListarProveedores();
            LimpiarCampos();
        }

        private void txtLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtNombre.Clear();
        }

 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtNombre.Text = dgvProveedores.Rows[row].Cells["Nombre"].Value.ToString();
                txtTelefono.Text = dgvProveedores.Rows[row].Cells["Telefono"].Value.ToString();
                txtDireccion.Text = dgvProveedores.Rows[row].Cells["Direccion"].Value.ToString();
                txtId.Text = dgvProveedores.Rows[row].Cells["Id"].Value.ToString();
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
    }
}



















