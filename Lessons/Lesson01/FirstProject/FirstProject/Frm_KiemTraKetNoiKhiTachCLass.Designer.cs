namespace FirstProject
{
    partial class Frm_KiemTraKetNoiKhiTachCLass
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
            this.btnKiemTraKetNoi = new System.Windows.Forms.Button();
            this.ckbWinNT = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnKiemTraKetNoi
            // 
            this.btnKiemTraKetNoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKiemTraKetNoi.Location = new System.Drawing.Point(155, 40);
            this.btnKiemTraKetNoi.Name = "btnKiemTraKetNoi";
            this.btnKiemTraKetNoi.Size = new System.Drawing.Size(420, 155);
            this.btnKiemTraKetNoi.TabIndex = 0;
            this.btnKiemTraKetNoi.Text = "Check Connect to Sql server";
            this.btnKiemTraKetNoi.UseVisualStyleBackColor = true;
            this.btnKiemTraKetNoi.Click += new System.EventHandler(this.btnKiemTraKetNoi_Click);
            // 
            // ckbWinNT
            // 
            this.ckbWinNT.AutoSize = true;
            this.ckbWinNT.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbWinNT.Location = new System.Drawing.Point(282, 201);
            this.ckbWinNT.Name = "ckbWinNT";
            this.ckbWinNT.Size = new System.Drawing.Size(113, 33);
            this.ckbWinNT.TabIndex = 1;
            this.ckbWinNT.Text = "WinNT ";
            this.ckbWinNT.UseVisualStyleBackColor = true;
            this.ckbWinNT.CheckedChanged += new System.EventHandler(this.ckbWinNT_CheckedChanged);
            // 
            // Frm_KiemTraKetNoiKhiTachCLass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ckbWinNT);
            this.Controls.Add(this.btnKiemTraKetNoi);
            this.Name = "Frm_KiemTraKetNoiKhiTachCLass";
            this.Text = "Frm_KiemTraKetNoiKhiTachCLass";
            this.Load += new System.EventHandler(this.Frm_KiemTraKetNoiKhiTachCLass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKiemTraKetNoi;
        private System.Windows.Forms.CheckBox ckbWinNT;
    }
}