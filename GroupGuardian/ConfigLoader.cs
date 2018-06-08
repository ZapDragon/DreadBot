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
    }


    class ConfigLoader
    {
        
        public ConfigLoader()
        {
            if (System.IO.File.Exists(Environment.CurrentDirectory + @"\config.json"))
            {

            }
            else
            {
                Configs.RunningConfig = new Config();
                Configs.RunningConfig.botSettings = new BotSettings();
                Configs.RunningConfig.DataBase = new DatabaseInfo();
                Configs.RunningConfig.botSettings.CacheTimer = new CacheTimers();

                Console.WriteLine("Local Config not found.\r\n");
                Console.WriteLine("Welcome to Group Guardian. In order to setup your bot, you will need an access token provided by @BotFather.\r\n");
                Console.Write("Please enter your token here and press enter: ");

                Configs.RunningConfig.botSettings.Token = Console.ReadLine();

                Console.WriteLine("Verifying token...\r\n\r\n");
                WebhookInfo face = Methods.getWebhookInfo();

                if (face != null)
                {
                    Console.WriteLine("Got your bot's data:\r\n" + face.hasCertificate + "\r\n" + face.pendingUpdateCount + "\r\n" + face.allowedUpdates + "\r\n" + face.lastError + "\r\n\r\n");
                }



                Console.ReadLine();

            }
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

        //[DataMember(Name = "source_code")]
        //public string Source = "";

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
        public WebHookDetails WebHookInfo = null;
    }

    [DataContract]
    class WebHookDetails
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
        [DataMember(Name = "DataBaseType")]
        public string DataBaseType = "mysql";

        [DataMember(Name = "Host")]
        public string Host = "localhost";

        [DataMember(Name = "Port")]
        public int Port = 3306;

        [DataMember(Name = "Username")]
        public string Username { get; set; }

        [DataMember(Name = "Password")]
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
