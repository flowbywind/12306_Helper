using System;
using System.Windows.Forms;

namespace aNyoNe.AutoServerSwitch
{
    public class CompareContext : System.Collections.IComparer
    {
        private int col;
        private bool desc;
        public CompareContext()
        {
            col = 0;
        }
        public CompareContext(int co, bool de)
        {
            col = co;
            desc = de;
        }
        public int Compare(object x, object y)
        {
            ListViewItem s1 = x as ListViewItem;
            ListViewItem s2 = y as ListViewItem;
            //默认排序为“--”最大“无”最小，其他数值转成整数比较大小
            if (s1.SubItems[col].Text == "--")
            {
                if (s2.SubItems[col].Text == "--")
                    return 0;
                return 1;
            }

            if (s2.SubItems[col].Text == "--")
                return -1;


            int result = 0;
            if (col == 0 || col >= 6)
            {
                result = String.Compare(s1.SubItems[col].Text, s2.SubItems[col].Text);
            }
            else
            {
                try
                {
                    int i = Convert.ToInt32(s1.SubItems[col].Text) - Convert.ToInt32(s2.SubItems[col].Text);
                    if (i > 0)
                        result = 1;
                    else if (i == 0)
                        result = 0;
                    else
                        result = -1;
                }
                catch
                {
                    result = String.Compare(s1.SubItems[col].Text, s2.SubItems[col].Text);
                }
            }
            if (desc)
                return -result;
            else
                return result;
        }
    }
}
