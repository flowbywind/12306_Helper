using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aNyoNe.AutoServerSwitch;
using aNyoNe.GetInfoFrom12306;

namespace _12306_Helper
{
    public partial class TicketFrame : UserControl
    {
        #region 框架属性
        public int SafeTime { get; set; }//订单提交安全期

        [Category("aNyoNe"), Description("当前登录账号的框架实例")]
        public static TicketFrame FormThis { get; private set; }

        private string _userName = "";
        [Category("aNyoNe"), Description("当前登录用户的用户名")]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private System.Net.CookieContainer _cookieContainer;
        [Category("aNyoNe"), Description("当前账号的回话")]
        public System.Net.CookieContainer Cookies
        {
            set { try { _cookieContainer = value; } catch { throw new ArgumentException(); } }
            get
            {
                if (_cookieContainer == null)
                    return new System.Net.CookieContainer();
                return _cookieContainer;
            }
        }

        private List<Nomal_Passengers> _passengers;
        [Category("aNyoNe"), Description("当前账号的常用联系人")]
        public List<Nomal_Passengers> Passengers
        {
            set { try { _passengers = value; } catch { throw new ArgumentException(); } }
            get
            {
                if (_passengers == null)
                    return new List<Nomal_Passengers>();
                return _passengers;
            }
        }

        private List<ConfigList> _configList;
        [Category("aNyoNe"), Description("当前账号的配置信息")]
        public List<ConfigList> ConfigList
        {
            get 
            {
                if (_configList == null)
                    _configList = new List<ConfigList>();
                else
                    _configList.Clear();
                bool defaultFlag = false;
                foreach (var control in tabSelectPages.TabPages)
                {
                    var page = (TabPage)control;
                    if (!defaultFlag)
                    {
                        defaultFlag = true;
                        var cfg = ((TicketMain)((TabPage)control).Controls[0]).Config;
                        cfg.ParentName ="defaultPage";
                        cfg.ParentText = "默认的查询页面";
                        _configList.Add(cfg);
                    }
                    else
                    {
                        var cfg = ((TicketMain)((TabPage)control).Controls[0]).Config;
                        cfg.ParentName = page.Name;
                        cfg.ParentText = page.Text;
                        _configList.Add(cfg);
                    }
                }
                return _configList;
            }
            set
            {
                try
                {
                    if (value != null)
                        _configList = value;
                    else
                        throw new ArgumentNullException();
                }
                catch { throw new ArgumentException(); }
            }
        }
        System.Windows.Forms.ContextMenuStrip contextMenuStrip ;
        #endregion

        ~TicketFrame()
        {
            GC.Collect();
            GC.Collect();
        }

        public TicketFrame()
        {
            InitializeComponent();
            SafeTime = 1;
            FormThis = this;
            contextMenuStrip = new System.Windows.Forms.ContextMenuStrip();
            this.tabSelectPages.ContextMenuStrip = contextMenuStrip;
        }

        public void AddNewTabPage(TabPage tp)
        {
            this.tabSelectPages.TabPages.Add(tp);
            this.tabSelectPages.SelectedTab = tp;
        }

        /// <summary>
        /// 初始化配置信息
        /// </summary>
        public void InitConfig()
        {
            _configList = GetConfigFile();
            InitSelectTicketPage(_configList);
        }

        private List<ConfigList> GetConfigFile()
        {
            //var cfgList = new List<ConfigList>();
            var path = System.IO.Directory.GetCurrentDirectory() + "\\data\\" + _userName;
            if (System.IO.Directory.Exists(path))
                return LocalCookie.ReadConfigFromDisk_ConfigList(path + "\\config.cfg");
            else
                return null;
        }

        private void InitSelectTicketPage(List<ConfigList> config)
        {
            if(config!=null)
            foreach (var c in config)
            {
                var cfg = (ConfigList)c;
                if (cfg.ParentName == "defaultPage")
                {
                    ((TicketMain)this.tabSelectPages.TabPages[0].Controls[0]).SetConfigToControl(cfg);
                }
                else
                    AddTabPage(cfg.ParentName, cfg.ParentText, cfg,this);
            }                        
                
        }

        private void AddTabPage(string name, string text, ConfigList config = null,Control frame=null)
        {
            var tp = new TabPage()
            {
                Name = name,
                Margin = new Padding(0),
                Text = text,
                Padding = new Padding(0)
            };

            var tsmi = new ToolStripMenuItem("关闭 " + tp.Text);
            var tsi = (ToolStripItem)tsmi;

            tp.TextChanged += (a, b) => { tsi.Text = "关闭 " + tp.Text; };
            tsi.Click += (s, a) => { this.tabSelectPages.TabPages.Remove(tp); contextMenuStrip.Items.Remove(tsi); };
            var pas = new List<Nomal_Passengers>();
            //CloneJsonTrainList(_passengersData, pas);
            var cfg = config.CloneConfigList();
            cfg.Init = false;
            tp.Controls.Add(new TicketMain(_cookieContainer, null, cfg, frame) { Dock = DockStyle.Fill, UserName = _userName });

            this.tabSelectPages.TabPages.Add(tp);
            this.tabSelectPages.SelectedTab = tp;
            contextMenuStrip.Items.Add(tsi);
        }

        private void CloneJsonTrainList(List<Nomal_Passengers> list1, List<Nomal_Passengers> list2)
        {
            if (list1 != null)
                for (int i = 0; i < list1.Count; i++)
                {
                    list2.Add(list1[i].CloneNomalPassengers());
                }
        }

        public void GetPassengersFromServer()
        {
            var modifyAction = new ModifyPassengerAction();
            var translation = new HTML_Translation();
            modifyAction.GetPassenger((strPassengers) =>
            {
                var returnString = translation.TranslationHtmlEx(strPassengers);
                if (returnString["data"]["normal_passengers"] == null)
                {
                    return;
                }

                translation.TranslationPassengerJson(strPassengers, (passengerSource) =>
                {
                    _passengers = passengerSource;
                });

            }, _cookieContainer);
        }
    }
}
