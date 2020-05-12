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
	/// This object represents one special entity in a text message. For example, hashtags, usernames, URLs, etc.
	/// </summary>
	[DataContract]
	public class MessageEntity
	{
		/// <summary>
		/// Type of the entity. Can be “mention” (@username), “hashtag” (#hashtag), “cashtag” ($USD), “bot_command” (/start@jobs_bot), “url” (https://telegram.org), “email” (do-not-reply@telegram.org), “phone_number” (+1-212-555-0123), “bold” (bold text), “italic” (italic text), “underline” (underlined text), “strikethrough” (strikethrough text), “code” (monowidth string), “pre” (monowidth block), “text_link” (for clickable text URLs), “text_mention” (for users without usernames)
		/// </summary>
		[DataMember(Name = "type", IsRequired = true)]
		public string type { get; set; }
		/// <summary>
		/// Offset in UTF-16 code units to the start of the entity
		/// </summary>
		[DataMember(Name = "offset", IsRequired = true)]
		public int offset { get; set; }
		/// <summary>
		/// Length of the entity in UTF-16 code units
		/// </summary>
		[DataMember(Name = "length", IsRequired = true)]
		public int length { get; set; }
		/// <summary>
		/// Optional. For “text_link” only, url that will be opened after user taps on the text
		/// </summary>
		[DataMember(Name = "url", EmitDefaultValue = false)]
		public string url { get; set; }
		/// <summary>
		/// Optional. For “text_mention” only, the mentioned user
		/// </summary>
		[DataMember(Name = "user", EmitDefaultValue = false)]
		public User user { get; set; }
		/// <summary>
		/// Optional. For “pre” only, the programming language of the entity text
		/// </summary>
		[DataMember(Name = "language", EmitDefaultValue = false)]
		public string language { get; set; }
	}
}
