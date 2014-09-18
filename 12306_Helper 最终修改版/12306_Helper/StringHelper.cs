using System;
using System.Collections.Generic;
using System.Text;

namespace _12306_Helper
{
    public static class StringHelper
    {
        public static string FindString(ref string text, string start, string end = null)
        {
            int startPos = text.IndexOf(start);
            if (startPos != -1)
            {
                if (!string.IsNullOrEmpty(end))
                {
                    int endPos = text.IndexOf(end, startPos);
                    if (endPos != -1)
                    {
                        return text.Substring(startPos, endPos - startPos + end.Length);
                    }
                    return null;
                }
                return text.Substring(startPos);
            }
            return null;
        }
    }
}
