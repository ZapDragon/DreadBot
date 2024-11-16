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
	/// Describes reply parameters for the message that is being sent.
	/// </summary>
	[DataContract]
	public class ReplyParameters
	{
		/// <summary>
		/// Identifier of the message that will be replied to in the current chat, or in the chat chat_id if it is specified
		/// </summary>
		[DataMember(Name = "message_id", IsRequired = true)]
		public long message_id { get; set; }
		/// <summary>
		/// Optional. If the message to be replied to is from a different chat, unique identifier for the chat or username of the channel (in the format @channelusername). Not supported for messages sent on behalf of a business account.
		/// </summary>
		[DataMember(Name = "chat_id", EmitDefaultValue = false)]
		public object chat_id { get; set; }
		/// <summary>
		/// Optional. Pass True if the message should be sent even if the specified message to be replied to is not found. Always False for replies in another chat or forum topic. Always True for messages sent on behalf of a business account.
		/// </summary>
		[DataMember(Name = "allow_sending_without_reply", EmitDefaultValue = false)]
		public bool allow_sending_without_reply { get; set; }
		/// <summary>
		/// Optional. Quoted part of the message to be replied to; 0-1024 characters after entities parsing. The quote must be an exact substring of the message to be replied to, including bold, italic, underline, strikethrough, spoiler, and custom_emoji entities. The message will fail to send if the quote isn't found in the original message.
		/// </summary>
		[DataMember(Name = "quote", EmitDefaultValue = false)]
		public string quote { get; set; }
		/// <summary>
		/// Optional. Mode for parsing entities in the quote. See formatting options for more details.
		/// </summary>
		[DataMember(Name = "quote_parse_mode", EmitDefaultValue = false)]
		public string quote_parse_mode { get; set; }
		/// <summary>
		/// Optional. A JSON-serialized list of special entities that appear in the quote. It can be specified instead of quote_parse_mode.
		/// </summary>
		[DataMember(Name = "quote_entities", EmitDefaultValue = false)]
		public Array<MessageEntity> quote_entities { get; set; }
		/// <summary>
		/// Optional. Position of the quote in the original message in UTF-16 code units
		/// </summary>
		[DataMember(Name = "quote_position", EmitDefaultValue = false)]
		public int quote_position { get; set; }
	}
}
