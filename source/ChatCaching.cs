using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using DreadBot;

namespace DreadBot
{
    public class ChatCaching
    {
        private static Dictionary<long, ChatCache> GroupCache = new Dictionary<long, ChatCache>();
        private static LiteCollection<ChatCache> chatCacheCol;
        internal static void Init()
        {
            chatCacheCol = Database.GetCollection<ChatCache>("chatcache");

            foreach (ChatCache chat in chatCacheCol.FindAll())
            {
                GroupCache.Add(chat.id, chat);
            }
        }

        #region Internal Update Events

        internal static void UpdatePinnedMsg(Message msg)
        {
            ChatCache chat = GetCache(msg.chat.id);
            chat.PinnedMessageHistory.Add(DateTime.Now, msg);
            Save(chat);
        }

        internal static void UpdateTitle(Message msg)
        {
            ChatCache chat = GetCache(msg.chat.id);
            chat.TitleHistory.Add(DateTime.Now, msg.new_chat_title);
            Save(chat);
        }

        internal static void UpdatePhoto(Message msg)
        {
            ChatCache chat = GetCache(msg.chat.id);
            chat.PhotoHistory.Add(DateTime.Now, msg.new_chat_photo[0]);
            Save(chat);
        }

        #endregion

        internal static void Save(ChatCache cChat)
        {
            lock (chatCacheCol)
            {
                chatCacheCol.Upsert(cChat);
            }
        }

        public static ChatCache GetCache(long ChatID)
        {
            if (GroupCache.ContainsKey(ChatID))
            {
                UpdateCache(GroupCache[ChatID]);
                return GroupCache[ChatID];
            }
            else
            {
                Result<Chat> gChatResult = Task.Run(() => Methods.getChat(ChatID)).Result;
                if (!gChatResult.ok)
                {
                    Logger.LogError("Could not getChat during Caching update. Chat Returned a null value.");
                    return null;
                }
                else
                {
                    Chat gChat = gChatResult.result;

                    ChatCache chat = new ChatCache();

                    chat.id = ChatID;
                    chat.can_set_sticker_set = gChat.can_set_sticker_set;
                    chat.description = gChat.description;
                    chat.first_name = gChat.first_name;
                    chat.invite_link = gChat.invite_link;
                    chat.last_name = gChat.last_name;
                    chat.permissions = gChat.permissions;
                    chat.photo = gChat.photo;
                    chat.pinned_message = gChat.pinned_message;
                    chat.title = gChat.title;
                    chat.type = gChat.type;

                    chat.LastUpdate = new DateTime(1900, 1, 1);
                    chat.Admins = new Dictionary<long, ChatMember>();
                    chat.TitleHistory = new SortedDictionary<DateTime, string>();
                    chat.PinnedMessageHistory = new SortedDictionary<DateTime, Message>();
                    chat.DescriptionHistory = new SortedDictionary<DateTime, string>();
                    chat.PhotoHistory = new SortedDictionary<DateTime, PhotoSize>();
                    chat.GlobalPerms = new ChatPermissions();

                    UpdateCache(chat);
                    lock (GroupCache) { GroupCache.Add(ChatID, chat); }
                    return chat;
                }
            }
        }

        internal static void UpdateCache(ChatCache chat, bool force = false)
        {

            TimeSpan t = DateTime.Now - chat.LastUpdate;
            if ((t.TotalSeconds > Configs.RunningConfig.ChatCacheTimer) || force)
            {
                chat.LastUpdate = DateTime.Now;
                Result<Chat> Chat = null;
                Chat = Task.Run(() => Methods.getChat(chat.id)).Result;
                if (Chat != null)
                {
                    if (!Chat.ok) { Logger.LogError("There was an error fetching the Chat info for " + chat.id + "\r\nReason: " + Chat.description); }
                    else
                    {
                        if (!chat.DescriptionHistory.ContainsValue(Chat.result.description))
                        {
                            chat.DescriptionHistory.Add(DateTime.Now, Chat.result.description);
                        }
                        chat.GlobalPerms = Chat.result.permissions;
                    }
                }

                Result<ChatMember[]> Admins = null;
                Admins = Task.Run(() => Methods.getChatAdministrators(chat.id)).Result;
                if (Admins != null)
                {
                    if (!Admins.ok) { Logger.LogError("There was an error fetching the Admin list for " + chat.id + "\r\nReason: " + Admins.description); }
                    else
                    {
                        chat.Admins.Clear();
                        foreach(ChatMember member in Admins.result)
                        {
                            if (member.status == "creator") { chat.owner_id = member.user.id; }
                            chat.Admins.Add(member.user.id, member);
                        }
                    }
                }
                Save(chat);
                Logger.LogDebug("Updated Cache for Chat: " + chat.id);
            }
        }

        internal static void ChatUpgrade(long from_chat_id, long to_chat_id)
        {
            ChatCache cChat = GetCache(from_chat_id);
            cChat.id = to_chat_id;
            Logger.LogDebug("Chat Upgraded (" + from_chat_id + " to " + to_chat_id + ") Title:" + cChat.title);
            Save(cChat);
        }
    }

    public class ChatCache : Chat
    {
        public long owner_id { get; set; }

        public DateTime LastUpdate { get; set; } = new DateTime();

        public DateTime LastForcedUpdate { get; set; } = new DateTime();

        public Dictionary<long, ChatMember> Admins { get; set; }
        
        public SortedDictionary<DateTime, string> TitleHistory { get; set; }

        public SortedDictionary<DateTime, PhotoSize> PhotoHistory { get; set; }

        public SortedDictionary<DateTime, string> DescriptionHistory { get; set; }

        public SortedDictionary<DateTime, Message> PinnedMessageHistory { get; set; }

        public ChatPermissions GlobalPerms { get; set; }


    }



}
