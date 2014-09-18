namespace _12306_Helper
{
    partial class formSupport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSupport));
            this.panel1 = new System.Windows.Forms.Panel();
            this.picSupport = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkSupport = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSupport)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lnkSupport);
            this.panel1.Controls.Add(this.picSupport);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 165);
            this.panel1.TabIndex = 18;
            // 
            // picSupport
            // 
            this.picSupport.Image = global::_12306_Helper.Properties.Resources.png_support;
            this.picSupport.Location = new System.Drawing.Point(37, 174);
            this.picSupport.Name = "picSupport";
            this.picSupport.Size = new System.Drawing.Size(159, 37);
            this.picSupport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSupport.TabIndex = 4;
            this.picSupport.TabStop = false;
            this.picSupport.Click += new System.EventHandler(this.picSupport_Click);
            this.picSupport.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSupport_MouseDown);
            this.picSupport.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picSupport_MouseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(193, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "aNyoNe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(15, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "不限金额，不管多少，我都会表示感谢 ！";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(15, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "您可以使用支付宝给我一定的支持。";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(15, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "并且您愿意给与我一点的支持，";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(15, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "如果我的软件或工具真的帮助到了您，";
            // 
            // lnkSupport
            // 
            this.lnkSupport.AutoSize = true;
            this.lnkSupport.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkSupport.Location = new System.Drawing.Point(35, 132);
            this.lnkSupport.Name = "lnkSupport";
            this.lnkSupport.Size = new System.Drawing.Size(177, 12);
            this.lnkSupport.TabIndex = 5;
            this.lnkSupport.TabStop = true;
            this.lnkSupport.Text = "支付宝: pengyouak@163.com";
            this.lnkSupport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSupport_LinkClicked);
            // 
            // formSupport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(246, 165);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formSupport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "支持";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSupport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picSupport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkSupport;
    }
}