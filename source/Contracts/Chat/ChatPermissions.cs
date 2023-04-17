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
	/// Describes actions that a non-administrator user is allowed to take in a chat.
	/// </summary>
	[DataContract]
	public class ChatPermissions
	{
		/// <summary>
		/// Optional. True, if the user is allowed to send text messages, contacts, invoices, locations and venues
		/// </summary>
		[DataMember(Name = "can_send_messages", EmitDefaultValue = false)]
		public bool can_send_messages { get; set; }
		/// <summary>
		/// Optional. True, if the user is allowed to send audios
		/// </summary>
		[DataMember(Name = "can_send_audios", EmitDefaultValue = false)]
		public bool can_send_audios { get; set; }
		/// <summary>
		/// Optional. True, if the user is allowed to send documents
		/// </summary>
		[DataMember(Name = "can_send_documents", EmitDefaultValue = false)]
		public bool can_send_documents { get; set; }
		/// <summary>
		/// Optional. True, if the user is allowed to send photos
		/// </summary>
		[DataMember(Name = "can_send_photos", EmitDefaultValue = false)]
		public bool can_send_photos { get; set; }
		/// <summary>
		/// Optional. True, if the user is allowed to send videos
		/// </summary>
		[DataMember(Name = "can_send_videos", EmitDefaultValue = false)]
		public bool can_send_videos { get; set; }
		/// <summary>
		/// Optional. True, if the user is allowed to send video notes
		/// </summary>
		[DataMember(Name = "can_send_video_notes", EmitDefaultValue = false)]
		public bool can_send_video_notes { get; set; }
		/// <summary>
		/// Optional. True, if the user is allowed to send voice notes
		/// </summary>
		[DataMember(Name = "can_send_voice_notes", EmitDefaultValue = false)]
		public bool can_send_voice_notes { get; set; }
		/// <summary>
		/// Optional. True, if the user is allowed to send polls
		/// </summary>
		[DataMember(Name = "can_send_polls", EmitDefaultValue = false)]
		public bool can_send_polls { get; set; }
		/// <summary>
		/// Optional. True, if the user is allowed to send animations, games, stickers and use inline bots
		/// </summary>
		[DataMember(Name = "can_send_other_messages", EmitDefaultValue = false)]
		public bool can_send_other_messages { get; set; }
		/// <summary>
		/// Optional. True, if the user is allowed to add web page previews to their messages
		/// </summary>
		[DataMember(Name = "can_add_web_page_previews", EmitDefaultValue = false)]
		public bool can_add_web_page_previews { get; set; }
		/// <summary>
		/// Optional. True, if the user is allowed to change the chat title, photo and other settings. Ignored in public supergroups
		/// </summary>
		[DataMember(Name = "can_change_info", EmitDefaultValue = false)]
		public bool can_change_info { get; set; }
		/// <summary>
		/// Optional. True, if the user is allowed to invite new users to the chat
		/// </summary>
		[DataMember(Name = "can_invite_users", EmitDefaultValue = false)]
		public bool can_invite_users { get; set; }
		/// <summary>
		/// Optional. True, if the user is allowed to pin messages. Ignored in public supergroups
		/// </summary>
		[DataMember(Name = "can_pin_messages", EmitDefaultValue = false)]
		public bool can_pin_messages { get; set; }
		/// <summary>
		/// Optional. True, if the user is allowed to create forum topics. If omitted defaults to the value of can_pin_messages
		/// </summary>
		[DataMember(Name = "can_manage_topics", EmitDefaultValue = false)]
		public bool can_manage_topics { get; set; }
	}
}
