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
	/// This object contains information about a user that was shared with the bot using a KeyboardButtonRequestUsers button.
	/// </summary>
	[DataContract]
	public class SharedUser
	{
		/// <summary>
		/// Identifier of the shared user. This number may have more than 32 significant bits and some programming languages may have difficulty/silent defects in interpreting it. But it has at most 52 significant bits, so 64-bit integers or double-precision float types are safe for storing these identifiers. The bot may not have access to the user and could be unable to use this identifier, unless the user is already known to the bot by some other means.
		/// </summary>
		[DataMember(Name = "user_id", IsRequired = true)]
		public long user_id { get; set; }
		/// <summary>
		/// Optional. First name of the user, if the name was requested by the bot
		/// </summary>
		[DataMember(Name = "first_name", EmitDefaultValue = false)]
		public string first_name { get; set; }
		/// <summary>
		/// Optional. Last name of the user, if the name was requested by the bot
		/// </summary>
		[DataMember(Name = "last_name", EmitDefaultValue = false)]
		public string last_name { get; set; }
		/// <summary>
		/// Optional. Username of the user, if the username was requested by the bot
		/// </summary>
		[DataMember(Name = "username", EmitDefaultValue = false)]
		public string username { get; set; }
		/// <summary>
		/// Optional. Available sizes of the chat photo, if the photo was requested by the bot
		/// </summary>
		[DataMember(Name = "photo", EmitDefaultValue = false)]
		public Array<PhotoSize> photo { get; set; }
	}
}
