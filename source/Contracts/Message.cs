#region License 
//MIT License
//Copyright(c) [2023]
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
	/// <summary>
	/// This object represents a message.
	/// </summary>
	[DataContract]
	public class Message
	{
		/// <summary>
		/// Unique message identifier inside this chat
		/// </summary>
		[DataMember(Name = "message_id", IsRequired = true)]
		public long message_id { get; set; }
		/// <summary>
		/// Optional. Unique identifier of a message thread to which the message belongs; for supergroups only
		/// </summary>
		[DataMember(Name = "message_thread_id", EmitDefaultValue = false)]
		public int message_thread_id { get; set; }
		/// <summary>
		/// Optional. Sender of the message; empty for messages sent to channels. For backward compatibility, the field contains a fake sender user in non-channel chats, if the message was sent on behalf of a chat.
		/// </summary>
		[DataMember(Name = "from", EmitDefaultValue = false)]
		public User from { get; set; }
		/// <summary>
		/// Optional. Sender of the message, sent on behalf of a chat. For example, the channel itself for channel posts, the supergroup itself for messages from anonymous group administrators, the linked channel for messages automatically forwarded to the discussion group. For backward compatibility, the field from contains a fake sender user in non-channel chats, if the message was sent on behalf of a chat.
		/// </summary>
		[DataMember(Name = "sender_chat", EmitDefaultValue = false)]
		public Chat sender_chat { get; set; }
		/// <summary>
		/// Date the message was sent in Unix time
		/// </summary>
		[DataMember(Name = "date", IsRequired = true)]
		public long date { get; set; }
		/// <summary>
		/// Conversation the message belongs to
		/// </summary>
		[DataMember(Name = "chat", IsRequired = true)]
		public Chat chat { get; set; }
		/// <summary>
		/// Optional. For forwarded messages, sender of the original message
		/// </summary>
		[DataMember(Name = "forward_from", EmitDefaultValue = false)]
		public User forward_from { get; set; }
		/// <summary>
		/// Optional. For messages forwarded from channels or from anonymous administrators, information about the original sender chat
		/// </summary>
		[DataMember(Name = "forward_from_chat", EmitDefaultValue = false)]
		public Chat forward_from_chat { get; set; }
		/// <summary>
		/// Optional. For messages forwarded from channels, identifier of the original message in the channel
		/// </summary>
		[DataMember(Name = "forward_from_message_id", EmitDefaultValue = false)]
		public long forward_from_message_id { get; set; }
		/// <summary>
		/// Optional. For forwarded messages that were originally sent in channels or by an anonymous chat administrator, signature of the message sender if present
		/// </summary>
		[DataMember(Name = "forward_signature", EmitDefaultValue = false)]
		public string forward_signature { get; set; }
		/// <summary>
		/// Optional. Sender's name for messages forwarded from users who disallow adding a link to their account in forwarded messages
		/// </summary>
		[DataMember(Name = "forward_sender_name", EmitDefaultValue = false)]
		public string forward_sender_name { get; set; }
		/// <summary>
		/// Optional. For forwarded messages, date the original message was sent in Unix time
		/// </summary>
		[DataMember(Name = "forward_date", EmitDefaultValue = false)]
		public long forward_date { get; set; }
		/// <summary>
		/// Optional. True, if the message is sent to a forum topic
		/// </summary>
		[DataMember(Name = "is_topic_message", EmitDefaultValue = false)]
		public bool is_topic_message { get; set; }
		/// <summary>
		/// Optional. True, if the message is a channel post that was automatically forwarded to the connected discussion group
		/// </summary>
		[DataMember(Name = "is_automatic_forward", EmitDefaultValue = false)]
		public bool is_automatic_forward { get; set; }
		/// <summary>
		/// Optional. For replies, the original message. Note that the Message object in this field will not contain further reply_to_message fields even if it itself is a reply.
		/// </summary>
		[DataMember(Name = "reply_to_message", EmitDefaultValue = false)]
		public Message reply_to_message { get; set; }
		/// <summary>
		/// Optional. Bot through which the message was sent
		/// </summary>
		[DataMember(Name = "via_bot", EmitDefaultValue = false)]
		public User via_bot { get; set; }
		/// <summary>
		/// Optional. Date the message was last edited in Unix time
		/// </summary>
		[DataMember(Name = "edit_date", EmitDefaultValue = false)]
		public long edit_date { get; set; } = 0;
		/// <summary>
		/// Optional. True, if the message can't be forwarded
		/// </summary>
		[DataMember(Name = "has_protected_content", EmitDefaultValue = false)]
		public bool has_protected_content { get; set; }
		/// <summary>
		/// Optional. The unique identifier of a media message group this message belongs to
		/// </summary>
		[DataMember(Name = "media_group_id", EmitDefaultValue = false)]
		public string media_group_id { get; set; }
		/// <summary>
		/// Optional. Signature of the post author for messages in channels, or the custom title of an anonymous group administrator
		/// </summary>
		[DataMember(Name = "author_signature", EmitDefaultValue = false)]
		public string author_signature { get; set; }
		/// <summary>
		/// Optional. For text messages, the actual UTF-8 text of the message
		/// </summary>
		[DataMember(Name = "text", EmitDefaultValue = false)]
		public string text { get; set; }
		/// <summary>
		/// Optional. For text messages, special entities like usernames, URLs, bot commands, etc. that appear in the text
		/// </summary>
		[DataMember(Name = "entities", EmitDefaultValue = false)]
		public Array<MessageEntity> entities { get; set; }
		/// <summary>
		/// Optional. Message is an animation, information about the animation. For backward compatibility, when this field is set, the document field will also be set
		/// </summary>
		[DataMember(Name = "animation", EmitDefaultValue = false)]
		public Animation animation { get; set; }
		/// <summary>
		/// Optional. Message is an audio file, information about the file
		/// </summary>
		[DataMember(Name = "audio", EmitDefaultValue = false)]
		public Audio audio { get; set; }
		/// <summary>
		/// Optional. Message is a general file, information about the file
		/// </summary>
		[DataMember(Name = "document", EmitDefaultValue = false)]
		public Document document { get; set; }
		/// <summary>
		/// Optional. Message is a photo, available sizes of the photo
		/// </summary>
		[DataMember(Name = "photo", EmitDefaultValue = false)]
		public Array<PhotoSize> photo { get; set; }
		/// <summary>
		/// Optional. Message is a sticker, information about the sticker
		/// </summary>
		[DataMember(Name = "sticker", EmitDefaultValue = false)]
		public Sticker sticker { get; set; }
		/// <summary>
		/// Optional. Message is a video, information about the video
		/// </summary>
		[DataMember(Name = "video", EmitDefaultValue = false)]
		public Video video { get; set; }
		/// <summary>
		/// Optional. Message is a video note, information about the video message
		/// </summary>
		[DataMember(Name = "video_note", EmitDefaultValue = false)]
		public VideoNote video_note { get; set; }
		/// <summary>
		/// Optional. Message is a voice message, information about the file
		/// </summary>
		[DataMember(Name = "voice", EmitDefaultValue = false)]
		public Voice voice { get; set; }
		/// <summary>
		/// Optional. Caption for the animation, audio, document, photo, video or voice
		/// </summary>
		[DataMember(Name = "caption", EmitDefaultValue = false)]
		public string caption { get; set; }
		/// <summary>
		/// Optional. For messages with a caption, special entities like usernames, URLs, bot commands, etc. that appear in the caption
		/// </summary>
		[DataMember(Name = "caption_entities", EmitDefaultValue = false)]
		public Array<MessageEntity> caption_entities { get; set; }
		/// <summary>
		/// Optional. True, if the message media is covered by a spoiler animation
		/// </summary>
		[DataMember(Name = "has_media_spoiler", EmitDefaultValue = false)]
		public bool has_media_spoiler { get; set; }
		/// <summary>
		/// Optional. Message is a shared contact, information about the contact
		/// </summary>
		[DataMember(Name = "contact", EmitDefaultValue = false)]
		public Contact contact { get; set; }
		/// <summary>
		/// Optional. Message is a dice with random value
		/// </summary>
		[DataMember(Name = "dice", EmitDefaultValue = false)]
		public Dice dice { get; set; }
		/// <summary>
		/// Optional. Message is a game, information about the game. More about games »
		/// </summary>
		[DataMember(Name = "game", EmitDefaultValue = false)]
		public Game game { get; set; }
		/// <summary>
		/// Optional. Message is a native poll, information about the poll
		/// </summary>
		[DataMember(Name = "poll", EmitDefaultValue = false)]
		public Poll poll { get; set; }
		/// <summary>
		/// Optional. Message is a venue, information about the venue. For backward compatibility, when this field is set, the location field will also be set
		/// </summary>
		[DataMember(Name = "venue", EmitDefaultValue = false)]
		public Venue venue { get; set; }
		/// <summary>
		/// Optional. Message is a shared location, information about the location
		/// </summary>
		[DataMember(Name = "location", EmitDefaultValue = false)]
		public Location location { get; set; }
		/// <summary>
		/// Optional. New members that were added to the group or supergroup and information about them (the bot itself may be one of these members)
		/// </summary>
		[DataMember(Name = "new_chat_members", EmitDefaultValue = false)]
		public Array<User> new_chat_members { get; set; }
		/// <summary>
		/// Optional. A member was removed from the group, information about them (this member may be the bot itself)
		/// </summary>
		[DataMember(Name = "left_chat_member", EmitDefaultValue = false)]
		public User left_chat_member { get; set; }
		/// <summary>
		/// Optional. A chat title was changed to this value
		/// </summary>
		[DataMember(Name = "new_chat_title", EmitDefaultValue = false)]
		public string new_chat_title { get; set; }
		/// <summary>
		/// Optional. A chat photo was change to this value
		/// </summary>
		[DataMember(Name = "new_chat_photo", EmitDefaultValue = false)]
		public Array<PhotoSize> new_chat_photo { get; set; }
		/// <summary>
		/// Optional. Service message: the chat photo was deleted
		/// </summary>
		[DataMember(Name = "delete_chat_photo", EmitDefaultValue = false)]
		public bool delete_chat_photo { get; set; }
		/// <summary>
		/// Optional. Service message: the group has been created
		/// </summary>
		[DataMember(Name = "group_chat_created", EmitDefaultValue = false)]
		public bool group_chat_created { get; set; }
		/// <summary>
		/// Optional. Service message: the supergroup has been created. This field can't be received in a message coming through updates, because bot can't be a member of a supergroup when it is created. It can only be found in reply_to_message if someone replies to a very first message in a directly created supergroup.
		/// </summary>
		[DataMember(Name = "supergroup_chat_created", EmitDefaultValue = false)]
		public bool supergroup_chat_created { get; set; }
		/// <summary>
		/// Optional. Service message: the channel has been created. This field can't be received in a message coming through updates, because bot can't be a member of a channel when it is created. It can only be found in reply_to_message if someone replies to a very first message in a channel.
		/// </summary>
		[DataMember(Name = "channel_chat_created", EmitDefaultValue = false)]
		public bool channel_chat_created { get; set; }
		/// <summary>
		/// Optional. Service message: auto-delete timer settings changed in the chat
		/// </summary>
		[DataMember(Name = "message_auto_delete_timer_changed", EmitDefaultValue = false)]
		public MessageAutoDeleteTimerChanged message_auto_delete_timer_changed { get; set; }
		/// <summary>
		/// Optional. The group has been migrated to a supergroup with the specified identifier. This number may have more than 32 significant bits and some programming languages may have difficulty/silent defects in interpreting it. But it has at most 52 significant bits, so a signed 64-bit integer or double-precision float type are safe for storing this identifier.
		/// </summary>
		[DataMember(Name = "migrate_to_chat_id", EmitDefaultValue = false)]
		public long migrate_to_chat_id { get; set; } = 0;
		/// <summary>
		/// Optional. The supergroup has been migrated from a group with the specified identifier. This number may have more than 32 significant bits and some programming languages may have difficulty/silent defects in interpreting it. But it has at most 52 significant bits, so a signed 64-bit integer or double-precision float type are safe for storing this identifier.
		/// </summary>
		[DataMember(Name = "migrate_from_chat_id", EmitDefaultValue = false)]
		public long migrate_from_chat_id { get; set; } = 0;
		/// <summary>
		/// Optional. Specified message was pinned. Note that the Message object in this field will not contain further reply_to_message fields even if it is itself a reply.
		/// </summary>
		[DataMember(Name = "pinned_message", EmitDefaultValue = false)]
		public Message pinned_message { get; set; }
		/// <summary>
		/// Optional. Message is an invoice for a payment, information about the invoice. More about payments »
		/// </summary>
		[DataMember(Name = "invoice", EmitDefaultValue = false)]
		public Invoice invoice { get; set; }
		/// <summary>
		/// Optional. Message is a service message about a successful payment, information about the payment. More about payments »
		/// </summary>
		[DataMember(Name = "successful_payment", EmitDefaultValue = false)]
		public SuccessfulPayment successful_payment { get; set; }
		/// <summary>
		/// Optional. Service message: a user was shared with the bot
		/// </summary>
		[DataMember(Name = "user_shared", EmitDefaultValue = false)]
		public UserShared user_shared { get; set; }
		/// <summary>
		/// Optional. Service message: a chat was shared with the bot
		/// </summary>
		[DataMember(Name = "chat_shared", EmitDefaultValue = false)]
		public ChatShared chat_shared { get; set; }
		/// <summary>
		/// Optional. The domain name of the website on which the user has logged in. More about Telegram Login »
		/// </summary>
		[DataMember(Name = "connected_website", EmitDefaultValue = false)]
		public string connected_website { get; set; }
		/// <summary>
		/// Optional. Service message: the user allowed the bot added to the attachment menu to write messages
		/// </summary>
		[DataMember(Name = "write_access_allowed", EmitDefaultValue = false)]
		public WriteAccessAllowed write_access_allowed { get; set; }
		/// <summary>
		/// Optional. Telegram Passport data
		/// </summary>
		[DataMember(Name = "passport_data", EmitDefaultValue = false)]
		public PassportData passport_data { get; set; }
		/// <summary>
		/// Optional. Service message. A user in the chat triggered another user's proximity alert while sharing Live Location.
		/// </summary>
		[DataMember(Name = "proximity_alert_triggered", EmitDefaultValue = false)]
		public ProximityAlertTriggered proximity_alert_triggered { get; set; }
		/// <summary>
		/// Optional. Service message: forum topic created
		/// </summary>
		[DataMember(Name = "forum_topic_created", EmitDefaultValue = false)]
		public ForumTopicCreated forum_topic_created { get; set; }
		/// <summary>
		/// Optional. Service message: forum topic edited
		/// </summary>
		[DataMember(Name = "forum_topic_edited", EmitDefaultValue = false)]
		public ForumTopicEdited forum_topic_edited { get; set; }
		/// <summary>
		/// Optional. Service message: forum topic closed
		/// </summary>
		[DataMember(Name = "forum_topic_closed", EmitDefaultValue = false)]
		public ForumTopicClosed forum_topic_closed { get; set; }
		/// <summary>
		/// Optional. Service message: forum topic reopened
		/// </summary>
		[DataMember(Name = "forum_topic_reopened", EmitDefaultValue = false)]
		public ForumTopicReopened forum_topic_reopened { get; set; }
		/// <summary>
		/// Optional. Service message: the 'General' forum topic hidden
		/// </summary>
		[DataMember(Name = "general_forum_topic_hidden", EmitDefaultValue = false)]
		public GeneralForumTopicHidden general_forum_topic_hidden { get; set; }
		/// <summary>
		/// Optional. Service message: the 'General' forum topic unhidden
		/// </summary>
		[DataMember(Name = "general_forum_topic_unhidden", EmitDefaultValue = false)]
		public GeneralForumTopicUnhidden general_forum_topic_unhidden { get; set; }
		/// <summary>
		/// Optional. Service message: video chat scheduled
		/// </summary>
		[DataMember(Name = "video_chat_scheduled", EmitDefaultValue = false)]
		public VideoChatScheduled video_chat_scheduled { get; set; }
		/// <summary>
		/// Optional. Service message: video chat started
		/// </summary>
		[DataMember(Name = "video_chat_started", EmitDefaultValue = false)]
		public VideoChatStarted video_chat_started { get; set; }
		/// <summary>
		/// Optional. Service message: video chat ended
		/// </summary>
		[DataMember(Name = "video_chat_ended", EmitDefaultValue = false)]
		public VideoChatEnded video_chat_ended { get; set; }
		/// <summary>
		/// Optional. Service message: new participants invited to a video chat
		/// </summary>
		[DataMember(Name = "video_chat_participants_invited", EmitDefaultValue = false)]
		public VideoChatParticipantsInvited video_chat_participants_invited { get; set; }
		/// <summary>
		/// Optional. Service message: data sent by a Web App
		/// </summary>
		[DataMember(Name = "web_app_data", EmitDefaultValue = false)]
		public WebAppData web_app_data { get; set; }
		/// <summary>
		/// Optional. Inline keyboard attached to the message. login_url buttons are represented as ordinary url buttons.
		/// </summary>
		[DataMember(Name = "reply_markup", EmitDefaultValue = false)]
		public InlineKeyboardMarkup reply_markup { get; set; }
	}
}
