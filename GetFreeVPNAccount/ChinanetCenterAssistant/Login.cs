using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChinanetCenterAssistant
{
    public partial class Login : Form
    {
        public const string IMG_URL = "https://portal.chinanetcenter.com/cas/captchaImage";
        public const string LOGIN_URL = "https://portal.chinanetcenter.com/cas/login?request_locale=zh_CN";
        public static string LTLT = "";
        Tools tools = new Tools();
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(LoginPOST));
            thread.Start();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            GetLTLogin();
            Thread thread = new Thread(new ThreadStart(ValidateShow));
            thread.Start();
        }
        private void GetLTLogin()
        {
            DotNet.Utilities.HttpHelper helper = new DotNet.Utilities.HttpHelper();
            DotNet.Utilities.HttpItem item = new DotNet.Utilities.HttpItem();
            DotNet.Utilities.HttpResult result = new DotNet.Utilities.HttpResult();
            item.URL = LOGIN_URL;
            item.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            item.ContentType = "application/x-www-form-urlencoded";
            item.Method = "GET";
            item.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:33.0) Gecko/20100101 Firefox/33.0";
            item.Referer = "https://portal.chinanetcenter.com/cas/login?request_locale=zh_CN";
            result = helper.GetHtml(item);
            string html = result.Html;
            int ltPOS = html.IndexOf("value=\"LT-");
            string ltType = html.Substring(ltPOS +7, 30);
            LTLT = ltType;
            //LoginPOST(ltType);
        }
        /// <summary>
        /// 显示验证码
        /// </summary>
        private void ValidateShow()
        {
            DotNet.Utilities.HttpHelper helper = new DotNet.Utilities.HttpHelper();
            DotNet.Utilities.HttpItem item = new DotNet.Utilities.HttpItem();
            DotNet.Utilities.HttpResult result = new DotNet.Utilities.HttpResult();
            item.URL = IMG_URL;
            item.ResultType = DotNet.Utilities.ResultType.Byte;
            result = helper.GetHtml(item);
            PicValidate.Image = tools.ByteArrayToImage(result.ResultByte);
        }
        private void LoginPOST()
        {
            DotNet.Utilities.HttpHelper helper = new DotNet.Utilities.HttpHelper();
            DotNet.Utilities.HttpItem item = new DotNet.Utilities.HttpItem();
            DotNet.Utilities.HttpResult result = new DotNet.Utilities.HttpResult();
            item.URL = LOGIN_URL;
            item.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            item.ContentType = "application/x-www-form-urlencoded";
            item.Method = "POST";
            item.UserAgent = "	Mozilla/5.0 (Windows NT 6.1; WOW64; rv:33.0) Gecko/20100101 Firefox/33.0";
            item.Referer = "https://portal.chinanetcenter.com/cas/login?request_locale=zh_CN";
            string postdata = string.Format("username={0}&password={1}&jcaptcha={2}&submit=登陆&lt={3}", TxtUsername.Text.Trim(), TxtPassword.Text.Trim(), TxtValidate.Text.Trim(), LTLT);
            item.Postdata = postdata;
            result = helper.GetHtml(item);
            string html = result.Html;
        }
        private void PicValidate_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ValidateShow));
            thread.Start();
        }
    }
}
