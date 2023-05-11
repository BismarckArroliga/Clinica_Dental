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
using capaComun;

namespace capaPresentacion
{
    public partial class frmVentas : Form
    {
        // Usuario Actual

       // private string ColorError = "#E73E32";
        //private string ColorBien = "#FFFFFF";


        public frmVentas()
        {
            InitializeComponent();
        }

        private void ListarTipoDocumentos()
        {
            CN_Ventas objVentas = new CN_Ventas();
            cmbDocumento.DataSource = objVentas.ListarTipoDocumentos();
            cmbDocumento.DisplayMember = "Nombre";
            cmbDocumento.ValueMember = "Id";
        }


        private void frmVentas_Load(object sender, EventArgs e)
        {
            ListarTipoDocumentos();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            using (var Modal = new md_Pacientes())
            {
                var res = Modal.ShowDialog();
                if (res == DialogResult.OK)
                {
                    txtIdPaceinte.Text = Modal._pacientes.Id;
                    txtPaciente.Text = Modal._pacientes.Nombre;

                }
            }
        }


        private void btnBuscarProductos_Click(object sender, EventArgs e)
        {
            using (var Modal = new md_Productos())
            {
                var res = Modal.ShowDialog();

                if (res == DialogResult.OK)
                {
                    txtCodigo.Text = Modal._productos.Codigo;
                    txtProducto.Text = Modal._productos.Producto;
                    txtPrecioVenta.Text = Modal._productos.PrecioVenta;
                    txtPrecioVenta.Text = Modal._productos.PrecioVenta;
                    txtExistencias.Text = Modal._productos.Existencias;
                }
            }
            txtUnidades.Select();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            bool productoExiste = false;

            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Debes seleccionar un Producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if(txtUnidades.Text == "" || int.Parse(txtUnidades.Text) == 0)
            {
                MessageBox.Show("Debes ingresar la unidades con un valor mayor a cero", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUnidades.Select();
                return;

            }
            if (decimal.TryParse(txtPrecioVenta.Text, out precio) == false) 
            {
                MessageBox.Show("Precio - Formato de números incorrecta");
                return;
            }

            if (int.Parse(txtUnidades.Text) > int.Parse(txtExistencias.Text))
            {
                MessageBox.Show("La cantidad ingresada no puede ser mayor al Stock", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtSub.Text = "0.00";
                return;
            }

            if (int.Parse(txtExistencias.Text) == 0)
            {
                MessageBox.Show("Este producto no tiene unidades disponible", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataGridViewRow filas in dgvDetalleFactura.Rows)
            {
                if (filas.Cells["Codigo"].Value.ToString() == txtCodigo.Text)
                {
                    productoExiste = true;
                    MessageBox.Show("Producto existente en la tabla", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                }
            }


            if (productoExiste == false)
            {
                CN_Productos objProductos = new CN_Productos();
                objProductos.RestarExistencias(txtUnidades.Text, txtCodigo.Text);


                dgvDetalleFactura.Rows.Add(new object[] {
                    txtCodigo.Text,
                    txtProducto.Text,
                    txtUnidades.Text,
                    txtPrecioVenta.Text,
                    Convert.ToDecimal(txtDescuento.Text).ToString("N2"),
                    ((Convert.ToDecimal(txtUnidades.Text) * precio) - Convert.ToDecimal(txtDescuento.Text)),
                    ((Convert.ToDecimal(txtUnidades.Text) * precio) - Convert.ToDecimal(txtDescuento.Text))
                });

            }
            calcularTotal();
            calcularDescuento();
            limpiarProductos();
        }

        private void txtUnidades_TextChanged(object sender, EventArgs e)
        {
            calcularTotalTimpoReal();
        }

      
        private void calcularTotalTimpoReal()
        {
            decimal total = 0;
            if(txtUnidades.Text != "")
            {
                decimal unidades = Convert.ToDecimal(txtUnidades.Text);
                decimal precio = Convert.ToDecimal(txtPrecioVenta.Text);
                total += unidades * precio;
                txtSub.Text = total.ToString();
            }
        }


        private void calcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow filas in dgvDetalleFactura.Rows)
            {
                total += Convert.ToDecimal(filas.Cells["Total"].Value.ToString()); 
            }
            txtTotal.Text = total.ToString("N2");
            txtSubTotal.Text = total.ToString("N2");
        }


        private void calcularDescuento()
        {
            decimal total = 0;
            foreach (DataGridViewRow filas in dgvDetalleFactura.Rows)
            {
                total += Convert.ToDecimal(filas.Cells["Descuento"].Value.ToString());
            }
            txtDesc.Text = total.ToString("N2");
        }


        private void limpiarProductos()
        {
            txtCodigo.Clear();
            txtProducto.Clear();
            txtPrecioVenta.Text = "0.00";
            txtDescuento.Text = "0";
            txtExistencias.Text = "0";
            txtUnidades.Clear();
            txtSub.Text = "0.00";
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if(txtPaciente.Text == "")
            {
                MessageBox.Show("Debes seleccionar un Paciente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvDetalleFactura.Rows.Count < 1)
            {
                MessageBox.Show("Debes ingresar productos a la Venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable detalleFactura = new DataTable();
            detalleFactura.Columns.Add("Codigo", typeof(string));
            detalleFactura.Columns.Add("Precio", typeof(decimal));
            detalleFactura.Columns.Add("Descuento", typeof(decimal));
            detalleFactura.Columns.Add("Unidades", typeof(decimal));
            detalleFactura.Columns.Add("SubTotal", typeof(decimal));
            detalleFactura.Columns.Add("Total", typeof(decimal));

            foreach (DataGridViewRow row in dgvDetalleFactura.Rows)
            {
                detalleFactura.Rows.Add(new object[] {
                    row.Cells["Codigo"].Value.ToString(),
                    row.Cells["Precio"].Value.ToString(),
                    row.Cells["Descuento"].Value.ToString(),
                    row.Cells["Unidades"].Value.ToString(),
                    row.Cells["SubTotal"].Value.ToString(),
                    row.Cells["Total"].Value.ToString()
                });
            }

            CN_Ventas objVentas = new CN_Ventas();
            var tipoDocuemento = cmbDocumento.SelectedValue.ToString();
            objVentas.InsertarVenta(tipoDocuemento, UserCache.Id.ToString(), txtIdPaceinte.Text, txtSubTotal.Text, txtTotal.Text, detalleFactura);
            MessageBox.Show("Venta factura Correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            limpiarVenta();
        }

       
        private void limpiarVenta()
        {
            txtIdPaceinte.Clear();
            txtPaciente.Clear();
            txtDesc.Text = "0.00";
            txtSubTotal.Text = "0.00";
            txtTotal.Text = "0.00";
            dgvDetalleFactura.Rows.Clear();
        }

       

        private void txtUnidades_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
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

      
        private void dgvDetalleFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleFactura.Columns[e.ColumnIndex].Name == "Delete")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    CN_Productos objProductos = new CN_Productos();
                    string stock = dgvDetalleFactura.Rows[index].Cells["Unidades"].Value.ToString();
                    string codigo = dgvDetalleFactura.Rows[index].Cells["Codigo"].Value.ToString();

                    objProductos.SumarExistencias(stock, codigo);

                    dgvDetalleFactura.Rows.RemoveAt(index);
                    calcularDescuento();
                    calcularTotal();
                }
            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtDescuento.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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
    }
}













