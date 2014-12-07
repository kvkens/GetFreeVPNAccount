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
using System.Windows.Forms;

namespace GetFreeVPNAccount
{
    public partial class FrmMain : Form
    {
        public delegate void UpdateText();
        public string URL = "http://user.tosver.com/reg.php?cont=store_user";
        VPNEntity UserEntity = new VPNEntity();
        Tools tools = new Tools();
        DotNet.Utilities.HttpHelper httphelper = new DotNet.Utilities.HttpHelper();
        DotNet.Utilities.HttpItem httpitem = new DotNet.Utilities.HttpItem();
        DotNet.Utilities.HttpResult httpresult = new DotNet.Utilities.HttpResult();
        string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
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
            ExecuteOneKey();
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
                    TxtAccount.Text = UserEntity.Username;
                    TxtPassword.Text = UserEntity.Password1;
                    LabInfo.Text = "获取成功，请复制使用！";
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
    }
}
