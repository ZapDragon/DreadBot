using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace GroupGuardian
{
    class Configs
    {
        public static Config RunningConfig;
        public static User Me;
        public static WebhookInfo webhookInfo;
    }


    class ConfigLoader
    {
        public ConfigLoader()
        {
            if (!System.IO.File.Exists(Environment.CurrentDirectory + @"\config.json"))
            {
                Configs.RunningConfig = new Config();
                Configs.RunningConfig.FirstLaunchEpoch = DateTime.UtcNow;
                Configs.RunningConfig.botSettings = new BotSettings();
                Configs.RunningConfig.DataBase = new DatabaseInfo();
                Configs.RunningConfig.botSettings.CacheTimer = new CacheTimers();

                Console.WriteLine("Local Config not found.\r\n");
                Console.WriteLine("Welcome to Group Guardian. In order to setup your bot, you will need an access token provided by @BotFather.\r\n");
                Console.Write("Please enter your token here and press enter: ");

                Configs.RunningConfig.botSettings.Token = Console.ReadLine();
            }
            else
            {
                Stream stream = null;
                Configs.RunningConfig = new Config();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Config));

                try { stream = System.IO.File.OpenRead(Environment.CurrentDirectory + @"\config.json"); }
                catch (Exception e) {
                    Console.WriteLine("Unable to read config.json. Exception details below.\r\n\r\n\r\n");
                    Console.WriteLine(e);
                    Console.WriteLine("\r\n\r\n\r\nPress any key to exit...");
                    Console.ReadKey();
                    Environment.Exit(Environment.ExitCode);
                }
                
                try { ser.WriteObject(stream, Configs.RunningConfig); }
                catch (Exception e)
                {
                    Console.WriteLine("Unable to deserialize Config.json. Please make sure you arent editing this file unless you know what youre doing. Exception details below.\r\n\r\n\r\n");
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



            Console.ReadLine();



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
