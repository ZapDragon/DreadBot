using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GroupGuardian
{
    #region Json Contracts

    // ALL Messages come in, as an Update object.
    [DataContract]
    public class Update
    {
        //Required
        [DataMember(Name = "update_id")]
        public long update_id { get; set; }
        //Optionals
        [DataMember(Name = "message")]
        public Message message { get; set; }

        [DataMember(Name = "edited_message")]
        public Message edited_message { get; set; }

        [DataMember(Name = "channel_post")]
        public Message channel_post { get; set; }

        [DataMember(Name = "edited_channel_post")]
        public Message edited_channel_post { get; set; }

        [DataMember(Name = "inline_query")]
        public InlineQuery inline_query { get; set; }

        [DataMember(Name = "chosen_inline_result")]
        public ChosenInlineResult chosen_inline_result { get; set; }

        [DataMember(Name = "callback_query")]
        public CallbackQuery callback_query { get; set; }

        [DataMember(Name = "shipping_query")]
        public ShippingQuery shipping_query { get; set; }

        [DataMember(Name = "pre_checkout_query")]
        public PreCheckoutQuery pre_checkout_query { get; set; }
    }

    //Most updates will contain Message objects.
    [DataContract]
    public class Message
    {
        [DataMember(Name = "message_id")]
        public long message_id { get; set; }

        [DataMember(Name = "from")]
        public User from { get; set; }

        [DataMember(Name = "date")]
        public long date { get; set; }

        [DataMember(Name = "chat")]
        public Chat chat { get; set; }

        [DataMember(Name = "forward_from")]
        public User forward_from { get; set; }

        [DataMember(Name = "forward_from_chat")]
        public Chat forward_from_chat { get; set; }

        [DataMember(Name = "forward_from_message_id")]
        public long forward_from_message_id { get; set; }

        [DataMember(Name = "forward_date")]
        public int forward_date { get; set; }

        [DataMember(Name = "reply_to_message")]
        public Message reply_to_message { get; set; }

        [DataMember(Name = "edit_date")]
        public long edit_date { get; set; }

        [DataMember(Name = "media_group_id")]
        public string media_group_id { get; set; }

        [DataMember(Name = "author_signature")]
        public string author_signature { get; set; }

        [DataMember(Name = "text")]
        public string text { get; set; }

        [DataMember(Name = "entities")]
        public MessageEntity[] entities { get; set; }

        [DataMember(Name = "caption_entities")]
        public MessageEntity[] caption_entities { get; set; }

        [DataMember(Name = "audio")]
        public Audio audio { get; set; }

        [DataMember(Name = "document")]
        public Document document { get; set; }

        [DataMember(Name = "game")]
        public Game game { get; set; }

        [DataMember(Name = "photo")]
        public PhotoSize[] photo { get; set; }

        [DataMember(Name = "sticker")]
        public Sticker sticker { get; set; }

        [DataMember(Name = "video")]
        public Video video { get; set; }

        [DataMember(Name = "voice")]
        public Voice voice { get; set; }

        [DataMember(Name = "video_note")]
        public VideoNote video_note { get; set; }

        [DataMember(Name = "caption")]
        public string caption { get; set; }

        [DataMember(Name = "contact")]
        public Contact contact { get; set; }

        [DataMember(Name = "location")]
        public Location location { get; set; }

        [DataMember(Name = "venue")]
        public Venue venue { get; set; }

        [DataMember(Name = "new_chat_members")]
        public User[] new_chat_members { get; set; }

        [DataMember(Name = "left_chat_member")]
        public User left_chat_member { get; set; }

        [DataMember(Name = "new_chat_title")]
        public string new_chat_title { get; set; }

        [DataMember(Name = "new_chat_photo")]
        public PhotoSize[] new_chat_photo { get; set; }

        [DataMember(Name = "delete_chat_photo")]
        public bool delete_chat_photo { get; set; }

        [DataMember(Name = "group_chat_created")]
        public bool group_chat_created { get; set; }

        [DataMember(Name = "supergroup_chat_created")]
        public bool supergroup_chat_created { get; set; }

        [DataMember(Name = "channel_chat_created")]
        public bool channel_chat_created { get; set; }

        [DataMember(Name = "migrate_to_chat_id")]
        public long migrate_to_chat_id { get; set; }

        [DataMember(Name = "migrate_from_chat_id")]
        public long migrate_from_chat_id { get; set; }

        [DataMember(Name = "pinned_message")]
        public Message pinned_message { get; set; }

        [DataMember(Name = "invoice")]
        public Invoice invoice { get; set; }

        [DataMember(Name = "successful_payment")]
        public SuccessfulPayment successful_payment { get; set; }

        [DataMember(Name = "connected_website")]
        public string connected_website { get; set; }
    }

    // User & Chat objects are set usually in refrence to the source of an update, in some for.
    [DataContract]
    public class User
    {
        [DataMember(Name = "id")]
        public long id { get; set; }

        [DataMember(Name = "is_bot")]
        public bool is_bot { get; set; }

        [DataMember(Name = "first_name")]
        public string first_name { get; set; }

        [DataMember(Name = "last_name")]
        public string last_name { get; set; }

        [DataMember(Name = "username")]
        public string username { get; set; }

        [DataMember(Name = "language_code")]
        public string language_code { get; set; }


        public long AccessHash = 0; //TLSharp specific id for ....I have no fucking clue

        public bool isDeleted = false; //Weather or not the user account is Deleted. Determined by TLSharp

        public bool isDreadBot = false; //Is the user Part of the DreadBot platform. (Internally used only)

        public Dictionary<string, int> UsernameHistory = new Dictionary<string, int>(); // <username, Epoch> Contains a record of previously used usernames, and the Epoch of when the change was detected.

    }
    [DataContract]
    public class Chat
    {
        [DataMember(Name = "id")]
        public long id { get; set; }
        [DataMember(Name = "type")]
        public string type { get; set; }
        [DataMember(Name = "title")]
        public string title { get; set; }
        [DataMember(Name = "username")]
        public string username { get; set; }
        [DataMember(Name = "first_name")]
        public string first_name { get; set; }
        [DataMember(Name = "last_name")]
        public string last_name { get; set; }
        [DataMember(Name = "all_members_are_administrators")]
        public bool all_members_are_administrators { get; set; }
        [DataMember(Name = "photo")]
        public ChatPhoto photo { get; set; }
        [DataMember(Name = "description")]
        public string description { get; set; }

        [DataMember(Name = "invite_link")]
        public string invite_link { get; set; }

        [DataMember(Name = "pinned_message")]
        public Message pinned_message { get; set; }

        [DataMember(Name = "sticker_set_name")]
        public string sticker_set_name { get; set; }

        [DataMember(Name = "can_set_sticker_set")]
        public bool can_set_sticker_set { get; set; }
    }
    [DataContract]
    public class ChatMember
    {
        [DataMember(Name = "user")]
        public User user;

        [DataMember(Name = "status")]
        public string status;

        [DataMember(Name = "until_date")]
        public int until_date;

        [DataMember(Name = "can_be_edited")]
        public bool can_be_edited = true;

        [DataMember(Name = "can_change_info")]
        public bool can_change_info = true;

        [DataMember(Name = "can_post_messages")]
        public bool can_post_messages = true;

        [DataMember(Name = "can_edit_messages")]
        public bool can_edit_messages = true;

        [DataMember(Name = "can_delete_messages")]
        public bool can_delete_messages = true;

        [DataMember(Name = "can_invite_users")]
        public bool can_invite_users = true;

        [DataMember(Name = "can_restrict_members")]
        public bool can_restrict_members = true;

        [DataMember(Name = "can_pin_messages")]
        public bool can_pin_messages = true;

        [DataMember(Name = "can_promote_members")]
        public bool can_promote_members = true;

        [DataMember(Name = "can_send_messages")]
        public bool can_send_messages = true;

        [DataMember(Name = "can_send_media_messages")]
        public bool can_send_media_messages = true;

        [DataMember(Name = "can_send_other_messages")]
        public bool can_send_other_messages = true;

        [DataMember(Name = "can_add_web_page_previews")]
        public bool can_add_web_page_previews = true;
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
    public class MessageEntity
    {
        [DataMember(Name = "type")]
        public string type { get; set; }
        [DataMember(Name = "offset")]
        public int offset { get; set; }
        [DataMember(Name = "length")]
        public int length { get; set; }
        [DataMember(Name = "url")]
        public string url { get; set; }
        [DataMember(Name = "user")]
        public User user { get; set; }
    }

    [DataContract]
    public class Audio
    {
        [DataMember(Name = "file_id")]
        public string file_id { get; set; }

        [DataMember(Name = "duration")]
        public int duration { get; set; }

        [DataMember(Name = "performer")]
        public string performer { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "mime_type")]
        public string mime_type { get; set; }

        [DataMember(Name = "file_size")]
        public int file_size { get; set; }
    }

    [DataContract]
    public class Document
    {
        [DataMember(Name = "file_id")]
        public string file_id { get; set; }

        [DataMember(Name = "thumb")]
        public PhotoSize thumb { get; set; }

        [DataMember(Name = "file_name")]
        public string file_name { get; set; }

        [DataMember(Name = "mime_type")]
        public string mime_type { get; set; }

        [DataMember(Name = "file_size")]
        public int file_size { get; set; }
    }
    [DataContract]
    public class Game
    {
        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "description")]
        public string description { get; set; }

        [DataMember(Name = "photo")]
        public PhotoSize[] photo { get; set; }

        [DataMember(Name = "text")]
        public string text { get; set; }

        [DataMember(Name = "text_entities")]
        public MessageEntity text_entities { get; set; }

        [DataMember(Name = "animation")]
        public Animation animation { get; set; }

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
        [DataMember(Name = "file_size")]
        public long file_size { get; set; }
    }

    [DataContract]
    public class Animation
    {
        [DataMember(Name = "file_id")]
        public string file_id { get; set; }

        [DataMember(Name = "thumb")]
        public PhotoSize thumb { get; set; }

        [DataMember(Name = "file_name")]
        public string file_name { get; set; }

        [DataMember(Name = "mime_type")]
        public string mime_type { get; set; }

        [DataMember(Name = "file_size")]
        public int file_size { get; set; }
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
    public class Sticker
    {
        [DataMember(Name = "file_id")]
        public string file_id { get; set; }

        [DataMember(Name = "width")]
        public int width { get; set; }

        [DataMember(Name = "height")]
        public int height { get; set; }

        [DataMember(Name = "thumb")]
        public PhotoSize thumb { get; set; }

        [DataMember(Name = "emoji")]
        public string emoji { get; set; }

        [DataMember(Name = "set_name")]
        public string set_name { get; set; }

        [DataMember(Name = "mask_position")]
        public MaskPosition mask_position { get; set; }

        [DataMember(Name = "file_size")]
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

        [DataMember(Name = "thumb")]
        public PhotoSize thumb { get; set; }

        [DataMember(Name = "mime_type")]
        public string mime_type { get; set; }

        [DataMember(Name = "file_size")]
        public int file_size { get; set; }
    }
    [DataContract]
    public class Voice
    {
        [DataMember(Name = "file_id")]
        public string file_id { get; set; }

        [DataMember(Name = "duration")]
        public int duration { get; set; }

        [DataMember(Name = "mime_type")]
        public string mime_type { get; set; }

        [DataMember(Name = "file_size")]
        public int file_size { get; set; }
    }
    [DataContract]
    public class VideoNote
    {
    }
    [DataContract]
    public class Contact
    {
    }
    //Location info
    [DataContract]
    public class Location
    {
    }
    [DataContract]
    public class Venue
    {
    }

    //Payment info
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
        public string total_amount { get; set; }
    }
    [DataContract]
    public class SuccessfulPayment
    {
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
    public class PreCheckoutQuery
    {
    }

    //InlineKeyboard
    [DataContract]
    public class CallbackQuery
    {
        [DataMember(Name = "id")]
        public string id { get; set; }
        [DataMember(Name = "from")]
        public User from { get; set; }
        [DataMember(Name = "message")]
        public Message message { get; set; }
        [DataMember(Name = "inline_message_id")]
        public string inline_message_id { get; set; }
        [DataMember(Name = "chat_instance")]
        public string chat_instance { get; set; }
        [DataMember(Name = "data")]
        public string data { get; set; }
    }

    [DataContract]
    public class InlineKeyboardMarkup
    {
        [DataMember(Name = "inline_keyboard")]
        public List<List<InlineKeyboardButton>> inline_keyboard { get; set; }

        public InlineKeyboardMarkup()
        {
            inline_keyboard = new List<List<InlineKeyboardButton>>();
        }
        public void AddRow()
        {
            inline_keyboard.Add(new List<InlineKeyboardButton>());
        }
        public void addButton(InlineKeyboardButton button, int row)
        {
            inline_keyboard[row].Add(button);
        }
    }
    [DataContract]
    public class InlineKeyboardButton
    {
        [DataMember(Name = "text")]
        public string text { get; set; }
        //USE ONLY ONE OF BELOW
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string url { get; set; }
        [DataMember(Name = "callback_data", EmitDefaultValue = false)]
        public string callback_data { get; set; }
        [DataMember(Name = "pay", EmitDefaultValue = false)]
        public bool pay { get; set; }
    }
    [DataContract]
    public class InlineQuery
    {
        [DataMember(Name = "id")]
        public string id { get; set; }
        [DataMember(Name = "from")]
        public User from { get; set; }
        [DataMember(Name = "query")]
        public string query { get; set; }
        [DataMember(Name = "offset")]
        public string offset { get; set; }
    }
    [DataContract]
    public class ChosenInlineResult
    {
        [DataMember(Name = "result_id")]
        public string result_id { get; set; }
        [DataMember(Name = "from")]
        public User from { get; set; }
        [DataMember(Name = "query")]
        public string query { get; set; }
        //Optional
        [DataMember(Name = "inline_message_id", EmitDefaultValue = false)]
        public string inline_message_id { get; set; }
    }
    //Sending stuff
    [DataContract]
    public class SendMessage
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
        public InlineKeyboardMarkup reply_markup { get; set; }

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

    [DataContract]
    public class ForwardMessageID
    {
        [DataMember(Name = "chat_id")]
        public long chat_id { get; set; }

        [DataMember(Name = "from_chat_id")]
        public long from_chat_id { get; set; }

        [DataMember(Name = "message_id")]
        public long message_id { get; set; }
    }

    [DataContract]
    public class GetChatById
    {
        [DataMember(Name = "chat_id")]
        public long chat_id { get; set; }
    }
    [DataContract]
    public class GetChatByIdResult
    {
        [DataMember(Name = "ok")]
        public bool ok { get; set; }
        [DataMember(Name = "result")]
        public Chat resutlt { get; set; }
    }

    public class GetChatAdminsResult
    {
        [DataMember(Name = "ok")]
        public bool ok { get; set; }
        [DataMember(Name = "result")]
        public ChatMember[] result { get; set; }
    }
    #endregion
}
