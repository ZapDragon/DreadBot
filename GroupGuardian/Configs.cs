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
        public static Config GlobalConfigs;

        public static void LoadConfig()
        {
            if (File.Exists(Environment.CurrentDirectory + @"\config.json"))
            {
                Stream fs = File.OpenRead(Environment.CurrentDirectory + @"\config.json");
                fs.Position = 1290;
                if (fs.ReadByte() != '{')
                {
                    long length = fs.Length;
                    for (int i = 0; i < length; i++)
                    {
                        if (fs.ReadByte() == '{')
                        {
                            fs.Position = i;
                            break;
                        }
                    }
                }



                try { GlobalConfigs = (Config)new DataContractJsonSerializer(typeof(Config)).ReadObject(fs); }
                catch (Exception e)
                {
                    Console.WriteLine("The local config file was found but an attempt to load it failed. Exception below.\r\n\r\n" + e + "\r\n\r\nWould you like to remove the existing file, and generate a new one? (Y = Yes or No = Any other Key)");
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Y)
                    {
                        try
                        {
                            File.Delete(Environment.CurrentDirectory + @"\config.json");
                            CreateConfig();
                        }
                        catch (Exception d)
                        {
                            Console.WriteLine("\r\nThere was an issue either deleting the file or writing the new one. Exception is below.\r\n\r\n" + d + "\r\n\r\nPlease manually delete the file located at\r\n" + Environment.CurrentDirectory + @"\config.json\r\n\r\n And run the bot again to attempt its recreation. If this problem continues, please make sure that the program has write access to the mentioned file.\r\n\r\nDO NOT Run this application in any Program Files Directories!\r\n\r\nPress any key to exit...");
                            Console.ReadKey();
                            Environment.Exit(1);
                        }
                        Console.WriteLine("The old file was been removed and a new template was created. Please edit this file and edit the required fields before launching again.\r\n\r\nPress any key to Exit...");
                        Console.ReadKey();
                        Environment.Exit(1);
                    }
                    else
                    { Environment.Exit(1); }
                }



                if (GlobalConfigs.BotSettings.Token == null)
                {
                    Console.WriteLine("Configuration Error!\r\n");
                    Console.WriteLine("You need to set the field Token To the token provided by Bot Father, on Telegram.");
                    Console.ReadLine();
                    Environment.Exit(-1);
                }

                if (GlobalConfigs.Admins == null || GlobalConfigs.Admins.Length <= 0)
                {
                    Console.WriteLine("Configuration Error!\r\n");
                    Console.WriteLine("You need to set the field Admins in an arry formmat\r\n[123456789] or [123456789,987654321]\r\nAs many users as youd like to have Admin access to the bot.\r\nYou MUST use the numeric Id of your account. Use @userinfobot to obtain it.");
                    Console.ReadLine();
                    Environment.Exit(-1);
                }

                if (GlobalConfigs.BotSettings.LogChatID == 0)
                {
                    Console.WriteLine("Configuration Error!\r\n");
                    Console.WriteLine("You need to set the field logchat To the chat ID of the SuperGroup you will use for logged events, and commands. Its a negitive number starting with -100. eg; -100123456789\r\n\r\nPlus Messenger will help you get this ID.");
                    Console.ReadLine();
                    Environment.Exit(-1);
                }
            }
            else
            {
                CreateConfig();
                Console.WriteLine("The config file \"config.json\" was not found, and a generic default file was created.\r\nPlease edit this file and add the settings required for the bot to function.");
                Console.ReadLine();
                Environment.Exit(-1);
            }
        }

        public static void CreateConfig()
        {
            Config newConfig = new Config();
            newConfig.BotSettings = new Bot();
            newConfig.DataBase = new DatabaseInfo();
            newConfig.BotSettings.CacheTimer = new CacheTimers();

            var fs = File.Create(Environment.CurrentDirectory + @"\config.json");
            StringBuilder sb = new StringBuilder();
            sb.Append("# \"Admins\" - A JSON Array of User IDs. Only give admin powers to HIGHLYtrusted users. Example: [123456789] or [123456789,987654321]\r\n");
            sb.Append("# \"AdminListTimer\" - The timer in seconds for how often a Groups Adminlist is ReCached. Default is 1800 (30 minutes)\r\n");
            sb.Append("# \"ChatTitleTimer\" - The timer in seconds for how often a Groups Title is ReCached. Default is 18000 (5 hours)\r\n");
            sb.Append("# \"CommandChars\" - An array of Characters used as the command identifier.\r\n");
            sb.Append("# \"LogApiErrors\" - If errors that are returned from telegram should be sent to \"LogChat\"\r\n");
            sb.Append("# \"LogChat\" - A SuperGroup or Channel ID for all error printing.A SuperGroup is recommended.Commanded testing and discussion between admins is especially useful.\r\n");
            sb.Append("# \"Token\" - The unique identifying Token provided by BotFather that gives this software access to your bot.Example: 987654321:krgyugEkHJKHFLJKHFKSGFRIgfj_klZJrl\r\n");
            sb.Append("# \"DataBaseType\" - Specifies which DataBase system you wish to use. Supported services: `mysql` Support for: postgre, mssql, mongodb is pending.\r\n");
            sb.Append("# \"Language\" - The default language for the bot when a new user attempts to use it. Users can change the language after performing /start\r\n");
            sb.Append("# \"Version\" - The last known version of the bot the software was at.This is set by GroupGuardian at every launch.No not change this unless told to.\r\n");

            //fs.Write(comments, 0, 1290);
            fs.Position = 0;
            var writer = JsonReaderWriterFactory.CreateJsonWriter(fs, Encoding.UTF8, true, true, "  ");

            new DataContractJsonSerializer(typeof(Config), new DataContractJsonSerializerSettings()).WriteObject(writer, newConfig);
            writer.Flush();
            fs.Close();
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
        public Bot BotSettings { get; set; }

        [DataMember(Name = "DataBase")]
        public DatabaseInfo DataBase { get; set; }

        [DataMember(Name = "WebHookMode")]
        public bool WebHookMode = false;

        [DataMember(Name = "WebHookDetails")]
        public WebHookDetails WebHookInfo = null;
    }

    [DataContract]
    class WebHookDetails
    {
        [DataMember(Name = "Url")]
        public string Url { get; set; }

        [DataMember(Name = "CertificateFilePath")]
        public string Certificate { get; set; }

        [DataMember(Name = "MaxConnextions")]
        public int MaxConnextions { get; set; }

        [DataMember(Name = "AllowedUpdates")]
        public string AllowedUpdates { get; set; }
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
    class Bot
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
        public int AdminListTimer = 18000;

        [DataMember(Name = "ChatTitleTimer")]
        public int ChatTitleTimer = 18000;
    }


}
