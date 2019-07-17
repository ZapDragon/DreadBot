using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace DreadBot
{
    //This class is used for each tool that can be used by DreadBot itself or any plugin that needs them. Translation System, Datestamps, Logging, ect.
    public class Utilities
    {
        public static List<string> AdminTokens = new List<string>();
        public static string OwnerToken;

        public static int EpochTime() { return (int)(DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds; }

        public static string NormalTime(int e) { return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local).AddSeconds(e).ToString(); }

        public static string CreateAdminToken(bool forOwner)
        {
            Random rand = new Random();
            string token = new string(Enumerable.Repeat("abcdefghijklnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWYZ123456789", 16).Select(s => s[rand.Next(s.Length)]).ToArray());
            if (forOwner) { OwnerToken = token; }
            else { AdminTokens.Add(token); }
            //Cron.NewJob();
            return token;
        }

        public static void AdminCommand(Message msg, string[] Args)
        {
            if (Configs.RunningConfig.Admins.Contains(msg.from.id) || Configs.RunningConfig.Owner == msg.from.id)
            {
                switch (Args[0].Substring(1))
                {
                    case "save": {
                            Database.FlushConfig();
                            Methods.sendReply(msg.chat.id, msg.message_id, "Flushed Database To Disk.");
                            break;
                        }


                }
            }
        }

        public static string Variables(string text, string title, string name, long id, string username)
        {
            string a = text.Replace("$username", "@" + username);
            string b = a.Replace("$title", title);
            string c = b.Replace("$name", name);
            string d = c.Replace("$id", id.ToString());
            return d;
        }

        public static string isCommand(string s)
        {
            char c = s[0];
            switch (c)
            {
                case '!': return s.Substring(1);
                case '/': return s.Substring(1);
                default: return "";
            }
        }
        public static bool isAdminCommand(char c)
        {
            switch (c)
            {
                case '$': return true;
                default: return false;
            }
        }
    }
}
