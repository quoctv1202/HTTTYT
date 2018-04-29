namespace DicomImageViewer
{
    partial class MainForm
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
            this.bnOpen = new System.Windows.Forms.Button();
            this.bnTags = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.imagePanelControl = new DicomImageViewer.ImagePanelControl();
            this.SuspendLayout();
            // 
            // bnOpen
            // 
            this.bnOpen.Location = new System.Drawing.Point(35, 78);
            this.bnOpen.Name = "bnOpen";
            this.bnOpen.Size = new System.Drawing.Size(117, 46);
            this.bnOpen.TabIndex = 0;
            this.bnOpen.Text = "Open File DICOM";
            this.bnOpen.UseVisualStyleBackColor = true;
            this.bnOpen.Click += new System.EventHandler(this.bnOpen_Click);
            // 
            // bnTags
            // 
            this.bnTags.Location = new System.Drawing.Point(35, 310);
            this.bnTags.Name = "bnTags";
            this.bnTags.Size = new System.Drawing.Size(117, 47);
            this.bnTags.TabIndex = 1;
            this.bnTags.Text = "DICOM Tags";
            this.bnTags.UseVisualStyleBackColor = true;
            this.bnTags.Click += new System.EventHandler(this.bnTags_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(35, 536);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(117, 43);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send to...";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // imagePanelControl
            // 
            this.imagePanelControl.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.imagePanelControl.BackColor = System.Drawing.SystemColors.Control;
            this.imagePanelControl.CausesValidation = false;
            this.imagePanelControl.Location = new System.Drawing.Point(185, 9);
            this.imagePanelControl.Name = "imagePanelControl";
            this.imagePanelControl.Size = new System.Drawing.Size(800, 647);
            this.imagePanelControl.TabIndex = 1;
            this.imagePanelControl.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(994, 668);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.bnTags);
            this.Controls.Add(this.imagePanelControl);
            this.Controls.Add(this.bnOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chương Trình Gửi/Nhận/Đọc DICOM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnOpen;
        private ImagePanelControl imagePanelControl;
        private System.Windows.Forms.Button bnTags;
        private System.Windows.Forms.Button btnSend;
    }
}

