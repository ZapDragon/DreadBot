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
	/// Represents a link to an animated GIF file. By default, this animated GIF file will be sent by the user with optional caption. Alternatively, you can use input_message_content to send a message with the specified content instead of the animation.
	/// </summary>
	[DataContract]
	public class InlineQueryResultGif : InlineQueryResult
	{
		/// <summary>
		/// A valid URL for the GIF file. File size must not exceed 1MB
		/// </summary>
		[DataMember(Name = "gif_url", IsRequired = true)]
		public string gif_url { get; set; }
		/// <summary>
		/// Optional. Width of the GIF
		/// </summary>
		[DataMember(Name = "gif_width", EmitDefaultValue = false)]
		public int gif_width { get; set; }
		/// <summary>
		/// Optional. Height of the GIF
		/// </summary>
		[DataMember(Name = "gif_height", EmitDefaultValue = false)]
		public int gif_height { get; set; }
		/// <summary>
		/// Optional. Duration of the GIF in seconds
		/// </summary>
		[DataMember(Name = "gif_duration", EmitDefaultValue = false)]
		public int gif_duration { get; set; }
		/// <summary>
		/// URL of the static (JPEG or GIF) or animated (MPEG4) thumbnail for the result
		/// </summary>
		[DataMember(Name = "thumbnail_url", IsRequired = true)]
		public string thumbnail_url { get; set; }
		/// <summary>
		/// Optional. MIME type of the thumbnail, must be one of “image/jpeg”, “image/gif”, or “video/mp4”. Defaults to “image/jpeg”
		/// </summary>
		[DataMember(Name = "thumbnail_mime_type", EmitDefaultValue = false)]
		public string thumbnail_mime_type { get; set; }
		/// <summary>
		/// Optional. Title for the result
		/// </summary>
		[DataMember(Name = "title", EmitDefaultValue = false)]
		public string title { get; set; }
		/// <summary>
		/// Optional. Caption of the GIF file to be sent, 0-1024 characters after entities parsing
		/// </summary>
		[DataMember(Name = "caption", EmitDefaultValue = false)]
		public string caption { get; set; }
		/// <summary>
		/// Optional. Mode for parsing entities in the caption. See formatting options for more details.
		/// </summary>
		[DataMember(Name = "parse_mode", EmitDefaultValue = false)]
		public string parse_mode { get; set; }
		/// <summary>
		/// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
		/// </summary>
		[DataMember(Name = "caption_entities", EmitDefaultValue = false)]
		public Array<MessageEntity> caption_entities { get; set; }
		/// <summary>
		/// Optional. Content of the message to be sent instead of the GIF animation
		/// </summary>
		[DataMember(Name = "input_message_content", EmitDefaultValue = false)]
		public InputMessageContent input_message_content { get; set; }
	}
}
