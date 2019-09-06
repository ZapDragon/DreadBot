#region License
//MIT License
//Copyright(c) [2019]
//[Xylex Sirrush Rayne]
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

#endregion
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DreadBot
{
    partial class Methods
    {
        #region Global Method Execution Object

        //This method is called by EVERY Telegram method. This is used to handle Most error checking, and the variable 'result' object is returned to the method that called this.
        private static Result<T> sendRequest<T>(Method method, string payload = "", string payloadType = "application/json", MultipartFormDataContent dataPayload = null)
        {
            //Console.WriteLine(method + " | " + payload);
            HttpResponseMessage response = null;
            int tryCount = 6;
            while (response == null)
            {
                if (tryCount == 0)
                {
                    Logger.LogFatal("Number of retries to send request exceeded. Breaking out.");
                    return null;
                }
                try
                {
                    if (dataPayload == null) { response = Task.Run(() => new HttpClient().PostAsync("https://api.telegram.org/bot" + Configs.RunningConfig.token + "/" + method, new StringContent(payload, Encoding.UTF8, payloadType))).Result; }
                    else { response = Task.Run(() => new HttpClient().PostAsync("https://api.telegram.org/bot" + Configs.RunningConfig.token + "/" + method, dataPayload)).Result; }
                }
                catch
                {
                    Logger.LogError("Socket Exception: Cannot connect to telegram. Waiting 60 seconds before next attempt.");
                    Thread.Sleep(60000);
                }
                tryCount--;
            }
            if (!response.IsSuccessStatusCode) //HTTP Error handling
            {
                Logger.LogFatal("Http Status Code: (" + response.StatusCode + ") Reason:" + response.ReasonPhrase);
                return null;
            }
            else
            {
                Stream stream = Task.Run(() => response.Content.ReadAsStreamAsync()).Result;
                Result<T> result = ((new DataContractJsonSerializer(typeof(Result<T>))).ReadObject(stream)) as Result<T>;
                return result;
            }
        }
        private static void isOk<T>(Result<T> res)
        {
            if (res == null) { Logger.LogError("Method Error: Method is null"); }
            else if (!res.ok) { Logger.LogError("(" + res.errorCode + ") " + res.description); }
        }

        #endregion

        #region Request Builder

        private static string buildRequest<T>(object o)
        {
            MemoryStream ms = new MemoryStream();
            new DataContractJsonSerializer(typeof(T)).WriteObject(ms, (T)o);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            return sr.ReadToEnd();
        }

        #endregion

        #region Internal Methods
        internal static Result<Update[]> getUpdates(GetUpdates args = null)
        {
            Result<Update[]> result = null;
            if (args == null) { result = sendRequest<Update[]>(Method.getUpdates); }
            else { result = sendRequest<Update[]>(Method.getUpdates, buildRequest<GetUpdates>(args)); }
            isOk(result);
            return result;
        }
        internal static Result<bool> setWebhook(SetWebHook args)
        {
            Result<bool> result = sendRequest<bool>(Method.setWebhook, buildRequest<SetWebHook>(args));
            isOk<bool>(result);
            return result;
        }
        internal static Result<bool> deleteWebhook()
        {
            Result<bool> result = sendRequest<bool>(Method.deleteWebhook);
            isOk<bool>(result);
            return result;
        }
        /// <summary>
        /// Returns a WebHookInfo object which contains data about the bot, number of availible updates, and weather or not the bot is in Webhook mode. In Most cases, you wont need this.
        /// </summary>
        /// <returns></returns>
        public static Result<WebhookInfo> getWebhookInfo()
        {
            Result<WebhookInfo> result = sendRequest<WebhookInfo>(Method.getWebhookInfo);
            isOk<WebhookInfo>(result);
            return result;
        }

        #endregion
    }
}
