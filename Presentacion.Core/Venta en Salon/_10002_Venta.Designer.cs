namespace Presentacion.Core.Venta_en_Salon
{
    partial class _10002_Venta
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
            this.txtCodigoEmpleado = new System.Windows.Forms.TextBox();
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
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTOTAL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCambiarCantidadItem
            // 
            this.btnCambiarCantidadItem.Location = new System.Drawing.Point(5, 513);
            this.btnCambiarCantidadItem.Name = "btnCambiarCantidadItem";
            this.btnCambiarCantidadItem.Size = new System.Drawing.Size(115, 42);
            this.btnCambiarCantidadItem.TabIndex = 83;
            this.btnCambiarCantidadItem.Text = "Disminuir Cantidad [F2]";
            this.btnCambiarCantidadItem.UseVisualStyleBackColor = true;
            this.btnCambiarCantidadItem.Click += new System.EventHandler(this.btnCambiarCantidadItem_Click);
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpleado.ForeColor = System.Drawing.Color.Maroon;
            this.lblEmpleado.Location = new System.Drawing.Point(207, 34);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(565, 21);
            this.lblEmpleado.TabIndex = 80;
            this.lblEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLookUpEmpleado
            // 
            this.btnLookUpEmpleado.Location = new System.Drawing.Point(169, 33);
            this.btnLookUpEmpleado.Name = "btnLookUpEmpleado";
            this.btnLookUpEmpleado.Size = new System.Drawing.Size(32, 23);
            this.btnLookUpEmpleado.TabIndex = 78;
            this.btnLookUpEmpleado.UseVisualStyleBackColor = true;
            this.btnLookUpEmpleado.Click += new System.EventHandler(this.btnLookUpEmpleado_Click);
            // 
            // txtCodigoEmpleado
            // 
            this.txtCodigoEmpleado.Location = new System.Drawing.Point(97, 34);
            this.txtCodigoEmpleado.Name = "txtCodigoEmpleado";
            this.txtCodigoEmpleado.Size = new System.Drawing.Size(66, 20);
            this.txtCodigoEmpleado.TabIndex = 77;
            this.txtCodigoEmpleado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoEmpleado_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(58, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 13);
            this.label13.TabIndex = 76;
            this.label13.Text = "Mozo";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 72;
            this.label11.Text = "Lista de Precio";
            // 
            // cmbListaPrecio
            // 
            this.cmbListaPrecio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbListaPrecio.FormattingEnabled = true;
            this.cmbListaPrecio.Location = new System.Drawing.Point(97, 7);
            this.cmbListaPrecio.Name = "cmbListaPrecio";
            this.cmbListaPrecio.Size = new System.Drawing.Size(221, 21);
            this.cmbListaPrecio.TabIndex = 71;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(534, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 70;
            this.label10.Text = "Fecha";
            // 
            // txtFecha
            // 
            this.txtFecha.Enabled = false;
            this.txtFecha.Location = new System.Drawing.Point(578, 8);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(195, 20);
            this.txtFecha.TabIndex = 69;
            this.txtFecha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(5, 504);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(772, 5);
            this.panel3.TabIndex = 68;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(8, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(768, 4);
            this.panel2.TabIndex = 67;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(609, 68);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(49, 13);
            this.lblCantidad.TabIndex = 66;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblPrecioUnitario
            // 
            this.lblPrecioUnitario.AutoSize = true;
            this.lblPrecioUnitario.Location = new System.Drawing.Point(502, 68);
            this.lblPrecioUnitario.Name = "lblPrecioUnitario";
            this.lblPrecioUnitario.Size = new System.Drawing.Size(76, 13);
            this.lblPrecioUnitario.TabIndex = 65;
            this.lblPrecioUnitario.Text = "Precio Unitario";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Location = new System.Drawing.Point(5, 68);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(50, 13);
            this.lblProducto.TabIndex = 64;
            this.lblProducto.Text = "Producto";
            // 
            // nudPrecio
            // 
            this.nudPrecio.DecimalPlaces = 2;
            this.nudPrecio.Enabled = false;
            this.nudPrecio.Location = new System.Drawing.Point(505, 84);
            this.nudPrecio.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(101, 20);
            this.nudPrecio.TabIndex = 62;
            this.nudPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(5, 85);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(492, 20);
            this.txtDescripcion.TabIndex = 61;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(702, 83);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 58;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // nudCantidad
            // 
            this.nudCantidad.DecimalPlaces = 2;
            this.nudCantidad.Enabled = false;
            this.nudCantidad.Location = new System.Drawing.Point(612, 84);
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
            this.nudCantidad.TabIndex = 55;
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
            this.nudTOTAL.Location = new System.Drawing.Point(570, 515);
            this.nudTOTAL.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudTOTAL.Name = "nudTOTAL";
            this.nudTOTAL.Size = new System.Drawing.Size(204, 38);
            this.nudTOTAL.TabIndex = 54;
            this.nudTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(457, 519);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 31);
            this.label4.TabIndex = 53;
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
            this.dgvGrilla.Location = new System.Drawing.Point(5, 112);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.ReadOnly = true;
            this.dgvGrilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.Size = new System.Drawing.Size(772, 386);
            this.dgvGrilla.TabIndex = 48;
            this.dgvGrilla.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGrilla_CellClick);
            this.dgvGrilla.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGrilla_CellMouseClick);
            // 
            // _10002_Venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnCambiarCantidadItem);
            this.Controls.Add(this.lblEmpleado);
            this.Controls.Add(this.btnLookUpEmpleado);
            this.Controls.Add(this.txtCodigoEmpleado);
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
            this.Name = "_10002_Venta";
            this.Text = "Venta";
            this.Load += new System.EventHandler(this._10002_Venta_Load);
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
        private System.Windows.Forms.TextBox txtCodigoEmpleado;
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
        private System.Windows.Forms.FontDialog fontDialog1;
    }
}