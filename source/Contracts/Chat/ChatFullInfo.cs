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
	/// This object contains full information about a chat.
	/// </summary>
	[DataContract]
	public class ChatFullInfo
	{
		/// <summary>
		/// Unique identifier for this chat. This number may have more than 32 significant bits and some programming languages may have difficulty/silent defects in interpreting it. But it has at most 52 significant bits, so a signed 64-bit integer or double-precision float type are safe for storing this identifier.
		/// </summary>
		[DataMember(Name = "id", IsRequired = true)]
		public long id { get; set; }
		/// <summary>
		/// Type of the chat, can be either “private”, “group”, “supergroup” or “channel”
		/// </summary>
		[DataMember(Name = "type", IsRequired = true)]
		public string type { get; set; }
		/// <summary>
		/// Optional. Title, for supergroups, channels and group chats
		/// </summary>
		[DataMember(Name = "title", EmitDefaultValue = false)]
		public string title { get; set; }
		/// <summary>
		/// Optional. Username, for private chats, supergroups and channels if available
		/// </summary>
		[DataMember(Name = "username", EmitDefaultValue = false)]
		public string username { get; set; }
		/// <summary>
		/// Optional. First name of the other party in a private chat
		/// </summary>
		[DataMember(Name = "first_name", EmitDefaultValue = false)]
		public string first_name { get; set; }
		/// <summary>
		/// Optional. Last name of the other party in a private chat
		/// </summary>
		[DataMember(Name = "last_name", EmitDefaultValue = false)]
		public string last_name { get; set; }
		/// <summary>
		/// Optional. True, if the supergroup chat is a forum (has topics enabled)
		/// </summary>
		[DataMember(Name = "is_forum", EmitDefaultValue = false)]
		public bool is_forum { get; set; }
		/// <summary>
		/// Identifier of the accent color for the chat name and backgrounds of the chat photo, reply header, and link preview. See accent colors for more details.
		/// </summary>
		[DataMember(Name = "accent_color_id", IsRequired = true)]
		public int accent_color_id { get; set; }
		/// <summary>
		/// The maximum number of reactions that can be set on a message in the chat
		/// </summary>
		[DataMember(Name = "max_reaction_count", IsRequired = true)]
		public int max_reaction_count { get; set; }
		/// <summary>
		/// Optional. Chat photo
		/// </summary>
		[DataMember(Name = "photo", EmitDefaultValue = false)]
		public ChatPhoto photo { get; set; }
		/// <summary>
		/// Optional. If non-empty, the list of all active chat usernames; for private chats, supergroups and channels
		/// </summary>
		[DataMember(Name = "active_usernames", EmitDefaultValue = false)]
		public Array<string> active_usernames { get; set; }
		/// <summary>
		/// Optional. For private chats, the date of birth of the user
		/// </summary>
		[DataMember(Name = "birthdate", EmitDefaultValue = false)]
		public Birthdate birthdate { get; set; }
		/// <summary>
		/// Optional. For private chats with business accounts, the intro of the business
		/// </summary>
		[DataMember(Name = "business_intro", EmitDefaultValue = false)]
		public BusinessIntro business_intro { get; set; }
		/// <summary>
		/// Optional. For private chats with business accounts, the location of the business
		/// </summary>
		[DataMember(Name = "business_location", EmitDefaultValue = false)]
		public BusinessLocation business_location { get; set; }
		/// <summary>
		/// Optional. For private chats with business accounts, the opening hours of the business
		/// </summary>
		[DataMember(Name = "business_opening_hours", EmitDefaultValue = false)]
		public BusinessOpeningHours business_opening_hours { get; set; }
		/// <summary>
		/// Optional. For private chats, the personal channel of the user
		/// </summary>
		[DataMember(Name = "personal_chat", EmitDefaultValue = false)]
		public Chat personal_chat { get; set; }
		/// <summary>
		/// Optional. List of available reactions allowed in the chat. If omitted, then all emoji reactions are allowed.
		/// </summary>
		[DataMember(Name = "available_reactions", EmitDefaultValue = false)]
		public Array<ReactionType> available_reactions { get; set; }
		/// <summary>
		/// Optional. Custom emoji identifier of the emoji chosen by the chat for the reply header and link preview background
		/// </summary>
		[DataMember(Name = "background_custom_emoji_id", EmitDefaultValue = false)]
		public string background_custom_emoji_id { get; set; }
		/// <summary>
		/// Optional. Identifier of the accent color for the chat's profile background. See profile accent colors for more details.
		/// </summary>
		[DataMember(Name = "profile_accent_color_id", EmitDefaultValue = false)]
		public int profile_accent_color_id { get; set; }
		/// <summary>
		/// Optional. Custom emoji identifier of the emoji chosen by the chat for its profile background
		/// </summary>
		[DataMember(Name = "profile_background_custom_emoji_id", EmitDefaultValue = false)]
		public string profile_background_custom_emoji_id { get; set; }
		/// <summary>
		/// Optional. Custom emoji identifier of the emoji status of the chat or the other party in a private chat
		/// </summary>
		[DataMember(Name = "emoji_status_custom_emoji_id", EmitDefaultValue = false)]
		public string emoji_status_custom_emoji_id { get; set; }
		/// <summary>
		/// Optional. Expiration date of the emoji status of the chat or the other party in a private chat, in Unix time, if any
		/// </summary>
		[DataMember(Name = "emoji_status_expiration_date", EmitDefaultValue = false)]
		public int emoji_status_expiration_date { get; set; }
		/// <summary>
		/// Optional. Bio of the other party in a private chat
		/// </summary>
		[DataMember(Name = "bio", EmitDefaultValue = false)]
		public string bio { get; set; }
		/// <summary>
		/// Optional. True, if privacy settings of the other party in the private chat allows to use tg://user?id=<user_id> links only in chats with the user
		/// </summary>
		[DataMember(Name = "has_private_forwards", EmitDefaultValue = false)]
		public bool has_private_forwards { get; set; }
		/// <summary>
		/// Optional. True, if the privacy settings of the other party restrict sending voice and video note messages in the private chat
		/// </summary>
		[DataMember(Name = "has_restricted_voice_and_video_messages", EmitDefaultValue = false)]
		public bool has_restricted_voice_and_video_messages { get; set; }
		/// <summary>
		/// Optional. True, if users need to join the supergroup before they can send messages
		/// </summary>
		[DataMember(Name = "join_to_send_messages", EmitDefaultValue = false)]
		public bool join_to_send_messages { get; set; }
		/// <summary>
		/// Optional. True, if all users directly joining the supergroup without using an invite link need to be approved by supergroup administrators
		/// </summary>
		[DataMember(Name = "join_by_request", EmitDefaultValue = false)]
		public bool join_by_request { get; set; }
		/// <summary>
		/// Optional. Description, for groups, supergroups and channel chats
		/// </summary>
		[DataMember(Name = "description", EmitDefaultValue = false)]
		public string description { get; set; }
		/// <summary>
		/// Optional. Primary invite link, for groups, supergroups and channel chats
		/// </summary>
		[DataMember(Name = "invite_link", EmitDefaultValue = false)]
		public string invite_link { get; set; }
		/// <summary>
		/// Optional. The most recent pinned message (by sending date)
		/// </summary>
		[DataMember(Name = "pinned_message", EmitDefaultValue = false)]
		public Message pinned_message { get; set; }
		/// <summary>
		/// Optional. Default chat member permissions, for groups and supergroups
		/// </summary>
		[DataMember(Name = "permissions", EmitDefaultValue = false)]
		public ChatPermissions permissions { get; set; }
		/// <summary>
		/// Optional. True, if paid media messages can be sent or forwarded to the channel chat. The field is available only for channel chats.
		/// </summary>
		[DataMember(Name = "can_send_paid_media", EmitDefaultValue = false)]
		public bool can_send_paid_media { get; set; }
		/// <summary>
		/// Optional. For supergroups, the minimum allowed delay between consecutive messages sent by each unprivileged user; in seconds
		/// </summary>
		[DataMember(Name = "slow_mode_delay", EmitDefaultValue = false)]
		public int slow_mode_delay { get; set; }
		/// <summary>
		/// Optional. For supergroups, the minimum number of boosts that a non-administrator user needs to add in order to ignore slow mode and chat permissions
		/// </summary>
		[DataMember(Name = "unrestrict_boost_count", EmitDefaultValue = false)]
		public int unrestrict_boost_count { get; set; }
		/// <summary>
		/// Optional. The time after which all messages sent to the chat will be automatically deleted; in seconds
		/// </summary>
		[DataMember(Name = "message_auto_delete_time", EmitDefaultValue = false)]
		public int message_auto_delete_time { get; set; }
		/// <summary>
		/// Optional. True, if aggressive anti-spam checks are enabled in the supergroup. The field is only available to chat administrators.
		/// </summary>
		[DataMember(Name = "has_aggressive_anti_spam_enabled", EmitDefaultValue = false)]
		public bool has_aggressive_anti_spam_enabled { get; set; }
		/// <summary>
		/// Optional. True, if non-administrators can only get the list of bots and administrators in the chat
		/// </summary>
		[DataMember(Name = "has_hidden_members", EmitDefaultValue = false)]
		public bool has_hidden_members { get; set; }
		/// <summary>
		/// Optional. True, if messages from the chat can't be forwarded to other chats
		/// </summary>
		[DataMember(Name = "has_protected_content", EmitDefaultValue = false)]
		public bool has_protected_content { get; set; }
		/// <summary>
		/// Optional. True, if new chat members will have access to old messages; available only to chat administrators
		/// </summary>
		[DataMember(Name = "has_visible_history", EmitDefaultValue = false)]
		public bool has_visible_history { get; set; }
		/// <summary>
		/// Optional. For supergroups, name of the group sticker set
		/// </summary>
		[DataMember(Name = "sticker_set_name", EmitDefaultValue = false)]
		public string sticker_set_name { get; set; }
		/// <summary>
		/// Optional. True, if the bot can change the group sticker set
		/// </summary>
		[DataMember(Name = "can_set_sticker_set", EmitDefaultValue = false)]
		public bool can_set_sticker_set { get; set; }
		/// <summary>
		/// Optional. For supergroups, the name of the group's custom emoji sticker set. Custom emoji from this set can be used by all users and bots in the group.
		/// </summary>
		[DataMember(Name = "custom_emoji_sticker_set_name", EmitDefaultValue = false)]
		public string custom_emoji_sticker_set_name { get; set; }
		/// <summary>
		/// Optional. Unique identifier for the linked chat, i.e. the discussion group identifier for a channel and vice versa; for supergroups and channel chats. This identifier may be greater than 32 bits and some programming languages may have difficulty/silent defects in interpreting it. But it is smaller than 52 bits, so a signed 64 bit integer or double-precision float type are safe for storing this identifier.
		/// </summary>
		[DataMember(Name = "linked_chat_id", EmitDefaultValue = false)]
		public int linked_chat_id { get; set; }
		/// <summary>
		/// Optional. For supergroups, the location to which the supergroup is connected
		/// </summary>
		[DataMember(Name = "location", EmitDefaultValue = false)]
		public ChatLocation location { get; set; }
	}
}
