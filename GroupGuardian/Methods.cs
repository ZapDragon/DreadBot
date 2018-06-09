using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.IO;

namespace GroupGuardian
{
    class Methods
    {
        private static bool Debug = false;

        #region Global Method Execution

        //This method is called by EVERY Telegram method. This is used to handle Most error checking, and the variable 'result' object is returned to the method that called this.
        private static async Task<T> sendRequest<T>(Method method, string payload = "", string payloadType = "application/json")
        {
            HttpResponseMessage HttpResponse = await new HttpClient().PostAsync("https://api.telegram.org/bot583846903:AAGtQ8UMY3YQ0bo0ZxI0qacF46WAOhC59Sk/" + method, new StringContent(payload, Encoding.UTF8, payloadType));

            if (!HttpResponse.IsSuccessStatusCode) //HTTP Error handling
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("HTTP Error: Status Code: " + HttpResponse.StatusCode + " Reason:" + HttpResponse.ReasonPhrase);
                Console.ResetColor();
                throw new HttpRequestException();
            }

            Result<T> ResponseObject = null;
            Result<bool> AltResponseObject = null;
            Stream stream = await HttpResponse.Content.ReadAsStreamAsync();
            if (Debug)
            {
                StreamReader reader = new StreamReader(stream);
                string resultPayload = await reader.ReadToEndAsync();
                Console.WriteLine(resultPayload);
                stream.Position = 0;
            }
            try { ResponseObject = (Result<T>)new DataContractJsonSerializer(typeof(Result<T>)).ReadObject(stream); }
            catch (Exception e) //JSON Deserialization error handling
            {
                Console.WriteLine("Error while parsing JSON for " + typeof(T) + " because of " + e + "\r\n\r\n");
                try { AltResponseObject = (Result<bool>)new DataContractJsonSerializer(typeof(Result<bool>)).ReadObject(stream); }
                catch(Exception e2) //JSON Deserialization error handling
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error while parsing JSON " + HttpResponse.StatusCode + " Reason:" + HttpResponse.ReasonPhrase);
                    Console.ResetColor();
                    throw e2;
                }
            }

            if (ResponseObject != null && !ResponseObject.ok) //Telegram API Error handling
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ResponseObject.errorCode + " " + ResponseObject.description);
                Console.ResetColor();
                throw new TelegramException(ResponseObject.errorCode); //Return the resulting object
            }
            else if (AltResponseObject != null && !AltResponseObject.ok) //Telegram API Error handling
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ResponseObject.errorCode + " " + ResponseObject.description);
                Console.ResetColor();
                throw new TelegramException(ResponseObject.errorCode);//Return the resulting object
            }
            return ResponseObject.result; //Return the resulting object
        }

        #endregion

        #region Telegram Bot Methods

        public static Update[] getUpdates(long off)
        {
            Update[] updates = Task.Run(() => sendRequest<Update[]>(Method.getUpdates, new GetUpdates() { offset = off , timeout = 20, limit=100 }.ToPayload())).Result;
            return updates;
        }

        public static bool setWebhook()
        {
            return false;
        }

        public static bool deleteWebhook()
        {
            return Task.Run(() => sendRequest<bool>(Method.deleteWebhook)).Result;
        }

        public static WebhookInfo getWebhookInfo()
        {
            return Task.Run(() => sendRequest<WebhookInfo>(Method.getWebhookInfo)).Result;
        }

        public static User getMe()
        {
            return Task.Run(() => sendRequest<User>(Method.getMe)).Result;
        }

        public static Message sendMessage(long dest, string msg, string token, object markdown)
        {
            /*
            SendMessageId SM = new SendMessageId() { chat_id = dest, text = msg };
            MemoryStream ms = new MemoryStream();
            
            if (markdown is InlineKeyboardMarkup)
            {
                SM.reply_markup = (InlineKeyboardMarkup)markdown;
            }
            else if (markdown is bool)
            {
                if ((bool)markdown) { SM.parse_mode = "Markdown"; }
            }
            
            
            
            new DataContractJsonSerializer(typeof(SendMessageId)).WriteObject(ms, SM);
            ms.Position = 0;
            string payload = new StreamReader(ms).ReadToEnd();
            Console.WriteLine(payload);
            
            Message response = Task.Run(() => sendRequest<Message>(Method.sendMessage, payload);
            
            
            if (!SendJsonAsync(payload, token, "sendMessage").IsSuccessStatusCode)
            {
                Console.WriteLine("Failed to Send message.");
                if (Directory.Exists(Environment.CurrentDirectory + @"\Logs"))
                {
                    //File.Create(Environment.CurrentDirectory + @"\Logs\" + MainClass.EpochTime() + "-SendMessage-Failure.log").Write((new StreamReader(ms).ReadToEnd), 0, ms.Length);
                }
                else { Console.WriteLine("LOG DIRECTORY MISSING!!!"); }
            }
            */


            


           return null;
        }

        public static Message forwardMessage()
        {
            return null;
        }

        public static Message sendPhoto()
        {
            MultipartFormDataContent content = new MultipartFormDataContent();

            content.Add(new StringContent("121922025", Encoding.UTF8), "chat_id");
            content.Add(new StreamContent(new FileStream(@"C:\example.jpg", FileMode.Open, FileAccess.Read)), "photo", "example");


            return null;
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

        public static bool kickChatMember()
        {
            return false;
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

        public static Chat getChat()
        {
            return null;
        }

        public static ChatMember[] getChatAdministrators()
        {
            return null;
        }

        public static int getChatMembersCount()
        {
            return 0;
        }

        public static ChatMember getChatMember()
        {
            return null;
        }

        public static bool setChatStickerSet()
        {
            return false;
        }

        public static bool deleteChatStickerSet()
        {
            return false;
        }

        public static bool answerCallbackQuery()
        {
            return false;
        }

        public static Message editMessageText() //Can apprently return a bool as well. 
        {
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

        public static Update getOneUpdate(int timeout = 1800)
        {


            string args = new GetUpdates() { limit=1, timeout=timeout }.ToPayload();

            Update result = Task.Run(() => sendRequest<Update[]>(Method.getUpdates, args)).Result[0];

            return result;
        }

        #endregion

    }

    //Telegram Bot Method Enums
    public enum Method : int
    {
        getMe                   = 0,
        sendMessage = 1,
        forwardMessage = 2,
        sendPhoto = 3,
        sendAudio = 4,
        sendDocument = 5,
        sendVideo = 6,
        sendVoice = 7,
        sendVideoNote = 8,
        sendMediaGroup = 9,
        sendLocation = 10,
        editMessageLiveLocation = 11,
        stopMessageLiveLocation = 12,
        sendVenue = 13,
        sendContact = 14,
        sendChatAction = 15,
        getUserProfilePhotos = 16,
        getFile = 17,
        kickChatMember = 18,
        unbanChatMember = 19,
        restrictChatMember = 20,
        promoteChatMember = 21,
        exportChatInviteLink = 22,
        setChatPhoto = 23,
        deleteChatPhoto = 24,
        setChatTitle = 25,
        setChatDescription = 26,
        pinChatMessage = 27,
        unpinChatMessage = 28,
        leaveChat = 29,
        getChat = 30,
        getChatAdministrators = 31,
        getChatMembersCount = 32,
        getChatMember = 33,
        setChatStickerSet = 34,
        deleteChatStickerSet = 35,
        answerCallbackQuery = 36,
        getUpdates = 37,
        getWebhookInfo = 38,
        deleteWebhook = 39
    }
}