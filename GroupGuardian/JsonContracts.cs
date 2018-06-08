using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace GroupGuardian
{
    //WTF Telegram ._.
    #region Telegram Object Types

    [DataContract]
    public class Result<T>
    {
        [DataMember(Name = "ok")]
        public bool ok { get; set; }

        [DataMember(Name = "error_code", IsRequired = false)]
        public int errorCode { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "parameters", IsRequired = false)]
        public ResponseParameters parameters { get; set; }

        [DataMember(Name = "result", IsRequired = false)]
        public T result { get; set; }

        public static explicit operator Result<T>(Result<object> v)
        {
            return new Result<T>() { ok = v.ok, description = v.description, errorCode = v.errorCode, parameters = v.parameters, result = (T)v.result };
        }
    }

    [DataContract]
    public class Update
    {
        //Required
        [DataMember(Name = "update_id")]
        public long update_id { get; set; }
        //Optionals
        [DataMember(Name = "message", IsRequired = false)]
        public Message message { get; set; }

        [DataMember(Name = "edited_message", IsRequired = false)]
        public Message edited_message { get; set; }

        [DataMember(Name = "channel_post", IsRequired = false)]
        public Message channel_post { get; set; }

        [DataMember(Name = "edited_channel_post", IsRequired = false)]
        public Message edited_channel_post { get; set; }

        [DataMember(Name = "inline_query", IsRequired = false)]
        public InlineQuery inline_query { get; set; }

        [DataMember(Name = "chosen_inline_result", IsRequired = false)]
        public ChosenInlineResult chosen_inline_result { get; set; }

        [DataMember(Name = "callback_query", IsRequired = false)]
        public CallbackQuery callback_query { get; set; }

        [DataMember(Name = "shipping_query", IsRequired = false)]
        public ShippingQuery shipping_query { get; set; }

        [DataMember(Name = "pre_checkout_query", IsRequired = false)]
        public PreCheckoutQuery pre_checkout_query { get; set; }
    }

    [DataContract]
    class WebhookInfo
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "has_custom_certificate")]
        public bool hasCertificate { get; set; }

        [DataMember(Name = "pending_update_count")]
        public int pendingUpdateCount { get; set; }

        [DataMember(Name = "last_error_date", IsRequired = false)]
        public int lastErrorEpoch { get; set; }

        [DataMember(Name = "last_error_message", IsRequired = false)]
        public string lastError { get; set; }

        [DataMember(Name = "max_connections", IsRequired = false)]
        public int maxConnections { get; set; }

        [DataMember(Name = "allowed_updates", IsRequired = false)]
        public string[] allowedUpdates { get; set; }
    }

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

        [DataMember(Name = "all_members_are_administrators", IsRequired = false)]
        public bool all_members_are_administrators { get; set; }

        [DataMember(Name = "photo", IsRequired = false)]
        public ChatPhoto photo { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "invite_link", IsRequired = false)]
        public string invite_link { get; set; }

        [DataMember(Name = "pinned_message", IsRequired = false)]
        public Message pinned_message { get; set; }

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
        public long edit_date { get; set; }

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
        public long migrate_to_chat_id { get; set; }

        [DataMember(Name = "migrate_from_chat_id", IsRequired = false)]
        public long migrate_from_chat_id { get; set; }

        [DataMember(Name = "pinned_message", IsRequired = false)]
        public Message pinned_message { get; set; }

        [DataMember(Name = "invoice", IsRequired = false)]
        public Invoice invoice { get; set; }

        [DataMember(Name = "successful_payment", IsRequired = false)]
        public SuccessfulPayment successful_payment { get; set; }

        [DataMember(Name = "connected_website", IsRequired = false)]
        public string connected_website { get; set; }
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
        [DataMember(Name = "inline_keyboard")]
        public List<List<InlineKeyboardButton>> inline_keyboard { get; set; }
    }

    [DataContract]
    public class InlineKeyboardButton
    {
        [DataMember(Name = "text")]
        public string text { get; set; }

        [DataMember(Name = "url", IsRequired = false)]
        public string url { get; set; }

        [DataMember(Name = "callback_data", IsRequired = false)]
        public string callback_data { get; set; }

        [DataMember(Name = "switch_inline_query", IsRequired = false)]
        public string switch_inline_query { get; set; }

        [DataMember(Name = "switch_inline_query_current_chat", IsRequired = false)]
        public string switch_inline_query_current_chat { get; set; }

        [DataMember(Name = "callback_game", IsRequired = false)]
        public CallbackGame callback_game { get; set; }

        [DataMember(Name = "pay", IsRequired = false)]
        public bool pay { get; set; }
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

        [DataMember(Name = "can_send_messages", IsRequired = false)]
        public bool can_send_messages { get; set; }

        [DataMember(Name = "can_send_media_messages", IsRequired = false)]
        public bool can_send_media_messages { get; set; }

        [DataMember(Name = "can_send_other_messages", IsRequired = false)]
        public bool can_send_other_messages { get; set; }

        [DataMember(Name = "can_add_web_page_previews", IsRequired = false)]
        public bool can_add_web_page_previews { get; set; }
    }

    [DataContract]
    public class ResponseParameters
    {
        [DataMember(Name = "migrate_to_chat_id", IsRequired = false)]
        public long migrate_to_chat_id { get; set; }

        [DataMember(Name = "retry_after", IsRequired = false)]
        public int retry_after { get; set; }
    }

    [DataContract]
    public class InputMediaPhoto
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "media")]
        public string media { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }
    }

    [DataContract]
    public class InputMediaVideo
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "media")]
        public string media { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "width", IsRequired = false)]
        public int width { get; set; }

        [DataMember(Name = "height", IsRequired = false)]
        public int height { get; set; }

        [DataMember(Name = "duration", IsRequired = false)]
        public int duration { get; set; }

        [DataMember(Name = "supports_streaming", IsRequired = false)]
        public bool supports_streaming { get; set; }
    }

    [DataContract]
    public class Sticker
    {
        [DataMember(Name = "file_id")]
        public string file_id { get; set; }

        [DataMember(Name = "width")]
        public int width { get; set; }

        [DataMember(Name = "height")]
        public int height { get; set; }

        [DataMember(Name = "thumb", IsRequired = false)]
        public PhotoSize thumb { get; set; }

        [DataMember(Name = "emoji", IsRequired = false)]
        public string emoji { get; set; }

        [DataMember(Name = "set_name", IsRequired = false)]
        public string set_name { get; set; }

        [DataMember(Name = "mask_position", IsRequired = false)]
        public MaskPosition mask_position { get; set; }

        [DataMember(Name = "file_size", IsRequired = false)]
        public int file_size { get; set; }
    }

    [DataContract]
    public class StickerSet
    {

        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "contains_masks")]
        public bool contains_masks { get; set; }

        [DataMember(Name = "stickers")]
        public Sticker[] stickers { get; set; }

    }

    [DataContract]
    public class MaskPosition
    {
        [DataMember(Name = "point")]
        public string point { get; set; }

        [DataMember(Name = "x_shift")]
        public float x_shift { get; set; }

        [DataMember(Name = "y_shift")]
        public float y_shift { get; set; }

        [DataMember(Name = "scale")]
        public float scale { get; set; }
    }

    [DataContract]
    public class InlineQuery
    {
        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "from")]
        public User from { get; set; }

        [DataMember(Name = "location", IsRequired = false)]
        public Location location { get; set; }

        [DataMember(Name = "query")]
        public string query { get; set; }

        [DataMember(Name = "offset")]
        public string offset { get; set; }
    }

    [DataContract]
    public class InlineQueryResult
    {
        //This is a mess.
        // No fields are specified in the documentation for this, but is allegedly supposed to be an array of results which can be one or several differnet Types entirely.
    }

    //I dont even know what the fuck Telegram is trying to do here...
    #region InlineQueryResult Types

    [DataContract]
    public class InlineQueryResultArticle
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "input_message_content")]
        public InputMessageContent input_message_content { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "url", IsRequired = false)]
        public string url { get; set; }

        [DataMember(Name = "hide_url", IsRequired = false)]
        public bool hide_url { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "thumb_url", IsRequired = false)]
        public string thumb_url { get; set; }

        [DataMember(Name = "thumb_width", IsRequired = false)]
        public int thumb_width { get; set; }

        [DataMember(Name = "thumb_height", IsRequired = false)]
        public int thumb_height { get; set; }
    }

    [DataContract]
    public class InlineQueryResultPhoto
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "photo_url")]
        public string photo_url { get; set; }

        [DataMember(Name = "thumb_url")]
        public string thumb_url { get; set; }

        [DataMember(Name = "photo_width", IsRequired = false)]
        public int photo_width { get; set; }

        [DataMember(Name = "photo_height", IsRequired = false)]
        public int photo_height { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        public string title { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultGif
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "gif_url")]
        public string gif_url { get; set; }

        [DataMember(Name = "gif_width", IsRequired = false)] //InlineQueryResultCachedMpeg4Gif
        public int gif_width { get; set; }

        [DataMember(Name = "gif_height", IsRequired = false)]
        public int gif_height { get; set; }

        [DataMember(Name = "gif_duration", IsRequired = false)]
        public int gif_duration { get; set; }

        [DataMember(Name = "thumb_url")]
        public string thumb_url { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        public string title { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultMpeg4Gif
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "mpeg4_url")]
        public string mpeg4_url { get; set; }

        [DataMember(Name = "mpeg4_width", IsRequired = false)] //InlineQueryResultCachedMpeg4Gif
        public int mpeg4_width { get; set; }

        [DataMember(Name = "mpeg4_height", IsRequired = false)]
        public int mpeg4_height { get; set; }

        [DataMember(Name = "mpeg4_duration", IsRequired = false)]
        public int mpeg4_duration { get; set; }

        [DataMember(Name = "thumb_url")]
        public string thumb_url { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        public string title { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultVideo
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "video_url")]
        public string video_url { get; set; }

        [DataMember(Name = "mime_type")]
        public string mime_type { get; set; }

        [DataMember(Name = "thumb_url")]
        public string thumb_url { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "video_width", IsRequired = false)]
        public int video_width { get; set; }

        [DataMember(Name = "video_height", IsRequired = false)]
        public int video_height { get; set; }

        [DataMember(Name = "video_duration", IsRequired = false)]
        public int video_duration { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultAudio
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "audio_url")]
        public string audio_url { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "performer", IsRequired = false)]
        public string performer { get; set; }

        [DataMember(Name = "audio_duration", IsRequired = false)]
        public int audio_duration { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultVoice
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "voice_url")]
        public string voice_url { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "voice_duration", IsRequired = false)]
        public int voice_duration { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultDocument
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "document_url")]
        public string document_url { get; set; }

        [DataMember(Name = "mime_type")]
        public string mime_type { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }

        [DataMember(Name = "thumb_url", IsRequired = false)]
        public string thumb_url { get; set; }

        [DataMember(Name = "thumb_width", IsRequired = false)]
        public int thumb_width { get; set; }

        [DataMember(Name = "thumb_height", IsRequired = false)]
        public int thumb_height { get; set; }
    }

    [DataContract]
    public class InlineQueryResultLocation
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "latitude")]
        public float latitude { get; set; }

        [DataMember(Name = "longitude")]
        public float longitude { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "live_period", IsRequired = false)]
        public int live_period { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }

        [DataMember(Name = "thumb_url", IsRequired = false)]
        public string thumb_url { get; set; }

        [DataMember(Name = "thumb_width", IsRequired = false)]
        public int thumb_width { get; set; }

        [DataMember(Name = "thumb_height", IsRequired = false)]
        public int thumb_height { get; set; }
    }

    [DataContract]
    public class InlineQueryResultVenue
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "latitude")]
        public float latitude { get; set; }

        [DataMember(Name = "longitude")]
        public float longitude { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "address")]
        public string address { get; set; }

        [DataMember(Name = "foursquare_id", IsRequired = false)]
        public string foursquare_id { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }

        [DataMember(Name = "thumb_url", IsRequired = false)]
        public string thumb_url { get; set; }

        [DataMember(Name = "thumb_width", IsRequired = false)]
        public int thumb_width { get; set; }

        [DataMember(Name = "thumb_height", IsRequired = false)]
        public int thumb_height { get; set; }
    }

    [DataContract]
    public class InlineQueryResultContact
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "phone_number")]
        public string phone_number { get; set; }

        [DataMember(Name = "first_name")]
        public string first_name { get; set; }

        [DataMember(Name = "last_name", IsRequired = false)]
        public string last_name { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }

        [DataMember(Name = "thumb_url", IsRequired = false)]
        public string thumb_url { get; set; }

        [DataMember(Name = "thumb_width", IsRequired = false)]
        public int thumb_width { get; set; }

        [DataMember(Name = "thumb_height", IsRequired = false)]
        public int thumb_height { get; set; }
    }

    [DataContract]
    public class InlineQueryResultGame
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "game_short_name")]
        public string game_short_name { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }
    }

    [DataContract]
    public class InlineQueryResultCachedPhoto
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "photo_file_id")]
        public string photo_file_id { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        public string title { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultCachedGif
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "gif_file_id")]
        public string gif_file_id { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        public string title { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultCachedMpeg4Gif
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "mpeg4_file_id")]
        public string mpeg4_file_id { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        public string title { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultCachedSticker
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "sticker_file_id")]
        public string sticker_file_id { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }


    }

    [DataContract]
    public class InlineQueryResultCachedDocument
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "document_file_id")]
        public string document_file_id { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultCachedVideo
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "video_file_id")]
        public string video_file_id { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultCachedVoice
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "voice_file_id")]
        public string voice_file_id { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultCachedAudio
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "audio_file_id")]
        public string audio_file_id { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    #endregion

    [DataContract]
    public class InputMessageContent
    {
        //This is a mess.
        // No fields are specified in the documentation for this, but is allegedly supposed to be an array of results which can be one or several differnet Types entirely.
    }
    // ... or here.
    #region InputMessageContent Types

    [DataContract]
    public class InputTextMessageContent
    {
        [DataMember(Name = "message_text")]
        public string message_text { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "disable_web_page_preview", IsRequired = false)]
        public bool disable_web_page_preview { get; set; }
    }

    [DataContract]
    public class InputLocationMessageContent
    {
        [DataMember(Name = "latitude")]
        public float latitude { get; set; }

        [DataMember(Name = "longitude")]
        public float longitude { get; set; }

        [DataMember(Name = "live_period", IsRequired = false)]
        public int live_period { get; set; }
    }

    [DataContract]
    public class InputVenueMessageContent
    {
        [DataMember(Name = "latitude")]
        public float latitude { get; set; }

        [DataMember(Name = "longitude")]
        public float longitude { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        public string title { get; set; }

        [DataMember(Name = "address")]
        public string address { get; set; }

        [DataMember(Name = "foursquare_id", IsRequired = false)]
        public string foursquare_id { get; set; }
    }

    [DataContract]
    public class InputContactMessageContent
    {
        [DataMember(Name = "phone_number")]
        public string phone_number { get; set; }

        [DataMember(Name = "first_name")]
        public string first_name { get; set; }

        [DataMember(Name = "last_name", IsRequired = false)]
        public string last_name { get; set; }
    }

    #endregion

    [DataContract]
    public class ChosenInlineResult
    {
        [DataMember(Name = "result_id")]
        public string result_id { get; set; }

        [DataMember(Name = "from")]
        public User from { get; set; }

        [DataMember(Name = "location", IsRequired = false)]
        public Location location { get; set; }

        [DataMember(Name = "inline_message_id", IsRequired = false)]
        public string inline_message_id { get; set; }

        [DataMember(Name = "query")]
        public string query { get; set; }
    }

    #region Payment System Types
    [DataContract]
    public class LabeledPrice
    {
        [DataMember(Name = "label")]
        public string label { get; set; }

        [DataMember(Name = "amount")]
        public int amount { get; set; }
    }

    [DataContract]
    public class Invoice
    {
        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "description")]
        public string description { get; set; }

        [DataMember(Name = "start_parameter")]
        public string start_parameter { get; set; }

        [DataMember(Name = "currency")]
        public string currency { get; set; }

        [DataMember(Name = "total_amount")]
        public int total_amount { get; set; }
    }

    [DataContract]
    public class ShippingAddress
    {
        [DataMember(Name = "country_code")]
        public string country_code { get; set; }

        [DataMember(Name = "state")]
        public string state { get; set; }

        [DataMember(Name = "city")]
        public string city { get; set; }

        [DataMember(Name = "street_line1")]
        public string street_line1 { get; set; }

        [DataMember(Name = "street_line2")]
        public string street_line2 { get; set; }

        [DataMember(Name = "post_code")]
        public string post_code { get; set; }

    }

    [DataContract]
    public class OrderInfo
    {
        [DataMember(Name = "name", IsRequired = false)]
        public string name { get; set; }

        [DataMember(Name = "phone_number", IsRequired = false)]
        public string phone_number { get; set; }

        [DataMember(Name = "email", IsRequired = false)]
        public string email { get; set; }

        [DataMember(Name = "shipping_address", IsRequired = false)]
        public ShippingAddress shipping_address { get; set; }
    }

    [DataContract]
    public class ShippingOption
    {
        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "name")]
        public LabeledPrice[] prices { get; set; }
    }

    [DataContract]
    public class SuccessfulPayment
    {
        [DataMember(Name = "currency")]
        public string currency { get; set; }

        [DataMember(Name = "total_amount")] //This is handled in the smallest currency type, such as cents.
        public int total_amount { get; set; }

        [DataMember(Name = "invoice_payload")]
        public string invoice_payload { get; set; }

        [DataMember(Name = "shipping_option_id", IsRequired = false)]
        public string shipping_option_id { get; set; }

        [DataMember(Name = "order_info", IsRequired = false)]
        public OrderInfo order_info { get; set; }

        [DataMember(Name = "telegram_payment_charge_id")]
        public string telegram_payment_charge_id { get; set; }

        [DataMember(Name = "provider_payment_charge_id")]
        public string provider_payment_charge_id { get; set; }

    }

    [DataContract]
    public class ShippingQuery
    {
        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "from")]
        public User from { get; set; }

        [DataMember(Name = "invoice_payload")]
        public string invoice_payload { get; set; }

        [DataMember(Name = "shipping_address")]
        public ShippingAddress shiping_address { get; set; }

    }

    [DataContract]
    public class PreCheckoutQuery
    {
        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "from")]
        public User from { get; set; }

        [DataMember(Name = "currency")]
        public string currency { get; set; }

        [DataMember(Name = "total_amount")]
        public int total_amount { get; set; }

        [DataMember(Name = "invoice_payload")]
        public string invoice_payload { get; set; }

        [DataMember(Name = "shipping_option_id", IsRequired = false)]
        public string shipping_option_id { get; set; }

        [DataMember(Name = "order_info", IsRequired = false)]
        public OrderInfo order_info { get; set; }
    }

    #endregion

    #region Game Types

    [DataContract]
    public class Game
    {
        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "description")]
        public string description { get; set; }

        [DataMember(Name = "photo")]
        public PhotoSize[] photo { get; set; }

        [DataMember(Name = "text", IsRequired = false)]
        public string text { get; set; }

        [DataMember(Name = "text_entities", IsRequired = false)]
        public MessageEntity[] text_entities { get; set; }

        [DataMember(Name = "animation", IsRequired = false)]
        public Animation animation { get; set; }
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
    public class CallbackGame
    {
        //A placeholder, currently holds no information. Use @BotFather to set up your game.
    }

    [DataContract]
    public class GameHighScore
    {
        [DataMember(Name = "position")]
        public int position { get; set; }

        [DataMember(Name = "user")]
        public User user { get; set; }

        [DataMember(Name = "score")]
        public int score { get; set; }
    }

    #endregion

    #endregion

    // This needs some love.
    #region Telegram Method Object Types
    
    [DataContract]
    public class GetMethod
    {
        public string ToPayload()
        {
            MemoryStream ms = new MemoryStream();
            new DataContractJsonSerializer(GetType()).WriteObject(ms, this);
            ms.Position = 0;

            return new StreamReader(ms).ReadToEnd();
        }
    }

    #region Send Message Contracts
    

    [DataContract]
    public class SendMessage : GetMethod
    {
        [DataMember(Name = "text")]
        public string text { get; set; }

        [DataMember(Name = "parse_mode", EmitDefaultValue = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "disable_notification", EmitDefaultValue = false)]
        public bool disable_notification { get; set; }

        [DataMember(Name = "disable_web_page_preview", EmitDefaultValue = false)]
        public bool disable_web_page_preview { get; set; }

        [DataMember(Name = "reply_to_message_id", EmitDefaultValue = false)]
        public int? reply_to_message_id { get; set; }

        [DataMember(Name = "reply_markup", EmitDefaultValue = false)]
        public object reply_markup { get; set; }

    }
    [DataContract]
    public class SendMessageId : SendMessage
    {
        [DataMember(Name = "chat_id")]
        public long chat_id { get; set; }
    }

    [DataContract]
    public class SendMessageUsername : SendMessage
    {
        [DataMember(Name = "chat_id")]
        public string chat_id { get; set; }
    }

    #endregion

    [DataContract]
    public class ForwardMessage : GetMethod
    {
        [DataMember(Name = "chat_id")]
        public long chat_id { get; set; }

        [DataMember(Name = "from_chat_id")]
        public long from_chat_id { get; set; }

        [DataMember(Name = "message_id")]
        public long message_id { get; set; }
    }












    [DataContract]
    public class GetChatById : GetMethod
    {
        [DataMember(Name = "chat_id")]
        public long chat_id { get; set; }
    }
    [DataContract]
    public class GetChatByIdResult : GetMethod
    {
        [DataMember(Name = "ok")]
        public bool ok { get; set; }

        [DataMember(Name = "result")]
        public Chat resutlt { get; set; }
    }

    public class GetChatAdminsResult : GetMethod
    {
        [DataMember(Name = "ok")]
        public bool ok { get; set; }

        [DataMember(Name = "result")]
        public ChatMember[] result { get; set; }
    }
    public class GetUpdates : GetMethod
    {
        [DataMember(Name = "offset", EmitDefaultValue = false)]
        public long offset { get; set; }
        [DataMember(Name = "limit", EmitDefaultValue = false)]
        public int limit { get; set; }
        [DataMember(Name = "timeout", EmitDefaultValue = false)]
        public int timeout { get; set; }
        [DataMember(Name = "allowed_updates", EmitDefaultValue = false)]
        public string[] allowed_updates { get; set; }
    }
    #endregion

}
