namespace ProjectConnection.DungThuVien
{
    partial class FrmCheckConnect03
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
            this.btnCheckConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCheckConnect
            // 
            this.btnCheckConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckConnect.Location = new System.Drawing.Point(104, 80);
            this.btnCheckConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnCheckConnect.Name = "btnCheckConnect";
            this.btnCheckConnect.Size = new System.Drawing.Size(448, 166);
            this.btnCheckConnect.TabIndex = 2;
            this.btnCheckConnect.Text = "Check connect to Sql server ";
            this.btnCheckConnect.UseVisualStyleBackColor = true;
            this.btnCheckConnect.Click += new System.EventHandler(this.btnCheckConnect_Click);
            // 
            // FrmCheckConnect03
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCheckConnect);
            this.Name = "FrmCheckConnect03";
            this.Text = "FrmCheckConnect03";
            this.Load += new System.EventHandler(this.FrmCheckConnect03_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCheckConnect;
    }
}