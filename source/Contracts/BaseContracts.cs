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

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DreadBot
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "id")]
        public long id { get; set; }

        [DataMember(Name = "is_bot")]
        public bool is_bot { get; set; }

        [DataMember(Name = "first_name")]
        public string first_name { get; set; }

        [DataMember(Name = "last_name", IsRequired = false)]
        public string last_name { get; set; }

        [DataMember(Name = "username", IsRequired = false)]
        public string username { get; set; }

        [DataMember(Name = "language_code", IsRequired = false)]
        public string language_code { get; set; }
    }

    [DataContract]
    public class Chat
    {
        [DataMember(Name = "id")]
        public long id { get; set; }

        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        public string title { get; set; }

        [DataMember(Name = "username", IsRequired = false)]
        public string username { get; set; }

        [DataMember(Name = "first_name", IsRequired = false)]
        public string first_name { get; set; }

        [DataMember(Name = "last_name", IsRequired = false)]
        public string last_name { get; set; }

        [DataMember(Name = "photo", IsRequired = false)]
        public ChatPhoto photo { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "invite_link", IsRequired = false)]
        public string invite_link { get; set; }

        [DataMember(Name = "pinned_message", IsRequired = false)]
        public Message pinned_message { get; set; }

        [DataMember(Name = "permissions", IsRequired = false)]
        public ChatPermissions permissions { get; set; }

        [DataMember(Name = "sticker_set_name", IsRequired = false)]
        public string sticker_set_name { get; set; }

        [DataMember(Name = "can_set_sticker_set", IsRequired = false)]
        public bool can_set_sticker_set { get; set; }
    }

    [DataContract]
    public class Message
    {
        [DataMember(Name = "message_id")]
        public long message_id { get; set; }

        [DataMember(Name = "from", IsRequired = false)]
        public User from { get; set; }

        [DataMember(Name = "date")]
        public long date { get; set; }

        [DataMember(Name = "chat")]
        public Chat chat { get; set; }

        [DataMember(Name = "forward_from", IsRequired = false)]
        public User forward_from { get; set; }

        [DataMember(Name = "forward_from_chat", IsRequired = false)]
        public Chat forward_from_chat { get; set; }

        [DataMember(Name = "forward_from_message_id", IsRequired = false)]
        public long forward_from_message_id { get; set; }

        [DataMember(Name = "forward_signature", IsRequired = false)]
        public string forward_signature { get; set; }

        [DataMember(Name = "forward_date", IsRequired = false)]
        public int forward_date { get; set; }

        [DataMember(Name = "reply_to_message", IsRequired = false)]
        public Message reply_to_message { get; set; }

        [DataMember(Name = "edit_date", IsRequired = false)]
        public long edit_date { get; set; } = 0;

        [DataMember(Name = "media_group_id", IsRequired = false)]
        public string media_group_id { get; set; }

        [DataMember(Name = "author_signature", IsRequired = false)]
        public string author_signature { get; set; }

        [DataMember(Name = "text", IsRequired = false)]
        public string text { get; set; }

        [DataMember(Name = "entities", IsRequired = false)]
        public MessageEntity[] entities { get; set; }

        [DataMember(Name = "caption_entities", IsRequired = false)]
        public MessageEntity[] caption_entities { get; set; }

        [DataMember(Name = "audio", IsRequired = false)]
        public Audio audio { get; set; }

        [DataMember(Name = "document", IsRequired = false)]
        public Document document { get; set; }

        [DataMember(Name = "animation", IsRequired = false)]
        public Animation animation { get; set; }

        [DataMember(Name = "game", IsRequired = false)]
        public Game game { get; set; }

        [DataMember(Name = "photo", IsRequired = false)]
        public PhotoSize[] photo { get; set; }

        [DataMember(Name = "sticker", IsRequired = false)]
        public Sticker sticker { get; set; }

        [DataMember(Name = "video", IsRequired = false)]
        public Video video { get; set; }

        [DataMember(Name = "voice", IsRequired = false)]
        public Voice voice { get; set; }

        [DataMember(Name = "video_note", IsRequired = false)]
        public VideoNote video_note { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "contact", IsRequired = false)]
        public Contact contact { get; set; }

        [DataMember(Name = "location", IsRequired = false)]
        public Location location { get; set; }

        [DataMember(Name = "venue", IsRequired = false)]
        public Venue venue { get; set; }

        [DataMember(Name = "poll", IsRequired = false)]
        public Poll poll { get; set; }

        [DataMember(Name = "new_chat_members", IsRequired = false)]
        public User[] new_chat_members { get; set; }

        [DataMember(Name = "left_chat_member", IsRequired = false)]
        public User left_chat_member { get; set; }

        [DataMember(Name = "new_chat_title", IsRequired = false)]
        public string new_chat_title { get; set; }

        [DataMember(Name = "new_chat_photo", IsRequired = false)]
        public PhotoSize[] new_chat_photo { get; set; }

        [DataMember(Name = "delete_chat_photo", IsRequired = false)]
        public bool delete_chat_photo { get; set; }

        [DataMember(Name = "group_chat_created", IsRequired = false)]
        public bool group_chat_created { get; set; }

        [DataMember(Name = "supergroup_chat_created", IsRequired = false)]
        public bool supergroup_chat_created { get; set; }

        [DataMember(Name = "channel_chat_created", IsRequired = false)]
        public bool channel_chat_created { get; set; }

        [DataMember(Name = "migrate_to_chat_id", IsRequired = false)]
        public long migrate_to_chat_id { get; set; } = 0;

        [DataMember(Name = "migrate_from_chat_id", IsRequired = false)]
        public long migrate_from_chat_id { get; set; } = 0;

        [DataMember(Name = "pinned_message", IsRequired = false)]
        public Message pinned_message { get; set; }

        [DataMember(Name = "invoice", IsRequired = false)]
        public Invoice invoice { get; set; }

        [DataMember(Name = "successful_payment", IsRequired = false)]
        public SuccessfulPayment successful_payment { get; set; }

        [DataMember(Name = "connected_website", IsRequired = false)]
        public string connected_website { get; set; }

        [DataMember(Name = "passport_data", IsRequired = false)]
        public PassportData passport_data { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }
    }

    [DataContract]
    public class MessageEntity
    {
        [DataMember(Name = "type")]
        public string type { get; set; }
        [DataMember(Name = "offset")]
        public int offset { get; set; }
        [DataMember(Name = "length")]
        public int length { get; set; }
        [DataMember(Name = "url", IsRequired = false)]
        public string url { get; set; }
        [DataMember(Name = "user", IsRequired = false)]
        public User user { get; set; }
    }

    [DataContract]
    public class PhotoSize
    {
        [DataMember(Name = "file_id")]
        public string file_id { get; set; }

        [DataMember(Name = "width")]
        public int width { get; set; }

        [DataMember(Name = "height")]
        public int height { get; set; }

        [DataMember(Name = "file_size", IsRequired = false)]
        public long file_size { get; set; }
    }

    [DataContract]
    public class Audio
    {
        [DataMember(Name = "file_id")]
        public string file_id { get; set; }

        [DataMember(Name = "duration")]
        public int duration { get; set; }

        [DataMember(Name = "performer", IsRequired = false)]
        public string performer { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        public string title { get; set; }

        [DataMember(Name = "mime_type", IsRequired = false)]
        public string mime_type { get; set; }

        [DataMember(Name = "file_size", IsRequired = false)]
        public int file_size { get; set; }
    }

    [DataContract]
    public class Document
    {
        [DataMember(Name = "file_id")]
        public string file_id { get; set; }

        [DataMember(Name = "thumb", IsRequired = false)]
        public PhotoSize thumb { get; set; }

        [DataMember(Name = "file_name", IsRequired = false)]
        public string file_name { get; set; }

        [DataMember(Name = "mime_type", IsRequired = false)]
        public string mime_type { get; set; }

        [DataMember(Name = "file_size", IsRequired = false)]
        public int file_size { get; set; }
    }

    [DataContract]
    public class Video
    {
        [DataMember(Name = "file_id")]
        public string file_id { get; set; }

        [DataMember(Name = "width")]
        public int width { get; set; }

        [DataMember(Name = "height")]
        public int height { get; set; }

        [DataMember(Name = "duration")]
        public int duration { get; set; }

        [DataMember(Name = "thumb", IsRequired = false)]
        public PhotoSize thumb { get; set; }

        [DataMember(Name = "mime_type", IsRequired = false)]
        public string mime_type { get; set; }

        [DataMember(Name = "file_size", IsRequired = false)]
        public int file_size { get; set; }
    }

    [DataContract]
    public class Animation
    {
        [DataMember(Name = "file_id")]
        public string file_id { get; set; }

        [DataMember(Name = "thumb", IsRequired = false)]
        public PhotoSize thumb { get; set; }

        [DataMember(Name = "file_name", IsRequired = false)]
        public string file_name { get; set; }

        [DataMember(Name = "mime_type", IsRequired = false)]
        public string mime_type { get; set; }

        [DataMember(Name = "file_size", IsRequired = false)]
        public int file_size { get; set; }
    }

    [DataContract]
    public class Voice
    {
        [DataMember(Name = "file_id")]
        public string file_id { get; set; }

        [DataMember(Name = "duration")]
        public int duration { get; set; }

        [DataMember(Name = "mime_type", IsRequired = false)]
        public string mime_type { get; set; }

        [DataMember(Name = "file_size", IsRequired = false)]
        public int file_size { get; set; }
    }

    [DataContract]
    public class VideoNote
    {
        [DataMember(Name = "file_id")]
        public string file_id { get; set; }

        [DataMember(Name = "length")]
        public int length { get; set; }

        [DataMember(Name = "duration")]
        public int duration { get; set; }

        [DataMember(Name = "thumb", IsRequired = false)]
        public PhotoSize thumb { get; set; }

        [DataMember(Name = "file_size", IsRequired = false)]
        public int file_size { get; set; }
    }

    [DataContract]
    public class Contact
    {
        [DataMember(Name = "phone_number")]
        public string phone_number { get; set; }

        [DataMember(Name = "first_name")]
        public string first_name { get; set; }

        [DataMember(Name = "last_name", IsRequired = false)]
        public string last_name { get; set; }

        [DataMember(Name = "user_id", IsRequired = false)]
        public int user_id { get; set; }

    }

    [DataContract]
    public class Location
    {
        [DataMember(Name = "longitude", IsRequired = false)]
        public float longitude { get; set; }

        [DataMember(Name = "latitude", IsRequired = false)]
        public float latitude { get; set; }
    }

    [DataContract]
    public class Venue
    {
        [DataMember(Name = "location")]
        public Location location { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "address")]
        public string address { get; set; }

        [DataMember(Name = "foursquare_id", IsRequired = false)]
        public string foursquare_id { get; set; }
    }

    [DataContract]
    public class PollOption
    {
        [DataMember(Name = "text")]
        public string text { get; set; }

        [DataMember(Name = "voter_count")]
        public int voter_count { get; set; }
    }

    [DataContract]
    public class Poll
    {
        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "question")]
        public string question { get; set; }

        [DataMember(Name = "options")]
        public PollOption[] options { get; set; }

        [DataMember(Name = "is_closed")]
        public bool is_closed { get; set; }
    }

    [DataContract]
    public class UserProfilePhotos
    {
        [DataMember(Name = "total_count")]
        public int total_count { get; set; }

        [DataMember(Name = "photos")]
        public PhotoSize[][] photos { get; set; }
    }

    [DataContract]
    public class File
    {
        [DataMember(Name = "file_id")]
        public string file_id { get; set; }

        [DataMember(Name = "file_size", IsRequired = false)]
        public int file_size { get; set; }

        [DataMember(Name = "file_path", IsRequired = false)]
        public string file_path { get; set; }
    }

    [DataContract]
    public class ReplyKeyboardMarkup
    {
        [DataMember(Name = "keyboard")]
        public KeyboardButton[][] keyboard { get; set; }

        [DataMember(Name = "resize_keyboard", IsRequired = false)]
        public bool resize_keyboard { get; set; }

        [DataMember(Name = "one_time_keyboard", IsRequired = false)]
        public bool one_time_keyboard { get; set; }

        [DataMember(Name = "selective", IsRequired = false)]
        public bool selective { get; set; }
    }

    [DataContract]
    public class KeyboardButton
    {
        [DataMember(Name = "text")]
        public string text { get; set; }

        [DataMember(Name = "request_contact", IsRequired = false)]
        public bool request_contact { get; set; }

        [DataMember(Name = "request_location", IsRequired = false)]
        public bool request_location { get; set; }
    }

    [DataContract]
    public class ReplyKeyboardRemove
    {
        [DataMember(Name = "remove_keyboard")]
        public bool remove_keyboard { get; set; }

        [DataMember(Name = "selective", IsRequired = false)]
        public bool selective { get; set; }
    }

    [DataContract]
    public class InlineKeyboardMarkup
    {
        int Rows = 0;
        public InlineKeyboardMarkup()
        {
            this.inline_keyboard = new List<List<InlineKeyboardButton>>(100);
        }
        public void SetRowCount(int r)
        {
            if (Rows > 0) { inline_keyboard = new List<List<InlineKeyboardButton>>(); }
            Rows = r;
            for (int i = 0; i < r; i++) { inline_keyboard.Add(new List<InlineKeyboardButton>()); }
        }
        public void addButton(InlineKeyboardButton button, int row)
        {
            this.inline_keyboard[row].Add(button);
        }

        [DataMember(Name = "inline_keyboard")]
        public List<List<InlineKeyboardButton>> inline_keyboard { get; set; }
    }

    [DataContract]
    public class InlineKeyboardButton
    {
        [DataMember(Name = "text")]
        public string text { get; set; }

        [DataMember(Name = "url", EmitDefaultValue = false, IsRequired = false)]
        public string url { get; set; }

        [DataMember(Name = "callback_data", EmitDefaultValue = false, IsRequired = false)]
        public string callback_data { get; set; }

        [DataMember(Name = "switch_inline_query", EmitDefaultValue = false, IsRequired = false)]
        public string switch_inline_query { get; set; }

        [DataMember(Name = "switch_inline_query_current_chat", EmitDefaultValue = false, IsRequired = false)]
        public string switch_inline_query_current_chat { get; set; }

        [DataMember(Name = "callback_game", EmitDefaultValue = false, IsRequired = false)]
        public CallbackGame callback_game { get; set; }

        [DataMember(Name = "pay", EmitDefaultValue = false, IsRequired = false)]
        public bool pay { get; set; }
    }

    [DataContract]
    public class LoginUrl
    {
        [DataMember(Name = "url")]
        public string url { get; set; }

        [DataMember(Name = "forward_text")]
        public string forward_text { get; set; }

        [DataMember(Name = "bot_username")]
        public string bot_username { get; set; }

        [DataMember(Name = "request_write_access")]
        public bool request_write_access { get; set; }
    }

    [DataContract]
    public class CallbackQuery
    {
        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "from")]
        public User from { get; set; }

        [DataMember(Name = "message", IsRequired = false)]
        public Message message { get; set; }

        [DataMember(Name = "inline_message_id", IsRequired = false)]
        public string inline_message_id { get; set; }

        [DataMember(Name = "chat_instance")]
        public string chat_instance { get; set; }

        [DataMember(Name = "data", IsRequired = false)]
        public string data { get; set; }

        [DataMember(Name = "game_short_name", IsRequired = false)]
        public string game_short_name { get; set; }
    }

    [DataContract]
    public class ForceReply
    {
        [DataMember(Name = "force_reply")]
        public bool force_reply { get; set; }

        [DataMember(Name = "selective", IsRequired = false)]
        public bool selective { get; set; }
    }

    [DataContract]
    public class ChatPhoto
    {
        [DataMember(Name = "small_file_id")]
        public string small_file_id { get; set; }

        [DataMember(Name = "big_file_id")]
        public string big_file_id { get; set; }
    }

    [DataContract]
    public class ChatMember
    {
        [DataMember(Name = "user")]
        public User user { get; set; }

        [DataMember(Name = "status", IsRequired = false)]
        public string status { get; set; }

        [DataMember(Name = "until_date", IsRequired = false)]
        public int until_date { get; set; }

        [DataMember(Name = "can_be_edited", IsRequired = false)]
        public bool can_be_edited { get; set; }

        [DataMember(Name = "can_change_info", IsRequired = false)]
        public bool can_change_info { get; set; }

        [DataMember(Name = "can_post_messages", IsRequired = false)]
        public bool can_post_messages { get; set; }

        [DataMember(Name = "can_edit_messages", IsRequired = false)]
        public bool can_edit_messages { get; set; }

        [DataMember(Name = "can_delete_messages", IsRequired = false)]
        public bool can_delete_messages { get; set; }

        [DataMember(Name = "can_invite_users", IsRequired = false)]
        public bool can_invite_users { get; set; }

        [DataMember(Name = "can_restrict_members", IsRequired = false)]
        public bool can_restrict_members { get; set; }

        [DataMember(Name = "can_pin_messages", IsRequired = false)]
        public bool can_pin_messages { get; set; }

        [DataMember(Name = "can_promote_members", IsRequired = false)]
        public bool can_promote_members { get; set; }

        [DataMember(Name = "is_member", IsRequired = false)]
        public bool is_member { get; set; }

        [DataMember(Name = "can_send_messages", IsRequired = false)]
        public bool can_send_messages { get; set; }

        [DataMember(Name = "can_send_media_messages", IsRequired = false)]
        public bool can_send_media_messages { get; set; }

        [DataMember(Name = "can_send_polls", IsRequired = false)]
        public bool can_send_polls { get; set; }

        [DataMember(Name = "can_send_other_messages", IsRequired = false)]
        public bool can_send_other_messages { get; set; }

        [DataMember(Name = "can_add_web_page_previews", IsRequired = false)]
        public bool can_add_web_page_previews { get; set; }
    }

    [DataContract]
    public class ChatPermissions
    {
        [DataMember(Name = "can_send_messages")]
        public bool can_send_messages { get; set; }

        [DataMember(Name = "can_send_media_messages")]
        public bool can_send_media_messages { get; set; }

        [DataMember(Name = "can_send_polls")]
        public bool can_send_polls { get; set; }

        [DataMember(Name = "can_send_other_messages")]
        public bool can_send_other_messages { get; set; }

        [DataMember(Name = "can_add_web_page_previews")]
        public bool can_add_web_page_previews { get; set; }

        [DataMember(Name = "can_change_info")]
        public bool can_change_info { get; set; }

        [DataMember(Name = "can_invite_users")]
        public bool can_invite_users { get; set; }

        [DataMember(Name = "can_pin_messages")]
        public bool can_pin_messages { get; set; }
    }

    [DataContract]
    public class ResponseParameters
    {
        [DataMember(Name = "migrate_to_chat_id", IsRequired = false)]
        public long migrate_to_chat_id { get; set; }

        [DataMember(Name = "retry_after", IsRequired = false)]
        public int retry_after { get; set; }
    }

    #region Input Media

    [DataContract]
    [KnownType(typeof(InputMediaPhoto))]
    [KnownType(typeof(InputMediaAnimation))]
    [KnownType(typeof(InputMediaVideo))]
    [KnownType(typeof(InputMediaAudio))]
    [KnownType(typeof(InputMediaDocument))]
    public class InputMedia
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "media")]
        public string media { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; } = "";

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; } = "";
    }

    [DataContract]
    public class InputMediaPhoto : InputMedia
    {

    }

    [DataContract]
    public class InputMediaAnimation : InputMedia
    {
        [DataMember(Name = "width", IsRequired = false)]
        public int width { get; set; }

        [DataMember(Name = "height", IsRequired = false)]
        public int height { get; set; }

        [DataMember(Name = "duration", IsRequired = false)]
        public int duration { get; set; }
    }


    [DataContract]
    public class InputMediaVideo : InputMediaAnimation
    {
        [DataMember(Name = "supports_streaming", IsRequired = false)]
        public bool supports_streaming { get; set; }
    }

    [DataContract]
    public class InputMediaAudio : InputMedia
    {
        [DataMember(Name = "duration", IsRequired = false)]
        public int duration { get; set; }

        [DataMember(Name = "performer", IsRequired = false)]
        public string performer { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        public int title { get; set; }
    }

    [DataContract]
    public class InputMediaDocument : InputMedia
    {

    }

    #endregion


}
