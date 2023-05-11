namespace capaPresentacion
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.panelFondo = new System.Windows.Forms.Panel();
            this.panelFormularios = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnUsuarios = new FontAwesome.Sharp.IconMenuItem();
            this.btnMedicos = new FontAwesome.Sharp.IconMenuItem();
            this.btnPaciente = new FontAwesome.Sharp.IconMenuItem();
            this.frmTratamientos = new FontAwesome.Sharp.IconMenuItem();
            this.btnServicio = new FontAwesome.Sharp.IconMenuItem();
            this.btnFacturas = new FontAwesome.Sharp.IconMenuItem();
            this.toolStripMenuFacturas = new System.Windows.Forms.ToolStripMenuItem();
            this.facturasVentasToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.facturasComprasToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConfiguracion = new FontAwesome.Sharp.IconMenuItem();
            this.citasToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.especialidadesToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReportes = new FontAwesome.Sharp.IconMenuItem();
            this.btnFarmacia = new FontAwesome.Sharp.IconMenuItem();
            this.productosToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.comprasToolStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.inventatarioToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlBorderTop = new System.Windows.Forms.Panel();
            this.panelFondo.SuspendLayout();
            this.panelFormularios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFondo
            // 
            this.panelFondo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panelFondo.Controls.Add(this.panelFormularios);
            this.panelFondo.Controls.Add(this.menuStrip1);
            this.panelFondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFondo.Location = new System.Drawing.Point(0, 1);
            this.panelFondo.Name = "panelFondo";
            this.panelFondo.Size = new System.Drawing.Size(1134, 660);
            this.panelFondo.TabIndex = 1;
            // 
            // panelFormularios
            // 
            this.panelFormularios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panelFormularios.Controls.Add(this.pictureBox1);
            this.panelFormularios.Controls.Add(this.lblNombre);
            this.panelFormularios.Controls.Add(this.lblCorreo);
            this.panelFormularios.Controls.Add(this.lblCargo);
            this.panelFormularios.Controls.Add(this.pictureLogo);
            this.panelFormularios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormularios.Location = new System.Drawing.Point(0, 58);
            this.panelFormularios.Name = "panelFormularios";
            this.panelFormularios.Size = new System.Drawing.Size(1134, 602);
            this.panelFormularios.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::capaPresentacion.Properties.Resources.user1;
            this.pictureBox1.Location = new System.Drawing.Point(20, 535);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(73, 534);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(60, 17);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "Mombre";
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.ForeColor = System.Drawing.Color.White;
            this.lblCorreo.Location = new System.Drawing.Point(73, 573);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(43, 15);
            this.lblCorreo.TabIndex = 10;
            this.lblCorreo.Text = "Correo";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargo.ForeColor = System.Drawing.Color.White;
            this.lblCargo.Location = new System.Drawing.Point(73, 555);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(39, 15);
            this.lblCargo.TabIndex = 9;
            this.lblCargo.Text = "Cargo";
            // 
            // pictureLogo
            // 
            this.pictureLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureLogo.Image = global::capaPresentacion.Properties.Resources.logo;
            this.pictureLogo.Location = new System.Drawing.Point(405, 188);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(324, 139);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLogo.TabIndex = 7;
            this.pictureLogo.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUsuarios,
            this.btnMedicos,
            this.btnPaciente,
            this.frmTratamientos,
            this.btnServicio,
            this.btnFacturas,
            this.btnConfiguracion,
            this.btnReportes,
            this.btnFarmacia});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(1134, 58);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.Color.White;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.ForeColor = System.Drawing.Color.Black;
            this.btnUsuarios.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.btnUsuarios.IconColor = System.Drawing.Color.Black;
            this.btnUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUsuarios.IconSize = 32;
            this.btnUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(80, 58);
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnMedicos
            // 
            this.btnMedicos.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedicos.ForeColor = System.Drawing.Color.Black;
            this.btnMedicos.IconChar = FontAwesome.Sharp.IconChar.UserNurse;
            this.btnMedicos.IconColor = System.Drawing.Color.Black;
            this.btnMedicos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMedicos.IconSize = 32;
            this.btnMedicos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMedicos.Name = "btnMedicos";
            this.btnMedicos.Size = new System.Drawing.Size(78, 58);
            this.btnMedicos.Text = "Medicos";
            this.btnMedicos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMedicos.Click += new System.EventHandler(this.btnMedicos_Click);
            // 
            // btnPaciente
            // 
            this.btnPaciente.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaciente.ForeColor = System.Drawing.Color.Black;
            this.btnPaciente.IconChar = FontAwesome.Sharp.IconChar.UserPen;
            this.btnPaciente.IconColor = System.Drawing.Color.Black;
            this.btnPaciente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPaciente.IconSize = 32;
            this.btnPaciente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPaciente.Name = "btnPaciente";
            this.btnPaciente.Size = new System.Drawing.Size(85, 58);
            this.btnPaciente.Text = "Pacientes";
            this.btnPaciente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPaciente.Click += new System.EventHandler(this.btnPaciente_Click);
            // 
            // frmTratamientos
            // 
            this.frmTratamientos.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmTratamientos.ForeColor = System.Drawing.Color.Black;
            this.frmTratamientos.IconChar = FontAwesome.Sharp.IconChar.Vial;
            this.frmTratamientos.IconColor = System.Drawing.Color.Black;
            this.frmTratamientos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.frmTratamientos.IconSize = 32;
            this.frmTratamientos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.frmTratamientos.Name = "frmTratamientos";
            this.frmTratamientos.Size = new System.Drawing.Size(109, 58);
            this.frmTratamientos.Text = "Tratamientos";
            this.frmTratamientos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.frmTratamientos.Click += new System.EventHandler(this.frmTratamientos_Click);
            // 
            // btnServicio
            // 
            this.btnServicio.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServicio.ForeColor = System.Drawing.Color.Black;
            this.btnServicio.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.btnServicio.IconColor = System.Drawing.Color.Black;
            this.btnServicio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnServicio.IconSize = 32;
            this.btnServicio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnServicio.Name = "btnServicio";
            this.btnServicio.Size = new System.Drawing.Size(82, 58);
            this.btnServicio.Text = "Servicios";
            this.btnServicio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnServicio.Click += new System.EventHandler(this.btnServicio_Click);
            // 
            // btnFacturas
            // 
            this.btnFacturas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuFacturas,
            this.facturasVentasToolStrip,
            this.facturasComprasToolStrip});
            this.btnFacturas.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturas.ForeColor = System.Drawing.Color.Black;
            this.btnFacturas.IconChar = FontAwesome.Sharp.IconChar.Clipboard;
            this.btnFacturas.IconColor = System.Drawing.Color.Black;
            this.btnFacturas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFacturas.IconSize = 32;
            this.btnFacturas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFacturas.Name = "btnFacturas";
            this.btnFacturas.Size = new System.Drawing.Size(77, 58);
            this.btnFacturas.Text = "Facturas";
            this.btnFacturas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripMenuFacturas
            // 
            this.toolStripMenuFacturas.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuFacturas.Name = "toolStripMenuFacturas";
            this.toolStripMenuFacturas.Size = new System.Drawing.Size(156, 22);
            this.toolStripMenuFacturas.Text = "Tratamientos";
            this.toolStripMenuFacturas.Click += new System.EventHandler(this.toolStripMenuFacturas_Click);
            // 
            // facturasVentasToolStrip
            // 
            this.facturasVentasToolStrip.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.facturasVentasToolStrip.Name = "facturasVentasToolStrip";
            this.facturasVentasToolStrip.Size = new System.Drawing.Size(156, 22);
            this.facturasVentasToolStrip.Text = "Ventas";
            this.facturasVentasToolStrip.Click += new System.EventHandler(this.facturasVentasToolStrip_Click);
            // 
            // facturasComprasToolStrip
            // 
            this.facturasComprasToolStrip.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.facturasComprasToolStrip.Name = "facturasComprasToolStrip";
            this.facturasComprasToolStrip.Size = new System.Drawing.Size(156, 22);
            this.facturasComprasToolStrip.Text = "Compras";
            this.facturasComprasToolStrip.Click += new System.EventHandler(this.facturasComprasToolStrip_Click);
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.citasToolStripMenu,
            this.especialidadesToolStripMenu});
            this.btnConfiguracion.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracion.ForeColor = System.Drawing.Color.Black;
            this.btnConfiguracion.IconChar = FontAwesome.Sharp.IconChar.Cogs;
            this.btnConfiguracion.IconColor = System.Drawing.Color.Black;
            this.btnConfiguracion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConfiguracion.IconSize = 34;
            this.btnConfiguracion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(118, 58);
            this.btnConfiguracion.Text = "Configuracion";
            this.btnConfiguracion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // citasToolStripMenu
            // 
            this.citasToolStripMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.citasToolStripMenu.Name = "citasToolStripMenu";
            this.citasToolStripMenu.Size = new System.Drawing.Size(163, 22);
            this.citasToolStripMenu.Text = "Citas";
            this.citasToolStripMenu.Click += new System.EventHandler(this.citasToolStripMenu_Click);
            // 
            // especialidadesToolStripMenu
            // 
            this.especialidadesToolStripMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.especialidadesToolStripMenu.Name = "especialidadesToolStripMenu";
            this.especialidadesToolStripMenu.Size = new System.Drawing.Size(163, 22);
            this.especialidadesToolStripMenu.Text = "Especialidades";
            this.especialidadesToolStripMenu.Click += new System.EventHandler(this.especialidadesToolStripMenu_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.Black;
            this.btnReportes.IconChar = FontAwesome.Sharp.IconChar.LineChart;
            this.btnReportes.IconColor = System.Drawing.Color.Black;
            this.btnReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReportes.IconSize = 32;
            this.btnReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(81, 58);
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnFarmacia
            // 
            this.btnFarmacia.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productosToolStripMenu,
            this.ventasToolStripMenu,
            this.proveedoresToolStrip,
            this.comprasToolStrip,
            this.inventatarioToolStripMenu});
            this.btnFarmacia.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFarmacia.ForeColor = System.Drawing.Color.Black;
            this.btnFarmacia.IconChar = FontAwesome.Sharp.IconChar.Pills;
            this.btnFarmacia.IconColor = System.Drawing.Color.Black;
            this.btnFarmacia.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFarmacia.IconSize = 32;
            this.btnFarmacia.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFarmacia.Name = "btnFarmacia";
            this.btnFarmacia.Size = new System.Drawing.Size(82, 58);
            this.btnFarmacia.Text = "Farmacia";
            this.btnFarmacia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // productosToolStripMenu
            // 
            this.productosToolStripMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productosToolStripMenu.Name = "productosToolStripMenu";
            this.productosToolStripMenu.Size = new System.Drawing.Size(153, 22);
            this.productosToolStripMenu.Text = "Productos";
            this.productosToolStripMenu.Click += new System.EventHandler(this.productosToolStripMenu_Click);
            // 
            // ventasToolStripMenu
            // 
            this.ventasToolStripMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventasToolStripMenu.Name = "ventasToolStripMenu";
            this.ventasToolStripMenu.Size = new System.Drawing.Size(153, 22);
            this.ventasToolStripMenu.Text = "Ventas";
            this.ventasToolStripMenu.Click += new System.EventHandler(this.ventasToolStripMenu_Click);
            // 
            // proveedoresToolStrip
            // 
            this.proveedoresToolStrip.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proveedoresToolStrip.Name = "proveedoresToolStrip";
            this.proveedoresToolStrip.Size = new System.Drawing.Size(153, 22);
            this.proveedoresToolStrip.Text = "Proveedores";
            this.proveedoresToolStrip.Click += new System.EventHandler(this.proveedoresToolStrip_Click);
            // 
            // comprasToolStrip
            // 
            this.comprasToolStrip.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comprasToolStrip.Name = "comprasToolStrip";
            this.comprasToolStrip.Size = new System.Drawing.Size(153, 22);
            this.comprasToolStrip.Text = "Compras";
            this.comprasToolStrip.Click += new System.EventHandler(this.comprasToolStrip_Click);
            // 
            // inventatarioToolStripMenu
            // 
            this.inventatarioToolStripMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventatarioToolStripMenu.Name = "inventatarioToolStripMenu";
            this.inventatarioToolStripMenu.Size = new System.Drawing.Size(153, 22);
            this.inventatarioToolStripMenu.Text = "Inventario";
            this.inventatarioToolStripMenu.Click += new System.EventHandler(this.inventatarioToolStripMenu_Click);
            // 
            // pnlBorderTop
            // 
            this.pnlBorderTop.BackColor = System.Drawing.Color.Gray;
            this.pnlBorderTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBorderTop.Location = new System.Drawing.Point(0, 0);
            this.pnlBorderTop.Name = "pnlBorderTop";
            this.pnlBorderTop.Size = new System.Drawing.Size(1134, 1);
            this.pnlBorderTop.TabIndex = 12;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 661);
            this.Controls.Add(this.panelFondo);
            this.Controls.Add(this.pnlBorderTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clinica Dental";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.panelFondo.ResumeLayout(false);
            this.panelFondo.PerformLayout();
            this.panelFormularios.ResumeLayout(false);
            this.panelFormularios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelFondo;
        private System.Windows.Forms.Panel panelFormularios;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.PictureBox pictureLogo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem btnUsuarios;
        private FontAwesome.Sharp.IconMenuItem btnMedicos;
        private FontAwesome.Sharp.IconMenuItem btnPaciente;
        private FontAwesome.Sharp.IconMenuItem btnServicio;
        private FontAwesome.Sharp.IconMenuItem btnFacturas;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuFacturas;
        private FontAwesome.Sharp.IconMenuItem btnReportes;
        private FontAwesome.Sharp.IconMenuItem btnConfiguracion;
        private System.Windows.Forms.ToolStripMenuItem citasToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem especialidadesToolStripMenu;
        private System.Windows.Forms.Panel pnlBorderTop;
        private FontAwesome.Sharp.IconMenuItem frmTratamientos;
        private FontAwesome.Sharp.IconMenuItem btnFarmacia;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem proveedoresToolStrip;
        private System.Windows.Forms.ToolStripMenuItem facturasVentasToolStrip;
        private System.Windows.Forms.ToolStripMenuItem comprasToolStrip;
        private System.Windows.Forms.ToolStripMenuItem facturasComprasToolStrip;
        private System.Windows.Forms.ToolStripMenuItem inventatarioToolStripMenu;
    }
}

