using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace aNyoNe.BitMapHandle
{
    public class DenoisingHandle
    {
        public DenoisingHandle()
        {

        }
        
        /// <summary>
        /// 去掉杂点（适合杂点/杂线粗为1）
        /// </summary>
        /// <param name="_bitMap"></param>
        /// <param name="dgGrayValue">前景背景的临界值</param>
        /// <param name="MaxNearPoints">干扰线粗细值 (像素)</param>
        /// <returns></returns>
        public Bitmap ClearNoise(Bitmap _bitMap,int dgGrayValue, int MaxNearPoints)
        {
            Color piexl;
            int nearDots = 0;
            //逐点判断
            for (int i = 0; i < _bitMap.Width; i++)
                for (int j = 0; j < _bitMap.Height; j++)
                {
                    piexl = _bitMap.GetPixel(i, j);
                    if (piexl.R < dgGrayValue)
                    {
                        nearDots = 0;
                        //判断周围8个点是否全为空
                        if (i == 0 || i == _bitMap.Width - 1 || j == 0 || j == _bitMap.Height - 1)  //边框全去掉
                        {
                            _bitMap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        }
                        else
                        {
                            if (_bitMap.GetPixel(i - 1, j - 1).R < dgGrayValue) nearDots++;
                            if (_bitMap.GetPixel(i, j - 1).R < dgGrayValue) nearDots++;
                            if (_bitMap.GetPixel(i + 1, j - 1).R < dgGrayValue) nearDots++;
                            if (_bitMap.GetPixel(i - 1, j).R < dgGrayValue) nearDots++;
                            if (_bitMap.GetPixel(i + 1, j).R < dgGrayValue) nearDots++;
                            if (_bitMap.GetPixel(i - 1, j + 1).R < dgGrayValue) nearDots++;
                            if (_bitMap.GetPixel(i, j + 1).R < dgGrayValue) nearDots++;
                            if (_bitMap.GetPixel(i + 1, j + 1).R < dgGrayValue) nearDots++;
                        }

                        if (nearDots < MaxNearPoints)
                            _bitMap.SetPixel(i, j, Color.FromArgb(255, 255, 255));   //去掉单点 && 粗细小3邻边点
                    }
                    else  //背景
                        _bitMap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                }
            return _bitMap;
        }
    }
}
