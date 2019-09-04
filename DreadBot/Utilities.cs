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
using System.Text;
using System.Collections.Generic;
using System.Linq;
using DreadBot;

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
                            Database.SaveConfig();
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
