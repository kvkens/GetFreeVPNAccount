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
        public const string LOGIN_URL = "https://portal.chinanetcenter.com/cas/login";
        Tools tools = new Tools();
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ValidateShow));
            thread.Start();
        }

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

        private void PicValidate_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ValidateShow));
            thread.Start();
        }
    }
}
