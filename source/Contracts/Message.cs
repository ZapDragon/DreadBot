#region License 
//MIT License
//Copyright(c) [2024]
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
		/// Optional. Sender of the message; may be empty for messages sent to channels. For backward compatibility, if the message was sent on behalf of a chat, the field contains a fake sender user in non-channel chats
		/// </summary>
		[DataMember(Name = "from", EmitDefaultValue = false)]
		public User from { get; set; }
		/// <summary>
		/// Optional. Sender of the message when sent on behalf of a chat. For example, the supergroup itself for messages sent by its anonymous administrators or a linked channel for messages automatically forwarded to the channel's discussion group. For backward compatibility, if the message was sent on behalf of a chat, the field from contains a fake sender user in non-channel chats.
		/// </summary>
		[DataMember(Name = "sender_chat", EmitDefaultValue = false)]
		public Chat sender_chat { get; set; }
		/// <summary>
		/// Optional. If the sender of the message boosted the chat, the number of boosts added by the user
		/// </summary>
		[DataMember(Name = "sender_boost_count", EmitDefaultValue = false)]
		public int sender_boost_count { get; set; }
		/// <summary>
		/// Optional. The bot that actually sent the message on behalf of the business account. Available only for outgoing messages sent on behalf of the connected business account.
		/// </summary>
		[DataMember(Name = "sender_business_bot", EmitDefaultValue = false)]
		public User sender_business_bot { get; set; }
		/// <summary>
		/// Date the message was sent in Unix time. It is always a positive number, representing a valid date.
		/// </summary>
		[DataMember(Name = "date", IsRequired = true)]
		public long date { get; set; }
		/// <summary>
		/// Optional. Unique identifier of the business connection from which the message was received. If non-empty, the message belongs to a chat of the corresponding business account that is independent from any potential bot chat which might share the same identifier.
		/// </summary>
		[DataMember(Name = "business_connection_id", EmitDefaultValue = false)]
		public string business_connection_id { get; set; }
		/// <summary>
		/// Chat the message belongs to
		/// </summary>
		[DataMember(Name = "chat", IsRequired = true)]
		public Chat chat { get; set; }
		/// <summary>
		/// Optional. Information about the original message for forwarded messages
		/// </summary>
		[DataMember(Name = "forward_origin", EmitDefaultValue = false)]
		public MessageOrigin forward_origin { get; set; }
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
		/// Optional. For replies in the same chat and message thread, the original message. Note that the Message object in this field will not contain further reply_to_message fields even if it itself is a reply.
		/// </summary>
		[DataMember(Name = "reply_to_message", EmitDefaultValue = false)]
		public Message reply_to_message { get; set; }
		/// <summary>
		/// Optional. Information about the message that is being replied to, which may come from another chat or forum topic
		/// </summary>
		[DataMember(Name = "external_reply", EmitDefaultValue = false)]
		public ExternalReplyInfo external_reply { get; set; }
		/// <summary>
		/// Optional. For replies that quote part of the original message, the quoted part of the message
		/// </summary>
		[DataMember(Name = "quote", EmitDefaultValue = false)]
		public TextQuote quote { get; set; }
		/// <summary>
		/// Optional. For replies to a story, the original story
		/// </summary>
		[DataMember(Name = "reply_to_story", EmitDefaultValue = false)]
		public Story reply_to_story { get; set; }
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
		/// Optional. True, if the message was sent by an implicit action, for example, as an away or a greeting business message, or as a scheduled message
		/// </summary>
		[DataMember(Name = "is_from_offline", EmitDefaultValue = false)]
		public bool is_from_offline { get; set; }
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
		/// Optional. Options used for link preview generation for the message, if it is a text message and link preview options were changed
		/// </summary>
		[DataMember(Name = "link_preview_options", EmitDefaultValue = false)]
		public LinkPreviewOptions link_preview_options { get; set; }
		/// <summary>
		/// Optional. Unique identifier of the message effect added to the message
		/// </summary>
		[DataMember(Name = "effect_id", EmitDefaultValue = false)]
		public string effect_id { get; set; }
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
		/// Optional. Message contains paid media; information about the paid media
		/// </summary>
		[DataMember(Name = "paid_media", EmitDefaultValue = false)]
		public PaidMediaInfo paid_media { get; set; }
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
		/// Optional. Message is a forwarded story
		/// </summary>
		[DataMember(Name = "story", EmitDefaultValue = false)]
		public Story story { get; set; }
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
		/// Optional. Caption for the animation, audio, document, paid media, photo, video or voice
		/// </summary>
		[DataMember(Name = "caption", EmitDefaultValue = false)]
		public string caption { get; set; }
		/// <summary>
		/// Optional. For messages with a caption, special entities like usernames, URLs, bot commands, etc. that appear in the caption
		/// </summary>
		[DataMember(Name = "caption_entities", EmitDefaultValue = false)]
		public Array<MessageEntity> caption_entities { get; set; }
		/// <summary>
		/// Optional. True, if the caption must be shown above the message media
		/// </summary>
		[DataMember(Name = "show_caption_above_media", EmitDefaultValue = false)]
		public bool show_caption_above_media { get; set; }
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
		/// Optional. Specified message was pinned. Note that the Message object in this field will not contain further reply_to_message fields even if it itself is a reply.
		/// </summary>
		[DataMember(Name = "pinned_message", EmitDefaultValue = false)]
		public MaybeInaccessibleMessage pinned_message { get; set; }
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
		/// Optional. Message is a service message about a refunded payment, information about the payment. More about payments »
		/// </summary>
		[DataMember(Name = "refunded_payment", EmitDefaultValue = false)]
		public RefundedPayment refunded_payment { get; set; }
		/// <summary>
		/// Optional. Service message: users were shared with the bot
		/// </summary>
		[DataMember(Name = "users_shared", EmitDefaultValue = false)]
		public UsersShared users_shared { get; set; }
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
		/// Optional. Service message: the user allowed the bot to write messages after adding it to the attachment or side menu, launching a Web App from a link, or accepting an explicit request from a Web App sent by the method requestWriteAccess
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
		/// Optional. Service message: user boosted the chat
		/// </summary>
		[DataMember(Name = "boost_added", EmitDefaultValue = false)]
		public ChatBoostAdded boost_added { get; set; }
		/// <summary>
		/// Optional. Service message: chat background set
		/// </summary>
		[DataMember(Name = "chat_background_set", EmitDefaultValue = false)]
		public ChatBackground chat_background_set { get; set; }
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
		/// Optional. Service message: a scheduled giveaway was created
		/// </summary>
		[DataMember(Name = "giveaway_created", EmitDefaultValue = false)]
		public GiveawayCreated giveaway_created { get; set; }
		/// <summary>
		/// Optional. The message is a scheduled giveaway message
		/// </summary>
		[DataMember(Name = "giveaway", EmitDefaultValue = false)]
		public Giveaway giveaway { get; set; }
		/// <summary>
		/// Optional. A giveaway with public winners was completed
		/// </summary>
		[DataMember(Name = "giveaway_winners", EmitDefaultValue = false)]
		public GiveawayWinners giveaway_winners { get; set; }
		/// <summary>
		/// Optional. Service message: a giveaway without public winners was completed
		/// </summary>
		[DataMember(Name = "giveaway_completed", EmitDefaultValue = false)]
		public GiveawayCompleted giveaway_completed { get; set; }
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
