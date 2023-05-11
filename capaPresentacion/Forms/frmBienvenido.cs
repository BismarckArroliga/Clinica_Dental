using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace capaPresentacion
{
    public partial class frmBienvenido : Form
    {
        public frmBienvenido()
        {

            InitializeComponent();
        }

        private void timerAbirForms_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.05;

            progressBar1.Value++;

            if(progressBar1.Value == 100)
            {
                timerAbirForms.Stop();
                timerCerrarForms.Start();
            }
        }

        private void timerCerrarForms_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if(this.Opacity == 0)
            {
                timerAbirForms.Stop();
                this.Close();
            }
        }

        private void frmBienvenido_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0;
            timerAbirForms.Start();
        }
    }
}
