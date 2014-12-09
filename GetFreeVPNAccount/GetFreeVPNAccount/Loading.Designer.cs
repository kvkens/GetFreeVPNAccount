namespace GetFreeVPNAccount
{
    partial class Loading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.PicLoading = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // PicLoading
            // 
            this.PicLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PicLoading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicLoading.Image = ((System.Drawing.Image)(resources.GetObject("PicLoading.Image")));
            this.PicLoading.Location = new System.Drawing.Point(0, 0);
            this.PicLoading.Name = "PicLoading";
            this.PicLoading.Size = new System.Drawing.Size(182, 183);
            this.PicLoading.TabIndex = 0;
            this.PicLoading.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(15, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "正在帮您注册着呢稍等喔~~~";
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 183);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PicLoading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.PicLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicLoading;
        private System.Windows.Forms.Label label1;
    }
}