namespace VideoCall
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.check_cameraEnabled = new System.Windows.Forms.CheckBox();
            this.parrotGradientPanel1 = new ReaLTaiizor.Controls.ParrotGradientPanel();
            this.check_saveVideo = new System.Windows.Forms.CheckBox();
            this.combo_cameras = new ReaLTaiizor.Controls.AloneComboBox();
            this.txt_insFPS = new ReaLTaiizor.Controls.BigTextBox();
            this.txt_insIpAI = new ReaLTaiizor.Controls.BigTextBox();
            this.txt_serverIp = new ReaLTaiizor.Controls.BigTextBox();
            this.txt_messageReceived = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.parrotGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 658);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1765, 188);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(45, 144);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1765, 507);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(281, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Inserisci IP Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(21, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 29);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select Camera";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(529, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "Inserisci IP AI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.Location = new System.Drawing.Point(713, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 29);
            this.label4.TabIndex = 12;
            this.label4.Text = "Inserisci FPS";
            // 
            // check_cameraEnabled
            // 
            this.check_cameraEnabled.AutoSize = true;
            this.check_cameraEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.check_cameraEnabled.Location = new System.Drawing.Point(904, 20);
            this.check_cameraEnabled.Name = "check_cameraEnabled";
            this.check_cameraEnabled.Size = new System.Drawing.Size(198, 30);
            this.check_cameraEnabled.TabIndex = 13;
            this.check_cameraEnabled.Text = "Camera Enabled";
            this.check_cameraEnabled.UseVisualStyleBackColor = true;
            // 
            // parrotGradientPanel1
            // 
            this.parrotGradientPanel1.BottomLeft = System.Drawing.Color.WhiteSmoke;
            this.parrotGradientPanel1.BottomRight = System.Drawing.Color.Silver;
            this.parrotGradientPanel1.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            this.parrotGradientPanel1.Controls.Add(this.txt_messageReceived);
            this.parrotGradientPanel1.Controls.Add(this.check_saveVideo);
            this.parrotGradientPanel1.Controls.Add(this.combo_cameras);
            this.parrotGradientPanel1.Controls.Add(this.txt_insFPS);
            this.parrotGradientPanel1.Controls.Add(this.txt_insIpAI);
            this.parrotGradientPanel1.Controls.Add(this.txt_serverIp);
            this.parrotGradientPanel1.Controls.Add(this.label4);
            this.parrotGradientPanel1.Controls.Add(this.check_cameraEnabled);
            this.parrotGradientPanel1.Controls.Add(this.label1);
            this.parrotGradientPanel1.Controls.Add(this.label2);
            this.parrotGradientPanel1.Controls.Add(this.label3);
            this.parrotGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.parrotGradientPanel1.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.parrotGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.parrotGradientPanel1.Name = "parrotGradientPanel1";
            this.parrotGradientPanel1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.parrotGradientPanel1.PrimerColor = System.Drawing.Color.White;
            this.parrotGradientPanel1.Size = new System.Drawing.Size(1924, 138);
            this.parrotGradientPanel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.parrotGradientPanel1.Style = ReaLTaiizor.Controls.ParrotGradientPanel.GradientStyle.Corners;
            this.parrotGradientPanel1.TabIndex = 15;
            this.parrotGradientPanel1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.parrotGradientPanel1.TopLeft = System.Drawing.Color.DeepSkyBlue;
            this.parrotGradientPanel1.TopRight = System.Drawing.Color.Turquoise;
            this.parrotGradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.parrotGradientPanel1_Paint);
            // 
            // check_saveVideo
            // 
            this.check_saveVideo.AutoSize = true;
            this.check_saveVideo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.check_saveVideo.Location = new System.Drawing.Point(904, 78);
            this.check_saveVideo.Name = "check_saveVideo";
            this.check_saveVideo.Size = new System.Drawing.Size(166, 30);
            this.check_saveVideo.TabIndex = 19;
            this.check_saveVideo.Text = "Record Video";
            this.check_saveVideo.UseVisualStyleBackColor = true;
            // 
            // combo_cameras
            // 
            this.combo_cameras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.combo_cameras.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.combo_cameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_cameras.EnabledCalc = true;
            this.combo_cameras.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.combo_cameras.FormattingEnabled = true;
            this.combo_cameras.ItemHeight = 50;
            this.combo_cameras.Location = new System.Drawing.Point(26, 52);
            this.combo_cameras.Name = "combo_cameras";
            this.combo_cameras.Size = new System.Drawing.Size(226, 56);
            this.combo_cameras.TabIndex = 18;
            // 
            // txt_insFPS
            // 
            this.txt_insFPS.BackColor = System.Drawing.Color.Transparent;
            this.txt_insFPS.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txt_insFPS.ForeColor = System.Drawing.Color.DimGray;
            this.txt_insFPS.Image = null;
            this.txt_insFPS.Location = new System.Drawing.Point(718, 52);
            this.txt_insFPS.MaxLength = 32767;
            this.txt_insFPS.Multiline = false;
            this.txt_insFPS.Name = "txt_insFPS";
            this.txt_insFPS.ReadOnly = false;
            this.txt_insFPS.Size = new System.Drawing.Size(157, 56);
            this.txt_insFPS.TabIndex = 17;
            this.txt_insFPS.Text = "localhost";
            this.txt_insFPS.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_insFPS.UseSystemPasswordChar = false;
            // 
            // txt_insIpAI
            // 
            this.txt_insIpAI.BackColor = System.Drawing.Color.Transparent;
            this.txt_insIpAI.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txt_insIpAI.ForeColor = System.Drawing.Color.DimGray;
            this.txt_insIpAI.Image = null;
            this.txt_insIpAI.Location = new System.Drawing.Point(534, 52);
            this.txt_insIpAI.MaxLength = 32767;
            this.txt_insIpAI.Multiline = false;
            this.txt_insIpAI.Name = "txt_insIpAI";
            this.txt_insIpAI.ReadOnly = false;
            this.txt_insIpAI.Size = new System.Drawing.Size(161, 56);
            this.txt_insIpAI.TabIndex = 16;
            this.txt_insIpAI.Text = "localhost";
            this.txt_insIpAI.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_insIpAI.UseSystemPasswordChar = false;
            // 
            // txt_serverIp
            // 
            this.txt_serverIp.BackColor = System.Drawing.Color.Transparent;
            this.txt_serverIp.Font = new System.Drawing.Font("Tahoma", 16F);
            this.txt_serverIp.ForeColor = System.Drawing.Color.DimGray;
            this.txt_serverIp.Image = null;
            this.txt_serverIp.Location = new System.Drawing.Point(286, 52);
            this.txt_serverIp.MaxLength = 32767;
            this.txt_serverIp.Multiline = false;
            this.txt_serverIp.Name = "txt_serverIp";
            this.txt_serverIp.ReadOnly = false;
            this.txt_serverIp.Size = new System.Drawing.Size(212, 56);
            this.txt_serverIp.TabIndex = 15;
            this.txt_serverIp.Text = "localhost";
            this.txt_serverIp.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_serverIp.UseSystemPasswordChar = false;
            // 
            // txt_messageReceived
            // 
            this.txt_messageReceived.AutoSize = true;
            this.txt_messageReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txt_messageReceived.Location = new System.Drawing.Point(1175, 52);
            this.txt_messageReceived.Name = "txt_messageReceived";
            this.txt_messageReceived.Size = new System.Drawing.Size(0, 29);
            this.txt_messageReceived.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 890);
            this.Controls.Add(this.parrotGradientPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Rampi VideoStreaming";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.parrotGradientPanel1.ResumeLayout(false);
            this.parrotGradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox check_cameraEnabled;
        private ReaLTaiizor.Controls.ParrotGradientPanel parrotGradientPanel1;
        private ReaLTaiizor.Controls.AloneComboBox combo_cameras;
        private ReaLTaiizor.Controls.BigTextBox txt_insFPS;
        private ReaLTaiizor.Controls.BigTextBox txt_insIpAI;
        private ReaLTaiizor.Controls.BigTextBox txt_serverIp;
        private System.Windows.Forms.CheckBox check_saveVideo;
        private System.Windows.Forms.Label txt_messageReceived;
    }
}

