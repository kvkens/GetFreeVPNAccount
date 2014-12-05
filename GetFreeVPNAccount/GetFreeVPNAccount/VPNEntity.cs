using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetFreeVPNAccount
{
    public class VPNEntity
    {
        public VPNEntity()
        {

        }
        /// <summary>
        /// 未知
        /// </summary>
        private string acceptterms = "1";
        /// <summary>
        /// 未知
        /// </summary>
        public string Acceptterms
        {
            get { return acceptterms; }
            set { acceptterms = value; }
        }
        /// <summary>
        /// 类型：创建账户
        /// </summary>
        private string adduser = "创建账户";
        /// <summary>
        /// 类型：创建账户
        /// </summary>
        public string Adduser
        {
            get { return adduser; }
            set { adduser = value; }
        }
        /// <summary>
        /// Email
        /// </summary>
        private string email;
        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        /// <summary>
        /// 语言:Chinese
        /// </summary>
        private string lang = "Chinese";
        /// <summary>
        /// 语言:Chinese
        /// </summary>
        public string Lang
        {
            get { return lang; }
            set { lang = value; }
        }
        /// <summary>
        /// 手机号
        /// </summary>
        private string mobile;
        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        /// <summary>
        /// 密码1
        /// </summary>
        private string password1 = "1234";
        /// <summary>
        /// 密码1
        /// </summary>
        public string Password1
        {
            get { return password1; }
            set { password1 = value; }
        }
        /// <summary>
        /// 密码2
        /// </summary>
        private string password2 = "1234";
        /// <summary>
        /// 密码2
        /// </summary>
        public string Password2
        {
            get { return password2; }
            set { password2 = value; }
        }
        /// <summary>
        /// 试用1
        /// </summary>
        private string srvid = "1";
        /// <summary>
        /// 试用1
        /// </summary>
        public string Srvid
        {
            get { return srvid; }
            set { srvid = value; }
        }
        /// <summary>
        /// 条款：提示：请仔细阅读以下条款，再注册帐号。使用本网站表示您同意遵守这些条款和条件。如果您不接受这些条款（“条款”），请勿注册。
        /// </summary>
        private string textarea = "提示：请仔细阅读以下条款，再注册帐号。使用本网站表示您同意遵守这些条款和条件。如果您不接受这些条款（“条款”），请勿注册。";
        /// <summary>
        /// 条款：提示：请仔细阅读以下条款，再注册帐号。使用本网站表示您同意遵守这些条款和条件。如果您不接受这些条款（“条款”），请勿注册。
        /// </summary>
        public string Textarea
        {
            get { return textarea; }
            set { textarea = value; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        private string username = "freevpn";
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username
        {
            get { return username; }
            set { username = value; }
        }


    }
}
