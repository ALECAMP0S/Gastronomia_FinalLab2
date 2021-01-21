namespace Presentacion.Core.Cadeteria
{
    partial class _100001_Cadeteria
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCambiarCantidadItem = new System.Windows.Forms.Button();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.btnLookUpEmpleado = new System.Windows.Forms.Button();
            this.txtCodigoCadete = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbListaPrecio = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblPrecioUnitario = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.nudPrecio = new System.Windows.Forms.NumericUpDown();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.nudTOTAL = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.btnLookUpCliente = new System.Windows.Forms.Button();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtEnviar = new System.Windows.Forms.Button();
            this.lblClientes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTOTAL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCambiarCantidadItem
            // 
            this.btnCambiarCantidadItem.Location = new System.Drawing.Point(6, 512);
            this.btnCambiarCantidadItem.Name = "btnCambiarCantidadItem";
            this.btnCambiarCantidadItem.Size = new System.Drawing.Size(115, 42);
            this.btnCambiarCantidadItem.TabIndex = 104;
            this.btnCambiarCantidadItem.Text = "Disminuir Cantidad [F2]";
            this.btnCambiarCantidadItem.UseVisualStyleBackColor = true;
            this.btnCambiarCantidadItem.Click += new System.EventHandler(this.btnCambiarCantidadItem_Click_1);
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpleado.ForeColor = System.Drawing.Color.Maroon;
            this.lblEmpleado.Location = new System.Drawing.Point(12, 31);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(44, 21);
            this.lblEmpleado.TabIndex = 103;
            this.lblEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLookUpEmpleado
            // 
            this.btnLookUpEmpleado.Location = new System.Drawing.Point(170, 32);
            this.btnLookUpEmpleado.Name = "btnLookUpEmpleado";
            this.btnLookUpEmpleado.Size = new System.Drawing.Size(32, 23);
            this.btnLookUpEmpleado.TabIndex = 102;
            this.btnLookUpEmpleado.UseVisualStyleBackColor = true;
            this.btnLookUpEmpleado.Click += new System.EventHandler(this.btnLookUpEmpleado_Click_1);
            // 
            // txtCodigoCadete
            // 
            this.txtCodigoCadete.Location = new System.Drawing.Point(98, 33);
            this.txtCodigoCadete.Name = "txtCodigoCadete";
            this.txtCodigoCadete.Size = new System.Drawing.Size(66, 20);
            this.txtCodigoCadete.TabIndex = 101;
            this.txtCodigoCadete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoCadete_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(59, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 100;
            this.label13.Text = "Cadete";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 99;
            this.label11.Text = "Lista de Precio";
            // 
            // cmbListaPrecio
            // 
            this.cmbListaPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListaPrecio.FormattingEnabled = true;
            this.cmbListaPrecio.Location = new System.Drawing.Point(98, 6);
            this.cmbListaPrecio.Name = "cmbListaPrecio";
            this.cmbListaPrecio.Size = new System.Drawing.Size(198, 21);
            this.cmbListaPrecio.TabIndex = 98;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(535, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 97;
            this.label10.Text = "Fecha";
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(579, 7);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(195, 20);
            this.txtFecha.TabIndex = 96;
            this.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(6, 503);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(772, 5);
            this.panel3.TabIndex = 95;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(9, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(768, 4);
            this.panel2.TabIndex = 94;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(610, 67);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(49, 13);
            this.lblCantidad.TabIndex = 93;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblPrecioUnitario
            // 
            this.lblPrecioUnitario.AutoSize = true;
            this.lblPrecioUnitario.Location = new System.Drawing.Point(503, 67);
            this.lblPrecioUnitario.Name = "lblPrecioUnitario";
            this.lblPrecioUnitario.Size = new System.Drawing.Size(76, 13);
            this.lblPrecioUnitario.TabIndex = 92;
            this.lblPrecioUnitario.Text = "Precio Unitario";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(6, 67);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(50, 13);
            this.lblProducto.TabIndex = 91;
            this.lblProducto.Text = "Producto";
            // 
            // nudPrecio
            // 
            this.nudPrecio.DecimalPlaces = 2;
            this.nudPrecio.Enabled = false;
            this.nudPrecio.Location = new System.Drawing.Point(506, 83);
            this.nudPrecio.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(101, 20);
            this.nudPrecio.TabIndex = 90;
            this.nudPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(6, 84);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(492, 20);
            this.txtDescripcion.TabIndex = 89;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(703, 82);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 88;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // nudCantidad
            // 
            this.nudCantidad.DecimalPlaces = 2;
            this.nudCantidad.Enabled = false;
            this.nudCantidad.Location = new System.Drawing.Point(613, 83);
            this.nudCantidad.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(84, 20);
            this.nudCantidad.TabIndex = 87;
            this.nudCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudTOTAL
            // 
            this.nudTOTAL.DecimalPlaces = 2;
            this.nudTOTAL.Enabled = false;
            this.nudTOTAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTOTAL.Location = new System.Drawing.Point(571, 514);
            this.nudTOTAL.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudTOTAL.Name = "nudTOTAL";
            this.nudTOTAL.Size = new System.Drawing.Size(204, 38);
            this.nudTOTAL.TabIndex = 86;
            this.nudTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(458, 518);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 31);
            this.label4.TabIndex = 85;
            this.label4.Text = "TOTAL";
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGrilla.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGrilla.Location = new System.Drawing.Point(6, 111);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.ReadOnly = true;
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(772, 386);
            this.dgvGrilla.TabIndex = 84;
            this.dgvGrilla.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGrilla_CellMouseClick);
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(208, 36);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(52, 13);
            this.lblDireccion.TabIndex = 106;
            this.lblDireccion.Text = "Direccion";
            // 
            // btnLookUpCliente
            // 
            this.btnLookUpCliente.Location = new System.Drawing.Point(418, 5);
            this.btnLookUpCliente.Name = "btnLookUpCliente";
            this.btnLookUpCliente.Size = new System.Drawing.Size(32, 23);
            this.btnLookUpCliente.TabIndex = 108;
            this.btnLookUpCliente.UseVisualStyleBackColor = true;
            this.btnLookUpCliente.Click += new System.EventHandler(this.btnLookUpCliente_Click);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(307, 9);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(39, 13);
            this.lblCliente.TabIndex = 107;
            this.lblCliente.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(346, 7);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(66, 20);
            this.txtCliente.TabIndex = 109;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Location = new System.Drawing.Point(265, 34);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(135, 20);
            this.txtDireccion.TabIndex = 110;
            // 
            // txtEnviar
            // 
            this.txtEnviar.Location = new System.Drawing.Point(310, 514);
            this.txtEnviar.Name = "txtEnviar";
            this.txtEnviar.Size = new System.Drawing.Size(115, 42);
            this.txtEnviar.TabIndex = 111;
            this.txtEnviar.Text = "Enviar";
            this.txtEnviar.UseVisualStyleBackColor = true;
            this.txtEnviar.Click += new System.EventHandler(this.txtEnviar_Click);
            // 
            // lblClientes
            // 
            this.lblClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientes.ForeColor = System.Drawing.Color.Maroon;
            this.lblClientes.Location = new System.Drawing.Point(414, 34);
            this.lblClientes.Name = "lblClientes";
            this.lblClientes.Size = new System.Drawing.Size(110, 21);
            this.lblClientes.TabIndex = 112;
            this.lblClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _100001_Cadeteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblClientes);
            this.Controls.Add(this.txtEnviar);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.btnLookUpCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.btnCambiarCantidadItem);
            this.Controls.Add(this.lblEmpleado);
            this.Controls.Add(this.btnLookUpEmpleado);
            this.Controls.Add(this.txtCodigoCadete);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbListaPrecio);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblPrecioUnitario);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.nudPrecio);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.nudTOTAL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvGrilla);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "_100001_Cadeteria";
            this.Text = "_100001_Cadeteria";
            this.Load += new System.EventHandler(this._100001_Cadeteria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTOTAL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCambiarCantidadItem;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.Button btnLookUpEmpleado;
        private System.Windows.Forms.TextBox txtCodigoCadete;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbListaPrecio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblPrecioUnitario;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.NumericUpDown nudPrecio;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.NumericUpDown nudTOTAL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Button btnLookUpCliente;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button txtEnviar;
        private System.Windows.Forms.Label lblClientes;
    }
}