using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Threading;

namespace GroupGuardian
{
    class Configs
    {
        public static Config RunningConfig;
        public static User Me;
        public static WebhookInfo webhookInfo;
        public static bool FirstRun = false;

        public static int EpochTime() { return (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds; }

        public static string NormalTime(int e) { return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local).AddSeconds(e).ToString(); }

        public static void FlushConfig()
        {
            try { new DataContractJsonSerializer(typeof(Config)).WriteObject(System.IO.File.OpenWrite(Environment.CurrentDirectory + @"\config.json"), RunningConfig); }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem with saving the local config file to disk. The exception is below.\r\n\r\n" + e + "\r\n\r\nThe bot CAN continue, but this exception will continue if the issue persists and you proceed. Please make sure you do not run this bot within your Program Files directory, and it has Write permissions. This error may also affect the DataBase, if its an error with writing to Disk.\r\n\r\nPress a Key to continue load... or close this Program to resolve the issue.\r\n");
                Console.ReadKey();
            }
        }

        public static string CreateAdminToken()
        {
            Random rand = new Random();
            return new string(Enumerable.Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 8).Select(s => s[rand.Next(s.Length)]).ToArray());
        }
    }


    class ConfigLoader
    {
        public ConfigLoader()
        {
            if (!System.IO.File.Exists(Environment.CurrentDirectory + @"\config.json"))
            {
                Configs.RunningConfig = new Config();
                Configs.RunningConfig.FirstLaunchEpoch = Configs.EpochTime();
                Configs.RunningConfig.botSettings = new BotSettings();
                Configs.RunningConfig.DataBase = new DatabaseInfo();
                Configs.RunningConfig.botSettings.CacheTimer = new CacheTimers();

                Console.WriteLine("Local Config not found.\r\n");
                Console.WriteLine("Welcome to Group Guardian. In order to setup your bot, you will need an access token provided by @BotFather.\r\n");
                Console.Write("Please enter your token here and press enter: ");

                Configs.RunningConfig.botSettings.Token = Console.ReadLine();
                Configs.FirstRun = true;
            }
            else
            {
                Configs.RunningConfig = new Config();

                try {

                    using (Stream ConfigStream = System.IO.File.OpenRead(Environment.CurrentDirectory + @"\config.json"))
                    {
                        DataContractJsonSerializer ConfigSerializer = new DataContractJsonSerializer(typeof(Config));
                        try { Configs.RunningConfig = ConfigSerializer.ReadObject(ConfigStream) as Config; }
                        catch (Exception e)
                        {
                            Console.WriteLine("Unable to deserialize Config.json. Please make sure you arent editing this file unless you know what youre doing. Exception details below.\r\n\r\n\r\n");
                            Console.WriteLine(e);
                            Console.WriteLine("\r\n\r\n\r\nPress any key to exit...");
                            Console.ReadKey();
                            Environment.Exit(Environment.ExitCode);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unable to read config.json. Exception details below.\r\n\r\n\r\n");
                    Console.WriteLine(e);
                    Console.WriteLine("\r\n\r\n\r\nPress any key to exit...");
                    Console.ReadKey();
                    Environment.Exit(Environment.ExitCode);
                }
            }

            Console.WriteLine("Verifying token...\r\n\r\n");

            try
            {
                Configs.webhookInfo = Methods.getWebhookInfo();
                Configs.Me = Methods.getMe();
            }
            catch (Exception)
            {
                Console.WriteLine("Theres a problem with the accesstoken. Please test your token in a web browser.\r\n\r\nhttps://api.telegram.org/bot" + Configs.RunningConfig.botSettings.Token + "/getMe\r\n\r\nIf you still have problems, verify your token is correct from @BotFather.\r\nPress any key to exit...");
                Console.ReadKey();
                Environment.Exit(Environment.ExitCode);
            }

            Console.WriteLine("Verified!\r\nBelow are the details to the bot, and its current settings.");

            Console.WriteLine("Bot ID: " + Configs.Me.id);
            Console.WriteLine("Bot Username: @" + Configs.Me.username);
            Console.WriteLine("Bot First Name: " + Configs.Me.first_name);
            Console.WriteLine("Bot Last Name: " + Configs.Me.last_name + "\r\n\r\nWeb Hook Info");

            Console.WriteLine("Current Webhook URL:" + Configs.webhookInfo.Url);
            Console.WriteLine("Number of Pending updates: " + Configs.webhookInfo.pendingUpdateCount);

            int LastErrorEpoch = Configs.webhookInfo.lastErrorEpoch;

            if (LastErrorEpoch > 0) { Console.WriteLine("Last Error at: " + Configs.NormalTime(LastErrorEpoch) + " With Error Message: " + Configs.webhookInfo.lastError); }
            else { Console.WriteLine("No pervious errors logged."); }

            Console.WriteLine("\r\n\r\nPress Pause/Break if you need to pause to review data before loading Group Guardian.\r\n");

            if (Configs.RunningConfig.Admins == null)
            {
                Console.WriteLine("There are no registered admins. Please use the command below to claim control over this bot.\r\n");
                Console.WriteLine("/admintoken " + Configs.CreateAdminToken() + "\r\n");

                //Add command here that will register the token for use to claim ownership.
            }

            Thread.Sleep(5000);

            Configs.FlushConfig();
        }
    }

    [DataContract]
    class Config
    {
        [DataMember(Name = "Language")]
        public string Language = "en";

        [DataMember(Name = "Version")]
        public string Version = "";

        [DataMember(Name = "UpdateChannel")]
        public string UpdateChannel = "@GroupGuardianUpdates";

        [DataMember(Name = "HelpGroup")]
        public string HelpGroup = "@GroupGuardianChat";

        [DataMember(Name = "Admins")]
        public long[] Admins { get; set; }

        [DataMember(Name = "BotSettings")]
        public BotSettings botSettings { get; set; }

        [DataMember(Name = "DataBase")]
        public DatabaseInfo DataBase { get; set; }

        [DataMember(Name = "AllowedUpdates", IsRequired = false)]
        public string[] AllowedUpdates = { "message", "edited_message", "callback_query" };

        [DataMember(Name = "WebHookMode")]
        public bool WebHookMode = false;

        [DataMember(Name = "WebHookDetails", IsRequired = false)]
        public WebhookConfig WebHookInfo = null;

        [DataMember(Name = "first_launch_epoch")]
        public int FirstLaunchEpoch { get; set; }

        [DataMember(Name = "last_launch_epoch")]
        public int LastLaunchEpoch { get; set; }

    }

    [DataContract]
    class WebhookConfig
    {
        [DataMember(Name = "Url")]
        public string Url { get; set; }

        [DataMember(Name = "CertificateFilePath")]
        public string Certificate { get; set; }

        [DataMember(Name = "MaxConnextions", IsRequired = false)]
        public int MaxConnextions { get; set; }

        [DataMember(Name = "AllowedUpdates", IsRequired = false)]
        public string[] AllowedUpdates { get; set; }
    }

    [DataContract]
    class DatabaseInfo
    {
        [DataMember(Name = "DataBaseType", IsRequired = true, EmitDefaultValue = true)]
        public string DataBaseType = "sqllite";

        [DataMember(Name = "Host", IsRequired = false, EmitDefaultValue = false)]
        public string Host = "localhost";

        [DataMember(Name = "Port", IsRequired = false, EmitDefaultValue = false)]
        public int Port = 3306;

        [DataMember(Name = "Username", IsRequired = false, EmitDefaultValue = false)]
        public string Username { get; set; }

        [DataMember(Name = "Password", IsRequired = false, EmitDefaultValue = false)]
        public string Password { get; set; }
    }


    [DataContract]
    class BotSettings
    {
        [DataMember(Name = "Token")]
        public string Token { get; set; }

        [DataMember(Name = "LogChat")]
        public long LogChatID { get; set; }

        [DataMember(Name = "CommandChars")]
        public char[] CommandChars = { '/', '!' };

        [DataMember(Name = "CacheTime")]
        public CacheTimers CacheTimer { get; set; }

        [DataMember(Name = "LogApiErrors")]
        public bool LogApiErrors = false;

    }

    [DataContract]
    public class CacheTimers
    {
        [DataMember(Name = "AdminListTimer")]
        public int AdminListTimer = 1800;

        [DataMember(Name = "KeepChatTitles")]
        public bool KeepChatTitles = false;

        [DataMember(Name = "ChatTitleTimer")]
        public int ChatTitleTimer = 18000;
    }


}
