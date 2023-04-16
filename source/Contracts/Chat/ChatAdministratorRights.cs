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
	/// Represents the rights of an administrator in a chat.
	/// </summary>
	[DataContract]
	public class ChatAdministratorRights
	{
		/// <summary>
		/// True, if the user's presence in the chat is hidden
		/// </summary>
		[DataMember(Name = "is_anonymous", IsRequired = true)]
		public bool is_anonymous { get; set; }
		/// <summary>
		/// True, if the administrator can access the chat event log, chat statistics, message statistics in channels, see channel members, see anonymous administrators in supergroups and ignore slow mode. Implied by any other administrator privilege
		/// </summary>
		[DataMember(Name = "can_manage_chat", IsRequired = true)]
		public bool can_manage_chat { get; set; }
		/// <summary>
		/// True, if the administrator can delete messages of other users
		/// </summary>
		[DataMember(Name = "can_delete_messages", IsRequired = true)]
		public bool can_delete_messages { get; set; }
		/// <summary>
		/// True, if the administrator can manage video chats
		/// </summary>
		[DataMember(Name = "can_manage_video_chats", IsRequired = true)]
		public bool can_manage_video_chats { get; set; }
		/// <summary>
		/// True, if the administrator can restrict, ban or unban chat members
		/// </summary>
		[DataMember(Name = "can_restrict_members", IsRequired = true)]
		public bool can_restrict_members { get; set; }
		/// <summary>
		/// True, if the administrator can add new administrators with a subset of their own privileges or demote administrators that he has promoted, directly or indirectly (promoted by administrators that were appointed by the user)
		/// </summary>
		[DataMember(Name = "can_promote_members", IsRequired = true)]
		public bool can_promote_members { get; set; }
		/// <summary>
		/// True, if the user is allowed to change the chat title, photo and other settings
		/// </summary>
		[DataMember(Name = "can_change_info", IsRequired = true)]
		public bool can_change_info { get; set; }
		/// <summary>
		/// True, if the user is allowed to invite new users to the chat
		/// </summary>
		[DataMember(Name = "can_invite_users", IsRequired = true)]
		public bool can_invite_users { get; set; }
		/// <summary>
		/// Optional. True, if the administrator can post in the channel; channels only
		/// </summary>
		[DataMember(Name = "can_post_messages", EmitDefaultValue = false)]
		public bool can_post_messages { get; set; }
		/// <summary>
		/// Optional. True, if the administrator can edit messages of other users and can pin messages; channels only
		/// </summary>
		[DataMember(Name = "can_edit_messages", EmitDefaultValue = false)]
		public bool can_edit_messages { get; set; }
		/// <summary>
		/// Optional. True, if the user is allowed to pin messages; groups and supergroups only
		/// </summary>
		[DataMember(Name = "can_pin_messages", EmitDefaultValue = false)]
		public bool can_pin_messages { get; set; }
		/// <summary>
		/// Optional. True, if the user is allowed to create, rename, close, and reopen forum topics; supergroups only
		/// </summary>
		[DataMember(Name = "can_manage_topics", EmitDefaultValue = false)]
		public bool can_manage_topics { get; set; }
	}
}
