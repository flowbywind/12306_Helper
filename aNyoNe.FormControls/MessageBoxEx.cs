using System;
using System.Drawing;
using System.Windows.Forms;

namespace aNyoNe.FormControls
{
    public partial class MessageBoxEx : Form
    {
        private bool _isFormLoad = true;
        private bool _isAutoClose = true;
        private double _opacityStep = 0.02;
        private int _height = 50;
        private int _width = 600;
        private Timer _timerRoll;
        private Timer _privateTimeRoll;
        private int _newInterval = 1;
        private int _newPrivateInterval = 3000;
        private Color _bkColor = Color.White;

        /// <summary>
        /// 设置背景色
        /// </summary>
        public Color BkColor
        {
            set { _bkColor = value; }
        }

        /// <summary>
        /// 设置变色间隔 (毫秒)
        /// </summary>
        public int NewInterval
        {
            set
            {
                if (_timerRoll == null)
                    _timerRoll = new Timer();
                if (value > 0)
                    _newInterval = value;
                else
                    throw new ArgumentOutOfRangeException("取值应为正整数");
            }
        }
        /// <summary>
        /// 如果设置了自动关闭，需设置悬停时间 (毫秒)
        /// </summary>
        public int NewPrivateInterval
        {
            set
            {
                if (_privateTimeRoll == null)
                    _privateTimeRoll = new Timer();
                if (value > 0)
                    _newPrivateInterval = value;
                else
                    throw new ArgumentOutOfRangeException("取值应为正整数");
            }
        }
        /// <summary>
        /// 设置高度
        /// </summary>
        public int NewHeight
        {
            set
            {
                if (value > 0 && value < 800)
                    _height = value;
                else
                    throw new ArgumentOutOfRangeException("你所设置的高度超出最大范围 800");
            }
        }

        /// <summary>
        /// 设置宽度
        /// </summary>
        public int NewWidth
        {
            set
            {
                if (value > 0 && value < 1200)
                    _width = value;
                else
                    throw new ArgumentOutOfRangeException("你所设置的高度超出最大范围 1200");
            }
        }
        /// <summary>
        /// 是否是加载窗体状态
        /// </summary>
        public bool IsFormLoad
        {
            set
            {
                _isFormLoad = value;
            }
        }
        /// <summary>
        /// 透明度step
        /// </summary>
        public double OpacityStep
        {
            set
            {
                if (value > 0 && value < 1)
                    _opacityStep = value;
                else
                    throw new ArgumentOutOfRangeException("取值范围应为 0-1 之间的小数");
            }
        }
        /// <summary>
        /// 是否自动关闭
        /// </summary>
        public bool IsAutoClose
        {
            set
            {
                _isAutoClose = value;
            }
        }

        public string Message
        {
            set { this.lblMessage.Text = value; }
        }

        public MessageboxExIcon Icon
        {
            set { pictureBox1.Image = GetIcon(value); }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public MessageBoxEx(string message,MessageboxExIcon ico)
        {
            InitializeComponent();
            this.lblMessage.Text = message;
            pictureBox1.Image = GetIcon(ico);
        }
        public MessageBoxEx()
        {
            InitializeComponent();
            pictureBox1.Image = GetIcon(MessageboxExIcon.OK);
            this.lblMessage.Text = "";
        }

        private Image GetIcon(MessageboxExIcon ico)
        {
            switch (ico)
            {
                case MessageboxExIcon.OK: return Resources.ok;
                case MessageboxExIcon.ERROR: return Resources.error;
                case MessageboxExIcon.Information: return Resources.information;
                case MessageboxExIcon.Question: return Resources.question;
                case MessageboxExIcon.Plus: return Resources.plus;
                case MessageboxExIcon.Substract: return Resources.substract;
            }
            return Resources.ok;
        }

        private void _timerRoll_Tick(object sender, EventArgs args)
        {
            if (_isFormLoad)//显示窗体
            {
                if (this.Opacity < 1)
                    this.Opacity += _opacityStep;
                else
                {
                    if (!_isAutoClose)//手动关闭
                        _timerRoll.Stop();
                    else
                    {
                        _timerRoll.Stop();
                        IsFormLoad = false;
                        _privateTimeRoll.Start();
                    }
                }
            }
            else//关闭窗体
            {
                if (this.Opacity > 0)
                    this.Opacity -= _opacityStep;
                else
                {
                    if (!_isAutoClose)
                        _timerRoll.Stop();
                    else
                    {
                        _timerRoll.Stop();
                        _timerRoll.Dispose();
                        _privateTimeRoll.Dispose();
                        this.Close();
                    }
                }
            }
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        public void CloseForm()
        {
            _isFormLoad = false;
            _timerRoll.Start();
        }

        private void FormInformation_Load(object sender, EventArgs e)
        {
            _timerRoll = new Timer() { Interval = _newInterval };
            _timerRoll.Tick += new EventHandler(_timerRoll_Tick);
            this.Height = _height;
            this.Width = _width;
            this.BackColor = _bkColor;
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2);
            _privateTimeRoll = new Timer() { Interval = _newPrivateInterval };
            _privateTimeRoll.Tick += new EventHandler(_privateTimeRoll_Tick);
            _timerRoll.Start();
        }

        private void _privateTimeRoll_Tick(object sender, EventArgs args)
        {
            _privateTimeRoll.Stop();
            _timerRoll.Start();
        }

        private void plMainForm_Click(object sender, EventArgs e)
        {
            CloseForm();//点击窗体关闭
        }

        private void lblMessage_MouseDown(object sender, MouseEventArgs e)
        {
            plMainForm.Focus();
        }

        /* 调用方法
            var fi = new FormInformation()
            {
                Opacity = 0,
                NewHeight = 50,
                NewWidth = 600,
                NewInterval = 1,
                NewPrivateInterval=3000,
                OpacityStep = 0.02,
                BkColor = Color.White,
                IsFormLoad = true,
                IsAutoClose=true
            };
            fi.ShowDialog();
         */
    }

    public enum MessageboxExIcon
    {
        OK=0,
        ERROR=1,
        Information=2,
        Question=3,
        Plus=4,
        Substract=5
    }
}
