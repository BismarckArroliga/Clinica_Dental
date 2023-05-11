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
    public partial class frmServicios : Form
    {
        public frmServicios()
        {
            InitializeComponent();
        }

        private void ListarServicios()
        {
            CN_Servicios objServicios = new CN_Servicios();
            dgvServicios.DataSource = objServicios.ListarServicios();
        }

        private void frmServicios_Load(object sender, EventArgs e)
        {
            ListarServicios();
            btnActualizar.Enabled = false;
            btnIngresar.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            CN_Servicios objServicios = new CN_Servicios();
            objServicios.InsertarServicios(txtNombre.Text, txtCosto.Text);
            MessageBox.Show("Nuevo servicio registrado");
            ListarServicios();
            limpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CN_Servicios objServicios = new CN_Servicios();
            objServicios.ActualizarServicios(txtNombre.Text, txtCosto.Text, txtId.Text);
            MessageBox.Show("Servicio actualizado correctamente");
            ListarServicios();
            limpiarCampos();
        }

        private void txtLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtCosto.Clear();
        }

        private void dgvServicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row >= 0)
            {
                txtNombre.Text = dgvServicios.Rows[row].Cells["Nombre"].Value.ToString();
                txtCosto.Text = dgvServicios.Rows[row].Cells["Costo"].Value.ToString();
                txtId.Text = dgvServicios.Rows[row].Cells["Id"].Value.ToString();
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtCosto.Text.Trim().Length == 0 && e.KeyChar.ToString() == "")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
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

        private void validarInsertar()
        {
            var res = !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtCosto.Text);
            btnIngresar.Enabled = res;
        }

        private void validarActualizar()
        {
            var res = !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtCosto.Text) &&
                !string.IsNullOrEmpty(txtId.Text);
            btnActualizar.Enabled = res;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validarInsertar();
        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {
            validarInsertar();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            validarActualizar();
        }
    }
}


















