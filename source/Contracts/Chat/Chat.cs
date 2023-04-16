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
	/// This object represents a chat.
	/// </summary>
	[DataContract]
	public class Chat
	{
		/// <summary>
		/// Unique identifier for this chat. This number may have more than 32 significant bits and some programming languages may have difficulty/silent defects in interpreting it. But it has at most 52 significant bits, so a signed 64-bit integer or double-precision float type are safe for storing this identifier.
		/// </summary>
		[DataMember(Name = "id", IsRequired = true)]
		public long id { get; set; }
		/// <summary>
		/// Type of chat, can be either “private”, “group”, “supergroup” or “channel”
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
		/// Optional. Chat photo. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "photo", EmitDefaultValue = false)]
		public ChatPhoto photo { get; set; }
		/// <summary>
		/// Optional. If non-empty, the list of all active chat usernames; for private chats, supergroups and channels. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "active_usernames", EmitDefaultValue = false)]
		public Array<string> active_usernames { get; set; }
		/// <summary>
		/// Optional. Custom emoji identifier of emoji status of the other party in a private chat. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "emoji_status_custom_emoji_id", EmitDefaultValue = false)]
		public string emoji_status_custom_emoji_id { get; set; }
		/// <summary>
		/// Optional. Bio of the other party in a private chat. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "bio", EmitDefaultValue = false)]
		public string bio { get; set; }
		/// <summary>
		/// Optional. True, if privacy settings of the other party in the private chat allows to use tg://user?id=<user_id> links only in chats with the user. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "has_private_forwards", EmitDefaultValue = false)]
		public bool has_private_forwards { get; set; }
		/// <summary>
		/// Optional. True, if the privacy settings of the other party restrict sending voice and video note messages in the private chat. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "has_restricted_voice_and_video_messages", EmitDefaultValue = false)]
		public bool has_restricted_voice_and_video_messages { get; set; }
		/// <summary>
		/// Optional. True, if users need to join the supergroup before they can send messages. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "join_to_send_messages", EmitDefaultValue = false)]
		public bool join_to_send_messages { get; set; }
		/// <summary>
		/// Optional. True, if all users directly joining the supergroup need to be approved by supergroup administrators. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "join_by_request", EmitDefaultValue = false)]
		public bool join_by_request { get; set; }
		/// <summary>
		/// Optional. Description, for groups, supergroups and channel chats. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "description", EmitDefaultValue = false)]
		public string description { get; set; }
		/// <summary>
		/// Optional. Primary invite link, for groups, supergroups and channel chats. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "invite_link", EmitDefaultValue = false)]
		public string invite_link { get; set; }
		/// <summary>
		/// Optional. The most recent pinned message (by sending date). Returned only in getChat.
		/// </summary>
		[DataMember(Name = "pinned_message", EmitDefaultValue = false)]
		public Message pinned_message { get; set; }
		/// <summary>
		/// Optional. Default chat member permissions, for groups and supergroups. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "permissions", EmitDefaultValue = false)]
		public ChatPermissions permissions { get; set; }
		/// <summary>
		/// Optional. For supergroups, the minimum allowed delay between consecutive messages sent by each unpriviledged user; in seconds. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "slow_mode_delay", EmitDefaultValue = false)]
		public int slow_mode_delay { get; set; }
		/// <summary>
		/// Optional. The time after which all messages sent to the chat will be automatically deleted; in seconds. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "message_auto_delete_time", EmitDefaultValue = false)]
		public int message_auto_delete_time { get; set; }
		/// <summary>
		/// Optional. True, if messages from the chat can't be forwarded to other chats. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "has_protected_content", EmitDefaultValue = false)]
		public bool has_protected_content { get; set; }
		/// <summary>
		/// Optional. For supergroups, name of group sticker set. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "sticker_set_name", EmitDefaultValue = false)]
		public string sticker_set_name { get; set; }
		/// <summary>
		/// Optional. True, if the bot can change the group sticker set. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "can_set_sticker_set", EmitDefaultValue = false)]
		public bool can_set_sticker_set { get; set; }
		/// <summary>
		/// Optional. Unique identifier for the linked chat, i.e. the discussion group identifier for a channel and vice versa; for supergroups and channel chats. This identifier may be greater than 32 bits and some programming languages may have difficulty/silent defects in interpreting it. But it is smaller than 52 bits, so a signed 64 bit integer or double-precision float type are safe for storing this identifier. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "linked_chat_id", EmitDefaultValue = false)]
		public int linked_chat_id { get; set; }
		/// <summary>
		/// Optional. For supergroups, the location to which the supergroup is connected. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "location", EmitDefaultValue = false)]
		public ChatLocation location { get; set; }
	}
}
