using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DreadBot
{
    public class Methods
    {
        #region Global Method Execution Object

        //This method is called by EVERY Telegram method. This is used to handle Most error checking, and the variable 'result' object is returned to the method that called this.
        public static HttpResponseMessage sendRequest(Method method, string payload = "", string payloadType = "application/json")
        {
            //Console.WriteLine(payload);

            HttpResponseMessage reponse = Task.Run(() => new HttpClient().PostAsync("https://api.telegram.org/bot" + Configs.RunningConfig.token + "/" + method, new StringContent(payload, Encoding.UTF8, payloadType))).Result;

            if (!reponse.IsSuccessStatusCode) //HTTP Error handling
            {
                Logger.LogError("Http Status Code: (" + reponse.StatusCode + ") Reason:" + reponse.ReasonPhrase);
                return null;
            }
            else { return reponse; }
        }

        #endregion


        #region Telegram Bot Methods

        public static Update[] getUpdates(GetUpdates args = null)
        {
            HttpResponseMessage response;
            if (args == null)
            {
                response = sendRequest(Method.getUpdates);
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                new DataContractJsonSerializer(typeof(GetUpdates)).WriteObject(ms, args);
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                response = sendRequest(Method.getUpdates, sr.ReadToEnd());
            }
            if (response.IsSuccessStatusCode)
            {
                Stream stream = Task.Run(() => response.Content.ReadAsStreamAsync()).Result;
                Result<Update[]> result = (Result<Update[]>)new DataContractJsonSerializer(typeof(Result<Update[]>)).ReadObject(stream);

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
            else return null;
        }

        public static bool setWebhook(SetWebHook args)
        {
            MemoryStream ms = new MemoryStream();
            new DataContractJsonSerializer(typeof(GetUpdates)).WriteObject(ms, args);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            HttpResponseMessage response = sendRequest(Method.setWebhook, sr.ReadToEnd());

            Stream stream = Task.Run(() => response.Content.ReadAsStreamAsync()).Result;
            Result<bool> result = (Result<bool>)new DataContractJsonSerializer(typeof(Result<bool>)).ReadObject(stream);

            if (result.ok) { return true; }
            else
            {
                Logger.LogError("[ERROR] (" + result.errorCode + ") " + result.description);
                return false;
            }
        }

        public static bool deleteWebhook()
        {
            HttpResponseMessage response = sendRequest(Method.deleteWebhook);

            Stream stream = Task.Run(() => response.Content.ReadAsStreamAsync()).Result;
            Result<bool> result = (Result<bool>)new DataContractJsonSerializer(typeof(Result<bool>)).ReadObject(stream);

            if (result.ok) { return true; }
            else
            {
                
                Logger.LogError("[ERROR] (" + result.errorCode + ") " + result.description);
                return false;
            }
        }

        public static WebhookInfo getWebhookInfo()
        {
            HttpResponseMessage response = sendRequest(Method.getWebhookInfo);

            Stream stream = Task.Run(() => response.Content.ReadAsStreamAsync()).Result;
            Result<WebhookInfo> result = (Result<WebhookInfo>)new DataContractJsonSerializer(typeof(Result<WebhookInfo>)).ReadObject(stream);

            if (result.ok) { return result.result; }
            else
            {
                Logger.LogError("[ERROR] (" + result.errorCode + ") " + result.description);
                return null;
            }
        }

        public static User getMe()
        {
            HttpResponseMessage response = sendRequest(Method.getMe);

            Stream stream = Task.Run(() => response.Content.ReadAsStreamAsync()).Result;
            Result<User> result = (Result<User>)new DataContractJsonSerializer(typeof(Result<User>)).ReadObject(stream);

            if (result.ok) { return result.result; }
            else
            {
                Logger.LogError("[ERROR] (" + result.errorCode + ") " + result.description);
                return null;
            }
        }

        public static Message sendMessage(long chatId, string text, string parse_mode = "markdown", InlineKeyboardMarkup keyboard = null)
        {
            SendMessageRequest smr = new SendMessageRequest()
            {
                chat_id = chatId,
                text = text,
                parse_mode = parse_mode
            };

            if (keyboard != null) { smr.reply_markup = keyboard; }
            
            HttpResponseMessage response;
            MemoryStream ms = new MemoryStream();
            new DataContractJsonSerializer(typeof(SendMessageRequest)).WriteObject(ms, smr);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            string payload = sr.ReadToEnd();
            response = sendRequest(Method.sendMessage, payload);
            
            if (response == null) { return null; }

            Stream stream = Task.Run(() => response.Content.ReadAsStreamAsync()).Result;
            Result<Message> result = (Result<Message>)new DataContractJsonSerializer(typeof(Result<Message>)).ReadObject(stream);

            if (result.ok)
            {
                return result.result;
            }
            else
            {
                Logger.LogError("[ERROR] (" + result.errorCode + ") " + result.description);
                return null;
            }
        }

        public static Message sendReply(long chatId, long messageId, string text, string parse_mode = "markdown", InlineKeyboardMarkup keyboard = null)
        {
            SendMessageRequest smr = new SendMessageRequest()
            {
                chat_id = chatId,
                text = text,
                parse_mode = parse_mode,
                reply_to_message_id = messageId
            };

            if (keyboard != null) { smr.reply_markup = keyboard; }

            HttpResponseMessage response;
            MemoryStream ms = new MemoryStream();
            new DataContractJsonSerializer(typeof(SendMessageRequest)).WriteObject(ms, smr);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            string payload = sr.ReadToEnd();
            response = sendRequest(Method.sendMessage, payload);

            Stream stream = Task.Run(() => response.Content.ReadAsStreamAsync()).Result;
            Result<Message> result = (Result<Message>)new DataContractJsonSerializer(typeof(Result<Message>)).ReadObject(stream);

            if (result.ok)
            {
                return result.result;
            }
            else
            {
                Logger.LogError("[ERROR] (" + result.errorCode + ") " + result.description);
                return null;
            }


        }

        public static Message forwardMessage(ForwardMessageRequest args)
        {
            HttpResponseMessage response;
            if (args == null)
            {
                response = sendRequest(Method.forwardMessage);
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                new DataContractJsonSerializer(typeof(GetUpdates)).WriteObject(ms, args);
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                response = sendRequest(Method.getUpdates, sr.ReadToEnd());
            }
            Stream stream = Task.Run(() => response.Content.ReadAsStreamAsync()).Result;
            Result<Message> result = (Result<Message>)new DataContractJsonSerializer(typeof(Result<Message>)).ReadObject(stream);

            if (result.ok)
            {
                return result.result;
            }
            else
            {
                Logger.LogError("[ERROR] (" + result.errorCode + ") " + result.description);
                return null;
            }
        }

        public static Message sendPhoto(long chatId, string url, string caption, string parse_mode = "markdown", bool disable_notification = false, int reply_to_message_id = 0, InlineKeyboardMarkup keyboard = null)
        {
            SendPhotoRequest spr = new SendPhotoRequest()
            {
                photo_url = url,
                chat_id = chatId,
                caption = caption,
                parse_mode = parse_mode,
            };

            if (disable_notification) { spr.disable_notification = true; }
            if (reply_to_message_id != 0) { spr.reply_to_message_id = reply_to_message_id; }
            if (keyboard != null) { spr.reply_markup = keyboard; }

            HttpResponseMessage response;
            MemoryStream ms = new MemoryStream();
            new DataContractJsonSerializer(typeof(SendPhotoRequest)).WriteObject(ms, spr);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            string payload = sr.ReadToEnd();
            //Console.WriteLine(payload);
            response = sendRequest(Method.sendPhoto, payload);

            if (response == null) { return null; }

            Stream stream = Task.Run(() => response.Content.ReadAsStreamAsync()).Result;
            Result<Message> result = (Result<Message>)new DataContractJsonSerializer(typeof(Result<Message>)).ReadObject(stream);

            if (result.ok)
            {
                return result.result;
            }
            else
            {
                Logger.LogError("[ERROR] (" + result.errorCode + ") " + result.description);
                return null;
            }
        }

        public static Message sendAudio()
        {
            return null;
        }

        public static Message sendDocument()
        {
            return null;
        }

        public static Message sendVideo()
        {
            return null;
        }

        public static Message sendVoice()
        {
            return null;
        }

        public static Message sendVideoNote()
        {
            return null;
        }

        public static Message[] sendMediaGroup()
        {
            return null;
        }

        public static Message sendLocation()
        {
            return null;
        }

        public static Message editMessageLiveLocation() //Can apprently return a bool as well. (FUCK THIS)
        {
            return null;
        }

        public static Message stopMessageLiveLocation() //Can apprently return a bool as well.
        {
            return null;
        }

        public static Message sendVenue()
        {
            return null;
        }

        public static Message sendContact()
        {
            return null;
        }

        public static bool sendChatAction()
        {
            return false;
        }

        public static UserProfilePhotos getUserProfilePhotos()
        {
            return null;
        }

        public static File getFile()
        {
            return null;
        }

        public static bool kickChatMember(long chatId, long userId, int untilEpoch = 1)
        {
            KickChatMemberRequest kcmr = new KickChatMemberRequest()
            {
                chat_id = chatId,
                user_id = userId,
                until_date = untilEpoch
            };

            HttpResponseMessage response;
            MemoryStream ms = new MemoryStream();
            new DataContractJsonSerializer(typeof(KickChatMemberRequest)).WriteObject(ms, kcmr);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            string payload = sr.ReadToEnd();
            response = sendRequest(Method.kickChatMember, payload);


            Stream stream = Task.Run(() => response.Content.ReadAsStreamAsync()).Result;
            Result<bool> result = (Result<bool>)new DataContractJsonSerializer(typeof(Result<bool>)).ReadObject(stream);

            if (result.ok)
            {
                return result.result;
            }
            else
            {
                Logger.LogError("[ERROR] (" + result.errorCode + ") " + result.description);
                return false;
            }
        }

        public static bool unbanChatMember()
        {
            return false;
        }

        public static bool restrictChatMember()
        {
            return false;
        }

        public static bool promoteChatMember()
        {
            return false;
        }

        public static string exportChatInviteLink()
        {
            return null;
        }

        public static bool setChatPhoto()
        {
            return false;
        }

        public static bool deleteChatPhoto()
        {
            return false;
        }

        public static bool setChatTitle()
        {
            return false;
        }

        public static bool setChatDescription()
        {
            return false;
        }

        public static bool pinChatMessage()
        {
            return false;
        }

        public static bool unpinChatMessage()
        {
            return false;
        }

        public static bool leaveChat()
        {
            return false;
        }

        public static Chat getChat(long chat_id)
        {
            GetChatRequest gcr = new GetChatRequest() { chat_id = chat_id };

            HttpResponseMessage response;
            MemoryStream ms = new MemoryStream();
            new DataContractJsonSerializer(typeof(GetChatRequest)).WriteObject(ms, gcr);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            string payload = sr.ReadToEnd();
            response = sendRequest(Method.getChat, payload);
            if (response == null) { return null; }

            Stream stream = Task.Run(() => response.Content.ReadAsStreamAsync()).Result;
            Result<Chat> result = (Result<Chat>)new DataContractJsonSerializer(typeof(Result<Chat>)).ReadObject(stream);

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

        public static ChatMember[] getChatAdministrators()
        {
            return null;
        }

        public static int getChatMembersCount()
        {
            return 0;
        }

        public static ChatMember getChatMember(long chatId, long userId)
        {
            ChatMemberRequest kcmr = new ChatMemberRequest()
            {
                chat_id = chatId,
                user_id = userId
            };

            HttpResponseMessage response;
            MemoryStream ms = new MemoryStream();
            new DataContractJsonSerializer(typeof(ChatMemberRequest)).WriteObject(ms, kcmr);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            string payload = sr.ReadToEnd();
            response = sendRequest(Method.getChatMember, payload);
            if (response == null) { return null; }

            Stream stream = Task.Run(() => response.Content.ReadAsStreamAsync()).Result;
            Result<ChatMember> result = (Result<ChatMember>)new DataContractJsonSerializer(typeof(Result<ChatMember>)).ReadObject(stream);

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

        public static bool setChatStickerSet()
        {
            return false;
        }

        public static bool deleteChatStickerSet()
        {
            return false;
        }

        public static bool answerCallbackQuery(string Callback, string text = "", bool show_alert = false, string url = "", int cache_time = 0)
        {
            AnswerCallBackRequest acbr = new AnswerCallBackRequest()
            {
                callback_query_id = Callback
            };

            if (text != "") { acbr.text = text; }
            acbr.show_alert = show_alert;
            if (url != "") { acbr.url = url; }
            if (cache_time != 0) { acbr.cache_time = cache_time; }

            HttpResponseMessage response;
            MemoryStream ms = new MemoryStream();
            new DataContractJsonSerializer(typeof(AnswerCallBackRequest)).WriteObject(ms, acbr);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            string payload = sr.ReadToEnd();
            response = sendRequest(Method.answerCallbackQuery, payload);

            if (response == null) {
                Logger.LogError("Answer Callback Query: Request returned a null object.");
                return false;
            }

            Stream stream = Task.Run(() => response.Content.ReadAsStreamAsync()).Result;

            Result<bool> result = null;
            try { result = (Result<bool>)new DataContractJsonSerializer(typeof(Result<bool>)).ReadObject(stream); }
            catch {
                Logger.LogWarn("Answer Callback Query: Failed to Parse Response.");
                return false;
            }

            if (result.ok) { return result.result; }
            else
            {
                Logger.LogError("Answer Callback Query: Response returned false. Code: " + result.errorCode + " - " + result.description );
                return false;
            }

        }

        public static Message editMessageText(long chatId, long msgId, string text, string parse_mode = "markdown", InlineKeyboardMarkup keyboard = null) //Can apprently return a bool as well. 
        {
            EditMessageRequest smr = new EditMessageRequest()
            {
                chat_id = chatId,
                message_id = msgId,
                text = text,
                parse_mode = parse_mode
            };

            if (keyboard != null) { smr.reply_markup = keyboard; }

            HttpResponseMessage response;
            MemoryStream ms = new MemoryStream();
            new DataContractJsonSerializer(typeof(EditMessageRequest)).WriteObject(ms, smr);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            string payload = sr.ReadToEnd();
            response = sendRequest(Method.editMessageText, payload);

            if (response == null) { return null; }

            Stream stream = Task.Run(() => response.Content.ReadAsStreamAsync()).Result;

            Result<Message> result1 = null;
            try { result1 = (Result<Message>)new DataContractJsonSerializer(typeof(Result<Message>)).ReadObject(stream); }
            catch { Logger.LogWarn("Failed to Parse wrong datatype 1"); }

            if (result1 != null)
            {
                if (result1.ok)
                {
                    return result1.result;
                }
                else
                {
                    Logger.LogError("(" + result1.errorCode + ") " + result1.description);
                    return null;
                }
            }

            Result<bool> result2 = null;
            try { result2 = (Result<bool>)new DataContractJsonSerializer(typeof(Result<bool>)).ReadObject(stream); }
            catch { Logger.LogWarn("Failed to Parse wrong datatype 2"); }

            if (result2 != null)
            {
                if (result2.ok)
                {
                    return new Message();
                }
                else
                {
                    Logger.LogError("(" + result2.errorCode + ") " + result2.description);
                    return null;
                }
            }
            return null;

        }

        public static Message editMessageCaption() //Can apprently return a bool as well. 
        {
            return null;
        }

        public static Message editMessageReplyMarkup() //Can apprently return a bool as well. 
        {
            return null;
        }

        public static bool deleteMessage()
        {
            return false;
        }

        public static Message sendSticker()
        {
            return null;
        }

        public static StickerSet getStickerSet()
        {
            return null;
        }

        public static File uploadStickerFile()
        {
            return null;
        }

        public static bool createNewStickerSet()
        {
            return false;
        }

        public static bool addStickerToSet()
        {
            return false;
        }

        public static bool setStickerPositionInSet()
        {
            return false;
        }

        public static bool deleteStickerFromSet()
        {
            return false;
        }

        public static bool answerInlineQuery()
        {
            return false;
        }

        public static Message sendInvoice()
        {
            return null;
        }

        public static bool answerShippingQuery()
        {
            return false;
        }

        public static bool answerPreCheckoutQuery()
        {
            return false;
        }

        public static Message sendGame()
        {
            return null;
        }

        public static Message setGameScore() //Returns a Message, EditedMessage or Bool.
        {
            return null;
        }

        public static GameHighScore[] getGameScore()
        {
            return null;
        }

        #endregion

        #region Group Guardian Methods

        public static Update[] getOneUpdate(int to = 1800)
        {
            GetUpdates request = new GetUpdates() { limit = 100, timeout = to };

            HttpResponseMessage response;
            MemoryStream ms = new MemoryStream();
            new DataContractJsonSerializer(typeof(GetUpdates)).WriteObject(ms, request);
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            response = sendRequest(Method.getUpdates, sr.ReadToEnd());
            Stream stream = Task.Run(() => response.Content.ReadAsStreamAsync()).Result;



            Result<Update[]> result = (Result<Update[]>)new DataContractJsonSerializer(typeof(Result<Update[]>)).ReadObject(stream);

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
        deleteMessage = 46
    }
    #endregion
}
