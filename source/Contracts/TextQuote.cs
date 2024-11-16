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
	/// This object contains information about the quoted part of a message that is replied to by the given message.
	/// </summary>
	[DataContract]
	public class TextQuote
	{
		/// <summary>
		/// Text of the quoted part of a message that is replied to by the given message
		/// </summary>
		[DataMember(Name = "text", IsRequired = true)]
		public string text { get; set; }
		/// <summary>
		/// Optional. Special entities that appear in the quote. Currently, only bold, italic, underline, strikethrough, spoiler, and custom_emoji entities are kept in quotes.
		/// </summary>
		[DataMember(Name = "entities", EmitDefaultValue = false)]
		public Array<MessageEntity> entities { get; set; }
		/// <summary>
		/// Approximate quote position in the original message in UTF-16 code units as specified by the sender
		/// </summary>
		[DataMember(Name = "position", IsRequired = true)]
		public int position { get; set; }
		/// <summary>
		/// Optional. True, if the quote was chosen manually by the message sender. Otherwise, the quote was added automatically by the server.
		/// </summary>
		[DataMember(Name = "is_manual", EmitDefaultValue = false)]
		public bool is_manual { get; set; }
	}
}
