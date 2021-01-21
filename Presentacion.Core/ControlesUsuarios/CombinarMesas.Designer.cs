namespace Presentacion.Core.ControlesUsuarios
{
    partial class CombinarMesas
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnCombinar = new System.Windows.Forms.Button();
            this.cmbMesa1 = new System.Windows.Forms.ComboBox();
            this.cmbMesa2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(66, 86);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(121, 41);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnCombinar
            // 
            this.btnCombinar.Location = new System.Drawing.Point(259, 86);
            this.btnCombinar.Name = "btnCombinar";
            this.btnCombinar.Size = new System.Drawing.Size(127, 41);
            this.btnCombinar.TabIndex = 3;
            this.btnCombinar.Text = "Combinar";
            this.btnCombinar.UseVisualStyleBackColor = true;
            this.btnCombinar.Click += new System.EventHandler(this.btnCombinar_Click);
            // 
            // cmbMesa1
            // 
            this.cmbMesa1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMesa1.FormattingEnabled = true;
            this.cmbMesa1.Location = new System.Drawing.Point(54, 42);
            this.cmbMesa1.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMesa1.Name = "cmbMesa1";
            this.cmbMesa1.Size = new System.Drawing.Size(156, 21);
            this.cmbMesa1.TabIndex = 8;
            // 
            // cmbMesa2
            // 
            this.cmbMesa2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMesa2.FormattingEnabled = true;
            this.cmbMesa2.Location = new System.Drawing.Point(230, 42);
            this.cmbMesa2.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMesa2.Name = "cmbMesa2";
            this.cmbMesa2.Size = new System.Drawing.Size(156, 21);
            this.cmbMesa2.TabIndex = 7;
            // 
            // CombinarMesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 145);
            this.Controls.Add(this.cmbMesa1);
            this.Controls.Add(this.cmbMesa2);
            this.Controls.Add(this.btnCombinar);
            this.Controls.Add(this.btnCerrar);
            this.Name = "CombinarMesas";
            this.Text = "CombinarMesas";
            this.Load += new System.EventHandler(this.CombinarMesas_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnCombinar;
        private System.Windows.Forms.ComboBox cmbMesa1;
        private System.Windows.Forms.ComboBox cmbMesa2;
    }
}