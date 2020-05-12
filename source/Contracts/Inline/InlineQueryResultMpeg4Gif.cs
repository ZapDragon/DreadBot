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
	/// Represents a link to a video animation (H.264/MPEG-4 AVC video without sound). By default, this animated MPEG-4 file will be sent by the user with optional caption. Alternatively, you can use input_message_content to send a message with the specified content instead of the animation.
	/// </summary>
	[DataContract]
	public class InlineQueryResultMpeg4Gif : InlineQueryResult
	{
		/// <summary>
		/// A valid URL for the MP4 file. File size must not exceed 1MB
		/// </summary>
		[DataMember(Name = "mpeg4_url", IsRequired = true)]
		public string mpeg4_url { get; set; }
		/// <summary>
		/// Optional. Video width
		/// </summary>
		[DataMember(Name = "mpeg4_width", EmitDefaultValue = false)]
		public int mpeg4_width { get; set; }
		/// <summary>
		/// Optional. Video height
		/// </summary>
		[DataMember(Name = "mpeg4_height", EmitDefaultValue = false)]
		public int mpeg4_height { get; set; }
		/// <summary>
		/// Optional. Video duration
		/// </summary>
		[DataMember(Name = "mpeg4_duration", EmitDefaultValue = false)]
		public int mpeg4_duration { get; set; }
		/// <summary>
		/// URL of the static thumbnail (jpeg or gif) for the result
		/// </summary>
		[DataMember(Name = "thumb_url", IsRequired = true)]
		public string thumb_url { get; set; }
		/// <summary>
		/// Optional. Title for the result
		/// </summary>
		[DataMember(Name = "title", EmitDefaultValue = false)]
		public string title { get; set; }
		/// <summary>
		/// Optional. Caption of the MPEG-4 file to be sent, 0-1024 characters after entities parsing
		/// </summary>
		[DataMember(Name = "caption", EmitDefaultValue = false)]
		public string caption { get; set; }
		/// <summary>
		/// Optional. Mode for parsing entities in the caption. See formatting options for more details.
		/// </summary>
		[DataMember(Name = "parse_mode", EmitDefaultValue = false)]
		public string parse_mode { get; set; }
		/// <summary>
		/// Optional. Content of the message to be sent instead of the video animation
		/// </summary>
		[DataMember(Name = "input_message_content", EmitDefaultValue = false)]
		public InputMessageContent input_message_content { get; set; }
	}
}
