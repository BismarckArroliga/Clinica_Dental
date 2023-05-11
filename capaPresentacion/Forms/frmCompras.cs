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
    public partial class frmCompras : Form
    {
        public frmCompras()
        {
            InitializeComponent();
        }

        private void btnBuscarProveedores_Click(object sender, EventArgs e)
        {
            using (var Modal = new md_Proveedores())
            {
                var res = Modal.ShowDialog();
                if (res == DialogResult.OK )
                {
                    txtIdProveedor.Text = Modal._proveedores.Id;
                    txtProveedor.Text = Modal._proveedores.Nombre;
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
                    txtPrecioCompra.Select();
                }
            }
        }

        private void ListarTipoDocumento()
        {
            CN_Ventas objVentas = new CN_Ventas();
            cmbDocumento.DataSource = objVentas.ListarTipoDocumentos();
            cmbDocumento.DisplayMember = "Nombre";
            cmbDocumento.ValueMember = "Id";
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            ListarTipoDocumento();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal unidades = 0;
            decimal precioCompra = 0;
            decimal precioVenta = 0;
            bool productoExiste = false;

            if (txtCodigo.Text == "")
            {
                MessageBox.Show("Debes seleccionar un Producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (decimal.TryParse(txtUnidades.Text, out unidades) == false || unidades == 0)
            {
                MessageBox.Show("Unidades - ingrese una mayor a cero", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (decimal.TryParse(txtPrecioCompra.Text, out precioCompra) == false)
            {
                MessageBox.Show("Precio Compra - Formato de moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (decimal.TryParse(txtPrecioVenta.Text, out precioVenta) == false)
            {
                MessageBox.Show("Precio Venta - Formato de moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            foreach (DataGridViewRow rows in dvgDetalleCompra.Rows)
            {
                if (rows.Cells["Codigo"].Value.ToString() == txtCodigo.Text)
                {
                    productoExiste = true;
                    break;
                }
            }


            if (productoExiste == false)
            {
                dvgDetalleCompra.Rows.Add(new object[]
                {
                    txtCodigo.Text,
                    txtProducto.Text,
                    txtPrecioCompra.Text,
                    txtPrecioVenta.Text,
                    txtUnidades.Text,
                    txtDescuento.Text,
                    (precioCompra * (unidades) - decimal.Parse(txtDescuento.Text)),
                    (precioCompra * (unidades) - decimal.Parse(txtDescuento.Text))
                });

                limpiarProductoAgregado();
                calcularTotal();
                calcularDescuento();
            }

        }

        private void txtUnidades_TextChanged(object sender, EventArgs e)
        {
            calcularTotalTimpoReal();
        }

        private void calcularTotalTimpoReal()
        {
            decimal total = 0;
            if (txtUnidades.Text != "")
            {
                decimal unidades = decimal.Parse(txtUnidades.Text);
                decimal precio = decimal.Parse(txtPrecioCompra.Text);
                total += unidades * precio;
                txtSubTotal.Text = total.ToString();
            }
        }

        private void calcularTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow filas in dvgDetalleCompra.Rows)
            {
                total += Convert.ToDecimal(filas.Cells["Total"].Value.ToString());
            }
            txtTotal.Text = total.ToString();
            txtSubT.Text = total.ToString();
        }

        private void calcularDescuento()
        {
            decimal total = 0;
            foreach (DataGridViewRow filas in dvgDetalleCompra.Rows)
            {
                total += Convert.ToDecimal(filas.Cells["Descuento"].Value.ToString());
            }
            txtDesc.Text = total.ToString();
        }

        private void limpiarProductoAgregado()
        {
            txtCodigo.Clear();
            txtProducto.Clear();
            txtPrecioCompra.Clear();
            txtPrecioVenta.Clear();
            txtSubTotal.Text = "0.00";
            txtDescuento.Text = "0";
            txtUnidades.Clear();
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            } else
            {
                if (txtPrecioCompra.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                } else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    } else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            } else
            {
                if (txtPrecioVenta.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                } else
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

        private void txtUnidades_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnFacturarCompra_Click(object sender, EventArgs e)
        {
            if (txtIdProveedor.Text == "")
            {
                MessageBox.Show("Debes seleccionar un Proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dvgDetalleCompra.Rows.Count < 1)
            {
                MessageBox.Show("Debes ingresar productos ala Compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable detalleCompra = new DataTable();
            detalleCompra.Columns.Add("Codigo", typeof(string));
            detalleCompra.Columns.Add("PrecioCompra", typeof(decimal));
            detalleCompra.Columns.Add("PrecioVenta", typeof(decimal));
            detalleCompra.Columns.Add("Unidades", typeof(int));
            detalleCompra.Columns.Add("Descuento", typeof(decimal));
            detalleCompra.Columns.Add("SubTotal", typeof(decimal));
            detalleCompra.Columns.Add("Total", typeof(decimal));

            foreach (DataGridViewRow row in dvgDetalleCompra.Rows)
            {
                detalleCompra.Rows.Add(
                    new object[]
                    {
                        row.Cells["Codigo"].Value.ToString(),
                        decimal.Parse(row.Cells["PrecioCompra"].Value.ToString()),
                        decimal.Parse(row.Cells["PrecioVenta"].Value.ToString()),
                        int.Parse(row.Cells["Unidades"].Value.ToString()),
                        decimal.Parse(row.Cells["Descuento"].Value.ToString()),
                        decimal.Parse(row.Cells["SubTotal"].Value.ToString()),
                        decimal.Parse(row.Cells["Total"].Value.ToString())
                    }
                 );
            }


            CN_Compras objCompras = new CN_Compras();
            var usuario = UserCache.Id.ToString();
            objCompras.RealizarCompra(cmbDocumento.SelectedValue.ToString(), usuario, txtIdProveedor.Text, txtSubT.Text, txtTotal.Text, detalleCompra);
            MessageBox.Show("Compra realizada correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            limpiarCompra();
        }


        private void limpiarCompra()
        {
            txtIdProveedor.Clear();
            txtProveedor.Clear();
            dvgDetalleCompra.Rows.Clear();
            txtSubT.Text = "0.00";
            txtDesc.Text = "0.00";
            txtTotal.Text = "0.00";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCompra();
            limpiarProductoAgregado();
        }
    }
}


























