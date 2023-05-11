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
    public partial class frmProcedimiento : Form
    {
        public frmProcedimiento()
        {
            InitializeComponent();
        }

        private void frmProcedimiento_Load(object sender, EventArgs e)
        {
            txtIdPaceinte.Select();
        }


        private void btnBuscarMedico_Click(object sender, EventArgs e)
        {
            using (var Modal = new md_Medicos())
            {
                var res = Modal.ShowDialog();
                if (res == DialogResult.OK)
                {
                    txtIdMedico.Text = Modal._medicos.Id;
                    txtMedico.Text = Modal._medicos.Nombre;
                }
            }
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

        private void btnBuscarServicio_Click(object sender, EventArgs e)
        {
            using (var Modal = new md_Servicios())
            {
                var res = Modal.ShowDialog();

                if (res == DialogResult.OK)
                {
                    txtId.Text = Modal._servicios.Id;
                    txtServicio.Text = Modal._servicios.Nombre;
                    txtPrecio.Text = Modal._servicios.Precio;
                    txtCantidad.Select();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool serviciExiste = false;

            if (txtId.Text == "")
            {
                MessageBox.Show("Ingrese un servicio ala Factura", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtCantidad.Text == "" || txtCantidad.Text == "0")
            {
                MessageBox.Show("Ingrese una cantidad mayor a cero", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCantidad.Clear();
                txtCantidad.Select();
                return;
            }


            foreach (DataGridViewRow row in dvgDetalleFactura.Rows)
            {
                if (row.Cells["Servicio"].Value.ToString() == txtServicio.Text)
                {
                    serviciExiste = true;

                    MessageBox.Show("No se pueden duplicar los servicios en la factura", "Advertenicia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiarTratamiento();
                    break;
                }
            }

            if (serviciExiste == false)
            {
                dvgDetalleFactura.Rows.Add(new object[] {

                    txtId.Text,
                    txtServicio.Text,
                    txtCantidad.Text,
                    txtPrecio.Text,
                    Convert.ToDecimal(txtDescuento.Text).ToString("N2"),
                    ((decimal.Parse(txtPrecio.Text) * decimal.Parse(txtCantidad.Text)) - decimal.Parse(txtDescuento.Text)),
                    ((decimal.Parse(txtPrecio.Text) * decimal.Parse(txtCantidad.Text)) - decimal.Parse(txtDescuento.Text))
                });

                calcularDescuento();
                calcularTotal();
                limpiarTratamiento();
            }

        }


        private void calcularDescuento()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dvgDetalleFactura.Rows)
            {
                total += Convert.ToDecimal(row.Cells["Descuento"].Value.ToString());
            }

            txtDesc.Text = total.ToString("N2");
        }


        private void calcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dvgDetalleFactura.Rows)
            {
                total += decimal.Parse(row.Cells["TOTAL"].Value.ToString());
            }

            txtTotal.Text = total.ToString("N2");
            txtSubTotal.Text = total.ToString("N2");
        }


        // ENVIAR DATOS ALA BASE DE DATOS

        private void btnFacturar_Click(object sender, EventArgs e)
        {

            if (txtPaciente.Text == "")
            {
                MessageBox.Show("Selecciona un Paciente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dvgDetalleFactura.Rows.Count < 1)
            {
                MessageBox.Show("Seleccione un Servicio", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtMedico.Text == "")
            {
                MessageBox.Show("Selecciona un Médico", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable detalleFactura = new DataTable();
            detalleFactura.Columns.Add("Id", typeof(int));
            detalleFactura.Columns.Add("Cantidad", typeof(int));
            detalleFactura.Columns.Add("Precio", typeof(decimal));
            detalleFactura.Columns.Add("Descuento", typeof(decimal));
            detalleFactura.Columns.Add("SubTotal", typeof(decimal));
            detalleFactura.Columns.Add("TOTAL", typeof(decimal));

            foreach (DataGridViewRow row in dvgDetalleFactura.Rows)
            {
                detalleFactura.Rows.Add(new object[] {
                    row.Cells["Id"].Value.ToString(),
                    row.Cells["Cantidad"].Value.ToString(),
                    row.Cells["Precio"].Value.ToString(),
                    row.Cells["Descuento"].Value.ToString(),
                    row.Cells["SubTotal"].Value.ToString(),
                    row.Cells["Total"].Value.ToString()
                });
            }

            CN_Factura objFactura = new CN_Factura();
            objFactura.InsertarFacturas(txtIdPaceinte.Text, UserCache.Id.ToString(), txtIdMedico.Text, txtDesc.Text, txtSubTotal.Text, txtTotal.Text, detalleFactura);
            MessageBox.Show("Factura generada correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            limpiarFactura();
        }



        // LIMPIEZA
        private void limpiarTratamiento()
        {
            txtId.Text = "";
            txtServicio.Text = "";
            txtPrecio.Text = "0.00";
            txtDescuento.Text = "0";
            txtCantidad.Text = "";
        }


        private void limpiarFactura()
        { 
            txtIdPaceinte.Clear();
            txtPaciente.Clear();
            txtIdMedico.Clear();
            txtMedico.Clear();
            dvgDetalleFactura.Rows.Clear();
            txtDesc.Text = "0.00";
            txtSubTotal.Text = "0.00";
            txtTotal.Text = "0.00";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarTratamiento();
            limpiarFactura();
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
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



















