namespace Presentacion.Core.ControlesUsuarios
{
    partial class UserControlMesa
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlEstado = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirMesaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarMesaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarDeMesaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservaActivaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservaConfirmadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservaCanceladaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separador = new System.Windows.Forms.ToolStripSeparator();
            this.combinarMesaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblNumeroMesa = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEstado
            // 
            this.pnlEstado.ContextMenuStrip = this.menu;
            this.pnlEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEstado.Location = new System.Drawing.Point(0, 0);
            this.pnlEstado.Name = "pnlEstado";
            this.pnlEstado.Size = new System.Drawing.Size(98, 22);
            this.pnlEstado.TabIndex = 0;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirMesaToolStripMenuItem,
            this.cerrarMesaToolStripMenuItem,
            this.cambiarDeMesaToolStripMenuItem,
            this.reservarToolStripMenuItem,
            this.separador,
            this.combinarMesaToolStripMenuItem});
            this.menu.Name = "contextMenuStrip1";
            this.menu.Size = new System.Drawing.Size(167, 120);
            // 
            // abrirMesaToolStripMenuItem
            // 
            this.abrirMesaToolStripMenuItem.Name = "abrirMesaToolStripMenuItem";
            this.abrirMesaToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.abrirMesaToolStripMenuItem.Text = "Abrir Mesa";
            this.abrirMesaToolStripMenuItem.Click += new System.EventHandler(this.abrirMesaToolStripMenuItem_Click);
            // 
            // cerrarMesaToolStripMenuItem
            // 
            this.cerrarMesaToolStripMenuItem.Name = "cerrarMesaToolStripMenuItem";
            this.cerrarMesaToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.cerrarMesaToolStripMenuItem.Text = "Cerrar Mesa";
            this.cerrarMesaToolStripMenuItem.Click += new System.EventHandler(this.cerrarMesaToolStripMenuItem_Click);
            // 
            // cambiarDeMesaToolStripMenuItem
            // 
            this.cambiarDeMesaToolStripMenuItem.Name = "cambiarDeMesaToolStripMenuItem";
            this.cambiarDeMesaToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.cambiarDeMesaToolStripMenuItem.Text = "Cambiar de Mesa";
            this.cambiarDeMesaToolStripMenuItem.Click += new System.EventHandler(this.cambiarDeMesaToolStripMenuItem_Click);
            // 
            // reservarToolStripMenuItem
            // 
            this.reservarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reservaActivaToolStripMenuItem,
            this.reservaConfirmadaToolStripMenuItem,
            this.reservaCanceladaToolStripMenuItem});
            this.reservarToolStripMenuItem.Name = "reservarToolStripMenuItem";
            this.reservarToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.reservarToolStripMenuItem.Text = "Reservar";
            // 
            // reservaActivaToolStripMenuItem
            // 
            this.reservaActivaToolStripMenuItem.Name = "reservaActivaToolStripMenuItem";
            this.reservaActivaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reservaActivaToolStripMenuItem.Text = "Reservar";
            this.reservaActivaToolStripMenuItem.Click += new System.EventHandler(this.reservaActivaToolStripMenuItem_Click);
            // 
            // reservaConfirmadaToolStripMenuItem
            // 
            this.reservaConfirmadaToolStripMenuItem.Name = "reservaConfirmadaToolStripMenuItem";
            this.reservaConfirmadaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reservaConfirmadaToolStripMenuItem.Text = "Reserva Confirmada";
            this.reservaConfirmadaToolStripMenuItem.Click += new System.EventHandler(this.reservaConfirmadaToolStripMenuItem_Click);
            // 
            // reservaCanceladaToolStripMenuItem
            // 
            this.reservaCanceladaToolStripMenuItem.Name = "reservaCanceladaToolStripMenuItem";
            this.reservaCanceladaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.reservaCanceladaToolStripMenuItem.Text = "Reserva Cancelada";
            this.reservaCanceladaToolStripMenuItem.Click += new System.EventHandler(this.reservaCanceladaToolStripMenuItem_Click);
            // 
            // separador
            // 
            this.separador.Name = "separador";
            this.separador.Size = new System.Drawing.Size(163, 6);
            // 
            // combinarMesaToolStripMenuItem
            // 
            this.combinarMesaToolStripMenuItem.Name = "combinarMesaToolStripMenuItem";
            this.combinarMesaToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.combinarMesaToolStripMenuItem.Text = "Combinar Mesa";
            this.combinarMesaToolStripMenuItem.Click += new System.EventHandler(this.combinarMesaToolStripMenuItem_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.ContextMenuStrip = this.menu;
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(0, 94);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(98, 29);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNumeroMesa
            // 
            this.lblNumeroMesa.ContextMenuStrip = this.menu;
            this.lblNumeroMesa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNumeroMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroMesa.Location = new System.Drawing.Point(0, 22);
            this.lblNumeroMesa.Name = "lblNumeroMesa";
            this.lblNumeroMesa.Size = new System.Drawing.Size(98, 72);
            this.lblNumeroMesa.TabIndex = 2;
            this.lblNumeroMesa.Text = "1";
            this.lblNumeroMesa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNumeroMesa.DoubleClick += new System.EventHandler(this.lblNumeroMesa_DoubleClick);
            // 
            // UserControlMesa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblNumeroMesa);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.pnlEstado);
            this.Name = "UserControlMesa";
            this.Size = new System.Drawing.Size(98, 123);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEstado;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ContextMenuStrip menu;
        public System.Windows.Forms.Label lblNumeroMesa;
        private System.Windows.Forms.ToolStripMenuItem abrirMesaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarMesaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator separador;
        private System.Windows.Forms.ToolStripMenuItem reservarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservaActivaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservaConfirmadaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservaCanceladaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarDeMesaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem combinarMesaToolStripMenuItem;
    }
}
