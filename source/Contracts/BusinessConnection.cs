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
	/// Describes the connection of the bot with a business account.
	/// </summary>
	[DataContract]
	public class BusinessConnection
	{
		/// <summary>
		/// Unique identifier of the business connection
		/// </summary>
		[DataMember(Name = "id", IsRequired = true)]
		public string id { get; set; }
		/// <summary>
		/// Business account user that created the business connection
		/// </summary>
		[DataMember(Name = "user", IsRequired = true)]
		public User user { get; set; }
		/// <summary>
		/// Identifier of a private chat with the user who created the business connection. This number may have more than 32 significant bits and some programming languages may have difficulty/silent defects in interpreting it. But it has at most 52 significant bits, so a 64-bit integer or double-precision float type are safe for storing this identifier.
		/// </summary>
		[DataMember(Name = "user_chat_id", IsRequired = true)]
		public long user_chat_id { get; set; }
		/// <summary>
		/// Date the connection was established in Unix time
		/// </summary>
		[DataMember(Name = "date", IsRequired = true)]
		public long date { get; set; }
		/// <summary>
		/// True, if the bot can act on behalf of the business account in chats that were active in the last 24 hours
		/// </summary>
		[DataMember(Name = "can_reply", IsRequired = true)]
		public bool can_reply { get; set; }
		/// <summary>
		/// True, if the connection is active
		/// </summary>
		[DataMember(Name = "is_enabled", IsRequired = true)]
		public bool is_enabled { get; set; }
	}
}
