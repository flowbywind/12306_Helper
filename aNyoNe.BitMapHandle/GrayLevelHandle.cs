using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace aNyoNe.BitMapHandle
{
    public class GrayLevelHandle
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="bit">要处理的图像</param>
        public GrayLevelHandle() 
        {

        }

        /// <summary>
        /// 图像的黑白化处理
        /// </summary>
        /// <param name="r">R 颜色的权值 例如：0.299</param>
        /// <param name="g">G 颜色的权值 例如：0.587</param>
        /// <param name="b">B 颜色的权值 例如：0.114</param>
        /// <param name="method">处理方法</param>
        /// <returns>处理后的黑白图像</returns>
        public Bitmap GrayHandle(Bitmap _bitMap,double r,double g,double b,GrayHandleMethod method)
        {
            switch (method)
            {
                case GrayHandleMethod.PixelFunc: { PixelFun(_bitMap,r,g,b); break; }
                case GrayHandleMethod.MemoryCopyFunc: { MemoryCopy(_bitMap, r, g, b); break; }
                case GrayHandleMethod.PointerFunc: { PointerFun(_bitMap, r, g, b); break; };
                default: { return null; }
            }
            return _bitMap;
        }

        /// <summary>
        /// 像素法
        ///  GetPixel(i,j)和SetPixel(i, j,Color)可以直接得到图像的一个像素的Color结构，但是处理速度比较慢.
        /// </summary>
        /// <param name="curBitmap"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        private void PixelFun(Bitmap curBitmap, double a, double b, double c)
        {
            double r = a;
            double g = b;
            double bb = c;
            int width = curBitmap.Width;
            int height = curBitmap.Height;
            for (int i = 0; i < width; i++) //这里如果用i<curBitmap.Width做循环对性能有影响
            {
                for (int j = 0; j < height; j++)
                {
                    Color curColor = curBitmap.GetPixel(i, j);
                    int ret = (int)(curColor.R * r + curColor.G * g + curColor.B * bb);
                    curBitmap.SetPixel(i, j, Color.FromArgb(ret, ret, ret));
                }
            }
        }

        /// <summary>
        /// 内存拷贝法
        /// 内存拷贝法就是采用System.Runtime.InteropServices.Marshal.Copy将图像数据拷贝到数组中，
        /// 然后进行处理，这不需要直接对指针进行操作，不需采用unsafe，处理速度和指针处理相差不大
        /// </summary>
        /// <param name="curBitmap"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        private unsafe void MemoryCopy(Bitmap curBitmap,double a,double b,double c)
        {
            double r = a;
            double g = b;
            double bb = c;

            int width = curBitmap.Width;
            int height = curBitmap.Height;

            Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
            System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);//curBitmap.PixelFormat

            IntPtr ptr = bmpData.Scan0;
            int bytesCount = bmpData.Stride * bmpData.Height;
            byte[] arrDst = new byte[bytesCount];
            Marshal.Copy(ptr, arrDst, 0, bytesCount);

            for (int i = 0; i < bytesCount; i += 3)
            {
                byte colorTemp = (byte)(arrDst[i + 2] * r + arrDst[i + 1] * g + arrDst[i] * bb);
                arrDst[i] = arrDst[i + 1] = arrDst[i + 2] = (byte)colorTemp;

            }
            Marshal.Copy(arrDst, 0, ptr, bytesCount);
            curBitmap.UnlockBits(bmpData);
        }

        /// <summary>
        /// 指针法
        /// 指针在c#中属于unsafe操作，需要用unsafe括起来进行处理，速度最快
        /// </summary>
        /// <param name="curBitmap"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        private unsafe void PointerFun(Bitmap curBitmap, double a, double b, double c)
        {
            double r = a;
            double g = b;
            double bb = c;

            int width = curBitmap.Width;
            int height = curBitmap.Height;

            Rectangle rect = new Rectangle(0, 0, curBitmap.Width, curBitmap.Height);
            System.Drawing.Imaging.BitmapData bmpData = curBitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);//curBitmap.PixelFormat
            byte temp = 0;
            int w = bmpData.Width;
            int h = bmpData.Height;
            byte* ptr = (byte*)(bmpData.Scan0);
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    temp = (byte)(r * ptr[2] + g * ptr[1] + bb * ptr[0]);
                    ptr[0] = ptr[1] = ptr[2] = temp;
                    ptr += 3; //Format24bppRgb格式每个像素占3字节
                }
                ptr += bmpData.Stride - bmpData.Width * 3;//每行读取到最后“有用”数据时，跳过未使用空间XX
            }
            curBitmap.UnlockBits(bmpData);
        }

        /*      以下是多组测试数据：
                * 1920*1080  1440*900    1208*800    1024*768    500*544    200*169
直接提取像素法  * 1705ms       1051ms      1710ms      1340ms      450ms       32ms
    内存拷贝法  * 54ms           33ms        26ms        20ms        7ms        0ms
        指针法  * 28ms           17ms        14ms        10ms        3ms        0ms
         * 
         * 
         * 比较以上方法优缺点：
1.总体上性能 指针法略强于内存拷贝法，直接提取像素法性能最低；
2.对大图片处理指针法和内存拷贝法性能提升明显，对小图片都比较快；
3.直接提取像素法简单易用，而且不必关注图片像素格式(PixelFormat),为安全代码；
  内存拷贝法和指针法如果不改变原图片像素格式要针对不同的像素格式做不同的处理，且为不安全代码。
         */
    }

    /// <summary>
    /// 黑白化处理方法枚举
    /// </summary>
    public enum GrayHandleMethod
    {
        /// <summary>
        /// 像素法,普通速度(安全代码)
        /// </summary>
        PixelFunc,
        /// <summary>
        /// 内存拷贝法,快速(不安全代码)
        /// </summary>
        MemoryCopyFunc,
        /// <summary>
        /// 指针法,非常快(不安全代码)
        /// </summary>
        PointerFunc
    }
}
