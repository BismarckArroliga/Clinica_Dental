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

namespace capaPresentacion
{
    public partial class frmLogin : Form
    {
        CN_Usuarios objUsuarios = new CN_Usuarios();

        public frmLogin()
        {
            InitializeComponent();
        }

        #region  Funcionalidades
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
            }
        }

        private void txtPassword_Enter_1(object sender, EventArgs e)
        {
            if (txtPassword.Text == "CONTRASEÑA")
            {
                txtPassword.Text = "";
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "CONTRASEÑA";
                txtPassword.UseSystemPasswordChar = false;
                btnMostar.Hide();
                btnOcultar.Hide();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int
       wparam, int lparam);

        public void Mover()
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            Mover();
        }

        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            Mover();
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            Mover();
        }
        #endregion


        private void btnIEntrar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text != "USUARIO")
            {
                if(txtPassword.Text != "CONTRASEÑA")
                {
                    var usuario = objUsuarios.Login(txtUsuario.Text, txtPassword.Text);
                    if(usuario == true)
                    {
                        frmBienvenido frmBienvenido = new frmBienvenido();
                        frmBienvenido.ShowDialog();
                        this.Hide();
                        frmPrincipal main = new frmPrincipal();
                        main.Show();
                        main.FormClosed += Login;

                    } else
                    {
                        MessageBox.Show("Usuario o contraseña incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                } else
                    MessageBox.Show("Error debes ingresar una Contraseña", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
               MessageBox.Show("Error debes ingresar un Usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);          
        }


        private void Login(object sender, FormClosedEventArgs e)
        {
            txtUsuario.Text = "USUARIO";
            txtPassword.Text = "CONTRASEÑA";
            txtPassword.UseSystemPasswordChar = false;
            this.Show();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            btnMostar.Hide();
            btnOcultar.Hide();

        }

        private void btnMostar_Click(object sender, EventArgs e)
        {
            btnMostar.Hide();
            btnOcultar.Show();
            txtPassword.UseSystemPasswordChar = false;
        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            btnOcultar.Hide();
            btnMostar.Show();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != "" || txtPassword.Text == "CONTRASEÑA")
            {
                btnOcultar.Show();
                btnMostar.Show();
                txtPassword.UseSystemPasswordChar = true;
            }  
            else
            {
                btnMostar.Hide();
                btnOcultar.Hide();
            }
        }
    }
}
