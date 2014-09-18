namespace _12306_Helper
{
    partial class TicketFrame
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabSelectPages = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // tabSelectPages
            // 
            this.tabSelectPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSelectPages.Location = new System.Drawing.Point(0, 0);
            this.tabSelectPages.Margin = new System.Windows.Forms.Padding(0);
            this.tabSelectPages.Name = "tabSelectPages";
            this.tabSelectPages.SelectedIndex = 0;
            this.tabSelectPages.Size = new System.Drawing.Size(860, 543);
            this.tabSelectPages.TabIndex = 0;
            // 
            // TicketFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabSelectPages);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TicketFrame";
            this.Size = new System.Drawing.Size(860, 543);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSelectPages;
    }
}
