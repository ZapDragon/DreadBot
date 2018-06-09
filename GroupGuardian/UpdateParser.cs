using System;
using System.Collections.Generic;
using System.Threading;

namespace GroupGuardian
{
    class UpdateParser
    {

        #region UpdateParse Contructors and varibles
        private Thread thread;
        private Update update;
        public UpdateParser(Update thisUpdate)
        {
            update = thisUpdate;
            thread = new Thread(NewUpdate);
            thread.IsBackground = true;
            thread.Start();
        }
        #endregion

        #region Handle new Update
        private void NewUpdate()
        {
            if (update.message != null)
            {
                Console.WriteLine(update.message.text??"a message update happneed with no text?!");
                if (update.message.from != null) { }//UpdateUser(update.message.from); }
                if (update.message.forward_from != null) { }//UpdateUser(update.message.forward_from); }
                if (update.message.chat != null)
                {
                    if (update.message.chat.type != "private")
                    {
                        //AddChat(update.message.chat);
                        if (update.message.left_chat_member != null)
                        {

                        }
                        if (update.message.new_chat_members != null)
                        {
                            foreach(User user in update.message.new_chat_members)
                            {
                                //UpdateUser(user);
                            }
                        }
                    }
                }
                if (update.message.forward_from_chat != null)
                {
                    if (update.message.forward_from_chat.type != "private")
                    {
                        //AddChat(update.message.forward_from_chat);
                    }
                }
            }
            if (update.callback_query != null)
            {
                if (update.callback_query.from != null) { }//UpdateUser(update.callback_query.from); }
            }
            if (update.channel_post != null)
            {
                if (update.channel_post.from != null) { }//UpdateUser(update.channel_post.from); }
                if (update.channel_post.forward_from != null) { }//UpdateUser(update.channel_post.forward_from); }
            }
        }
        #endregion
        /*
        #region Add User to the Dictionary and Database
        private void UpdateUser(User user)
        {
            if (user.username == null) { user.username = ""; }
            if (user.last_name == null) { user.last_name = ""; }
            Console.WriteLine("Update user: " + user.username);
            
            Console.WriteLine("Casting " + user.id);
            lock (TLObjects.UserListByID) { TLObjects.UserListByID.TryGetValue(user.id, out user); }

            if (user != null)
            {
                //Username history checks and updates
                if (!user.UsernameHistory.ContainsKey(user.username))
                {
                    if (user.username != "") { user.UsernameHistory.Add(user.username, MainClass.EpochTime()); }
                    new DatabaseLoader().UpdateQuery("INSERT INTO usernamehistory VALUES (@userid, @username, " + MainClass.EpochTime() + ");", new Dictionary<string, object>(2)
                {
                    { "@userid", user.id },
                    { "@username", user.username }
                });
                }

                // Username DB Checks and updates
                if (user.username != user.username)
                {
                    user.username = user.username;
                    user.first_name = user.first_name;
                    user.last_name = user.last_name;

                    new DatabaseLoader().UpdateQuery("UPDATE tlusers SET Username = @username, FirstName = @firstname, LastName = @lastname;",
                        new Dictionary<string, object>(3)
                        {
                        { "@username", user.username },
                        { "@firstname", user.first_name },
                        { "@lastname", user.last_name }
                        }
                    );

                    lock (TLObjects.UserListByUsername)
                    {
                        long id = 0;
                        TLObjects.UserListByUsername.TryGetValue(user.username, out id);
                        if (id == 0) { TLObjects.UserListByUsername.Add(user.username, user.id); }
                        else if (id != user.id)
                        {
                            TLObjects.UserListByUsername.Remove(user.username);
                            TLObjects.UserListByUsername.Add(user.username, user.id);
                        }
                    }
                }
            }
            else
            {

                user.UsernameHistory.Add(user.username, MainClass.EpochTime());
                new DatabaseLoader().UpdateQuery("INSERT INTO usernamehistory VALUES (@userid, @username, " + MainClass.EpochTime() + ");", new Dictionary<string, object>(2)
                {
                    { "@userid", user.id },
                    { "@username", user.username }
                });

                new DatabaseLoader().UpdateQuery("INSERT INTO tlusers (`UserID`, `Username`, `FirstName`, `LastName`, `IsBot`) VALUE (@userid, @username, @firstname, @lastname, @isbot);", new Dictionary<string, object>(5)
            {
                { "@userid", user.id },
                { "@username", user.username },
                { "@firstname", user.first_name },
                { "@lastname", user.last_name },
                { "@isbot", user.is_bot }
            });

                lock (TLObjects.UserListByID) {
                    if (!TLObjects.UserListByID.ContainsKey(user.id)) { TLObjects.UserListByID.Add(user.id, user); }
                }
                lock (TLObjects.UserListByUsername) {
                    if (user.username != "" && !TLObjects.UserListByUsername.ContainsKey(user.username)) { TLObjects.UserListByUsername.Add(user.username, user.id); }
                }
                lock (TLObjects.BotUserList)
                {
                    if (!TLObjects.BotUserList.ContainsKey(user.id)) { TLObjects.BotUserList.Add(user.id, user); }
                }

            }
            
        }
        #endregion

        #region Add Chat to the Dictionary and Database
        private void AddChat(Chat chat)
        {
            TLChat tlchat = null;
            lock (TLObjects.ChatListByID) { TLObjects.ChatListByID.TryGetValue(chat.id, out tlchat); }

            if (tlchat != null)
            {
                tlchat.title = chat.title;
                tlchat.type = chat.type;
                new DatabaseLoader().UpdateQuery("UPDATE tlchats SET ChatTitle = @chattitle, ChatType = '" + tlchat.type + "' WHERE ChatID = " + tlchat.id + ";", new Dictionary<string, object>(1)
                    {
                        { "@chattitle", tlchat.title }
                    });
            }
            else
            {
                tlchat = new TLChat()
                {
                     all_members_are_administrators = chat.all_members_are_administrators,
                     can_set_sticker_set = chat.can_set_sticker_set,
                     description = chat.description != null ? chat.description : "",
                     first_name = chat.first_name != null ? chat.first_name : "",
                     id = chat.id,
                     invite_link = chat.invite_link != null ? chat.invite_link : "",
                     last_name = chat.last_name != null ? chat.last_name : "",
                     photo = chat.photo,
                     pinned_message = chat.pinned_message,
                     sticker_set_name = chat.sticker_set_name != null ? chat.sticker_set_name : "",
                     title = chat.title,
                     type = chat.type,
                     username = chat.username != null ? chat.username : ""
                };
                lock (TLObjects.ChatListByID) { TLObjects.ChatListByID.Add(chat.id, tlchat); }
                new DatabaseLoader().UpdateQuery("INSERT INTO tlchats (`ChatID`, `ChatType`, `ChatTitle`, `JoinDate`) VALUE (@chatid, @chattype, @chattitle, " + MainClass.EpochTime() + ");", new Dictionary<string, object>(3)
                {
                        { "@chatid", tlchat.id },
                        { "@chattype", tlchat.type },
                        { "@chattitle", chat.title }
                });
            }
        }
        #endregion
    */
    }
}
