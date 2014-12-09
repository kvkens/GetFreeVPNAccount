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
        public string URL = "http://user.tosver.com/reg.php?cont=store_user";
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
            LabInfo.Text = "Kvkens 荣誉出品 当前版本：" + version;
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
                    if(TxtAccount.InvokeRequired)
                    {
                        UpdateRegisterText urt = new UpdateRegisterText(RegisterSuccess);
                        TxtAccount.Invoke(urt,UserEntity);
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
        public void RegisterSuccess(VPNEntity entity)
        {
            TxtAccount.Text = entity.Username;
            TxtPassword.Text = entity.Password1;
            LabInfo.Text = "获取成功，请复制使用！";
            loading.Close();
        }

        private void TimeClock_Tick(object sender, EventArgs e)
        {
            TssInfo.Text = "系统时间：" + DateTime.Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
        }
    }
}
