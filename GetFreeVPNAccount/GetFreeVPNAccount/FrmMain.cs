using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GetFreeVPNAccount
{
    public partial class FrmMain : Form
    {
        public delegate void UpdateRegisterText(VPNEntity entity);
        public delegate void CheckUpdateSuccessDelegate(string html);
        public const string URL = "http://user.tosver.com/reg.php?cont=store_user";
        public const string UPDATE_URL = "http://www.imyy.org/SoftUpdate/GetFreeVPNAccount/update.html";
        VPNEntity UserEntity = new VPNEntity();
        Tools tools = new Tools();
        DotNet.Utilities.HttpHelper httphelper = new DotNet.Utilities.HttpHelper();
        DotNet.Utilities.HttpItem httpitem = new DotNet.Utilities.HttpItem();
        DotNet.Utilities.HttpResult httpresult = new DotNet.Utilities.HttpResult();
        string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        Loading loading = new Loading();
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LabInfo.Text = "正在检测是否有新版本...";
            Thread update = new Thread(new ThreadStart(ExecuteUpdate));
            update.Start();
        }

        private void BtnCopyAccount_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TxtAccount.Text.Trim());
            LabInfo.Text = "用户名复制成功！";
            TxtAccount.BackColor = Color.AliceBlue;
        }

        private void BtnCopyPassword_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(TxtPassword.Text.Trim());
            LabInfo.Text = "密码复制成功！";
            TxtPassword.BackColor = Color.AliceBlue;
        }
        private void BtnGetOneKey_Click(object sender, EventArgs e)
        {
            Thread GoOneKeyThread = new Thread(new ThreadStart(ExecuteOneKey));
            GoOneKeyThread.Start();
            loading.ShowDialog();
        }
        /// <summary>
        /// 执行一键注册
        /// </summary>
        public void ExecuteOneKey()
        {
            UserEntity.Username = tools.GenerateRandomUserName();
            httpitem.Referer = "http://user.tosver.com/reg.php";
            httpitem.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            httpitem.ContentType = "application/x-www-form-urlencoded";
            httpitem.Method = "POST";
            httpitem.Postdata = tools.GetPOSTData(UserEntity.Username);
            httpitem.Timeout = 10000;
            httpitem.URL = URL;
            httpitem.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:33.0) Gecko/20100101 Firefox/33.0";
            httpresult = httphelper.GetHtml(httpitem);
            string s = httpresult.Html;
            if (httpresult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (httpresult.Html.IndexOf("您的账户已经创建") != -1)
                {
                    UserEntity.Html = httpresult.Html;
                    if (TxtAccount.InvokeRequired)
                    {
                        UpdateRegisterText urt = new UpdateRegisterText(RegisterSuccess);
                        TxtAccount.Invoke(urt, UserEntity);
                    }
                    else
                    {
                        RegisterSuccess(UserEntity);
                    }
                }
                else
                {
                    LabInfo.Text = "用户名重复，请重新尝试！";
                }

            }
            else
            {
                LabInfo.Text = "获取失败，请重试！";
            }
        }
        /// <summary>
        /// 检测升级
        /// </summary>
        public void ExecuteUpdate()
        {
            httpitem.Referer = "http://www.imyy.org/SoftUpdate/GetFreeVPNAccount/update.html";
            httpitem.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            httpitem.ContentType = "application/x-www-form-urlencoded";
            httpitem.Method = "GET";
            httpitem.Timeout = 10000;
            httpitem.URL = UPDATE_URL;
            httpitem.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:33.0) Gecko/20100101 Firefox/33.0";
            httpresult = httphelper.GetHtml(httpitem);
            string html = httpresult.Html;
            if (httpresult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                if (LabInfo.InvokeRequired)
                {
                    CheckUpdateSuccessDelegate checkdelegate = new CheckUpdateSuccessDelegate(CheckUpdateSuccess);
                    LabInfo.Invoke(checkdelegate, html);
                }
                else
                {
                    CheckUpdateSuccess(html);
                }
                
            }
        }
        public void RegisterSuccess(VPNEntity entity)
        {
            TxtAccount.Text = entity.Username;
            TxtPassword.Text = entity.Password1;
            LabInfo.Text = "获取成功，请复制使用！";
            File.AppendAllText(".\\Log.log", "用户名：【" + entity.Username + "】 密码：【1234】\r\n");
            loading.Close();
        }
        public void CheckUpdateSuccess(string html)
        {
            string serverver = html.Split('$')[0].Trim();
            string downurl = html.Split('$')[1].Trim();
            string whatnew = html.Split('$')[2].Trim();
            if (serverver == version)
            {
                LabInfo.Text = "当前已经是最新版本：" + version;
            }
            else
            {
                LabInfo.Text = "发现新版本：" + html.Split('$')[0] + " 当前：" + version + " 版本介绍：" + whatnew;
                if (MessageBox.Show("发现新版本：" + html.Split('$')[0] + " 当前：" + version + " 版本介绍：" + whatnew + "\n\n是否下载整合压缩包？", "发现新版本，是否更新！", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "iexplore.exe";
                    process.StartInfo.Arguments = downurl;
                    process.Start();
                }
            }
        }

        private void TimeClock_Tick(object sender, EventArgs e)
        {
            TssInfo.Text = "系统时间：" + DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("真的要关闭我嘛(⊙_⊙)？", "关闭", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
