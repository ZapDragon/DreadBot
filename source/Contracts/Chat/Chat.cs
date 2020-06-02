#region License 
//MIT License
//Copyright(c) [2020]
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
		/// Unique identifier for this chat. This number may be greater than 32 bits and some programming languages may have difficulty/silent defects in interpreting it. But it is smaller than 52 bits, so a signed 64 bit integer or double-precision float type are safe for storing this identifier.
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
		/// Optional. Chat photo. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "photo", EmitDefaultValue = false)]
		public ChatPhoto photo { get; set; }
		/// <summary>
		/// Optional. Description, for groups, supergroups and channel chats. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "description", EmitDefaultValue = false)]
		public string description { get; set; }
		/// <summary>
		/// Optional. Chat invite link, for groups, supergroups and channel chats. Each administrator in a chat generates their own invite links, so the bot must first generate the link using exportChatInviteLink. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "invite_link", EmitDefaultValue = false)]
		public string invite_link { get; set; }
		/// <summary>
		/// Optional. Pinned message, for groups, supergroups and channels. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "pinned_message", EmitDefaultValue = false)]
		public Message pinned_message { get; set; }
		/// <summary>
		/// Optional. Default chat member permissions, for groups and supergroups. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "permissions", EmitDefaultValue = false)]
		public ChatPermissions permissions { get; set; }
		/// <summary>
		/// Optional. For supergroups, the minimum allowed delay between consecutive messages sent by each unprivileged user. Returned only in getChat.
		/// </summary>
		[DataMember(Name = "slow_mode_delay", EmitDefaultValue = false)]
		public int slow_mode_delay { get; set; }
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
	}
}
