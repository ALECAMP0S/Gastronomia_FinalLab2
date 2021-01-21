namespace Presentacion.Core.Facturacion
{
    partial class Comprobante_LookUp
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
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.nudTOTAL = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTOTAL)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(12, 12);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.Size = new System.Drawing.Size(741, 422);
            this.dgvGrilla.TabIndex = 0;
            // 
            // nudTOTAL
            // 
            this.nudTOTAL.DecimalPlaces = 2;
            this.nudTOTAL.Enabled = false;
            this.nudTOTAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTOTAL.Location = new System.Drawing.Point(549, 440);
            this.nudTOTAL.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudTOTAL.Name = "nudTOTAL";
            this.nudTOTAL.Size = new System.Drawing.Size(204, 38);
            this.nudTOTAL.TabIndex = 56;
            this.nudTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(436, 444);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 31);
            this.label4.TabIndex = 55;
            this.label4.Text = "TOTAL";
            // 
            // Comprobante_LookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 490);
            this.Controls.Add(this.nudTOTAL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvGrilla);
            this.Name = "Comprobante_LookUp";
            this.Text = "Comprobante_LookUp";
            this.Load += new System.EventHandler(this.Comprobante_LookUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTOTAL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.NumericUpDown nudTOTAL;
        private System.Windows.Forms.Label label4;
    }
}