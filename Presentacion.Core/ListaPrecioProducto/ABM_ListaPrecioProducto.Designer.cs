namespace Presentacion.Core.ListaPrecioProducto
{
    partial class ABM_ListaPrecioProducto
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
            this.txtPrecioPublico = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.cmdLista = new System.Windows.Forms.ComboBox();
            this.nudPrecioCosto = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioCosto)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPrecioPublico
            // 
            this.txtPrecioPublico.Enabled = false;
            this.txtPrecioPublico.Location = new System.Drawing.Point(151, 200);
            this.txtPrecioPublico.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrecioPublico.Name = "txtPrecioPublico";
            this.txtPrecioPublico.Size = new System.Drawing.Size(186, 20);
            this.txtPrecioPublico.TabIndex = 23;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(150, 234);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(186, 20);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // cmbProducto
            // 
            this.cmbProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(152, 131);
            this.cmbProducto.Margin = new System.Windows.Forms.Padding(2);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(185, 21);
            this.cmbProducto.TabIndex = 19;
            // 
            // cmdLista
            // 
            this.cmdLista.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdLista.FormattingEnabled = true;
            this.cmdLista.Location = new System.Drawing.Point(151, 101);
            this.cmdLista.Margin = new System.Windows.Forms.Padding(2);
            this.cmdLista.Name = "cmdLista";
            this.cmdLista.Size = new System.Drawing.Size(186, 21);
            this.cmdLista.TabIndex = 20;
            // 
            // nudPrecioCosto
            // 
            this.nudPrecioCosto.Location = new System.Drawing.Point(152, 166);
            this.nudPrecioCosto.Margin = new System.Windows.Forms.Padding(2);
            this.nudPrecioCosto.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudPrecioCosto.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPrecioCosto.Name = "nudPrecioCosto";
            this.nudPrecioCosto.Size = new System.Drawing.Size(184, 20);
            this.nudPrecioCosto.TabIndex = 18;
            this.nudPrecioCosto.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPrecioCosto.ValueChanged += new System.EventHandler(this.nudPrecioCosto_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 240);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Fecha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 200);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Precio Publico";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 107);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Lista";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 166);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Precio Costo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Producto";
            // 
            // ABM_ListaPrecioProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 312);
            this.Controls.Add(this.txtPrecioPublico);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.cmdLista);
            this.Controls.Add(this.nudPrecioCosto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "ABM_ListaPrecioProducto";
            this.Text = "ABM_ListaPrecioProducto";
            this.Load += new System.EventHandler(this.ABM_ListaPrecioProducto_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.nudPrecioCosto, 0);
            this.Controls.SetChildIndex(this.cmdLista, 0);
            this.Controls.SetChildIndex(this.cmbProducto, 0);
            this.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.Controls.SetChildIndex(this.txtPrecioPublico, 0);
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecioCosto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrecioPublico;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.ComboBox cmdLista;
        private System.Windows.Forms.NumericUpDown nudPrecioCosto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}