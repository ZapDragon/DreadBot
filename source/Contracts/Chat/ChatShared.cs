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
	/// This object contains information about a chat that was shared with the bot using a KeyboardButtonRequestChat button.
	/// </summary>
	[DataContract]
	public class ChatShared
	{
		/// <summary>
		/// Identifier of the request
		/// </summary>
		[DataMember(Name = "request_id", IsRequired = true)]
		public int request_id { get; set; }
		/// <summary>
		/// Identifier of the shared chat. This number may have more than 32 significant bits and some programming languages may have difficulty/silent defects in interpreting it. But it has at most 52 significant bits, so a 64-bit integer or double-precision float type are safe for storing this identifier. The bot may not have access to the chat and could be unable to use this identifier, unless the chat is already known to the bot by some other means.
		/// </summary>
		[DataMember(Name = "chat_id", IsRequired = true)]
		public int chat_id { get; set; }
		/// <summary>
		/// Optional. Title of the chat, if the title was requested by the bot.
		/// </summary>
		[DataMember(Name = "title", EmitDefaultValue = false)]
		public string title { get; set; }
		/// <summary>
		/// Optional. Username of the chat, if the username was requested by the bot and available.
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
