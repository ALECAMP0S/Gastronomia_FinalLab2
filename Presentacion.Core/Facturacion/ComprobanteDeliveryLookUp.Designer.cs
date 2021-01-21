namespace Presentacion.Core.Facturacion
{
    partial class ComprobanteDeliveryLookUp
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
            this.nudTOTAL = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nudTOTAL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // nudTOTAL
            // 
            this.nudTOTAL.DecimalPlaces = 2;
            this.nudTOTAL.Enabled = false;
            this.nudTOTAL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudTOTAL.Location = new System.Drawing.Point(539, 427);
            this.nudTOTAL.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nudTOTAL.Name = "nudTOTAL";
            this.nudTOTAL.Size = new System.Drawing.Size(204, 38);
            this.nudTOTAL.TabIndex = 59;
            this.nudTOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(426, 431);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 31);
            this.label4.TabIndex = 58;
            this.label4.Text = "TOTAL";
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(2, 5);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.Size = new System.Drawing.Size(741, 416);
            this.dgvGrilla.TabIndex = 57;
            // 
            // ComprobanteDeliveryLookUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 470);
            this.Controls.Add(this.nudTOTAL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvGrilla);
            this.Name = "ComprobanteDeliveryLookUp";
            this.Text = "ComprobanteDeliveryLookUp";
            this.Load += new System.EventHandler(this.ComprobanteDeliveryLookUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudTOTAL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nudTOTAL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvGrilla;
    }
}