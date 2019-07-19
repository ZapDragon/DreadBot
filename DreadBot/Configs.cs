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
using System;
using System.Collections.Generic;

namespace DreadBot
{
    public class Configs
    {
        public static BotConfig RunningConfig;
        public static WebhookInfo webhookinfo = null;
        public static User Me;
        public static bool FirstRun = false;

        public static void Welcome()
        {
            Console.WriteLine("Welcome to DreadBot!\r\nIn order to setup your bot, you will need an access token provided by @BotFather on Telegram.\r\n");
            Console.Write("Please enter your token here and press enter: ");

            RunningConfig = new BotConfig();

            RunningConfig.token = Console.ReadLine();

            Console.Write("Verifying token...");

            Result<WebhookInfo> res = null;
            res = Methods.getWebhookInfo();
            if (!res.ok)
            {
                Logger.LogFatal(res.description);
            }
            else { webhookinfo = res.result; }


            Result<User> meres = null;
            meres = Methods.getMe();
            if (!meres.ok)
            {
                Logger.LogFatal(meres.description);
                return;
            }
            else { Me = meres.result; }
            

            if (webhookinfo == null || Me == null)
            {
                Console.WriteLine("Nope.\n\nTheres a problem with the accesstoken. Please test your token in a web browser.\r\n\r\nhttps://api.telegram.org/bot" + RunningConfig.token + "/getMe\r\n\r\nIf you still have problems, verify your token is correct from @BotFather.\r\nPress any key to exit...");
                Console.ReadKey();
                Database.db.Dispose();
                System.IO.File.Delete(Environment.CurrentDirectory + @"Dreadbot.db");
                Environment.Exit(Environment.ExitCode);
            }

            Console.WriteLine("Verified!\r\n\r\nBelow are the details to the bot, and its current settings.");

            Console.WriteLine("Bot ID: " + Me.id);
            Console.WriteLine("Bot Username: @" + Me.username);
            Console.WriteLine("Bot First Name: " + Me.first_name);
            Console.WriteLine("Bot Last Name: " + Me.last_name + "\r\n\r\n");
            Console.Title = "DreadBot: @" + Me.username;

            if (string.IsNullOrEmpty(webhookinfo.Url))
            {
                Console.WriteLine("WebHook Status: Disabled");
                RunningConfig.GetupdatesMode = true;
            }
            else
            {
                Console.WriteLine("WebHook Status: Enabled?!?!");
                RunningConfig.GetupdatesMode = false;
            }
        }
    }

    public class BotConfig
    {
        public BotConfig()
        {
            Owner = 0;
            Admins = new List<long>(16);
            AdminChat = 0;
            RetainChatTtiles = false;
            GULimit = 1;
            AdminListTimer = 1800;
            FirstLaunch = Utilities.EpochTime();
            LastLaunch = Utilities.EpochTime();
            GetupdatesMode = true;
            SystemSounds = true;
        }

        public int id { get; set; } //Database placeholder.
        public string token { get; set; } //Telegram bot access token.
        public long Owner { get; set; } // Id of the primary owner/operator of DreadBot. This account is the only one allowed to add admins, plugins.
        public List<long> Admins { get; set; } //List of User IDs to allow Administrative control over the bot.
        public long AdminChat { get; set; } //The id of a user, Group or Supergroup. This is used for debug information. Optionally also used for administrative commands.
        public bool AdminChatCommands { get; set; } //If AdminChat is a Group or Supergroup, this can be enabled to allow anyone in the chat to perform administrative commands.
        public bool RetainChatTtiles { get; set; } //Bool to enable to the bot to keep Chat titles after a certain amount of time. The related timer will still run for updating this list.
        public int GULimit { get; set; } //Abreveated "Get Updates Limit" - This is a value is used for how many updates at a time the bot should request in Get Updates mode. Use this setting CAREFULLY.
        public int AdminListTimer { get; set; } //Timer in seconds for cron to automatically update the local cache admin list of a group.
        public int FirstLaunch { get; set; } //The epoch time when the bot was first launched.
        public int LastLaunch { get; set; } //The epoch time when the bot was last launched.
        public bool GetupdatesMode { get; set; } //Toggle between GetUpdates and Webhook mode. This is controlled by The bot API.
        public bool SystemSounds { get; set; } //Enable/Disable the Platform playing sounds on types of Events.
    }
}
