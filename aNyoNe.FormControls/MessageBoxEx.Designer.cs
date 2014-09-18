namespace aNyoNe.FormControls
{
    partial class MessageBoxEx
    {
        /// <summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageBoxEx));
            this.plMainForm = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.plMainForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // plMainForm
            // 
            this.plMainForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plMainForm.Controls.Add(this.lblMessage);
            this.plMainForm.Controls.Add(this.pictureBox1);
            this.plMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plMainForm.Location = new System.Drawing.Point(0, 0);
            this.plMainForm.Margin = new System.Windows.Forms.Padding(0);
            this.plMainForm.Name = "plMainForm";
            this.plMainForm.Size = new System.Drawing.Size(600, 50);
            this.plMainForm.TabIndex = 0;
            this.plMainForm.Click += new System.EventHandler(this.plMainForm_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessage.BackColor = System.Drawing.Color.White;
            this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblMessage.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMessage.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.lblMessage.Location = new System.Drawing.Point(61, 8);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.ReadOnly = true;
            this.lblMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.lblMessage.Size = new System.Drawing.Size(511, 33);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.TabStop = false;
            this.lblMessage.Text = "";
            this.lblMessage.Click += new System.EventHandler(this.plMainForm_Click);
            this.lblMessage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblMessage_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(23, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ok.png");
            this.imageList1.Images.SetKeyName(1, "error.png");
            this.imageList1.Images.SetKeyName(2, "information.png");
            this.imageList1.Images.SetKeyName(3, "question.png");
            this.imageList1.Images.SetKeyName(4, "plus.png");
            this.imageList1.Images.SetKeyName(5, "substract.png");
            // 
            // MessageBoxEx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 50);
            this.Controls.Add(this.plMainForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageBoxEx";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "信息提示";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormInformation_Load);
            this.plMainForm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel plMainForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.RichTextBox lblMessage;
    }
}