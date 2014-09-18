using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace aNyoNe.BitMapHandle
{
    public class BinaryzationHandle
    {
        /// <summary>
        /// 图像的二值化
        /// </summary>
        public BinaryzationHandle()
        {
            
        }

        /// <summary>
        /// 固定阀值的二值化方法
        /// </summary>
        /// <param name="b"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public Bitmap BitmapBinaryzation(Bitmap _bitMap,byte threshold)   
        {
            int width = _bitMap.Width;
            int height = _bitMap.Height;
            BitmapData data = _bitMap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);   
            unsafe  
            {   
                byte* p = (byte*)data.Scan0;   
                int offset = data.Stride - width * 4;   
                byte R, G, B, gray;   
                for (int y = 0; y < height; y++)   
                {   
                    for (int x = 0; x < width; x++)   
                    {   
                        R = p[2];   
                        G = p[1];   
                        B = p[0];   
                        gray = (byte)((R * 19595 + G * 38469 + B * 7472) >> 16);   
                        if (gray >= threshold)   
                        {   
                            p[0] = p[1] = p[2] = 255;   
                        }   
                        else  
                        {   
                            p[0] = p[1] = p[2] = 0;   
                        }   
                        p += 4;   
                    }   
                    p += offset;   
                }
                _bitMap.UnlockBits(data);
                return _bitMap;   
            }   
        }  
    }
}
