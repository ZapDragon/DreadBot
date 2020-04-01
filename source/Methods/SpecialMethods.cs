using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DreadBot
{
    public partial class Methods
    {

        public static Update[] getFirstUpdates(int to = 1800)
        {
            SortedDictionary<long, Update> updates = new SortedDictionary<long, Update>();
            Result<Update[]> result = null;

            if (Configs.webhookinfo.pendingUpdateCount == 0) { Configs.webhookinfo.pendingUpdateCount = 1; } //make it wait for first post anyways

            while (updates.Count() < Configs.webhookinfo.pendingUpdateCount)
            {
                GetUpdates u = new GetUpdates() { limit = 100, timeout = to };
                if (MainClass.UpdateId > 0) { u.offset = MainClass.UpdateId + 1; }

                result = sendRequest<Update[]>(Method.getUpdates, buildRequest<GetUpdates>(u));

                if (result == null || !result.ok || result.result.Length < 1) { continue; }

                foreach (Update update in result.result)
                {
                    updates.Add(update.update_id, update);
                    if (update.update_id > MainClass.UpdateId) { MainClass.UpdateId = update.update_id; }
                }
            }

            return updates.Values.ToArray();
        }

        //internal static Update[] getFirstUpdates(int to = 3600)
        //{
        //    GetUpdates request = new GetUpdates() { limit = 100, timeout = to };
        //
        //    Result<Update[]> result = sendRequest<Update[]>(Method.getUpdates, buildRequest<GetUpdates>(request));
        //
        //    if (result.ok)
        //    {
        //        return result.result;
        //    }
        //    else
        //    {
        //        Logger.LogError("(" + result.errorCode + ") " + result.description);
        //        return null;
        //    }
        //}

        /// <summary>
        /// This method is the same as kick, except it leaves the restriction on the user.
        /// </summary>
        /// <param name="chatId">The Numeric long that represents a group or channel ID. You cannot use a bot or user ID here.</param>
        /// <param name="userId">The Numeric long that represents a user or bot to ban.</param>
        /// <param name="untilEpoch">The Epoch date in which Telegram will automatically unban the users. Less then 30 seconds, or more than 365 days, the ban is permanant.</param>
        /// <returns></returns>
        public static Result<bool> banChatMember(long chatId, long userId, int untilEpoch = 0)
        {
            KickChatMemberRequest kcmr = new KickChatMemberRequest()
            {
                chat_id = chatId,
                user_id = userId,
            };
            if (untilEpoch < 30) { kcmr.until_date = Utilities.EpochTime() + 10; }
            Result<bool> result = null;
            result = sendRequest<bool>(Method.kickChatMember, buildRequest<KickChatMemberRequest>(kcmr));
            return result;
        }


        /// <summary>
        /// Sends a message to a Chat in response to another message, Channel, Group, or User. Returns the Result<Message> object on success.
        /// </summary>
        /// <param name="chat_id">The Id number od the chat to send a message. Can be a User, Channel, Or group. Cannot be a bot.</param>
        /// <param name="text">The text to send to the Chat. Character Limit of 4096.</param>
        /// <param name="messageId">The Message ID of the message you want the bot to reply to.</param>
        /// <param name="parse_mode">Makrkdown, HTML, or Empty. Tells telegram how to parse special markdown flags in the text. Makrdown by default.</param>
        /// <param name="keyboard">InlineKeyboardMarkup Object. Pass a built Keyboard object in here to include it in your messages.</param>
        /// <returns></returns>
        public static Result<Message> sendReply(long chatId, long messageId, string text, string parse_mode = "markdown", InlineKeyboardMarkup keyboard = null)
        {
            SendMessageRequest smr = new SendMessageRequest()
            {
                chat_id = chatId,
                text = text,
                parse_mode = parse_mode,
                reply_to_message_id = messageId
            };
            if (keyboard != null) { smr.reply_markup = keyboard; }
            Result<Message> result = sendRequest<Message>(Method.sendMessage, buildRequest<SendMessageRequest>(smr));
            return result;
        }

        /// <summary>
        /// Use this method to download a file after performing getFile(). The result will be a Stream.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Stream downloadFile(string token)
        {
            Uri uri = new Uri("https://api.telegram.org/bot" + Configs.RunningConfig.token + "/" + token);
            HttpResponseMessage resposne = null;
            try
            {
                resposne = Task.Run(() => new HttpClient().GetAsync(uri)).Result;
            }
            catch
            {
                Logger.LogError("Failed to download file.");
                return null;
            }
            HttpContent content = resposne.Content;
            return Task.Run(() => content.ReadAsStreamAsync()).Result;

        }
    }
}
