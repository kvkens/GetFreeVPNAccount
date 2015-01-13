using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChinanetCenterAssistant
{
    public partial class MainFrm : Form
    {

        Login login = new Login();
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            
        }

        private void MainFrm_Shown(object sender, EventArgs e)
        {
            //login.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //GetSale();
            //webBrowser1.Url = new Uri("http://item.taobao.com/item.htm?id=41939750743");
        }
        private void GetSale()
        {
            DotNet.Utilities.HttpHelper helper = new DotNet.Utilities.HttpHelper();
            DotNet.Utilities.HttpItem item = new DotNet.Utilities.HttpItem();
            DotNet.Utilities.HttpResult result = new DotNet.Utilities.HttpResult();
            item.URL = "http://item.taobao.com/item.htm?id=41939750743";
            item.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            item.ContentType = "application/x-www-form-urlencoded";
            item.Method = "GET";
            item.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:33.0) Gecko/20100101 Firefox/33.0";
            item.Referer = "item.taobao.com";
            result = helper.GetHtml(item);
            string html = result.Html;
            //richTextBox1.Text = html;
            //LoginPOST(ltType);
        }
    }
}
