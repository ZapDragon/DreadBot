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
	/// Represents a link to a file. By default, this file will be sent by the user with an optional caption. Alternatively, you can use input_message_content to send a message with the specified content instead of the file. Currently, only .PDF and .ZIP files can be sent using this method.
	/// </summary>
	[DataContract]
	public class InlineQueryResultDocument : InlineQueryResult
	{
		/// <summary>
		/// Title for the result
		/// </summary>
		[DataMember(Name = "title", IsRequired = true)]
		public string title { get; set; }
		/// <summary>
		/// Optional. Caption of the document to be sent, 0-1024 characters after entities parsing
		/// </summary>
		[DataMember(Name = "caption", EmitDefaultValue = false)]
		public string caption { get; set; }
		/// <summary>
		/// Optional. Mode for parsing entities in the document caption. See formatting options for more details.
		/// </summary>
		[DataMember(Name = "parse_mode", EmitDefaultValue = false)]
		public string parse_mode { get; set; }
		/// <summary>
		/// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
		/// </summary>
		[DataMember(Name = "caption_entities", EmitDefaultValue = false)]
		public Array<MessageEntity> caption_entities { get; set; }
		/// <summary>
		/// A valid URL for the file
		/// </summary>
		[DataMember(Name = "document_url", IsRequired = true)]
		public string document_url { get; set; }
		/// <summary>
		/// MIME type of the content of the file, either “application/pdf” or “application/zip”
		/// </summary>
		[DataMember(Name = "mime_type", IsRequired = true)]
		public string mime_type { get; set; }
		/// <summary>
		/// Optional. Short description of the result
		/// </summary>
		[DataMember(Name = "description", EmitDefaultValue = false)]
		public string description { get; set; }
		/// <summary>
		/// Optional. Content of the message to be sent instead of the file
		/// </summary>
		[DataMember(Name = "input_message_content", EmitDefaultValue = false)]
		public InputMessageContent input_message_content { get; set; }
		/// <summary>
		/// Optional. URL of the thumbnail (JPEG only) for the file
		/// </summary>
		[DataMember(Name = "thumb_url", EmitDefaultValue = false)]
		public string thumb_url { get; set; }
		/// <summary>
		/// Optional. Thumbnail width
		/// </summary>
		[DataMember(Name = "thumb_width", EmitDefaultValue = false)]
		public int thumb_width { get; set; }
		/// <summary>
		/// Optional. Thumbnail height
		/// </summary>
		[DataMember(Name = "thumb_height", EmitDefaultValue = false)]
		public int thumb_height { get; set; }
	}
}
