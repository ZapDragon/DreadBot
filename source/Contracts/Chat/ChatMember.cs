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
	/// This object contains information about one member of a chat.
	/// </summary>
	[DataContract]
	public class ChatMember
	{
		/// <summary>
		/// Information about the user
		/// </summary>
		[DataMember(Name = "user", IsRequired = true)]
		public User user { get; set; }
		/// <summary>
		/// The member's status in the chat. Can be “creator”, “administrator”, “member”, “restricted”, “left” or “kicked”
		/// </summary>
		[DataMember(Name = "status", IsRequired = true)]
		public string status { get; set; }
		/// <summary>
		/// Optional. Owner and administrators only. Custom title for this user
		/// </summary>
		[DataMember(Name = "custom_title", EmitDefaultValue = false)]
		public string custom_title { get; set; }
		/// <summary>
		/// Optional. Owner and administrators only. True, if the user's presence in the chat is hidden
		/// </summary>
		[DataMember(Name = "is_anonymous", EmitDefaultValue = false)]
		public bool is_anonymous { get; set; }
		/// <summary>
		/// Optional. Administrators only. True, if the bot is allowed to edit administrator privileges of that user
		/// </summary>
		[DataMember(Name = "can_be_edited", EmitDefaultValue = false)]
		public bool can_be_edited { get; set; }
		/// <summary>
		/// Optional. Administrators only. True, if the administrator can post in the channel; channels only
		/// </summary>
		[DataMember(Name = "can_post_messages", EmitDefaultValue = false)]
		public bool can_post_messages { get; set; }
		/// <summary>
		/// Optional. Administrators only. True, if the administrator can edit messages of other users and can pin messages; channels only
		/// </summary>
		[DataMember(Name = "can_edit_messages", EmitDefaultValue = false)]
		public bool can_edit_messages { get; set; }
		/// <summary>
		/// Optional. Administrators only. True, if the administrator can delete messages of other users
		/// </summary>
		[DataMember(Name = "can_delete_messages", EmitDefaultValue = false)]
		public bool can_delete_messages { get; set; }
		/// <summary>
		/// Optional. Administrators only. True, if the administrator can restrict, ban or unban chat members
		/// </summary>
		[DataMember(Name = "can_restrict_members", EmitDefaultValue = false)]
		public bool can_restrict_members { get; set; }
		/// <summary>
		/// Optional. Administrators only. True, if the administrator can add new administrators with a subset of their own privileges or demote administrators that he has promoted, directly or indirectly (promoted by administrators that were appointed by the user)
		/// </summary>
		[DataMember(Name = "can_promote_members", EmitDefaultValue = false)]
		public bool can_promote_members { get; set; }
		/// <summary>
		/// Optional. Administrators and restricted only. True, if the user is allowed to change the chat title, photo and other settings
		/// </summary>
		[DataMember(Name = "can_change_info", EmitDefaultValue = false)]
		public bool can_change_info { get; set; }
		/// <summary>
		/// Optional. Administrators and restricted only. True, if the user is allowed to invite new users to the chat
		/// </summary>
		[DataMember(Name = "can_invite_users", EmitDefaultValue = false)]
		public bool can_invite_users { get; set; }
		/// <summary>
		/// Optional. Administrators and restricted only. True, if the user is allowed to pin messages; groups and supergroups only
		/// </summary>
		[DataMember(Name = "can_pin_messages", EmitDefaultValue = false)]
		public bool can_pin_messages { get; set; }
		/// <summary>
		/// Optional. Restricted only. True, if the user is a member of the chat at the moment of the request
		/// </summary>
		[DataMember(Name = "is_member", EmitDefaultValue = false)]
		public bool is_member { get; set; }
		/// <summary>
		/// Optional. Restricted only. True, if the user is allowed to send text messages, contacts, locations and venues
		/// </summary>
		[DataMember(Name = "can_send_messages", EmitDefaultValue = false)]
		public bool can_send_messages { get; set; }
		/// <summary>
		/// Optional. Restricted only. True, if the user is allowed to send audios, documents, photos, videos, video notes and voice notes
		/// </summary>
		[DataMember(Name = "can_send_media_messages", EmitDefaultValue = false)]
		public bool can_send_media_messages { get; set; }
		/// <summary>
		/// Optional. Restricted only. True, if the user is allowed to send polls
		/// </summary>
		[DataMember(Name = "can_send_polls", EmitDefaultValue = false)]
		public bool can_send_polls { get; set; }
		/// <summary>
		/// Optional. Restricted only. True, if the user is allowed to send animations, games, stickers and use inline bots
		/// </summary>
		[DataMember(Name = "can_send_other_messages", EmitDefaultValue = false)]
		public bool can_send_other_messages { get; set; }
		/// <summary>
		/// Optional. Restricted only. True, if the user is allowed to add web page previews to their messages
		/// </summary>
		[DataMember(Name = "can_add_web_page_previews", EmitDefaultValue = false)]
		public bool can_add_web_page_previews { get; set; }
		/// <summary>
		/// Optional. Restricted and kicked only. Date when restrictions will be lifted for this user; unix time
		/// </summary>
		[DataMember(Name = "until_date", EmitDefaultValue = false)]
		public long until_date { get; set; }
	}
}
