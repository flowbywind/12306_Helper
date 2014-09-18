using System.Drawing.Imaging;
using System.Text;
using System.IO;
using System.Drawing;

namespace aNyoNe.VeriCodeRecognation
{
    public class PicRecognation
    {
        private bool _susess;
        public bool Susess
        { get { return this._susess; } set { this._susess = value; } }
        StringBuilder codeBuilder = new StringBuilder(8, 8);

        public PicRecognation()
        {
            byte[] buffer = Resources.data;
            if (!SundayAPI.LoadLibFromBuffer(buffer, buffer.Length, "123"))
            {
                _susess = false;
            }
            else
                _susess = true;
        }
        
        /// <summary>
        /// 验证码识别
        /// </summary>
        /// <param name="byt">图像数组</param>
        /// <returns></returns>
        public string GetPicStringCode(Bitmap bit)
        {
            try
            {
                string code = string.Empty;
                byte[] buffer = GetPicBytes(bit);
                int count = 0;
                do
                {
                    if (buffer != null)
                    {
                        codeBuilder.Length = 0;
                        if (SundayAPI.GetCodeFromBuffer(1, buffer, buffer.Length, codeBuilder))
                        {
                            code = codeBuilder.ToString();
                        }
                    }
                    count++;
                } while (count<1&&code.Length != 4);
                return code;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 获取bitmap的bytes数组
        /// </summary>
        /// <param name="bit"></param>
        /// <returns></returns>
        private byte[] GetPicBytes(Bitmap bit)
        {
            using (var ms = new MemoryStream())
            {
                bit.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
    }
}
