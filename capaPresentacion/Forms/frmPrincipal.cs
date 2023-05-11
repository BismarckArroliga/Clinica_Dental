using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using capaNegocios;
using capaComun;

namespace capaPresentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
        }

        
        private Form Accion = null;
        private void AbrirFormulario(Form Formulario)
        {
            if(Accion != null)
                Accion.Close();
            
            Accion = Formulario;
            Formulario.TopLevel = false;
            Formulario.Dock = DockStyle.Fill; 
            Formulario.FormBorderStyle = FormBorderStyle.None;
            panelFormularios.Controls.Add(Formulario);
            panelFormularios.Tag = Formulario;
            Formulario.BringToFront();   
            Formulario.Show();
        }

        public void DatosUsuario()
        {
            lblNombre.Text = UserCache.Nombre; 
            lblCargo.Text = UserCache.Cargo; 
            lblCorreo.Text = UserCache.Correo;

            if (UserCache.Cargo == "Empleado")
            {
                btnUsuarios.Visible = false;              
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            DatosUsuario();
        }


        #region Usuarios
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmUsuarios());
        }
        #endregion

        #region Medicos
        private void btnMedicos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmPersonal());
        }
        #endregion

        #region Pacientes
        private void btnPaciente_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmPacientes());
        }
        #endregion

        #region Tratamientos
        private void frmTratamientos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmProcedimiento());
        }
        #endregion

        #region Servicios
        private void btnServicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmServicios());
        }
        #endregion

        #region Facturas
        private void toolStripMenuFacturas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmFacturas());
        }

        private void facturasVentasToolStrip_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmFacturasVentas());
        }

        private void facturasComprasToolStrip_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmFacturasCompras());
        }

        #endregion

        #region Reportes
        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmReportes());
        }
        #endregion

        #region Configuracion
        private void especialidadesToolStripMenu_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmEspecialidades());
        }

        private void citasToolStripMenu_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmCitas());
        }
        #endregion

        #region Farmacia
        private void productosToolStripMenu_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmProductos());
        }

        private void ventasToolStripMenu_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmVentas());
        }

        private void proveedoresToolStrip_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmProveedores());
        }

        private void comprasToolStrip_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmCompras());
        }
        #endregion

        private void inventatarioToolStripMenu_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmInventario());
        }
    }
}




