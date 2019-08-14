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
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DreadBot
{
    public class Methods
    {
        #region Global Method Execution Object

        //This method is called by EVERY Telegram method. This is used to handle Most error checking, and the variable 'result' object is returned to the method that called this.
        private static Result<T> sendRequest<T>(Method method, string payload = "", string payloadType = "application/json", MultipartFormDataContent dataPayload = null)
        {
            //Console.WriteLine(method + " | " + payload);
            HttpResponseMessage response = null;
            int tryCount = 6;
            while (response == null) {
                if (tryCount == 0) {
                    Logger.LogFatal("Number of retries exceeded. Breaking out.");
                    return null;
                }
                try
                {
                    if (dataPayload == null) { response = Task.Run(() => new HttpClient().PostAsync("https://api.telegram.org/bot" + Configs.RunningConfig.token + "/" + method, new StringContent(payload, Encoding.UTF8, payloadType))).Result; }
                    else { response = Task.Run(() => new HttpClient().PostAsync("https://api.telegram.org/bot" + Configs.RunningConfig.token + "/" + method, dataPayload)).Result; }
                }
                catch
                {
                    Logger.LogError("Socket Exception: Cannot connect to telegram. Waiting 60 seconds before next attempt.");
                    Thread.Sleep(60000);
                }
                tryCount--;
            }
            if (!response.IsSuccessStatusCode) //HTTP Error handling
            {
                Logger.LogFatal("Http Status Code: (" + response.StatusCode + ") Reason:" + response.ReasonPhrase);
                return null;
            }
            else {
                Stream stream = Task.Run(() => response.Content.ReadAsStreamAsync()).Result;
                Result<T> result = ((new DataContractJsonSerializer(typeof(Result<T>))).ReadObject(stream)) as Result<T>;
                return result;
            }
        }
        //Making sure the object serialized, isnt null, and isnt an error.
        private static void isOk<T>(Result<T> res) {
            if (res == null) { Logger.LogError("Method Error: Method is null"); }
            else if (!res.ok) { Logger.LogError("(" + res.errorCode + ") " + res.description); }
        }

        #endregion

        #region Request Builder

        private static string buildRequest<T>(object o) {
            MemoryStream ms = new MemoryStream();
            new DataContractJsonSerializer(typeof(T)).WriteObject(ms, (T)o);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            return sr.ReadToEnd();
        }

        #endregion

        #region Telegram Bot Methods

        public static Result<Update[]> getUpdates(GetUpdates args = null)
        {
            Result<Update[]> result = null;
            if (args == null) { result = sendRequest<Update[]>(Method.getUpdates); }
            else { result = sendRequest<Update[]>(Method.getUpdates, buildRequest<GetUpdates>(args)); }
            isOk(result);
            return result;
        }
        public static Result<bool> setWebhook(SetWebHook args)
        {
            Result<bool> result = sendRequest<bool>(Method.setWebhook, buildRequest<SetWebHook>(args));
            isOk<bool>(result);
            return result;
        }
        public static Result<bool> deleteWebhook()
        {
            Result<bool> result = sendRequest<bool>(Method.deleteWebhook);
            isOk<bool>(result);
            return result;
        }
        public static Result<WebhookInfo> getWebhookInfo()
        {
            Result<WebhookInfo> result = sendRequest<WebhookInfo>(Method.getWebhookInfo);
            isOk<WebhookInfo>(result);
            return result;
        }
        public static Result<User> getMe()
        {
            return sendRequest<User>(Method.getMe);
        }
        public static Result<Message> sendMessage(long chatId, string text, string parse_mode = "markdown", InlineKeyboardMarkup keyboard = null)
        {
            SendMessageRequest smr = new SendMessageRequest()
            {
                chat_id = chatId,
                text = text,
                parse_mode = parse_mode
            };

            if (keyboard != null) { smr.reply_markup = keyboard; }
            Result<Message> result = null;
            result = sendRequest<Message>(Method.sendMessage, buildRequest<SendMessageRequest>(smr));
            isOk<Message>(result);
            return result;
        }
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
            isOk<Message>(result);
            return result;
        }
        public static Result<Message> forwardMessage(ForwardMessageRequest args)
        {
            Result<Message> result = null;
            if (args == null) { result = sendRequest<Message>(Method.forwardMessage); }
            else { result = sendRequest<Message>(Method.getUpdates, buildRequest<ForwardMessageRequest>(args)); }
            return result;
        }
        public static Result<Message> sendPhotoFile(long chatId, StreamContent fileData, string filename, string caption, string parse_mode = "markdown", bool disable_notification = false, int reply_to_message_id = 0, InlineKeyboardMarkup keyboard = null)
        {
            SendPhotoDataRequest spr = new SendPhotoDataRequest()
            {
                chat_id = chatId,
                caption = caption,
                parse_mode = parse_mode,
            };
            using (var form = new MultipartFormDataContent())
            {
                form.Add(new StringContent(chatId.ToString(), Encoding.UTF8), "chat_id");
                form.Add(fileData, "photo", filename);
                if (caption != null)
                {
                    form.Add(new StringContent(caption.ToString(), Encoding.UTF8), "caption");
                }
                if (parse_mode != null)
                {
                    form.Add(new StringContent(parse_mode.ToString(), Encoding.UTF8), "parse_mode");
                }
                if (disable_notification)
                {
                    form.Add(new StringContent(disable_notification.ToString(), Encoding.UTF8), "disable_notification");
                }
                if (reply_to_message_id != 0)
                {
                    form.Add(new StringContent(reply_to_message_id.ToString(), Encoding.UTF8), "reply_to_message_id");
                }
                if (keyboard != null)
                {
                    string payload1 = buildRequest<SendPhotoDataRequest>(spr);
                    form.Add(new StringContent(payload1, Encoding.UTF8), "reply_markup");
                }
                Result<Message> result = sendRequest<Message>(Method.sendPhoto, "", "", form);
                isOk(result);
                return result;
            }
        }
        public static Result<Message> sendPhoto(long chatId, string url, string caption, string parse_mode = "markdown", bool disable_notification = false, int reply_to_message_id = 0, InlineKeyboardMarkup keyboard = null)
        {
            SendPhotoUrlRequest spr = new SendPhotoUrlRequest()
            {
                photo_url = url,
                chat_id = chatId,
                caption = caption,
                parse_mode = parse_mode,
            };
            if (disable_notification) { spr.disable_notification = true; }
            if (reply_to_message_id != 0) { spr.reply_to_message_id = reply_to_message_id; }
            if (keyboard != null) { spr.reply_markup = keyboard; }
            Result<Message> result;
            result = sendRequest<Message>(Method.sendPhoto, buildRequest<SendPhotoUrlRequest>(spr));
            isOk(result);
            return result;
        }
        public static Result<Message> sendAudio(long chatId, StreamContent fileData, string filename, string caption, string parse_mode = "markdown", int duration = 0, string performer = "", string title = "", bool disable_notification = false, int reply_to_message_id = 0, InlineKeyboardMarkup keyboard = null)
        {
            SendAudioRequest spr = new SendAudioRequest()
            {
                chat_id = chatId,
                caption = caption,
                parse_mode = parse_mode,
            };
            using (var form = new MultipartFormDataContent())
            {
                form.Add(new StringContent(chatId.ToString(), Encoding.UTF8), "chat_id");
                form.Add(fileData, "audio", filename);
                if (caption != null)
                {
                    form.Add(new StringContent(caption.ToString(), Encoding.UTF8), "caption");
                }
                if (parse_mode != null)
                {
                    form.Add(new StringContent(parse_mode.ToString(), Encoding.UTF8), "parse_mode");
                }
                if (duration != 0)
                {
                    form.Add(new StringContent(duration.ToString(), Encoding.UTF8), "duration");
                }
                if (performer != "")
                {
                    form.Add(new StringContent(performer.ToString(), Encoding.UTF8), "performer");
                }
                if (title != "")
                {
                    form.Add(new StringContent(title.ToString(), Encoding.UTF8), "title");
                }
                if (disable_notification)
                {
                    form.Add(new StringContent(disable_notification.ToString(), Encoding.UTF8), "disable_notification");
                }
                if (reply_to_message_id != 0)
                {
                    form.Add(new StringContent(reply_to_message_id.ToString(), Encoding.UTF8), "reply_to_message_id");
                }
                if (keyboard != null)
                {
                    string payload1 = buildRequest<SendPhotoDataRequest>(spr);
                    form.Add(new StringContent(payload1, Encoding.UTF8), "reply_markup");
                }
                Result<Message> result = sendRequest<Message>(Method.sendAudio, "", "", form);
                isOk(result);
                return result;
            }
        }
        public static Result<Message> sendDocument()
        {
            return null;
        }
        public static Result<Message> sendVideo()
        {
            return null;
        }
        public static Result<Message> sendVoice()
        {
            return null;
        }
        public static Result<Message> sendVideoNote()
        {
            return null;
        }
        public static Result<Message[]> sendMediaGroup()
        {
            return null;
        }
        public static Result<Message> sendLocation()
        {
            return null;
        }
        public static Result<Message> editMessageLiveLocation() //Can apprently return a bool as well. (FUCK THIS)
        {
            return null;
        }
        public static Result<Message> stopMessageLiveLocation() //Can apprently return a bool as well.
        {
            return null;
        }
        public static Result<Message> sendVenue()
        {
            return null;
        }
        public static Result<Message> sendContact()
        {
            return null;
        }
        public static Result<bool> sendChatAction()
        {
            return null;
        }
        public static Result<UserProfilePhotos> getUserProfilePhotos(long user_id, int offset = 0, int limit = 0)
        {
            UserProfilePhotosRequest uppr = new UserProfilePhotosRequest() { user_id = user_id };
            if (offset > 0) { uppr.offset = offset; }
            if (limit > 0) { uppr.limit = limit; }
            Result<UserProfilePhotos> result = null;
            result = sendRequest<UserProfilePhotos>(Method.getUserProfilePhotos, buildRequest<UserProfilePhotosRequest>(uppr));
            isOk(result);
            return result;
        }
        public static Result<File> getFile()
        {
            return null;
        }

        public static Result<bool> kickChatMember(long chatId, long userId, int untilEpoch = 0)
        {
            KickChatMemberRequest kcmr = new KickChatMemberRequest()
            {
                chat_id = chatId,
                user_id = userId,
            };
            if (untilEpoch < 30) { kcmr.until_date = Utilities.EpochTime() + 10; }
            Result<bool> result = null;
            result = sendRequest<bool>(Method.kickChatMember, buildRequest<KickChatMemberRequest>(kcmr));
            isOk(result);
            return result;
        }
        public static Result<bool> unbanChatMember()
        {
            return null;
        }
        public static Result<bool> restrictChatMember()
        {
            return null;
        }
        public static Result<bool> promoteChatMember()
        {
            return null;
        }
        public static Result<string> exportChatInviteLink()
        {
            return null;
        }

        public static Result<bool> setChatPhoto()
        {
            return null;
        }
        public static Result<bool> deleteChatPhoto()
        {
            return null;
        }
        public static Result<bool> setChatTitle()
        {
            return null;
        }
        public static Result<bool> setChatDescription()
        {
            return null;
        }
        public static Result<bool> pinChatMessage()
        {
            return null;
        }
        public static Result<bool> unpinChatMessage()
        {
            return null;
        }
        public static Result<bool> leaveChat()
        {
            return null;
        }
        public static Result<Chat> getChat(long chat_id)
        {
            GetChatRequest gcr = new GetChatRequest() { chat_id = chat_id };
            Result<Chat> result = null;
            result = sendRequest<Chat>(Method.getChat, buildRequest<GetChatRequest>(gcr));
            isOk(result);
            return result;
        }
        public static Result<ChatMember[]> getChatAdministrators(long chat_id)
        {
            GetChatRequest gcr = new GetChatRequest() { chat_id = chat_id };
            Result<ChatMember[]> result = null;
            result = sendRequest<ChatMember[]>(Method.getChatAdministrators, buildRequest<GetChatRequest>(gcr));
            isOk(result);
            return result;
        }
        public static Result<int> getChatMembersCount()
        {
            return null;
        }
        public static Result<ChatMember> getChatMember(long chatId, long userId)
        {
            ChatMemberRequest gcmr = new ChatMemberRequest()
            {
                chat_id = chatId,
                user_id = userId
            };
            Result<ChatMember> result;
            result = sendRequest<ChatMember>(Method.getChatMember, buildRequest<ChatMemberRequest>(gcmr));
            isOk(result);
            return result;
        }
        public static Result<bool> setChatStickerSet()
        {
            return null;
        }
        public static Result<bool> deleteChatStickerSet()
        {
            return null;
        }

        public static Result<bool> answerCallbackQuery(string Callback, string text = "", bool show_alert = false, string url = "", int cache_time = 0)
        {
            AnswerCallBackRequest acbr = new AnswerCallBackRequest()
            {
                callback_query_id = Callback
            };

            if (text != "") { acbr.text = text; }
            acbr.show_alert = show_alert;
            if (url != "") { acbr.url = url; }
            if (cache_time != 0) { acbr.cache_time = cache_time; }

            Result<bool> result = null;
            result = sendRequest<bool>(Method.answerCallbackQuery, buildRequest<AnswerCallBackRequest>(acbr));
            isOk(result);
            return result;
        }
        public static Result<object> editMessageText(long chatId, long msgId, string text, string parse_mode = "markdown", InlineKeyboardMarkup keyboard = null) //Can apprently return a bool as well. 
        {
            EditMessageRequest smr = new EditMessageRequest()
            {
                chat_id = chatId,
                message_id = msgId,
                text = text,
                parse_mode = parse_mode
            };

            if (keyboard != null) { smr.reply_markup = keyboard; }
            Result<object> result = null;
            try {
                result = sendRequest<object>(Method.editMessageText, buildRequest<EditMessageRequest>(smr));
                isOk(result);
                return result;
            }
            catch { Logger.LogWarn("Failed to Parse wrong datatype 1"); }
            return null;
        }

        public static Result<Message> editMessageCaption() //Can apprently return a bool as well. 
        {
            return null;
        }
        public static Result<Message> editMessageReplyMarkup() //Can apprently return a bool as well. 
        {
            return null;
        }
        public static Result<bool> deleteMessage()
        {
            return null;
        }

        public static Result<Message> sendSticker()
        {
            return null;
        }
        public static Result<StickerSet> getStickerSet()
        {
            return null;
        }
        public static Result<File> uploadStickerFile()
        {
            return null;
        }
        public static Result<bool> createNewStickerSet()
        {
            return null;
        }
        public static Result<bool> addStickerToSet()
        {
            return null;
        }
        public static Result<bool> setStickerPositionInSet()
        {
            return null;
        }
        public static Result<bool> deleteStickerFromSet()
        {
            return null;
        }
        public static Result<bool> answerInlineQuery()
        {
            return null;
        }
        public static Result<Message> sendInvoice()
        {
            return null;
        }
        public static Result<bool> answerShippingQuery()
        {
            return null;
        }
        public static Result<bool> answerPreCheckoutQuery()
        {
            return null;
        }
        public static Result<Message> sendGame()
        {
            return null;
        }
        public static Result<Message> setGameScore() //Returns a Message, EditedMessage or Bool.
        {
            return null;
        }
        public static Result<GameHighScore[]> getGameScore()
        {
            return null;
        }

        #endregion

        #region DreadBot Methods

        //public static Update[] getFirstUpdates(int to = 1800)
        //{
        //    Result<Update[]> result = null;
        //    List<Update> updates = new List<Update>();
        //    result = sendRequest<Update[]>(Method.getUpdates, buildRequest<GetUpdates>(new GetUpdates() { limit = 1, timeout = to }));
        //
        //    if (result == null)
        //    {
        //        Logger.LogFatal("Getting First Update: Shit broke.");
        //        return null;
        //    }
        //    if (result.result.Length < 1)
        //    {
        //        return null;
        //    }
        //    updates.Add(result.result[0]);
        //
        //    isOk(result);
        //    try { MainClass.UpdateId = result.result[0].update_id; }
        //    catch { return null; }
        //
        //    long uid = MainClass.UpdateId;
        //    while (uid + Configs.webhookinfo.pendingUpdateCount > MainClass.UpdateId)
        //    {
        //        result = sendRequest<Update[]>(Method.getUpdates, buildRequest<GetUpdates>(new GetUpdates() { limit = 100, timeout = to, offset = MainClass.UpdateId + 1}));
        //        MainClass.UpdateId += result.result.Length;
        //        isOk(result);
        //        updates.AddRange(result.result);
        //    }
        //
        //    return updates.ToArray();
        //}

        public static Update[] getFirstUpdates(int to = 3600)
        {
            GetUpdates request = new GetUpdates() { limit = 1, timeout = to };
            
            Result<Update[]> result = sendRequest<Update[]>(Method.getUpdates, buildRequest<GetUpdates>(request));

            if (result.ok)
            {
                return result.result;
            }
            else
            {
                Logger.LogError("(" + result.errorCode + ") " + result.description);
                return null;
            }
        }


        #endregion
    }
    //Telegram Bot Method Enums
    #region Method Enums

    public enum Method : int
    {
        getMe = 0,
        sendMessage = 1,
        forwardMessage = 2,
        sendPhoto = 3,
        sendAudio = 4,
        sendDocument = 5,
        sendVideo = 6,
        sendAnimation = 7,
        sendVoice = 8,
        sendVideoNote = 9,
        sendMediaGroup = 10,
        sendLocation = 11,
        editMessageLiveLocation = 12,
        stopMessageLiveLocation = 13,
        sendVenue = 14,
        sendContact = 15,
        sendChatAction = 16,
        getUserProfilePhotos = 17,
        getFile = 18,
        kickChatMember = 19,
        unbanChatMember = 20,
        restrictChatMember = 21,
        promoteChatMember = 22,
        exportChatInviteLink = 23,
        setChatPhoto = 24,
        deleteChatPhoto = 25,
        setChatTitle = 26,
        setChatDescription = 27,
        pinChatMessage = 28,
        unpinChatMessage = 29,
        leaveChat = 30,
        getChat = 31,
        getChatAdministrators = 32,
        getChatMembersCount = 33,
        getChatMember = 34,
        setChatStickerSet = 35,
        deleteChatStickerSet = 36,
        answerCallbackQuery = 37,
        getUpdates = 38,
        getWebhookInfo = 39,
        deleteWebhook = 40,
        setWebhook = 41,
        editMessageText = 42,
        editMessageCaption = 43,
        editMessageMedia = 44,
        editMessageReplyMarkup = 45,
        deleteMessage = 46,
        sendPoll = 47,
        stopPoll = 48
    }
    #endregion
}
