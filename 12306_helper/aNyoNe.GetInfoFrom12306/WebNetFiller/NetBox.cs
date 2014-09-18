using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace aNyoNe.GetInfoFrom12306
{
    class NetBox
    {
        public static FormWebData netForm;
        public static void AddNetInfo(string id, string link, string referer, string method, string querystring, string postdata, string backdata)
        {
            if (netForm != null)
                netForm.AddNetInfo(id, link, referer, method, querystring, postdata, backdata);
        }
    }
}
