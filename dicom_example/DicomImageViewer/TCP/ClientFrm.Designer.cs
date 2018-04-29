namespace DicomImageViewer
{
    partial class ClientFrm
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSend = new System.Windows.Forms.Button();
            this.btnOpenServer = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(34, 38);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(99, 36);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Send file";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnOpenServer
            // 
            this.btnOpenServer.Location = new System.Drawing.Point(174, 38);
            this.btnOpenServer.Name = "btnOpenServer";
            this.btnOpenServer.Size = new System.Drawing.Size(99, 36);
            this.btnOpenServer.TabIndex = 0;
            this.btnOpenServer.Text = "Open Server";
            this.btnOpenServer.UseVisualStyleBackColor = true;
            this.btnOpenServer.Click += new System.EventHandler(this.btnOpenServer_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(42, 99);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(64, 20);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Status: ";
            // 
            // lblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContent.Location = new System.Drawing.Point(112, 99);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(13, 20);
            this.lblContent.TabIndex = 1;
            this.lblContent.Text = " ";
            // 
            // ClientFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 166);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnOpenServer);
            this.Controls.Add(this.btnSend);
            this.Name = "ClientFrm";
            this.Text = "ClientFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnOpenServer;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblContent;
    }
}