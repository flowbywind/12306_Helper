using _12306_Helper.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _12306_Helper
{
    class OpaqueCommand
    {
        private MyOpaqueLayer m_OpaqueLayer = null;//半透明蒙板层

        /// <summary>
        /// 显示遮罩层
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="alpha">透明度</param>
        /// <param name="isShowLoadingImage">是否显示图标</param>
        public void ShowOpaqueLayer(Control control, int alpha, bool isShowLoadingImage,bool opera=true)
        {
            try
            {
                if (this.m_OpaqueLayer == null)
                {
                    this.m_OpaqueLayer = new MyOpaqueLayer(alpha, isShowLoadingImage);
                    
                    control.Controls.Add(this.m_OpaqueLayer);
                    this.m_OpaqueLayer.Dock = DockStyle.Fill;
                    this.m_OpaqueLayer.BringToFront();
                    if(!opera)
                        this.m_OpaqueLayer.LostFocus += new EventHandler((o, e) =>
                        {
                            this.m_OpaqueLayer.Focus();
                        });
                    else
                        this.m_OpaqueLayer.LostFocus -= new EventHandler((o, e) =>
                        {
                            this.m_OpaqueLayer.Focus();
                        });
                    this.m_OpaqueLayer.Focus();
                }
                this.m_OpaqueLayer.Enabled = true;
                this.m_OpaqueLayer.Visible = true;
            }
            catch { }
        }

        /// <summary>
        /// 隐藏遮罩层
        /// </summary>
        public void HideOpaqueLayer()
        {
            try
            {
                if (this.m_OpaqueLayer != null)
                {
                    this.m_OpaqueLayer.Visible = false;
                    this.m_OpaqueLayer.Enabled = false;
                    m_OpaqueLayer = null;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { }
        }
    }
}
