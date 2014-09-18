using System;
using System.Runtime.InteropServices;

namespace _12306_Helper
{
    class FormShowStyle
    {
        #region 窗体淡入淡出
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr whnd, int dwtime, int dwflag);
        //dwflag的取值如下
        //从左到右显示
        private const Int32 AW_HOR_POSITIVE = 0x00000001;
        //从右到左显示
        private const Int32 AW_HOR_NEGATIVE = 0x00000002;
        //从上到下显示
        private const Int32 AW_VER_POSITIVE = 0x00000004;
        //从下到上显示
        private const Int32 AW_VER_NEGATIVE = 0x00000008;

        private const Int32 AW_CENTER = 0x00000010;

        //若使用了AW_HIDE标志，则使窗口向内重叠，即收缩窗口；否则使窗口向外扩展，即展开窗口
        private const Int32 AW_HIDE = 0x00010000;
        //隐藏窗口，缺省则显示窗口
        private const Int32 AW_ACTIVATE = 0x00020000;
        //激活窗口。在使用了AW_HIDE标志后不能使用这个标志
        private const Int32 AW_SLIDE = 0x00040000;
        //使用滑动类型。缺省则为滚动动画类型。当使用AW_CENTER标志时，这个标志就被忽略
        private const Int32 AW_BLEND = 0x00080000;

        /// <summary>
        /// 窗体淡入
        /// </summary>
        /// <param name="whnd">窗体(handle to window)</param>
        /// <param name="dwtime">时间(毫秒)</param>
        public void ShowForm(IntPtr whnd,int dwtime)
        {   //whnd=this.Handle
            //在Form_Load中添加代码实现窗体的淡入
            AnimateWindow((IntPtr)whnd, (int)dwtime, AW_BLEND | AW_ACTIVATE);
            //多个dwflag之间用 | 隔开
        }
        /// <summary>
        /// 窗体淡出
        /// </summary>
        /// <param name="whnd">窗体(handle to window)</param>
        /// <param name="dwtime">时间(毫秒)</param>
        public void HideForm(IntPtr whnd, int dwtime)
        {   //whnd=this.Handle
            //在Form_FormClosing中添加代码实现窗体的淡出
            AnimateWindow((IntPtr)whnd, (int)dwtime, AW_BLEND | AW_HIDE);
            //必须有AW_HIDE才能看到窗体的淡出
        }
        //透明度从高到低
        #endregion

        #region 在窗体代码中使用，视窗体具有AERO效果，试用于WIN7
        //[StructLayout(LayoutKind.Sequential)]
        //public struct MARGINS
        //{
        //    public int Left;
        //    public int Right;
        //    public int Top;
        //    public int Bottom;
        //}

        //[DllImport("dwmapi.dll", PreserveSig = false)]
        //static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);

        //[DllImport("dwmapi.dll", PreserveSig = false)]
        //static extern bool DwmIsCompositionEnabled();

        //protected override void OnLoad(EventArgs e)
        //{
        //    if (DwmIsCompositionEnabled())
        //    {
        //        MARGINS m = new MARGINS();
        //        m.Right = m.Left = m.Top = this.Width + this.Height;
        //        DwmExtendFrameIntoClientArea(this.Handle, ref m);
        //    }
        //    base.OnLoad(e);
        //}

        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    base.OnPaintBackground(e);
        //    if (DwmIsCompositionEnabled())
        //    {
        //        e.Graphics.Clear(Color.Black);
        //    }
        //}
        #endregion

        #region 无边框窗体拖动窗体任意地方移动
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_MOVE = 0xF010;
        private const int HTCAPTION = 0x0002;

        public void MoveForm(IntPtr handle)
        {
            ReleaseCapture();
            SendMessage(handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        #endregion

        #region 窗体边框阴影效果
        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetClassLong(IntPtr hwnd, int nIndex);

        public void MakeShadow(IntPtr handle)
        {
            SetClassLong(handle, GCL_STYLE, GetClassLong(handle, GCL_STYLE) | CS_DropSHADOW); //API函数加载，实现窗体边框阴影效果
        }
        #endregion
    }
}
