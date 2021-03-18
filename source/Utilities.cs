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
using System.Net.Http;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text.RegularExpressions;

namespace DreadBot
{
    //This class is used for each tool that can be used by DreadBot itself or any plugin that needs them. Translation System, Datestamps, Logging, ect.
    public class Utilities
    {
        public static List<string> AdminTokens = new List<string>();
        public static string OwnerToken;

        public static int EpochTime() { return (int)(DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds; }

        public static int ToEpoch(DateTime dateTime)
        {
            TimeSpan t = dateTime - new DateTime(1970, 1, 1);
            return (int)t.TotalSeconds;
        }

        public static string NormalTime(int e) { return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local).AddSeconds(e).ToString(); }

        internal static string CreateAdminToken(bool forOwner)
        {
            Random rand = new Random();
            string token = new string(Enumerable.Repeat("abcdefghijklnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWYZ123456789", 16).Select(s => s[rand.Next(s.Length)]).ToArray());
            if (forOwner) { OwnerToken = token; }
            else { AdminTokens.Add(token); }
            //Cron.NewJob();
            return token;
        }

        #region Permission Checking

        public static bool isBotAdmin(User user)
        {
            if (Configs.RunningConfig.Admins.Contains(user.id) || (Configs.RunningConfig.Owner == user.id)) { return true; }
            else return false;
        }

        public static bool isBotOwner(User user)
        {
            if (Configs.RunningConfig.Owner == user.id) { return true; }
            else return false;
        }

        public static bool isChatOwner(long userID, long chatID)
        {
            ChatCache cChat = ChatCaching.GetCache(chatID);
            if (cChat == null) { return false; }
            if (cChat.owner_id == userID) { return true;}
            return false;
        }

        public static bool isChatAdmin(long userID, long chatID)
        {
            ChatCache chat = ChatCaching.GetCache(chatID);
            if ((EpochTime() - ToEpoch(chat.LastUpdate)) >= Configs.RunningConfig.ChatCacheTimer) { ChatCaching.UpdateCache(chat); }

            if (chat.Admins.ContainsKey(userID))
            {
                ChatMember admin = chat.Admins[userID];
                if (admin.status == "creator" || admin.status == "administrator") { return true; }
            }
            return false;
        }

        public static bool CheckMemberPermission(long userID, long chatID, ChatMemberPerms perm)
        {
            ChatCache chat = ChatCaching.GetCache(chatID);
            if ((EpochTime() - ToEpoch(chat.LastUpdate)) >= Configs.RunningConfig.ChatCacheTimer) { ChatCaching.UpdateCache(chat); }

            if (chat.Admins.ContainsKey(userID))
            {
                ChatMember admin = chat.Admins[userID];
                if (admin.status == "creator") { return true; }
                if (admin.status == "administrator") { return PermCheck(admin, perm); }
            }
            else
            {
                Result<ChatMember> memberResult = Methods.getChatMember(chatID, userID);
                if (!memberResult.ok)
                {
                    Logger.LogWarn("There was an error while getting the permission for " + userID + " in chat " + chatID + "\nError: (" + memberResult.errorCode + ") Description: " + memberResult.description);
                    return false;
                }
                else
                {
                    ChatMember member = memberResult.result;
                    if (!member.is_member) { return false; }
                    if (member.status == "left") { return false; }
                    if (member.status == "kicked") { return false; }
                    if (member.status == "restricted") { return PermCheck(member, perm); }
                    if (member.status == "member") { return PermCheck(member, perm); }
                }
            }
            return false;

        }

        #endregion

        public static bool AdminCommand(Message msg)
        {
            if (!Configs.RunningConfig.Admins.Contains(msg.from.id) && (Configs.RunningConfig.Owner != msg.from.id)) { return false; }

            string[] cmd = msg.text.Trim().Split(' ');
            switch (Utilities.isAdminCommand(cmd[0]))
            {
                case "makemenu":
                    {
                        // /makemenu Yes,noop,0|No,noop,1|Back,noop,2|forward,noop,2
                        InlineKeyboardMarkup kb = new InlineKeyboardMarkup();
                        msg.text = msg.text.Replace("$makemenu ", "");
                        string[] buttons = msg.text.Split('|');
                        foreach (string button in buttons)
                        {
                            string[] bargs = button.Split(',');
                            try
                            {
                                kb.addCallbackButton(bargs[0], bargs[1], Convert.ToInt32(bargs[2]));
                            }
                            catch
                            {
                                Methods.sendReply(msg.chat.id, msg.message_id, "Missing button argument.");
                                return true;
                            }
                        }
                        Methods.sendMessage(msg.chat.id, "Demo Keyboard", "markdown", kb);
                        return true;
                    }

                case "save":
                    {
                        Database.SaveConfig();
                        Methods.sendReply(msg.chat.id, msg.message_id, "Flushed Database To Disk.");
                        return true;
                    }
                case "adminmenu":
                    {
                        if (msg.from.id != Configs.RunningConfig.Owner)
                        {
                            Logger.LogWarn("User attempted to use /adminmenu command: " + msg.from.id);
                            return true;
                        }
                        Logger.LogAdmin("Admin Menu Called: " + msg.from.id);
                        Menus.PostAdminMenu(msg.from.id);
                        return true;
                    }
                case "admintoken":
                    {
                        string token = Utilities.CreateAdminToken(false);
                        Methods.sendMessage(msg.from.id, "Have an admin send this to me to add them to the admin list.\n`/token " + token + "`");

                        return true;
                    }

                case "setdebug":
                    {
                        if (msg.from.id != Configs.RunningConfig.Owner)
                        {
                            Logger.LogWarn("User attempted to use /setdebug command: " + msg.from.id);
                            return true;
                        }
                        if (msg.chat.type == "private" || msg.chat.type == "channel")
                        {
                            Result<Message> res = Methods.sendReply(msg.chat.id, msg.message_id, "You can only assign a Group or Supergroup to be the Debug Chat.\nIf you want to reset it back to PM, please use the admin menu.");
                            if (!res.ok) { Logger.LogError("Error contacting the admin Chat: " + res.description); }
                            return true;
                        }
                        else
                        {
                            if (msg.chat.id == Configs.RunningConfig.AdminChat)
                            {
                                Result<Message> res = Methods.sendReply(msg.chat.id, msg.message_id, "Debug Chat is already set to this group.");
                                if (!res.ok) { Logger.LogError("Error contacting the admin Chat: " + res.description); }
                                return true;
                            }
                            else
                            {
                                Configs.RunningConfig.AdminChat = msg.chat.id;
                                Database.SaveConfig();
                                Result<Message> res = Methods.sendReply(msg.chat.id, msg.message_id, "Debug Chat is now set to this group.");
                                if (!res.ok) { Logger.LogError("Error contacting the admin Chat: " + res.description); }
                                Logger.LogAdmin("Debug Chat has been set to: " + msg.chat.id);
                                return true;
                            }
                        }
                    }


                default: return false;
            }


        }

        internal static bool Commands(Message msg)
        {
            string[] cmd = msg.text.Trim().Split(' ');
            switch (isCommand(cmd[0])) {
                  case "version":
                        {
                             TimeSpan t = TimeSpan.FromSeconds(Utilities.EpochTime() - MainClass.LauchTime);

                             string answer = string.Format("{0:D3} Days, {1:D2} Hours, {2:D2} Minutes, {3:D2} Seconds", t.Days, t.Hours, t.Minutes, t.Seconds);
                             Methods.sendReply(msg.chat.id, (int)msg.message_id, "Dread Bot " + Configs.Version + "\n\nUptime: " + answer);
                             return true;
                        }

                    case "updatecache":
                    {
                        if (Utilities.isChatAdmin(msg.from.id, msg.chat.id))
                        {
                            ChatCache chat = ChatCaching.GetCache(msg.chat.id);
                            if ((Utilities.EpochTime() - Utilities.ToEpoch(chat.LastUpdate)) >= 3600)
                            {
                                ChatCaching.UpdateCache(chat);
                                chat.LastForcedUpdate = DateTime.Now;
                                ChatCaching.Save(chat);
                                Methods.sendReply(msg.chat.id, msg.message_id, "The Cache for the group has been updated. You will be unable to use this command again for atleast 1 hour.");
                            }
                            else { Methods.sendReply(msg.chat.id, msg.message_id, "You can use this command only once per hour."); }
                        }
                        return true;
                    }

                    case "adminlist":
                    {
                        if (msg.chat.type == "group" || msg.chat.type == "supergroup")
                        {
                            ChatCache chat = ChatCaching.GetCache(msg.chat.id);
                            if ((Utilities.EpochTime() - Utilities.ToEpoch(chat.LastUpdate)) >= Configs.RunningConfig.ChatCacheTimer) { ChatCaching.UpdateCache(chat); }

                            StringBuilder sb = new StringBuilder();
                            sb.Append("👑 Creator\n");
                            List<string> Admins = new List<string>();
                            int i = 0;
                            foreach (ChatMember admin in chat.Admins.Values)
                            {
                                if (admin.status == "creator") { sb.Append("└" + admin.user.first_name + "\n\n"); }
                                else
                                {
                                    i++;
                                    Admins.Add(admin.user.first_name);
                                }
                            }

                            sb.Append("👮‍♂️ Admins (" + i + ")\n");
                            int j = 0;
                            foreach (string name in Admins)
                            {
                                if (i == j) { sb.Append("└ " + name); }
                                else { sb.Append("├" + name + "\n"); }
                                j++;
                            }
                            Methods.sendReply(msg.chat.id, msg.message_id, sb.ToString());
                        }
                        return true;
                    }
                case "token":
                    {
                        if (msg.chat.type != "private") { return false; }
                        if (cmd.Length == 2)
                        {
                            if (Utilities.OwnerToken == cmd[1])
                            {
                                StringBuilder sb = new StringBuilder();

                                Utilities.OwnerToken = "";
                                Configs.RunningConfig.Owner = msg.from.id;

                                sb.Append("Ownership of this bot has been claimed by " + msg.from.id + "\n");

                                if (!String.IsNullOrEmpty(msg.from.username)) //username can be null
                                {
                                    sb.Append("Username: @" + msg.from.username + "\n");
                                }
                                else { sb.Append("Username: -none-\n"); }

                                Methods.sendReply(msg.from.id, msg.message_id, "You have claimed ownership over this bot.\nPlease check out the [Wiki](http://dreadbot.net/wiki/) on getting me setup.\n\nFrom this point on, please use the admin command $adminmenu for DreadBot specific configuration.");

                                Configs.RunningConfig.GULimit = 100;
                                Configs.RunningConfig.AdminChat = msg.from.id;

                                Logger.LogAdmin(sb.ToString());

                                Database.SaveConfig();

                            }

                            else if (Utilities.AdminTokens.Contains(cmd[1]))
                            {
                                StringBuilder sb = new StringBuilder();

                                if (Configs.RunningConfig.Admins.Contains(msg.from.id))
                                {
                                    sb.Append("You are already an admin of this bot. No need to use a token.");
                                    Methods.sendReply(msg.from.id, msg.message_id, sb.ToString());
                                    Logger.LogAdmin("User tried to validate a token, despite already being an admin: " + msg.from.id);
                                    return true;
                                }
                                Utilities.AdminTokens.Remove(cmd[1]);
                                Configs.RunningConfig.Admins.Add(msg.from.id);
                                sb.Append(msg.from.first_name + " is now an admin of @" + Configs.Me.username);
                                Methods.sendReply(msg.from.id, msg.message_id, "You are now an admin. Welcome. :)");
                                Logger.LogAdmin(sb.ToString());
                                Methods.sendMessage(Configs.RunningConfig.AdminChat, sb.ToString());
                                return true;
                            }

                            else
                            {
                                Methods.sendReply(msg.from.id, (int)msg.message_id, "The token you have specified does not exist. This error has been logged.");
                                Result<Message> res = Methods.sendMessage(Configs.RunningConfig.AdminChat, "The token command was attempted by ([" + msg.from.id + "](tg://user?id=" + msg.from.id + ")) using the token " + cmd[1]);
                                if (res == null || !res.ok) { Logger.LogError("Error contacting the admin Chat: " + res.description); }
                                return true;
                            }
                        }
                        return true;
                    }
                case "config":
                    {
                        if (msg.chat.type != "supergroup") return false;
                        Methods.sendMessage(msg.from.id, "Here is the list of active running plugins with Configs's.", "markdown", Menus.PluginConfigMgr(msg.chat.id));
                        return true;
                    }

                default: return false;
            }
        }

        internal static bool isBlacklisted(User user)
        {
            if (Configs.RunningConfig.Blacklist.Contains(user.id)) { return true; }
            return false;
        }

        public static string Variables(string text, string title, string name, long id, string username)
        {
            string a = text.Replace("$username", "@" + username);
            string b = a.Replace("$title", title);
            string c = b.Replace("$name", name);
            string d = c.Replace("$id", id.ToString());
            string e = d.Replace("$idlink", "[" + id + "](tg://user?id=" + id + ")");
            return e;
        }

        public static string isCommand(string s)
        {
            char c = s[0];
            switch (c)
            {
                case '!': return Regex.Replace(s, @"^!([\w_]+)@" + Configs.Me.username, "$1");
                case '/': return Regex.Replace(s, @"^\/([\w_]+)@" + Configs.Me.username, "$1");
                default: return "";
            }
        }
        public static string isAdminCommand(string s)
        {
            char c = s[0];
            switch (c)
            {
                case '$': return s.Substring(1).Replace(@"^([\w_]+)@" + Configs.Me.username, "$1"); ;
                default: return "";
            }
        }

        private static bool PermCheck(ChatMember user, ChatMemberPerms perm)
        {
            switch (perm)
            {
                case ChatMemberPerms.CanBeEdited: { return user.can_be_edited ? true : false; }
                case ChatMemberPerms.CanPostMessages: { return user.can_post_messages ? true : false; }
                case ChatMemberPerms.CanEditMessages: { return user.can_edit_messages ? true : false; }
                case ChatMemberPerms.CanDeleteMessages: { return user.can_delete_messages ? true : false; }
                case ChatMemberPerms.CanRestrictMembers: { return user.can_restrict_members ? true : false; }
                case ChatMemberPerms.CanPromoteMembers: { return user.can_promote_members ? true : false; }
                case ChatMemberPerms.CanChangeInfo: { return user.can_change_info ? true : false; }
                case ChatMemberPerms.CanInviteUsers: { return user.can_invite_users ? true : false; }
                case ChatMemberPerms.CanPinMessages: { return user.can_pin_messages ? true : false; }
                case ChatMemberPerms.CanSendMessages: { return user.can_send_messages ? true : false; }
                case ChatMemberPerms.CanSendMedia: { return user.can_send_media_messages ? true : false; }
                case ChatMemberPerms.CanSendPolls: { return user.can_send_polls ? true : false; }
                case ChatMemberPerms.CanSendOther: { return user.can_send_other_messages ? true : false; }
                case ChatMemberPerms.CanAddWebPagePreviews: { return user.can_add_web_page_previews ? true : false; }
                default: return false;
            }
        }

        public enum ChatMemberPerms
        {
            CanBeEdited, //Administrators only. True, if the bot is allowed to edit administrator privileges of that user
            CanPostMessages, //Administrators only. True, if the administrator can post in the channel; channels only
            CanEditMessages, //Administrators only. True, if the administrator can edit messages of other users and can pin messages; channels only
            CanDeleteMessages, //Administrators only. True, if the administrator can delete messages of other users
            CanRestrictMembers, //Administrators only. True, if the administrator can restrict, ban or unban chat members
            CanPromoteMembers, //Administrators only. True, if the administrator can add new administrators with a subset of his own privileges or demote administrators that he has promoted, directly or indirectly (promoted by administrators that were appointed by the user)
            CanChangeInfo, //Administrators and restricted only. True, if the user is allowed to change the chat title, photo and other settings
            CanInviteUsers, //Administrators and restricted only. True, if the user is allowed to invite new users to the chat
            CanPinMessages, //Administrators and restricted only. True, if the user is allowed to pin messages; groups and supergroups only
            CanSendMessages, //Restricted only. True, if the user is allowed to send text messages, contacts, locations and venues
            CanSendMedia, //Restricted only. True, if the user is allowed to send audios, documents, photos, videos, video notes and voice notes
            CanSendPolls, //Restricted only. True, if the user is allowed to send polls
            CanSendOther, //Gifs, Games, Stickers, Inline
            CanAddWebPagePreviews //Restricted only. True, if the user is allowed to add web page previews to their messages

        }
    }
}
