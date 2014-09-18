using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;


namespace aNyoNe.AutoServerSwitch
{
    public partial class formSwitchServer : Form
    {
        bool IsOver = false;
        bool switchEnable = true;
        bool listenFlag = false;//监听标志
        string address = "";
        int timeOutCount = 0;
        int lowCount = 0;
        private object locker = new object();
        HostAction hostAction;
        List<Object_Server> uploadList = new List<Object_Server>();
        CancellationTokenSource ctsSwitch = new CancellationTokenSource();
        CancellationTokenSource ctsListen = new CancellationTokenSource();
        public static bool hostEnable = true;
        List<Object_IP> dnsList = new List<Object_IP>();//缓存服务器列表
        
        List<Object_IP> dnsListTmp = new List<Object_IP>();//缓存服务器列表
        int switchSeed = 0;//服务器切换标志位
        IPAddress ipAddress = null;//本地解析12306的服务器地址
        private const string dnsInterface = "http://www.fishlee.net/apps/cn12306/ipservice/getlist";//"http://www.fishlee.net/Apps/Cn12306/IpService/getall";
        private const string domain = "kyfw.12306.cn";
        private const string uploadServer = "http://www.fishlee.net/Apps/Cn12306/ServerIP?method=reg&ip=";
        private const string uploadCloud = "http://www.fishlee.net/apps/cn12306/ipservice/update2";
        public formSwitchServer()
        {
            InitializeComponent();
            InitHostPath();
        }
        private void InitHostPath()
        {
            try
            {
                hostAction = new HostAction(Environment.SystemDirectory + "\\drivers\\etc\\hosts");
            }
            catch
            {
                hostEnable = false;
            }
        }

        #region CacheServerAction
        /// <summary>
        /// 开启加载缓存服务器的线程
        /// </summary>
        private void StartGetDnsList()
        {
            if (switchEnable)
            {
                DeterMineCall(() =>
                {
                    lvSwitch.Items.Clear();
                });
                GetIPAndReport();
                ctsSwitch = new CancellationTokenSource();
                ThreadPool.QueueUserWorkItem(new WaitCallback(SwitchMethod), ctsSwitch.Token);
            }
        }


        private void GetIPAndReport()
        {
            DeterMineCall(() =>
            {
                AddSwitchListViewItem("正在解析服务器IP并上报到服务器以便共享.....", Color.Navy, "");
                ipAddress = Dns.GetHostAddresses("kyfw.12306.cn").FirstOrDefault<IPAddress>();
                if (ipAddress != null)
                {
                    address = ipAddress.ToString();
                    ipAddress = null;
                    string str = "";
                    try
                    {
                        WebClient webClient = new WebClient();
                        str = webClient.DownloadString(string.Concat(uploadServer, address));
                    }
                    catch
                    {
                    }
                    if (str != "ok")
                    {
                        AddSwitchListViewItem("服务器IP上报失败.....", Color.Red, "");
                    }
                    else
                    {
                        AddSwitchListViewItem("服务器IP上报成功", Color.Green, "");
                    }
                }
                else
                {
                    AddSwitchListViewItem("服务器IP上报失败.....", Color.Red, "");
                }
            });
        }

        /// <summary>
        /// 添加ListView行
        /// </summary>
        /// <param name="str">显示文本</param>
        /// <param name="color">文本颜色</param>
        /// <param name="param">参数，没有填""</param>
        private void AddServerListViewItem(Color color, Object_Server server)
        {
            DeterMineCall(() =>
            {
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems[0].Name = "ip";
                lvi.SubItems.Add("validcount").Name = "validcount";
                lvi.SubItems.Add("failedcount").Name = "failedcount";
                lvi.SubItems.Add("brokencount").Name = "brokencount";
                lvi.SubItems.Add("serverspeed").Name = "serverspeed";
                lvi.SubItems.Add("localspeed").Name = "localspeed";
                lvi.SubItems.Add("status").Name = "status";
                lvi.Name = server.Ip;
                lvi.Tag = server;
                lvi.SubItems[0].Text = server.Ip;
                lvi.SubItems[1].Text = server.ValidCount.ToString();
                lvi.SubItems[2].Text = server.FailedCount.ToString();
                lvi.SubItems[3].Text = server.BrokenCount.ToString();
                lvi.SubItems[4].Text = server.ServerSpeed.ToString();
                lvi.SubItems[5].Text = "--";
                lvi.SubItems[6].Text = "--";
                lvi.ForeColor = color;
                lvi.Group = lvServerList.Groups["testing"];
                lvServerList.Items.Insert(0, lvi);
            });
        }

        private void RefreshServerList(int flag, Object_Server item)
        {
            try
            {
                DeterMineCall(() =>
                {
                    switch (flag)
                    {
                        case 0:
                            {
                                lvServerList.Items[item.Ip].SubItems["localspeed"].Text = item.LocalSpeed.ToString();
                                lvServerList.Items[item.Ip].SubItems["status"].Text = "速度过慢";
                                lvServerList.Items[item.Ip].ForeColor = Color.FromArgb(192, 64, 0);
                                lvServerList.Items[item.Ip].Group = lvServerList.Groups["low"];
                                break;
                            }
                        case 1:
                            {
                                lvServerList.Items[item.Ip].SubItems["localspeed"].Text = item.LocalSpeed.ToString();
                                lvServerList.Items[item.Ip].SubItems["status"].Text = "正常";
                                lvServerList.Items[item.Ip].ForeColor = Color.Green;
                                lvServerList.Items[item.Ip].Group = lvServerList.Groups["normal"];
                                break;
                            }
                        case 2:
                            {
                                lvServerList.Items[item.Ip].ForeColor = Color.Red;
                                lvServerList.Items[item.Ip].SubItems["status"].Text = "不可用";
                                lvServerList.Items[item.Ip].Group = lvServerList.Groups["notvalid"];
                                break;
                            }
                        case 3:
                            {
                                lvServerList.Items[item.Ip].ForeColor = Color.Red;
                                lvServerList.Items[item.Ip].SubItems["status"].Text = "已被封禁";
                                lvServerList.Items[item.Ip].Group = lvServerList.Groups["breakout"];
                                break;
                            }
                        case 4:
                            {
                                lvServerList.Items[item.Ip].ForeColor = Color.Crimson;
                                lvServerList.Items[item.Ip].SubItems["status"].Text = "测试中";
                                lvServerList.Items[item.Ip].Group = lvServerList.Groups["test"];
                                break;
                            }
                    }
                });
            }
            catch { }
        }

        private void CallbackServer(List<Object_Server> servers, Action<object[]> callback)
        {
            var tmpList = CloneObjectServers(servers);
            Parallel.ForEach(tmpList, server =>
            {
                try
                {
                    if (IsOver || ctsSwitch.Token.IsCancellationRequested)
                        return;
                    RefreshServerList(4, server);
                    var obj = new Object_IP() {Ip = server.Ip};
                    obj.HttpSetSpeed();
                    if (!obj.IsNotValid && !obj.IsForbidden)
                        obj.HttpSetSpeed();
                    var o = new object[2];
                    o[0] = server;
                    o[1] = obj;
                    callback(o);
                }
                catch
                {
                }
            });
        }

        private List<Object_Server> CloneObjectServers(List<Object_Server> list)
        {
            lock (list)
            {
                var servers = new List<Object_Server>();
                for (int i = 0; i < list.Count; i++)
                {
                    servers.Add(list[i]);
                }
                return servers;
            }
        }

        /// <summary>
        /// 获取可用的缓存服务器列表
        /// </summary>
        private void SwitchMethod(object token)
        {
            CancellationToken ct = (CancellationToken)token;
            if (ct.IsCancellationRequested)
            {
                return;
            }
            GetIPInfoList getlist = new GetIPInfoList();
            dnsList.Clear();
            if (dnsList.Count <= 0)
            {
                DeterMineCall(() =>
                {
                    AddSwitchListViewItem("正在从服务器更新列表...", Color.Navy, "");
                });
                List<Object_Server> list = getlist.GetSourceItem(dnsInterface);
                if (list == null)
                {
                    AddSwitchListViewItem("警告: 下载服务器列表失败, 10秒钟后重试.", Color.Red, "");
                    Thread.Sleep(10000);
                    SwitchMethod(ctsSwitch.Token);
                }
                else
                {
                    Parallel.ForEach(list,x=> AddServerListViewItem(Color.Blue, x));
                    AddSwitchListViewItem("下载服务器列表成功,已经获得 {0} 个服务器IP.", Color.Navy, list.Count);
                    AddSwitchListViewItem("开始测试服务器速度...", Color.Navy, "");
                }
                bool flag=false;
                foreach (Object_Server s in list)
                {
                    if (s.Ip == address)
                    {
                        flag = true; break;
                    }
                }
                if (!flag)
                {
                    var oServer = new Object_Server() 
                    { 
                        Ip = address,
                        LocalSpeed = 0,
                        FailedCount = 0,
                        BrokenCount = 0,
                        AddTime = DateTime.Now, 
                        ValidCount = 0 
                    };
                    list.Add(oServer);
                }
                CallbackServer(list, dic =>
                {
                    if (ct.IsCancellationRequested)
                    {
                        DeterMineCall(() =>
                        {
                            foreach (ListViewItem lvi in lvServerList.Items)
                            {
                                if (lvi.Group.Name == "test")
                                    lvi.Group = lvServerList.Groups["testing"];
                            }
                        });
                        return;
                    }
                    lock (locker)
                    {
                        DeterMineCall(() =>
                        {
                            var obj = new Object_IP();
                            obj = (Object_IP)dic[1];
                            var server = new Object_Server();
                            server = (Object_Server)dic[0];
                            
                            var lvi = new ListViewItem();
                            lvi.SubItems.Add("时间");
                            lvi.SubItems.Add("信息");
                            lvi.SubItems[0].Text = DateTime.Now.ToLongTimeString();
                            if (!obj.IsForbidden)
                            {
                                if (!obj.IsNotValid)
                                {
                                    server.LocalSpeed = Convert.ToInt16(obj.Speed.Value.TotalMilliseconds);
                                    if (obj.Speed.Value.TotalSeconds > 1)
                                    {
                                        dnsList.Remove(obj);
                                        lvi.ForeColor = Color.FromArgb(192, 64, 0);
                                        RefreshServerList(0, server);
                                        lvi.SubItems[1].Text = string.Format("服务器 [{0}] 响应速度过低, 放弃使用. (响应速度={1}秒)", obj.Ip, obj.Speed.Value.TotalSeconds.ToString("#0.00"));
                                    }
                                    else
                                    {
                                        dnsList.Add(obj);
                                        lvi.ForeColor = Color.Green;
                                        RefreshServerList(1, server);
                                        lvi.SubItems[1].Text = string.Format("服务器 [{0}] 正常. (响应速度={1}秒)", obj.Ip, obj.Speed.Value.TotalSeconds.ToString("#0.00"));
                                    }
                                }
                                else
                                {
                                    dnsList.Remove(obj);
                                    lvi.ForeColor = Color.Red;
                                    server.LocalSpeed = -1;
                                    RefreshServerList(2, server);
                                    lvi.SubItems[1].Text = string.Format("服务器 [{0}] 当前不可用. ({1})", obj.Ip, obj.Message);
                                }
                            }
                            else
                            {
                                dnsList.Remove(obj);
                                lvi.ForeColor = Color.Red;
                                server.LocalSpeed = -2;
                                RefreshServerList(3, server);
                                lvi.SubItems[1].Text = string.Format("服务器 [{0}] 已禁止了您的IP. ({1})", obj.Ip, obj.Message);
                            }
                            uploadList.Add(server);
                            lvSwitch.Items.Insert(0, lvi);
                        });
                    }
                });
                    
                //});
                //rbtnFishlee.Checked? Properties.Resources.GetDnsInterface:Properties.Resources.GetDnsInterfaceATM
                //排序
                if (ct.IsCancellationRequested)
                {
                    return;
                }
                dnsListTmp = dnsList;
                getlist.SortList((lists) =>
                {
                    AddSwitchListViewItem("服务器测试完毕...共得到可用服务器{0}个", Color.Navy, new object[] { dnsListTmp.Count });
                    //上报到云端
                    try
                    {
                        AddSwitchListViewItem("开始上报到云端...", Color.Navy, "");
                        var wc = new WebClient();
                        wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                        wc.UploadString(uploadCloud, "POST", string.Format("kyfw.12306.cn={0}", HttpUtility.UrlEncode(JsonConvert.SerializeObject(this.uploadList))));
                        AddSwitchListViewItem("上报成功...", Color.Navy, "");
                        dnsListTmp = lists;
                    }   
                    catch {
                        AddSwitchListViewItem("上报失败...", Color.Navy, "");
                    }
                }, dnsListTmp, GetIPInfoList.SortOrder.Ascending);
                switchSeed = 0;
                CDNSwitcher.CDN_List.Clear();
                CDNSwitcher.CDN_List.AddRange(dnsListTmp);
                //开启监控线程
                if (!listenFlag)
                {
                    try
                    {
                        hostAction.AddDnsResolve(dnsListTmp[0].Ip, domain);
                        switchSeed++;
                    }
                    catch { }
                    ListenLocalHost();
                }
                Thread.Sleep(60 * 60 * 1000);
                lvServerList.Clear();
                StartGetDnsList();
            }
        }

        private void AddSwitchListViewItem(string str, Color color, params object[] param)
        {
            DeterMineCall(() =>
            {
                var lvi = new ListViewItem();
                lvi.SubItems.Add("时间");
                lvi.SubItems.Add("信息");
                lvi.SubItems[0].Text = DateTime.Now.ToLongTimeString();
                lvi.SubItems[1].Text = string.Format(str, param);
                lvi.ForeColor = color;
                lvSwitch.Items.Insert(0, lvi);
            });
        }
        /// <summary>
        /// 启动监听线程
        /// </summary>
        private void ListenLocalHost()
        {
            listenFlag = true;
            ctsListen = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem(new WaitCallback(ListenMethod), ctsListen.Token);
        }

        /// <summary>
        /// 监听方法
        /// </summary>
        private void ListenMethod(object token)
        {
            var ct = (CancellationToken)token;
            if (ct.IsCancellationRequested)
            {
                return;
            }
            lock (locker)
            {
                var localhost = new Object_IP();
                string hostLine = hostAction.GetCacheServerIP(domain);
                if (ipAddress != null)
                {
                    localhost.Ip = ipAddress.ToString();
                    ipAddress = null;
                }
                else
                {
                    localhost.Ip = hostLine == "" ? domain : hostLine.Replace(" " + domain, "");
                }
                localhost.HttpSetSpeed();

                hostAction.AddDnsResolve(localhost.Ip, domain);

                if (localhost.Speed == null)
                {
                    timeOutCount++;
                    if (timeOutCount + lowCount < 2)
                    {
                        AddSwitchListViewItem("服务器 [{0}] 操作超时,已记录 [{1}] 次,连续累计超时或过慢2次则进行切换...", Color.FromArgb(192, 0, 192), localhost.Ip, timeOutCount + lowCount);
                    }
                    else
                    {
                        AddSwitchListViewItem("服务器 [{0}] 操作超时,正在切换...", Color.FromArgb(192, 0, 192), localhost.Ip);
                        ServerSwitch(ct, localhost, (obj) => localhost = obj);
                        timeOutCount = 0;
                    }
                }
                else
                {
                    if (localhost.Speed.Value.TotalSeconds > 1)//小于1秒,为正常速度
                    {
                        lowCount++;
                        if (timeOutCount + lowCount < 3)
                        {
                            AddSwitchListViewItem("服务器 [{0}] 速度过慢,响应速度={1}秒,已记录 [{2}] 次,连续累计超时或过慢3次则进行切换...", Color.FromArgb(192, 0, 192), localhost.Ip, localhost.Speed.Value.TotalSeconds.ToString("#0.00"), timeOutCount + lowCount);
                        }
                        else
                        {
                            AddSwitchListViewItem("服务器 [{0}] 速度过慢,响应速度={1}秒,正在切换...", Color.FromArgb(192, 0, 192), localhost.Ip, localhost.Speed.Value.TotalSeconds.ToString("#0.00"));
                            ServerSwitch(ct, localhost, (obj) => localhost = obj);
                            lowCount = 0;
                        }
                    }
                    else
                    {
                        AddSwitchListViewItem("服务器 [{0}] 正常,响应速度={1}秒", Color.Green, localhost.Ip, localhost.Speed.Value.TotalSeconds.ToString("#0.00"));
                        timeOutCount = 0;
                        lowCount = 0;
                    }
                }
            }
            Thread.Sleep(10000);
            ListenMethod(token);
        }
        /// <summary>
        /// 切换服务器
        /// </summary>
        /// <param name="objp">切换前的服务器</param>
        /// <param name="callback">切换后的服务器</param>
        /// <param name="flag">是否为手动切换</param>
        private void ServerSwitch(CancellationToken token, Object_IP objp, Action<Object_IP> callback,bool flag=false)
        {
            DeterMineCall(() =>
            {
                if (flag)
                {
                    objp.HttpSetSpeed();
                    switchSeed++;

                    if (objp.Speed != null)
                    {
                        hostAction.AddDnsResolve(objp.Ip, domain);
                        callback(objp);
                    }
                }
                else
                {
                    if (dnsListTmp.Count <= 0)
                    {
                        AddSwitchListViewItem("没有可用的服务器，请重启关闭本窗口重新启动并测试。", Color.Red, "");
                        ctsListen.Cancel();
                        ctsSwitch.Cancel();
                        return;
                    }
                    for (int i = switchSeed; i < dnsListTmp.Count; i++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }
                        objp.Ip = dnsListTmp[i].Ip;
                        objp.HttpSetSpeed();
                        switchSeed++;

                        if (objp.Speed != null)
                        {
                            hostAction.AddDnsResolve(objp.Ip, domain);
                            callback(objp);
                            break;
                        }
                    }
                    if (objp.Speed != null)
                    {
                        AddSwitchListViewItem("切换完成 [{0}] ,响应速度={1}秒", Color.Green, new object[] { objp.Ip, objp.Speed.Value.TotalSeconds.ToString("#0.00") });
                    }
                }
            });
        }

        private void lvServerList_DoubleClick(object sender, EventArgs e)
        {
            if (lvServerList.SelectedItems.Count > 0 && listenFlag)
            {
                var ip = new Object_IP() { Ip = lvServerList.SelectedItems[0].SubItems[0].Text };
                AddSwitchListViewItem("正在执行手动切换 服务器 [{0}] ", Color.FromArgb(192, 0, 192), ip.Ip);
                
                ServerSwitch(ctsSwitch.Token, ip, (objip) => {
                    AddSwitchListViewItem("切换完成 [{0}] ,响应速度={1}秒", Color.Green, new object[] { objip.Ip, objip.Speed.Value.TotalSeconds.ToString("#0.00") });
                },true);
            }
        }

        #endregion

        private void DeterMineCall(MethodInvoker method)
        {
            if (InvokeRequired && !this.IsDisposed)
                Invoke(method);
            else
                method();
        }
        private void formSwitchServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("如果您开启了自动切换功能，退出后程序会停止切换并恢复系统初始设置，你确定要退出吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            //{
                IsOver = true;
                ctsListen.Cancel();
                ctsSwitch.Cancel();
            //}
            //else
            //    e.Cancel = true;
        }

        private void formSwitchServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            dnsList.Clear();
            noticeSwitch.Visible = false;
        }

        private void 退出自动切换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInitHosts_Click(object sender, EventArgs e)
        {
            try
            {
                hostAction.RestoreHostsFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("由于访问Hosts文件失败，失败原因：{0}\r\n导致无法初始化Hosts文件，请允许程序访问Hosts文件或者去除Hosts文件的保护,然后重新启动本程序", ex.Message), "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnStopSwitch_Click(object sender, EventArgs e)
        {
            if (btnStopSwitch.Text == "启动自动切换服务器")
            {
                btnStopSwitch.Text = "正在启动...";
                Application.DoEvents();
                StartGetDnsList();
                btnStopSwitch.Text = "停止自动切换服务器";
            }
            else
            {
                btnStopSwitch.Text = "正在停止...";
                Application.DoEvents();
                ctsListen.Cancel();
                ctsSwitch.Cancel();
                AddSwitchListViewItem("线程已经取消", Color.Red, ""); 
                btnStopSwitch.Text = "启动自动切换服务器";
            }
        }

        private void notice_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            noticeSwitch.Visible = false;
        }

        private void lvServerList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvServerList.ListViewItemSorter = new CompareContext(e.Column, false);
            lvServerList.Sort();
        }

        private void formSwitchServer_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                noticeSwitch.Visible = true;
                this.Visible = false;
            }
        }
    }
}
