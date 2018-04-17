using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BIMFM.Web.Controllers.SignalR
{
    public class HuanXinActivity
    {
        private string currentToken;
        /// <summary>
        /// 获取APP管理员Token用于之后API中使用的Token
        /// </summary>
        /// <returns></returns>
        private async Task<bool> GenToken()
        {

            string url = "https://a1.easemob.com/beiliubei/arcplusfm/token";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.ContentType = "text/plain; charset=utf-8";

            request.Method = "POST";

            string postData = "{\"grant_type\":\"client_credentials\",\"client_id\":\"YXA65D6xoHw-Eee7_HOG6FC9yg\",\"client_secret\":\"YXA6RFfn3JzMpX8GN8bRXPnS7bH5edU\"}";
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(postData);
            request.ContentLength = byte1.Length;
            Stream newStream = request.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            newStream.Close();

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    return true;
                    //process the response
                }
            }
        }

        /// <summary>
        /// IM用户管理
        /// 注册单个用户
        /// </summary>
        /// <returns></returns>
        private async Task<bool> AddHxUser(string userName,string passWord)
        {

            string url = "https://a1.easemob.com/beiliubei/arcplusfm/users";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.ContentType = "application/json; charset=utf-8";
            request.Headers.Add("Authorization", "Bearer YWMtUqcRhIYfEee4pZOQ3jirIAAAAAAAAAAAAAAAAAAAAAHkPrGgfD4R57v8c4boUL3KAgMAAAFeAsv1fwBPGgD8B-LvqloSyoR5VP_qW8tqz6PeDwBfk4-zAD4zg0858g");

            request.Method = "POST";

            string postData = "{\"username\":\""+userName+"\",\"password\":\""+passWord+"\"}";
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(postData);
            request.ContentLength = byte1.Length;
            Stream newStream = request.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            newStream.Close();

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    return true;
                    //process the response
                }
            }
        }

        /// <summary>
        /// 用户修改密码后调用，重置密码
        /// </summary>
        /// <returns></returns>
        private async Task<bool> ResetHXPwd()
        {

            string url = "https://a1.easemob.com/beiliubei/arcplusfm/chatgroups";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.ContentType = "text/plain; charset=utf-8";
            request.Headers.Add("Authorization", "Bearer YWMtUqcRhIYfEee4pZOQ3jirIAAAAAAAAAAAAAAAAAAAAAHkPrGgfD4R57v8c4boUL3KAgMAAAFeAsv1fwBPGgD8B-LvqloSyoR5VP_qW8tqz6PeDwBfk4-zAD4zg0858g");

            request.Method = "POST";

            string postData = "{\n  \"groupname\": \"testrestgrp12\",\n  \"desc\": \"server create group\",\n  \"public\": true,\n  \"approval\": true,\n  \"owner\": \"liubei\",\n  \"maxusers\": 500,\n   \"members\":[\"liubei2\", \"liubei3\"]\n}";
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(postData);
            request.ContentLength = byte1.Length;
            Stream newStream = request.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            newStream.Close();

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    return true;
                    //process the response
                }
            }
        }

        /// <summary>
        /// 创建一个群组
        /// </summary>
        /// <returns></returns>
        private async Task<bool> GenChartGroup()
        {

            string url = "https://a1.easemob.com/beiliubei/arcplusfm/chatgroups/25051150745601/users/liubei2";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.Headers.Add("Authorization", "Bearer YWMtUqcRhIYfEee4pZOQ3jirIAAAAAAAAAAAAAAAAAAAAAHkPrGgfD4R57v8c4boUL3KAgMAAAFeAsv1fwBPGgD8B-LvqloSyoR5VP_qW8tqz6PeDwBfk4-zAD4zg0858g");

            request.Method = "POST";

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    return true;
                    //process the response
                }
            }
        }

        /// <summary>
        /// 删除群组
        /// </summary>
        /// <returns></returns>
        private async Task<bool> RemoveChartGroup()
        {

            string url = "https://a1.easemob.com/beiliubei/arcplusfm/chatgroups/25051150745601/admin";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.ContentType = "text/plain; charset=utf-8";
            request.Headers.Add("Authorization", "Bearer YWMtUqcRhIYfEee4pZOQ3jirIAAAAAAAAAAAAAAAAAAAAAHkPrGgfD4R57v8c4boUL3KAgMAAAFeAsv1fwBPGgD8B-LvqloSyoR5VP_qW8tqz6PeDwBfk4-zAD4zg0858g");

            request.Method = "POST";

            string postData = "{\"newadmin\":\"liubei2\"}";
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(postData);
            request.ContentLength = byte1.Length;
            Stream newStream = request.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            newStream.Close();

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    return true;
                    //process the response
                }
            }
        }

        /// <summary>
        /// 添加群组成员
        /// </summary>
        /// <returns></returns>
        private async Task<bool> AddGroupUser()
        {

            string url = "https://a1.easemob.com/beiliubei/arcplusfm/chatgroups/25051150745601/admin/liubei2";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.Headers.Add("Authorization", "Bearer YWMtUqcRhIYfEee4pZOQ3jirIAAAAAAAAAAAAAAAAAAAAAHkPrGgfD4R57v8c4boUL3KAgMAAAFeAsv1fwBPGgD8B-LvqloSyoR5VP_qW8tqz6PeDwBfk4-zAD4zg0858g");

            request.Method = "DELETE";

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    return true;
                    //process the response
                }
            }
        }

        /// <summary>
        /// 移除群组成员
        /// </summary>
        /// <returns></returns>
        private async Task<bool> RemoveGroupUser()
        {

            string url = "https://a1.easemob.com/beiliubei/arcplusfm/chatgroups/25051150745601/users/liubei2";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.Headers.Add("Authorization", "Bearer YWMtUqcRhIYfEee4pZOQ3jirIAAAAAAAAAAAAAAAAAAAAAHkPrGgfD4R57v8c4boUL3KAgMAAAFeAsv1fwBPGgD8B-LvqloSyoR5VP_qW8tqz6PeDwBfk4-zAD4zg0858g");

            request.Method = "DELETE";

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    return true;
                    //process the response
                }
            }
        }

        /// <summary>
        /// 添加群管理员
        /// </summary>
        /// <returns></returns>
        private async Task<bool> AddGroupAdmin()
        {

            string url = "https://a1.easemob.com/beiliubei/arcplusfm/chatgroups/25051078393857";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.Headers.Add("Authorization", "Bearer YWMtUqcRhIYfEee4pZOQ3jirIAAAAAAAAAAAAAAAAAAAAAHkPrGgfD4R57v8c4boUL3KAgMAAAFeAsv1fwBPGgD8B-LvqloSyoR5VP_qW8tqz6PeDwBfk4-zAD4zg0858g");

            request.Method = "DELETE";

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    return true;
                    //process the response
                }
            }
        }

        /// <summary>
        /// 移除群管理员
        /// </summary>
        /// <returns></returns>
        private async Task<bool> RemoveGroupAdmin()
        {

            string url = "https://a1.easemob.com/beiliubei/arcplusfm/users/liubei/password";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
            request.ContentType = "text/plain; charset=utf-8";
            request.Headers.Add("Authorization", "Bearer YWMtUqcRhIYfEee4pZOQ3jirIAAAAAAAAAAAAAAAAAAAAAHkPrGgfD4R57v8c4boUL3KAgMAAAFeAsv1fwBPGgD8B-LvqloSyoR5VP_qW8tqz6PeDwBfk4-zAD4zg0858g");

            request.Method = "POST";

            string postData = "{\n  \"newpassword\": \"123456\"\n}";
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] byte1 = encoding.GetBytes(postData);
            request.ContentLength = byte1.Length;
            Stream newStream = request.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);
            newStream.Close();

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    return true;
                    //process the response
                }
            }
        }
    }
}