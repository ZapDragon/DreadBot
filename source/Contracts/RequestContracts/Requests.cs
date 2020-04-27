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
using System.Runtime.Serialization;

namespace DreadBot
{
    #region Request Objects

    [DataContract]
    public class GetUpdates
    {
        [DataMember(Name = "offset")]
        public long offset { get; set; }

        [DataMember(Name = "limit")]
        public long limit { get; set; }

        [DataMember(Name = "timeout")]
        public int timeout { get; set; }

        [DataMember(Name = "allowed_updates")]
        public string[] allowed_updates { get; set; }
    }

    [DataContract]
    public class SetWebHook
    {
        [DataMember(Name = "url", IsRequired = true)]
        public string url { get; set; }

        [DataMember(Name = "certificate")]
        public int certificate { get; set; }

        [DataMember(Name = "max_connections")]
        public int max_connections { get; set; }

        [DataMember(Name = "allowed_updates")]
        public string[] allowed_updates { get; set; }
    }

    #region Edit Messages




    [DataContract]
    public class EditMessageTextRequest
    {
        [DataMember(Name = "chat_id", EmitDefaultValue = false)]
        public long chat_id { get; set; }

        [DataMember(Name = "message_id", EmitDefaultValue = false)]
        public long message_id { get; set; }

        [DataMember(Name = "inline_message_id", EmitDefaultValue = false)]
        public long inline_message_id { get; set; }

        [DataMember(Name = "text", IsRequired = true)]
        public string text { get; set; }

        [DataMember(Name = "parse_mode", EmitDefaultValue = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "disable_web_page_preview", EmitDefaultValue = false)]
        public bool disable_web_page_preview { get; set; }

        [DataMember(Name = "reply_markup", EmitDefaultValue = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }
    }

    [DataContract]
    public class EditReplyMarkupRequest
    {
        [DataMember(Name = "chat_id", EmitDefaultValue = false, IsRequired = true)]
        public long chat_id { get; set; }

        [DataMember(Name = "message_id", EmitDefaultValue = false, IsRequired = true)]
        public long message_id { get; set; }

        [DataMember(Name = "inline_message_id", EmitDefaultValue = false)]
        public string inline_message_id { get; set; }

        [DataMember(Name = "reply_markup", EmitDefaultValue = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }
    }

    [DataContract]
    public class EditMessageCaptionRequest
    {
        [DataMember(Name = "chat_id", EmitDefaultValue = false)]
        public long chat_id { get; set; }

        [DataMember(Name = "message_id", EmitDefaultValue = false)]
        public long message_id { get; set; }

        [DataMember(Name = "inline_message_id", EmitDefaultValue = false)]
        public long inline_message_id { get; set; }

        [DataMember(Name = "caption", IsRequired = true)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", EmitDefaultValue = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", EmitDefaultValue = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }
    }

    [DataContract]
    public class EditMessageMediaRequest
    {
        [DataMember(Name = "chat_id", EmitDefaultValue = false)]
        public long chat_id { get; set; }

        [DataMember(Name = "message_id", EmitDefaultValue = false)]
        public long message_id { get; set; }

        [DataMember(Name = "inline_message_id", EmitDefaultValue = false)]
        public long inline_message_id { get; set; }

        [DataMember(Name = "reply_markup", EmitDefaultValue = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }
    }

    [DataContract]
    public class editMessageReplyMarkup
    {
        [DataMember(Name = "chat_id", EmitDefaultValue = false)]
        public long chat_id { get; set; }

        [DataMember(Name = "message_id", EmitDefaultValue = false)]
        public long message_id { get; set; }

        [DataMember(Name = "inline_message_id", EmitDefaultValue = false)]
        public long inline_message_id { get; set; }

        [DataMember(Name = "reply_markup", EmitDefaultValue = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }
    }

    #endregion

    [DataContract]
    public class SendMessageRequest
    {
        [DataMember(Name = "chat_id", IsRequired = true)]
        public long chat_id { get; set; }

        [DataMember(Name = "text", IsRequired = true)]
        public string text { get; set; }

        [DataMember(Name = "parse_mode", EmitDefaultValue = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "disable_web_page_preview", EmitDefaultValue = false)]
        public bool disable_web_page_preview { get; set; }

        [DataMember(Name = "disable_notification", EmitDefaultValue = false)]
        public bool disable_notification { get; set; }

        [DataMember(Name = "reply_to_message_id", EmitDefaultValue = false)]
        public long reply_to_message_id { get; set; }

        [DataMember(Name = "reply_markup", EmitDefaultValue = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }
    }

    [DataContract]
    public class SendPhotoUrlRequest
    {
        [DataMember(Name = "chat_id", IsRequired = true)]
        public long chat_id { get; set; }

        [DataMember(Name = "photo", IsRequired = true)]
        public string photo_url { get; set; }

        [DataMember(Name = "caption", EmitDefaultValue = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", EmitDefaultValue = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "disable_notification", EmitDefaultValue = false)]
        public bool disable_notification { get; set; }

        [DataMember(Name = "reply_to_message_id", EmitDefaultValue = false)]
        public long reply_to_message_id { get; set; }

        [DataMember(Name = "reply_markup", EmitDefaultValue = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }
    }

    [DataContract]
    public class SendPhotoDataRequest
    {
        [DataMember(Name = "chat_id", IsRequired = true)]
        public long chat_id { get; set; }

        [DataMember(Name = "caption", EmitDefaultValue = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", EmitDefaultValue = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "disable_notification", EmitDefaultValue = false)]
        public bool disable_notification { get; set; }

        [DataMember(Name = "reply_to_message_id", EmitDefaultValue = false)]
        public long reply_to_message_id { get; set; }

        [DataMember(Name = "reply_markup", EmitDefaultValue = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }
    }

    [DataContract]
    public class SendAudioRequest
    {
        [DataMember(Name = "chat_id", IsRequired = true)]
        public long chat_id { get; set; }

        [DataMember(Name = "caption", EmitDefaultValue = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", EmitDefaultValue = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "duration", EmitDefaultValue = false)]
        public int duration { get; set; }

        [DataMember(Name = "performer", EmitDefaultValue = false)]
        public string performer { get; set; }

        [DataMember(Name = "title", EmitDefaultValue = false)]
        public string title { get; set; }

        [DataMember(Name = "thumb", EmitDefaultValue = false)]
        public string thumb { get; set; }

        [DataMember(Name = "disable_notification", EmitDefaultValue = false)]
        public bool disable_notification { get; set; }

        [DataMember(Name = "reply_to_message_id", EmitDefaultValue = false)]
        public int reply_to_message_id { get; set; }

        [DataMember(Name = "reply_markup", EmitDefaultValue = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }
    }

    [DataContract]
    public class SendVideoRequest
    {
        [DataMember(Name = "chat_id", IsRequired = true)]
        public long chat_id { get; set; }

        [DataMember(Name = "duration", EmitDefaultValue = false)]
        public int duration { get; set; }

        [DataMember(Name = "width", EmitDefaultValue = false)]
        public int width { get; set; }

        [DataMember(Name = "height", EmitDefaultValue = false)]
        public int height { get; set; }

        [DataMember(Name = "thumb", EmitDefaultValue = false)]
        public string thumb { get; set; }

        [DataMember(Name = "caption", EmitDefaultValue = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", EmitDefaultValue = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "supports_streaming", EmitDefaultValue = false)]
        public bool supports_streaming { get; set; }

        [DataMember(Name = "disable_notification", EmitDefaultValue = false)]
        public bool disable_notification { get; set; }

        [DataMember(Name = "reply_to_message_id", EmitDefaultValue = false)]
        public int reply_to_message_id { get; set; }

        [DataMember(Name = "reply_markup", EmitDefaultValue = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }
    }

    [DataContract]
    public class SendDocumentDataRequest
    {
        [DataMember(Name = "chat_id", IsRequired = true)]
        public long chat_id { get; set; }

        [DataMember(Name = "caption", EmitDefaultValue = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", EmitDefaultValue = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "disable_notification", EmitDefaultValue = false)]
        public bool disable_notification { get; set; }

        [DataMember(Name = "reply_to_message_id", EmitDefaultValue = false)]
        public long reply_to_message_id { get; set; }

        [DataMember(Name = "reply_markup", EmitDefaultValue = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }
    }

    [DataContract]
    public class SendAnimationUrlRequest
    {
        [DataMember(Name = "chat_id", IsRequired = true)]
        public long chat_id { get; set; }

        [DataMember(Name = "animation", IsRequired = true)]
        public string animation_url { get; set; }

        [DataMember(Name = "duration", EmitDefaultValue = false)]
        public string duration { get; set; }

        [DataMember(Name = "width", EmitDefaultValue = false)]
        public string width { get; set; }

        [DataMember(Name = "caption", EmitDefaultValue = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", EmitDefaultValue = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "disable_notification", EmitDefaultValue = false)]
        public bool disable_notification { get; set; }

        [DataMember(Name = "reply_to_message_id", EmitDefaultValue = false)]
        public long reply_to_message_id { get; set; }

        [DataMember(Name = "reply_markup", EmitDefaultValue = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }
    }
    [DataContract]
    public class SendChatActionRequest
    {
        [DataMember(Name = "chat_id", IsRequired = true)]
        public long chat_id { get; set; }

        [DataMember(Name = "action", IsRequired = true)]
        public string action { get; set; }
    }
    [DataContract]
    public class ForwardMessageRequest
    {
        [DataMember(Name = "chat_id", IsRequired = true)]
        public long chat_id { get; set; }

        [DataMember(Name = "from_chat_id", IsRequired = true)]
        public int from_chat_id { get; set; }

        [DataMember(Name = "disable_notification")]
        public bool disable_notification { get; set; }

        [DataMember(Name = "message_id", IsRequired = true)]
        public int message_id { get; set; }
    }

    [DataContract]
    public class KickChatMemberRequest
    {
        [DataMember(Name = "chat_id", IsRequired = true)]
        public long chat_id { get; set; }

        [DataMember(Name = "user_id", IsRequired = true)]
        public long user_id { get; set; }

        [DataMember(Name = "until_date", IsRequired = false)]
        public int until_date { get; set; }
    }

    [DataContract]
    public class AnswerCallBackRequest
    {
        [DataMember(Name = "callback_query_id", IsRequired = true)]
        public string callback_query_id { get; set; }

        [DataMember(Name = "text", EmitDefaultValue = false)]
        public string text { get; set; }

        [DataMember(Name = "show_alert", EmitDefaultValue = false)]
        public bool show_alert { get; set; }

        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string url { get; set; }

        [DataMember(Name = "cache_time", EmitDefaultValue = false)]
        public int cache_time { get; set; }
    }

    [DataContract]
    public class ChatMemberRequest
    {
        [DataMember(Name = "chat_id", IsRequired = true)]
        public long chat_id { get; set; }

        [DataMember(Name = "user_id", IsRequired = true)]
        public long user_id { get; set; }
    }

    [DataContract]
    public class GetChatRequest
    {
        [DataMember(Name = "chat_id", IsRequired = true)]
        public long chat_id { get; set; }
    }

    public class UserProfilePhotosRequest
    {
        [DataMember(Name = "user_id", IsRequired = true)]
        public long user_id { get; set; }

        [DataMember(Name = "offset", IsRequired = true)]
        public int offset { get; set; }

        [DataMember(Name = "limit", IsRequired = false)]
        public int limit { get; set; }
    }

    [DataContract]
    public class DeleteMessageRequest
    {
        [DataMember(Name = "chat_id", IsRequired = true)]
        public long chat_id { get; set; }

        [DataMember(Name = "message_id", IsRequired = true)]
        public long msg_id { get; set; }
    }

    [DataContract]
    public class GetFileRequest
    {
        [DataMember(Name = "file_id", IsRequired = true)]
        public string file_id { get; set; }
    }

    [DataContract]
    public class SendMediaGroupRequest
    {
        [DataMember(Name = "chat_id", IsRequired = true)]
        public long chat_id { get; set; }

        [DataMember(Name = "media", IsRequired = true)]
        public InputMedia[] media { get; set; }

        [DataMember(Name = "disable_notification", IsRequired = false)]
        public bool disable_notification { get; set; }

        [DataMember(Name = "reply_to_message_id", IsRequired = false)]
        public int reply_to_message_id { get; set; }

    }
	#endregion
}