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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        private void ListarProductos()
        {
            CN_Productos objProductos = new CN_Productos();
            dgvProductos.DataSource = objProductos.ListarProductos();
        }

        private void ListarCategorias()
        {
            CN_Productos objProductos = new CN_Productos();
            cmbCategorias.DataSource = objProductos.ListaCategorias();
            cmbCategorias.DisplayMember = "Nombre";
            cmbCategorias.ValueMember = "Id";
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            txtCodigo.CharacterCasing = CharacterCasing.Upper;
            ListarProductos();
            ListarCategorias();
            btnActualizar.Enabled = false;
            btnIngresar.Enabled = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            CN_Productos objProductos = new CN_Productos();
            objProductos.InsertarProductos(txtCodigo.Text, txtNombre.Text,cmbCategorias.SelectedValue.ToString(),txtDescripcion.Text);
            MessageBox.Show("Nuevo producto agregado correctamente " + txtNombre.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            ListarProductos();
            limpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            bool productoExiste = false;
            foreach (DataGridViewRow item in dgvProductos.Rows)
            {
                if (item.Cells["Codigo"].Value.ToString() == txtCodigo.Text)
                {
                    productoExiste = true;
                    break;
                }
            }

            if(productoExiste == true)
            {
                CN_Productos objProductos = new CN_Productos();
                objProductos.ActualizarProductos(txtCodigo.Text, txtNombre.Text, cmbCategorias.SelectedValue.ToString(),txtDescripcion.Text);
                MessageBox.Show("Producto actualizado correctamente " + txtNombre.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ListarProductos();
                limpiarCampos();

            } else
            {
                MessageBox.Show("El producto ha actualizar no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


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
            txtCodigo.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtCodigo.Text = dgvProductos.Rows[row].Cells["Codigo"].Value.ToString();
                txtNombre.Text = dgvProductos.Rows[row].Cells["Nombre"].Value.ToString();
                cmbCategorias.SelectedValue = dgvProductos.Rows[row].Cells["IdCategoria"].Value;
                txtDescripcion.Text = dgvProductos.Rows[row].Cells["Descripcion"].Value.ToString();
            }
        }

        private void validarInsertar()
        {
            var res = !string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtNombre.Text)
                && !string.IsNullOrEmpty(txtDescripcion.Text);
            btnIngresar.Enabled = res;
            btnActualizar.Enabled = res;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            validarInsertar();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            validarInsertar();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            validarInsertar();
        }
    }
}








