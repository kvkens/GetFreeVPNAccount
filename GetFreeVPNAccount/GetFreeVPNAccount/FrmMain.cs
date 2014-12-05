using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public bool PostRegisterVPN(string name, Encoding encoding)
        {
            string ret = string.Empty;
            string url = "http://user.tosver.com/reg.php?cont=store_user";
            string paramData = "lang=Chinese&username=" + name.Trim() + "&password1=1111&password2=1111&mobile=&email=&srvid=1&textarea=%E6%8F%90%E7%A4%BA%EF%BC%9A%E8%AF%B7%E4%BB%94%E7%BB%86%E9%98%85%E8%AF%BB%E4%BB%A5%E4%B8%8B%E6%9D%A1%E6%AC%BE%EF%BC%8C%E5%86%8D%E6%B3%A8%E5%86%8C%E5%B8%90%E5%8F%B7%E3%80%82%E4%BD%BF%E7%94%A8%E6%9C%AC%E7%BD%91%E7%AB%99%E8%A1%A8%E7%A4%BA%E6%82%A8%E5%90%8C%E6%84%8F%E9%81%B5%E5%AE%88%E8%BF%99%E4%BA%9B%E6%9D%A1%E6%AC%BE%E5%92%8C%E6%9D%A1%E4%BB%B6%E3%80%82%E5%A6%82%E6%9E%9C%E6%82%A8%E4%B8%8D%E6%8E%A5%E5%8F%97%E8%BF%99%E4%BA%9B%E6%9D%A1%E6%AC%BE%EF%BC%88%E2%80%9C%E6%9D%A1%E6%AC%BE%E2%80%9D%EF%BC%89%EF%BC%8C%E8%AF%B7%E5%8B%BF%E6%B3%A8%E5%86%8C%E3%80%82&acceptterms=1&adduser=%E5%88%9B%E5%BB%BA%E8%B4%A6%E6%88%B7";
            try
            {
                byte[] byteArray = encoding.GetBytes(paramData);
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(url));
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";
                webReq.ContentLength = byteArray.Length;
                webReq.Referer = "http://user.tosver.com/reg.php?cont=store_user";
                webReq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                webReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:23.0) Gecko/20100101 Firefox/23.0";
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }
            bool RegBool = false;
            if (ret.IndexOf("您的账户已经创建") != -1)
            {
                RegBool = true;
            }
            else
            {
                RegBool = false;
            }
            return RegBool;
        }
        private void BtnGetOneKey_Click(object sender, EventArgs e)
        {
            //bool b = PostRegisterVPN(tools.GetUserAccount(),Encoding.UTF8);

            UserEntity.Username = tools.GenerateRandomUserName();
            httpitem.Referer = "http://user.tosver.com/reg.php";
            httpitem.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            httpitem.ContentType = "application/x-www-form-urlencoded";
            httpitem.Method = "POST";
            httpitem.Postdata = tools.GetPOSTData(UserEntity.Username);
            //httpitem.Timeout = 10000;
            httpitem.URL = URL;
            httpitem.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:33.0) Gecko/20100101 Firefox/33.0";
            //MessageBox.Show(tools.GetPOSTData());
            //MessageBox.Show(httpitem.Postdata);
            httpresult = httphelper.GetHtml(httpitem);
            //string s = httpresult.Html;
            if ((httpresult.StatusCode == System.Net.HttpStatusCode.OK) && (httpresult.Html.IndexOf("您的账户已经创建") != -1))
            {
                TxtAccount.Text = UserEntity.Username;
                TxtPassword.Text = UserEntity.Password1;
                LabInfo.Text = "获取成功，请复制使用！";
            }
            
        }
    }
}
