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
	/// This object represents a Telegram user or bot.
	/// </summary>
	[DataContract]
	public class User
	{
		/// <summary>
		/// Unique identifier for this user or bot
		/// </summary>
		[DataMember(Name = "id", IsRequired = true)]
		public long id { get; set; }
		/// <summary>
		/// True, if this user is a bot
		/// </summary>
		[DataMember(Name = "is_bot", IsRequired = true)]
		public bool is_bot { get; set; }
		/// <summary>
		/// User‘s or bot’s first name
		/// </summary>
		[DataMember(Name = "first_name", IsRequired = true)]
		public string first_name { get; set; }
		/// <summary>
		/// Optional. User‘s or bot’s last name
		/// </summary>
		[DataMember(Name = "last_name", EmitDefaultValue = false)]
		public string last_name { get; set; }
		/// <summary>
		/// Optional. User‘s or bot’s username
		/// </summary>
		[DataMember(Name = "username", EmitDefaultValue = false)]
		public string username { get; set; }
		/// <summary>
		/// Optional. IETF language tag of the user's language
		/// </summary>
		[DataMember(Name = "language_code", EmitDefaultValue = false)]
		public string language_code { get; set; }
		/// <summary>
		/// Optional. True, if the bot can be invited to groups. Returned only in getMe.
		/// </summary>
		[DataMember(Name = "can_join_groups", EmitDefaultValue = false)]
		public bool can_join_groups { get; set; }
		/// <summary>
		/// Optional. True, if privacy mode is disabled for the bot. Returned only in getMe.
		/// </summary>
		[DataMember(Name = "can_read_all_group_messages", EmitDefaultValue = false)]
		public bool can_read_all_group_messages { get; set; }
		/// <summary>
		/// Optional. True, if the bot supports inline queries. Returned only in getMe.
		/// </summary>
		[DataMember(Name = "supports_inline_queries", EmitDefaultValue = false)]
		public bool supports_inline_queries { get; set; }
	}
}
