using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.IO;
using System.Threading;

namespace DreadBot
{
    class MainClass
    {
        #region Main GetUpdates Loop

        public static long UpdateId = 0;
        public static readonly int LauchTime = Utilities.EpochTime();
        static void Main()
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(ExitCleanUp);

            Database.Init();

            Configs.Me = Methods.getMe();
            Configs.webhookinfo = Methods.getWebhookInfo();

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

            Console.Title = "DreadBot: @" + Configs.Me.username;
            Console.WriteLine(PluginManager.getPluginList() + "\n");
            Console.WriteLine("DreadBot Loaded, and Started!\n");

            while (true)
            {
                if (Configs.RunningConfig.GetupdatesMode) //GetUpdates Mode
                {
                    Update[] updates = null;
                    if (UpdateId == 0) {
                        updates = Methods.getOneUpdate(3600);
                        if (updates == null || updates.Length < 1) { continue; }
                        else
                        {
                            UpdateId = updates[0].update_id;
                            if (Configs.webhookinfo.pendingUpdateCount > 3) { Logger.LogInfo("Playing catchup; " + Configs.webhookinfo.pendingUpdateCount + " updates behind."); }
                        }
                    }
                    else
                    {
                        GetUpdates request = new GetUpdates() { timeout = 20, offset = ++UpdateId, limit = Configs.RunningConfig.GULimit };
                        updates = Methods.getUpdates(request);
                    }
                    if (updates.Length < 1) { continue; }
                    foreach (Update update in updates)
                    {
                        UpdateId = update.update_id;
                        Events.ParseUpdate(update);
                    }
                }
                else // Webhook mode
                {
                    // Webhook mode init Code.
                }
            }
        }

        #endregion

        #region Shutdown Cleanup

        private static void ExitCleanUp(object o, EventArgs e)
        {
            Logger.LogAdmin("Exiting DreadBot. Cleaning up...");

            Database.databaseCron.Abort();
            Database.dbEvent.OnDatabseFire();

            Cron.CronThread.Abort();

            if (Configs.RunningConfig.AdminChat != 0)
            {
                Methods.sendMessage(Configs.RunningConfig.AdminChat, "DreadBot is termining Cleaningly.");
            }
        }

        #endregion
    }
}
