using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace aNyoNe.TestSomthing
{
    public partial class grayLevelTest : Form
    {
        public grayLevelTest()
        {
            InitializeComponent();
        }
        private Bitmap srcBitmap = null;
        private Bitmap showBitmap = null;
        //打开文件
        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = @"Bitmap文件(*.bmp)|*.bmp|Jpeg文件(*.jpg)|*.jpg|所有合适文件(*.bmp,*.jpg)|*.bmp;*.jpg";
            openFileDialog.FilterIndex = 3;
            openFileDialog.RestoreDirectory = true;
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                srcBitmap = (Bitmap)Bitmap.FromFile(openFileDialog.FileName, false);
                showBitmap = srcBitmap;
                this.BackgroundImage = showBitmap;
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.Invalidate();
            }
        }
        //保存图像文件
        private void menuFileSave_Click(object sender, EventArgs e)
        {
            if (showBitmap != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = @"Bitmap文件(*.bmp)|*.bmp|Jpeg文件(*.jpg)|*.jpg|所有合适文件(*.bmp,*.jpg)|*.bmp;*.jpg";
                saveFileDialog.FilterIndex = 3;
                saveFileDialog.RestoreDirectory = true;
                if (DialogResult.OK == saveFileDialog.ShowDialog())
                {
                    ImageFormat format = ImageFormat.Jpeg;
                    switch (Path.GetExtension(saveFileDialog.FileName).ToLower())
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                        default:
                            MessageBox.Show(this, "Unsupported image format was specified", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }
                    try
                    {
                        showBitmap.Save(saveFileDialog.FileName, format);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(this, "Failed writing image file", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        //窗口重绘,在窗体上显示图像,重载Paint
        private void frmMain_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (showBitmap != null)
            {
                Graphics g = e.Graphics;
                g.DrawImage(showBitmap, new Rectangle(this.AutoScrollPosition.X, this.AutoScrollPosition.Y,
                (int)(showBitmap.Width), (int)(showBitmap.Height)));
            }
        }
        //灰度化
        private void menu2Gray_Click(object sender, EventArgs e)
        {
            if (showBitmap == null) return;
            aNyoNe.BitMapHandle.GrayLevelHandle hnd = new BitMapHandle.GrayLevelHandle();
            Bitmap grayMap=hnd.GrayHandle(showBitmap,0.299, 0.587, 0.114, aNyoNe.BitMapHandle.GrayHandleMethod.PixelFunc);
            aNyoNe.BitMapHandle.ThresholdCompute com = new BitMapHandle.ThresholdCompute();
            aNyoNe.BitMapHandle.BinaryzationHandle bi=new BitMapHandle.BinaryzationHandle();
            showBitmap=grayMap = bi.BitmapBinaryzation(grayMap, com.OtsuThreshold(grayMap));
            //aNyoNe.BitMapHandle.DenoisingHandle de = new BitMapHandle.DenoisingHandle();
            //showBitmap = de.ClearNoise(grayMap,com.GetDgGrayValue(grayMap),2);
            //showBitmap = de.ClearNoise(grayMap, com.GetDgGrayValue(grayMap)-100);
            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.12306.cn/mormhweb/kyfw/");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            int i = 0;
            int x = i;
            
        }
    }
}
