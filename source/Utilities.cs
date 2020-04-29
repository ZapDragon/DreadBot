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

        public static bool isOwner(long userID, long chatID)
        {
            ChatCache cChat = ChatCaching.GetCache(chatID);
            if (cChat == null) { return false; }
            if (cChat.owner_id == userID) { return true;}
            return false;
        }

        public static bool isAdmin(long userID, long chatID)
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

        public static void AdminCommand(Message msg, string[] Args)
        {
            if (msg != null)
            {
                if (Configs.RunningConfig.Admins.Contains(msg.from.id) || Configs.RunningConfig.Owner == msg.from.id)
                {
                    switch (Args[0].Substring(1))
                    {
                        case "save":
                            {
                                Database.SaveConfig();
                                Methods.sendReply(msg.chat.id, msg.message_id, "Flushed Database To Disk.");
                                break;
                            }
                        case "export":
                            {
                                if (Args.Length == 1)
                                {
                                    if ((msg.chat.id != Configs.RunningConfig.AdminChat) && (msg.chat.type == "group" || msg.chat.type == "supergroup"))
                                    {
                                        Methods.sendReply(msg.chat.id, msg.message_id, "Please PM me this command. These backups contain sensitive data, and I will not risk sharing it.");
                                        return;
                                    }
                                    else
                                    {
                                        //Methods.sendChatAction(msg.from.id, "upload_document");
                                        FileStream f = new FileStream(Environment.CurrentDirectory + "\\DreadBot-Export-" + Utilities.EpochTime() + ".json", FileMode.CreateNew);
                                        Stream s = Database.ExportDreadBotDB();
                                        byte[] b = new byte[s.Length];
                                        s.Read(b, 0, (int)s.Length);
                                        f.Write(b, 0, b.Length);
                                        f.Close();

                                        Methods.sendReply(msg.chat.id, msg.message_id, "The file has been written to a JSON file in the DreadBot dirrectory.");
                                        //Result<Message> res = Methods.sendDocument(msg.from.id, new StreamContent(compressedData), "DreadBot Database Export");
                                        //if (res == null || !res.ok) { Methods.sendReply(msg.chat.id, msg.message_id, "There was an error sending the Backup. Please consult the error log."); }
                                        break;
                                    }
                                }
                                else if (Args.Length == 2)
                                {
                                    Events.OnDatabaseExport(Args);
                                    break;
                                }
                                break;
                            }
                        case "import":
                            {
                                break;
                            }
                        case "setwebhook":
                            {
                                Methods.setWebhook(new SetWebHook() { url = Args[1] });
                                Methods.sendMessage(msg.chat.id, "Webhook set!");
                                break;
                            }
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
            string e = d.Replace("$link", "[" + id + "](tg://user?id=" + id + ")");
            return e;
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
