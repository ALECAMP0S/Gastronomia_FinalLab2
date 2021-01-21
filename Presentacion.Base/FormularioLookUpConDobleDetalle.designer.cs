namespace Presentacion.Base
{
    partial class FormularioLookUpConDobleDetalle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioLookUpConDobleDetalle));
            this.Menu = new System.Windows.Forms.ToolStrip();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.imgTitulo = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUsuarioLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvDetalle1 = new System.Windows.Forms.DataGridView();
            this.dgvDetalle2 = new System.Windows.Forms.DataGridView();
            this.lblTituloDetalle1 = new System.Windows.Forms.Label();
            this.lblTituloDetalle2 = new System.Windows.Forms.Label();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTitulo)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle2)).BeginInit();
            this.pnlBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.Color.SteelBlue;
            this.Menu.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalir});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(784, 52);
            this.Menu.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(34, 49);
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(11, 104);
            this.dgvGrilla.MultiSelect = false;
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.ReadOnly = true;
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(763, 204);
            this.dgvGrilla.TabIndex = 11;
            this.dgvGrilla.DataSourceChanged += new System.EventHandler(this.dgvGrilla_DataSourceChanged);
            this.dgvGrilla.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrilla_RowEnter);
            this.dgvGrilla.DoubleClick += new System.EventHandler(this.dgvGrilla_DoubleClick);
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTitulo.Location = new System.Drawing.Point(55, 60);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(719, 38);
            this.lblTitulo.TabIndex = 10;
            this.lblTitulo.Text = "Titulo";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgTitulo
            // 
            this.imgTitulo.BackColor = System.Drawing.Color.Transparent;
            this.imgTitulo.Location = new System.Drawing.Point(11, 60);
            this.imgTitulo.Name = "imgTitulo";
            this.imgTitulo.Size = new System.Drawing.Size(38, 38);
            this.imgTitulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgTitulo.TabIndex = 9;
            this.imgTitulo.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuarioLogin});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblUsuarioLogin
            // 
            this.lblUsuarioLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuarioLogin.Name = "lblUsuarioLogin";
            this.lblUsuarioLogin.Size = new System.Drawing.Size(50, 17);
            this.lblUsuarioLogin.Text = "Usuario:";
            // 
            // dgvDetalle1
            // 
            this.dgvDetalle1.AllowUserToAddRows = false;
            this.dgvDetalle1.AllowUserToDeleteRows = false;
            this.dgvDetalle1.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle1.Location = new System.Drawing.Point(11, 391);
            this.dgvDetalle1.MultiSelect = false;
            this.dgvDetalle1.Name = "dgvDetalle1";
            this.dgvDetalle1.ReadOnly = true;
            this.dgvDetalle1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle1.Size = new System.Drawing.Size(379, 145);
            this.dgvDetalle1.TabIndex = 17;
            // 
            // dgvDetalle2
            // 
            this.dgvDetalle2.AllowUserToAddRows = false;
            this.dgvDetalle2.AllowUserToDeleteRows = false;
            this.dgvDetalle2.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle2.Location = new System.Drawing.Point(395, 391);
            this.dgvDetalle2.MultiSelect = false;
            this.dgvDetalle2.Name = "dgvDetalle2";
            this.dgvDetalle2.ReadOnly = true;
            this.dgvDetalle2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle2.Size = new System.Drawing.Size(379, 145);
            this.dgvDetalle2.TabIndex = 18;
            // 
            // lblTituloDetalle1
            // 
            this.lblTituloDetalle1.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloDetalle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloDetalle1.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTituloDetalle1.Location = new System.Drawing.Point(12, 365);
            this.lblTituloDetalle1.Name = "lblTituloDetalle1";
            this.lblTituloDetalle1.Size = new System.Drawing.Size(376, 21);
            this.lblTituloDetalle1.TabIndex = 19;
            this.lblTituloDetalle1.Text = "Titulo";
            this.lblTituloDetalle1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTituloDetalle2
            // 
            this.lblTituloDetalle2.BackColor = System.Drawing.Color.Transparent;
            this.lblTituloDetalle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloDetalle2.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTituloDetalle2.Location = new System.Drawing.Point(394, 365);
            this.lblTituloDetalle2.Name = "lblTituloDetalle2";
            this.lblTituloDetalle2.Size = new System.Drawing.Size(380, 21);
            this.lblTituloDetalle2.TabIndex = 20;
            this.lblTituloDetalle2.Text = "Titulo";
            this.lblTituloDetalle2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pnlBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBusqueda.Controls.Add(this.button1);
            this.pnlBusqueda.Controls.Add(this.textBox1);
            this.pnlBusqueda.Controls.Add(this.label1);
            this.pnlBusqueda.Location = new System.Drawing.Point(11, 314);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(763, 42);
            this.pnlBusqueda.TabIndex = 21;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(655, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(557, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Busqueda";
            // 
            // FormularioLookUpConDobleDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.pnlBusqueda);
            this.Controls.Add(this.lblTituloDetalle2);
            this.Controls.Add(this.lblTituloDetalle1);
            this.Controls.Add(this.dgvDetalle2);
            this.Controls.Add(this.dgvDetalle1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvGrilla);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.imgTitulo);
            this.Controls.Add(this.Menu);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormularioLookUpConDobleDetalle";
            this.Text = "Busqueda";
            this.Load += new System.EventHandler(this.FormularioLookUp_Load);
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTitulo)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle2)).EndInit();
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip Menu;
        public System.Windows.Forms.ToolStripButton btnSalir;
        public System.Windows.Forms.DataGridView dgvGrilla;
        public System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.PictureBox imgTitulo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel lblUsuarioLogin;
        public System.Windows.Forms.DataGridView dgvDetalle1;
        public System.Windows.Forms.DataGridView dgvDetalle2;
        public System.Windows.Forms.Label lblTituloDetalle1;
        public System.Windows.Forms.Label lblTituloDetalle2;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}