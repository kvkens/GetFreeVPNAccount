using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace GetFreeVPNAccount
{
    public class Tools
    {
        public Tools()
        {
 
        }
        /// <summary>
        /// 获取随机注册用户名
        /// </summary>
        /// <returns></returns>
        public string GetUserAccount()
        {
            string TimeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string Name = "";
            return Name + TimeStamp;
        }
        public string GenerateRandomUserName()
        {
            //ABCDEFGHIJKLMNOPQRSTUVWXYZ
            string DictStr = "abcdefghijklmnopqrstuvwxyz0123456789";
            Random randomStr = new Random();
            string _username = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                char _username01 = DictStr[randomStr.Next(0, 35)];
                _username += _username01;
            }
            return _username + DateTime.Now.ToString("HHmmss");
        }
        /// <summary>
        /// 获取POST数据
        /// </summary>
        /// <returns></returns>
        public string GetPOSTData(string username)
        {
            VPNEntity entity = new VPNEntity();
            string POSTData = string.Format("lang={0}&username={1}&password1={2}&password2={3}&mobile={4}&email={5}&srvid={6}&textarea={7}&acceptterms={8}&adduser={9}", entity.Lang, username, entity.Password1, entity.Password1, entity.Mobile, entity.Email, entity.Srvid, entity.Textarea, entity.Acceptterms, entity.Adduser);
            return POSTData;
        }
        public void DownLoadFile(string url,string path)
        {
            WebClient webclient = new WebClient();
            webclient.DownloadFileAsync(new Uri(url), path);
        }
    }
}
