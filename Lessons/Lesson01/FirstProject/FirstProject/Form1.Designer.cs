namespace FirstProject
{
    partial class Form1
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
            this.btnConnectToSQL = new System.Windows.Forms.Button();
            this.ckbWinNT = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnConnectToSQL
            // 
            this.btnConnectToSQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectToSQL.Location = new System.Drawing.Point(167, 61);
            this.btnConnectToSQL.Name = "btnConnectToSQL";
            this.btnConnectToSQL.Size = new System.Drawing.Size(395, 164);
            this.btnConnectToSQL.TabIndex = 0;
            this.btnConnectToSQL.Text = "Connect to SQL Server";
            this.btnConnectToSQL.UseVisualStyleBackColor = true;
            this.btnConnectToSQL.Click += new System.EventHandler(this.btnConnectToSQL_Click);
            // 
            // ckbWinNT
            // 
            this.ckbWinNT.AutoSize = true;
            this.ckbWinNT.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbWinNT.Location = new System.Drawing.Point(180, 250);
            this.ckbWinNT.Name = "ckbWinNT";
            this.ckbWinNT.Size = new System.Drawing.Size(107, 33);
            this.ckbWinNT.TabIndex = 1;
            this.ckbWinNT.Text = "WinNT";
            this.ckbWinNT.UseVisualStyleBackColor = true;
            this.ckbWinNT.CheckedChanged += new System.EventHandler(this.ckbWinNT_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ckbWinNT);
            this.Controls.Add(this.btnConnectToSQL);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnectToSQL;
        private System.Windows.Forms.CheckBox ckbWinNT;
    }
}

