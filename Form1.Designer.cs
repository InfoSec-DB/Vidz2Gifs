namespace VideoToGifConverter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Declare controls
        private System.Windows.Forms.TextBox txtVideoPath;
        private System.Windows.Forms.Button btnBrowseVideo;
        private System.Windows.Forms.Label lblVideoPath;

        private System.Windows.Forms.TextBox txtGifPath;
        private System.Windows.Forms.Button btnSaveGif;
        private System.Windows.Forms.Label lblGifPath;

        private System.Windows.Forms.CheckBox chkEnableWatermark;
        private System.Windows.Forms.TextBox txtWatermarkText;
        private System.Windows.Forms.Label lblWatermarkText;

        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.ProgressBar progressBar;

        // Custom close button
        private System.Windows.Forms.Button btnClose;

        // New controls for selection
        private System.Windows.Forms.RadioButton rdoProcessVideo;
        private System.Windows.Forms.RadioButton rdoProcessImage;

        // New controls for image processing
        private System.Windows.Forms.Label lblImagePath;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnBrowseImage;

        private System.Windows.Forms.Label lblImageOutputPath;
        private System.Windows.Forms.TextBox txtImageOutputPath;
        private System.Windows.Forms.Button btnSaveImage;

        // Label for credits
        private System.Windows.Forms.Label label1;

        // Note: Removed the variables 'dragging', 'dragCursorPoint', and 'dragFormPoint' from here

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        ///   true if managed resources should be disposed; otherwise, false.
        /// </param>
        protected override void Dispose(bool disposing) // Correctly override Dispose method
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing); // Call base class Dispose method
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtVideoPath = new System.Windows.Forms.TextBox();
            this.btnBrowseVideo = new System.Windows.Forms.Button();
            this.lblVideoPath = new System.Windows.Forms.Label();
            this.txtGifPath = new System.Windows.Forms.TextBox();
            this.btnSaveGif = new System.Windows.Forms.Button();
            this.lblGifPath = new System.Windows.Forms.Label();
            this.chkEnableWatermark = new System.Windows.Forms.CheckBox();
            this.txtWatermarkText = new System.Windows.Forms.TextBox();
            this.lblWatermarkText = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnClose = new System.Windows.Forms.Button();
            this.rdoProcessVideo = new System.Windows.Forms.RadioButton();
            this.rdoProcessImage = new System.Windows.Forms.RadioButton();
            this.lblImagePath = new System.Windows.Forms.Label();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.lblImageOutputPath = new System.Windows.Forms.Label();
            this.txtImageOutputPath = new System.Windows.Forms.TextBox();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtVideoPath
            // 
            this.txtVideoPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtVideoPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVideoPath.ForeColor = System.Drawing.Color.White;
            this.txtVideoPath.Location = new System.Drawing.Point(15, 68);
            this.txtVideoPath.Name = "txtVideoPath";
            this.txtVideoPath.Size = new System.Drawing.Size(380, 23);
            this.txtVideoPath.TabIndex = 2;
            // 
            // btnBrowseVideo
            // 
            this.btnBrowseVideo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(151)))), ((int)(((byte)(234)))));
            this.btnBrowseVideo.FlatAppearance.BorderSize = 0;
            this.btnBrowseVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseVideo.ForeColor = System.Drawing.Color.White;
            this.btnBrowseVideo.Location = new System.Drawing.Point(400, 67);
            this.btnBrowseVideo.Name = "btnBrowseVideo";
            this.btnBrowseVideo.Size = new System.Drawing.Size(75, 25);
            this.btnBrowseVideo.TabIndex = 3;
            this.btnBrowseVideo.Text = "Browse";
            this.btnBrowseVideo.UseVisualStyleBackColor = false;
            this.btnBrowseVideo.Click += new System.EventHandler(this.BtnBrowseVideo_Click);
            // 
            // lblVideoPath
            // 
            this.lblVideoPath.AutoSize = true;
            this.lblVideoPath.ForeColor = System.Drawing.Color.White;
            this.lblVideoPath.Location = new System.Drawing.Point(12, 50);
            this.lblVideoPath.Name = "lblVideoPath";
            this.lblVideoPath.Size = new System.Drawing.Size(92, 15);
            this.lblVideoPath.TabIndex = 10;
            this.lblVideoPath.Text = "Select Video File";
            // 
            // txtGifPath
            // 
            this.txtGifPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtGifPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGifPath.ForeColor = System.Drawing.Color.White;
            this.txtGifPath.Location = new System.Drawing.Point(15, 118);
            this.txtGifPath.Name = "txtGifPath";
            this.txtGifPath.Size = new System.Drawing.Size(380, 23);
            this.txtGifPath.TabIndex = 4;
            // 
            // btnSaveGif
            // 
            this.btnSaveGif.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(151)))), ((int)(((byte)(234)))));
            this.btnSaveGif.FlatAppearance.BorderSize = 0;
            this.btnSaveGif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveGif.ForeColor = System.Drawing.Color.White;
            this.btnSaveGif.Location = new System.Drawing.Point(400, 117);
            this.btnSaveGif.Name = "btnSaveGif";
            this.btnSaveGif.Size = new System.Drawing.Size(75, 25);
            this.btnSaveGif.TabIndex = 5;
            this.btnSaveGif.Text = "Save As";
            this.btnSaveGif.UseVisualStyleBackColor = false;
            this.btnSaveGif.Click += new System.EventHandler(this.BtnSaveGif_Click);
            // 
            // lblGifPath
            // 
            this.lblGifPath.AutoSize = true;
            this.lblGifPath.ForeColor = System.Drawing.Color.White;
            this.lblGifPath.Location = new System.Drawing.Point(12, 100);
            this.lblGifPath.Name = "lblGifPath";
            this.lblGifPath.Size = new System.Drawing.Size(92, 15);
            this.lblGifPath.TabIndex = 11;
            this.lblGifPath.Text = "GIF Output Path";
            // 
            // chkEnableWatermark
            // 
            this.chkEnableWatermark.AutoSize = true;
            this.chkEnableWatermark.BackColor = System.Drawing.Color.Transparent;
            this.chkEnableWatermark.ForeColor = System.Drawing.Color.White;
            this.chkEnableWatermark.Location = new System.Drawing.Point(15, 155);
            this.chkEnableWatermark.Name = "chkEnableWatermark";
            this.chkEnableWatermark.Size = new System.Drawing.Size(122, 19);
            this.chkEnableWatermark.TabIndex = 6;
            this.chkEnableWatermark.Text = "Enable Watermark";
            this.chkEnableWatermark.UseVisualStyleBackColor = false;
            // 
            // txtWatermarkText
            // 
            this.txtWatermarkText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtWatermarkText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWatermarkText.ForeColor = System.Drawing.Color.White;
            this.txtWatermarkText.Location = new System.Drawing.Point(15, 198);
            this.txtWatermarkText.Name = "txtWatermarkText";
            this.txtWatermarkText.Size = new System.Drawing.Size(460, 23);
            this.txtWatermarkText.TabIndex = 7;
            // 
            // lblWatermarkText
            // 
            this.lblWatermarkText.AutoSize = true;
            this.lblWatermarkText.ForeColor = System.Drawing.Color.White;
            this.lblWatermarkText.Location = new System.Drawing.Point(12, 180);
            this.lblWatermarkText.Name = "lblWatermarkText";
            this.lblWatermarkText.Size = new System.Drawing.Size(89, 15);
            this.lblWatermarkText.TabIndex = 12;
            this.lblWatermarkText.Text = "Watermark Text";
            // 
            // btnConvert
            // 
            this.btnConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(151)))), ((int)(((byte)(234)))));
            this.btnConvert.FlatAppearance.BorderSize = 0;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConvert.ForeColor = System.Drawing.Color.White;
            this.btnConvert.Location = new System.Drawing.Point(15, 235);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(460, 35);
            this.btnConvert.TabIndex = 8;
            this.btnConvert.Text = "Convert to GIF";
            this.btnConvert.UseVisualStyleBackColor = false;
            this.btnConvert.Click += new System.EventHandler(this.BtnConvert_Click);
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(151)))), ((int)(((byte)(234)))));
            this.progressBar.Location = new System.Drawing.Point(15, 280);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(460, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(475, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 99;
            this.btnClose.Text = "✖";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            this.btnClose.MouseEnter += new System.EventHandler(this.BtnClose_MouseEnter);
            this.btnClose.MouseLeave += new System.EventHandler(this.BtnClose_MouseLeave);
            // 
            // rdoProcessVideo
            // 
            this.rdoProcessVideo.AutoSize = true;
            this.rdoProcessVideo.Location = new System.Drawing.Point(15, 15);
            this.rdoProcessVideo.Name = "rdoProcessVideo";
            this.rdoProcessVideo.Size = new System.Drawing.Size(98, 19);
            this.rdoProcessVideo.TabIndex = 0;
            this.rdoProcessVideo.TabStop = true;
            this.rdoProcessVideo.Text = "Process Video";
            this.rdoProcessVideo.UseVisualStyleBackColor = true;
            this.rdoProcessVideo.CheckedChanged += new System.EventHandler(this.RdoProcessVideo_CheckedChanged);
            // 
            // rdoProcessImage
            // 
            this.rdoProcessImage.AutoSize = true;
            this.rdoProcessImage.Location = new System.Drawing.Point(130, 15);
            this.rdoProcessImage.Name = "rdoProcessImage";
            this.rdoProcessImage.Size = new System.Drawing.Size(101, 19);
            this.rdoProcessImage.TabIndex = 1;
            this.rdoProcessImage.TabStop = true;
            this.rdoProcessImage.Text = "Process Image";
            this.rdoProcessImage.UseVisualStyleBackColor = true;
            this.rdoProcessImage.CheckedChanged += new System.EventHandler(this.RdoProcessImage_CheckedChanged);
            // 
            // lblImagePath
            // 
            this.lblImagePath.AutoSize = true;
            this.lblImagePath.ForeColor = System.Drawing.Color.White;
            this.lblImagePath.Location = new System.Drawing.Point(12, 50);
            this.lblImagePath.Name = "lblImagePath";
            this.lblImagePath.Size = new System.Drawing.Size(95, 15);
            this.lblImagePath.TabIndex = 20;
            this.lblImagePath.Text = "Select Image File";
            // 
            // txtImagePath
            // 
            this.txtImagePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtImagePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImagePath.ForeColor = System.Drawing.Color.White;
            this.txtImagePath.Location = new System.Drawing.Point(15, 68);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(380, 23);
            this.txtImagePath.TabIndex = 2;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(151)))), ((int)(((byte)(234)))));
            this.btnBrowseImage.FlatAppearance.BorderSize = 0;
            this.btnBrowseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseImage.ForeColor = System.Drawing.Color.White;
            this.btnBrowseImage.Location = new System.Drawing.Point(400, 67);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(75, 25);
            this.btnBrowseImage.TabIndex = 3;
            this.btnBrowseImage.Text = "Browse";
            this.btnBrowseImage.UseVisualStyleBackColor = false;
            this.btnBrowseImage.Click += new System.EventHandler(this.BtnBrowseImage_Click);
            // 
            // lblImageOutputPath
            // 
            this.lblImageOutputPath.AutoSize = true;
            this.lblImageOutputPath.ForeColor = System.Drawing.Color.White;
            this.lblImageOutputPath.Location = new System.Drawing.Point(12, 100);
            this.lblImageOutputPath.Name = "lblImageOutputPath";
            this.lblImageOutputPath.Size = new System.Drawing.Size(108, 15);
            this.lblImageOutputPath.TabIndex = 21;
            this.lblImageOutputPath.Text = "Image Output Path";
            // 
            // txtImageOutputPath
            // 
            this.txtImageOutputPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtImageOutputPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImageOutputPath.ForeColor = System.Drawing.Color.White;
            this.txtImageOutputPath.Location = new System.Drawing.Point(15, 118);
            this.txtImageOutputPath.Name = "txtImageOutputPath";
            this.txtImageOutputPath.Size = new System.Drawing.Size(380, 23);
            this.txtImageOutputPath.TabIndex = 4;
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(151)))), ((int)(((byte)(234)))));
            this.btnSaveImage.FlatAppearance.BorderSize = 0;
            this.btnSaveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveImage.ForeColor = System.Drawing.Color.White;
            this.btnSaveImage.Location = new System.Drawing.Point(400, 117);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(75, 25);
            this.btnSaveImage.TabIndex = 5;
            this.btnSaveImage.Text = "Save As";
            this.btnSaveImage.UseVisualStyleBackColor = false;
            this.btnSaveImage.Click += new System.EventHandler(this.BtnSaveImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(390, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Made by CBKB";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(498, 340);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.rdoProcessVideo);
            this.Controls.Add(this.rdoProcessImage);
            this.Controls.Add(this.lblVideoPath);
            this.Controls.Add(this.txtVideoPath);
            this.Controls.Add(this.btnBrowseVideo);
            this.Controls.Add(this.lblGifPath);
            this.Controls.Add(this.txtGifPath);
            this.Controls.Add(this.btnSaveGif);
            this.Controls.Add(this.lblImagePath);
            this.Controls.Add(this.txtImagePath);
            this.Controls.Add(this.btnBrowseImage);
            this.Controls.Add(this.lblImageOutputPath);
            this.Controls.Add(this.txtImageOutputPath);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.chkEnableWatermark);
            this.Controls.Add(this.lblWatermarkText);
            this.Controls.Add(this.txtWatermarkText);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video and Image Watermarking Tool";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
