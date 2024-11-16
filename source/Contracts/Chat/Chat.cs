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
	}
}
