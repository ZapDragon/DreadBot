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
	/// The paid media to send is a video.
	/// </summary>
	[DataContract]
	public class InputPaidMediaVideo
	{
		/// <summary>
		/// Type of the media, must be video
		/// </summary>
		[DataMember(Name = "type", IsRequired = true)]
		public string type { get; set; }
		/// <summary>
		/// File to send. Pass a file_id to send a file that exists on the Telegram servers (recommended), pass an HTTP URL for Telegram to get a file from the Internet, or pass “attach://<file_attach_name>” to upload a new one using multipart/form-data under <file_attach_name> name. More information on Sending Files »
		/// </summary>
		[DataMember(Name = "media", IsRequired = true)]
		public string media { get; set; }
		/// <summary>
		/// Optional. Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side. The thumbnail should be in JPEG format and less than 200 kB in size. A thumbnail's width and height should not exceed 320. Ignored if the file is not uploaded using multipart/form-data. Thumbnails can't be reused and can be only uploaded as a new file, so you can pass “attach://<file_attach_name>” if the thumbnail was uploaded using multipart/form-data under <file_attach_name>. More information on Sending Files »
		/// </summary>
		[DataMember(Name = "thumbnail", EmitDefaultValue = false)]
		public object thumbnail { get; set; }
		/// <summary>
		/// Optional. Video width
		/// </summary>
		[DataMember(Name = "width", EmitDefaultValue = false)]
		public int width { get; set; }
		/// <summary>
		/// Optional. Video height
		/// </summary>
		[DataMember(Name = "height", EmitDefaultValue = false)]
		public int height { get; set; }
		/// <summary>
		/// Optional. Video duration in seconds
		/// </summary>
		[DataMember(Name = "duration", EmitDefaultValue = false)]
		public int duration { get; set; }
		/// <summary>
		/// Optional. Pass True if the uploaded video is suitable for streaming
		/// </summary>
		[DataMember(Name = "supports_streaming", EmitDefaultValue = false)]
		public bool supports_streaming { get; set; }
	}
}
