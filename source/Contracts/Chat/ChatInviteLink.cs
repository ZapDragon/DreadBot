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
	/// Represents an invite link for a chat.
	/// </summary>
	[DataContract]
	public class ChatInviteLink
	{
		/// <summary>
		/// The invite link. If the link was created by another chat administrator, then the second part of the link will be replaced with “…”.
		/// </summary>
		[DataMember(Name = "invite_link", IsRequired = true)]
		public string invite_link { get; set; }
		/// <summary>
		/// Creator of the link
		/// </summary>
		[DataMember(Name = "creator", IsRequired = true)]
		public User creator { get; set; }
		/// <summary>
		/// True, if users joining the chat via the link need to be approved by chat administrators
		/// </summary>
		[DataMember(Name = "creates_join_request", IsRequired = true)]
		public bool creates_join_request { get; set; }
		/// <summary>
		/// True, if the link is primary
		/// </summary>
		[DataMember(Name = "is_primary", IsRequired = true)]
		public bool is_primary { get; set; }
		/// <summary>
		/// True, if the link is revoked
		/// </summary>
		[DataMember(Name = "is_revoked", IsRequired = true)]
		public bool is_revoked { get; set; }
		/// <summary>
		/// Optional. Invite link name
		/// </summary>
		[DataMember(Name = "name", EmitDefaultValue = false)]
		public string name { get; set; }
		/// <summary>
		/// Optional. Point in time (Unix timestamp) when the link will expire or has been expired
		/// </summary>
		[DataMember(Name = "expire_date", EmitDefaultValue = false)]
		public int expire_date { get; set; }
		/// <summary>
		/// Optional. The maximum number of users that can be members of the chat simultaneously after joining the chat via this invite link; 1-99999
		/// </summary>
		[DataMember(Name = "member_limit", EmitDefaultValue = false)]
		public int member_limit { get; set; }
		/// <summary>
		/// Optional. Number of pending join requests created using this link
		/// </summary>
		[DataMember(Name = "pending_join_request_count", EmitDefaultValue = false)]
		public int pending_join_request_count { get; set; }
	}
}
