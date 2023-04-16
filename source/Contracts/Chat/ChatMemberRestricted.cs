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
	/// Represents a chat member that is under certain restrictions in the chat. Supergroups only.
	/// </summary>
	[DataContract]
	public class ChatMemberRestricted : ChatMember
	{
		/// <summary>
		/// True, if the user is a member of the chat at the moment of the request
		/// </summary>
		[DataMember(Name = "is_member", IsRequired = true)]
		public bool is_member { get; set; }
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
		/// True, if the user is allowed to pin messages
		/// </summary>
		[DataMember(Name = "can_pin_messages", IsRequired = true)]
		public bool can_pin_messages { get; set; }
		/// <summary>
		/// True, if the user is allowed to create forum topics
		/// </summary>
		[DataMember(Name = "can_manage_topics", IsRequired = true)]
		public bool can_manage_topics { get; set; }
		/// <summary>
		/// True, if the user is allowed to send text messages, contacts, locations and venues
		/// </summary>
		[DataMember(Name = "can_send_messages", IsRequired = true)]
		public bool can_send_messages { get; set; }
		/// <summary>
		/// True, if the user is allowed to send audios, documents, photos, videos, video notes and voice notes
		/// </summary>
		[DataMember(Name = "can_send_media_messages", IsRequired = true)]
		public bool can_send_media_messages { get; set; }
		/// <summary>
		/// True, if the user is allowed to send polls
		/// </summary>
		[DataMember(Name = "can_send_polls", IsRequired = true)]
		public bool can_send_polls { get; set; }
		/// <summary>
		/// True, if the user is allowed to send animations, games, stickers and use inline bots
		/// </summary>
		[DataMember(Name = "can_send_other_messages", IsRequired = true)]
		public bool can_send_other_messages { get; set; }
		/// <summary>
		/// True, if the user is allowed to add web page previews to their messages
		/// </summary>
		[DataMember(Name = "can_add_web_page_previews", IsRequired = true)]
		public bool can_add_web_page_previews { get; set; }
		/// <summary>
		/// Date when restrictions will be lifted for this user; unix time. If 0, then the user is restricted forever
		/// </summary>
		[DataMember(Name = "until_date", IsRequired = true)]
		public long until_date { get; set; }
	}
}
