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
	/// Represents the content of a text message to be sent as the result of an inline query.
	/// </summary>
	[DataContract]
	public class InputTextMessageContent
	{
		/// <summary>
		/// Text of the message to be sent, 1-4096 characters
		/// </summary>
		[DataMember(Name = "message_text", IsRequired = true)]
		public string message_text { get; set; }
		/// <summary>
		/// Optional. Mode for parsing entities in the message text. See formatting options for more details.
		/// </summary>
		[DataMember(Name = "parse_mode", EmitDefaultValue = false)]
		public string parse_mode { get; set; }
		/// <summary>
		/// Optional. List of special entities that appear in message text, which can be specified instead of parse_mode
		/// </summary>
		[DataMember(Name = "entities", EmitDefaultValue = false)]
		public Array<MessageEntity> entities { get; set; }
		/// <summary>
		/// Optional. Disables link previews for links in the sent message
		/// </summary>
		[DataMember(Name = "disable_web_page_preview", EmitDefaultValue = false)]
		public bool disable_web_page_preview { get; set; }
	}
}
