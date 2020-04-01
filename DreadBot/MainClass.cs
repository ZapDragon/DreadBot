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
using System;
using System.Threading;
using System.Diagnostics;

namespace DreadBot
{
    public class MainClass
    {
        #region Main Class

        internal static long UpdateId = 0;
        internal static readonly int LauchTime = Utilities.EpochTime();
        public static Stopwatch sw; 
        static void Main()
        {
            #region Bot Initialization Phase

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(ExitCleanUp);

            Database.Init();

            Result<User> res = null;
            while (res == null) {
                res = Methods.getMe();
                if (res == null)
                {
                    Logger.LogError("Error getting bot info. Reattempting..");
                }
                else if (!res.ok)
                {
                    Logger.LogFatal("Error getting bot info (" + res.errorCode + ") " + res.description);
                    Logger.LogFatal("Press anykey to terminate...");
                    Console.ReadKey();
                    Environment.Exit(-1);
                }
            }

            Configs.Me = res.result;
            Result<WebhookInfo> webres = Methods.getWebhookInfo();
            if (!webres.ok)
            {
                Logger.LogFatal("Error getting bot info: " + webres.description);
                Environment.Exit(-1);
            }
            Configs.webhookinfo = webres.result;

            ChatCaching.Init();

            PluginManager.Init();

            Cron.CronInit();

            if (Configs.RunningConfig.Owner == 0)
            {
                Console.WriteLine("There is no owner assigned to this bot.\r\nPlease send me the command below to claim ownership.\r\nThis token will be deleted once you use it.\r\n\r\n");
                Console.WriteLine("/token " + Utilities.CreateAdminToken(true));
            }

            if (Configs.RunningConfig.AdminChat < 0 || Configs.RunningConfig.AdminChat > 0)
            {
                string text = "**DreadBot Started**\n" + Utilities.NormalTime(Utilities.EpochTime()) + "\n\n" + PluginManager.getPluginList();
                Methods.sendMessage(Configs.RunningConfig.AdminChat, text);
            }

            Console.Title = "DreadBot v" + Configs.Version + " @" + Configs.Me.username;
            Console.WriteLine(PluginManager.getPluginList() + "\n");
            Console.WriteLine("DreadBot Loaded, and Started!\n");

            if (!String.IsNullOrEmpty(Configs.webhookinfo.Url)) { Configs.RunningConfig.GetupdatesMode = false; } //WebHook is enabled. Launch in Webhook mode.

            #endregion

            while (true)
            {
                #region Main GetUpdates Loop

                if (Configs.RunningConfig.GetupdatesMode) //GetUpdates Mode
                {
                    Update[] updates = null;
                    if (UpdateId == 0) {
                        if (Configs.webhookinfo.pendingUpdateCount > 3) { Logger.LogInfo("Playing catchup; " + Configs.webhookinfo.pendingUpdateCount + " updates behind."); }
                        updates = Methods.getFirstUpdates(60);
                        if (updates == null || updates.Length < 1) { continue; }
                    }
                    else
                    {
                        GetUpdates request = new GetUpdates() { timeout = 20, offset = ++UpdateId, limit = Configs.RunningConfig.GULimit };
                        sw = new Stopwatch();
                        sw.Start();
                        Result<Update[]> updatesres = Methods.getUpdates(request);
                        if (!updatesres.ok)
                        {
                            Logger.LogError("Error fetching updates: (" + updatesres.errorCode + ") " + updatesres.description);
                            Thread.Sleep(10000);
                            continue;
                        }
                        updates = updatesres.result;
                    }
                    if (updates.Length < 1) { continue; }
                    foreach (Update update in updates)
                    {
                        UpdateId = update.update_id;
                        //Console.WriteLine("Parsing Update: " + UpdateId);
                        Events.ParseUpdate(update);
                    }
                }

                #endregion

                #region WebHook Loop

                else // Webhook mode
                {
                    //// Webhook Not Implemented.
                    Logger.LogError("DreadBot Cannot continue:\n\nWebhook Mode is enabled for this bot. This version of DreadBot does not have Webhook support and will close.\n\n");
                    ExitCleanUp(null, null);
                    Thread.Sleep(10000);
                    throw new NotImplementedException("This version of DreadBot does not have Webhook support and will terminate.");
                }

                #endregion
            }
        }

        #endregion

        #region Shutdown Cleanup

        private static void ExitCleanUp(object o, EventArgs e)
        {
            Logger.LogAdmin("Exiting DreadBot. Cleaning up...");

            Database.DisposeDB();

            Cron.CronThread.Abort();

            if (Configs.RunningConfig.AdminChat != 0)
            {
                Methods.sendMessage(Configs.RunningConfig.AdminChat, "DreadBot is termining Cleaningly.");
            }
        }

        #endregion
    }
}
