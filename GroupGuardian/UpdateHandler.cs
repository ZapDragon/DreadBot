using System;
using System.Collections.Generic;
using System.Threading;

namespace GroupGuardian
{
    class UpdateHandler
    {

        #region Update Handler Methods and varibles
        
        #endregion

        #region Handle new Update
        public static void Parse(Update update)
        {
            if (update.message != null)
            {
                
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

    }
}
