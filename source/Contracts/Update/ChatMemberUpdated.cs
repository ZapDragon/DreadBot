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
	/// This object represents changes in the status of a chat member.
	/// </summary>
	[DataContract]
	public class ChatMemberUpdated : ChatMember
	{
		/// <summary>
		/// Chat the user belongs to
		/// </summary>
		[DataMember(Name = "chat", IsRequired = true)]
		public Chat chat { get; set; }
		/// <summary>
		/// Performer of the action, which resulted in the change
		/// </summary>
		[DataMember(Name = "from", IsRequired = true)]
		public User from { get; set; }
		/// <summary>
		/// Date the change was done in Unix time
		/// </summary>
		[DataMember(Name = "date", IsRequired = true)]
		public long date { get; set; }
		/// <summary>
		/// Previous information about the chat member
		/// </summary>
		[DataMember(Name = "old_chat_member", IsRequired = true)]
		public ChatMember old_chat_member { get; set; }
		/// <summary>
		/// New information about the chat member
		/// </summary>
		[DataMember(Name = "new_chat_member", IsRequired = true)]
		public ChatMember new_chat_member { get; set; }
		/// <summary>
		/// Optional. Chat invite link, which was used by the user to join the chat; for joining by invite link events only.
		/// </summary>
		[DataMember(Name = "invite_link", EmitDefaultValue = false)]
		public ChatInviteLink invite_link { get; set; }
		/// <summary>
		/// Optional. True, if the user joined the chat after sending a direct join request without using an invite link and being approved by an administrator
		/// </summary>
		[DataMember(Name = "via_join_request", EmitDefaultValue = false)]
		public bool via_join_request { get; set; }
		/// <summary>
		/// Optional. True, if the user joined the chat via a chat folder invite link
		/// </summary>
		[DataMember(Name = "via_chat_folder_invite_link", EmitDefaultValue = false)]
		public bool via_chat_folder_invite_link { get; set; }
	}
}
