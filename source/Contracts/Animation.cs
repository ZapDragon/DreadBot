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
	/// This object represents an animation file (GIF or H.264/MPEG-4 AVC video without sound).
	/// </summary>
	[DataContract]
	public class Animation
	{
		/// <summary>
		/// Identifier for this file, which can be used to download or reuse the file
		/// </summary>
		[DataMember(Name = "file_id", IsRequired = true)]
		public string file_id { get; set; }
		/// <summary>
		/// Unique identifier for this file, which is supposed to be the same over time and for different bots. Can't be used to download or reuse the file.
		/// </summary>
		[DataMember(Name = "file_unique_id", IsRequired = true)]
		public string file_unique_id { get; set; }
		/// <summary>
		/// Video width as defined by sender
		/// </summary>
		[DataMember(Name = "width", IsRequired = true)]
		public int width { get; set; }
		/// <summary>
		/// Video height as defined by sender
		/// </summary>
		[DataMember(Name = "height", IsRequired = true)]
		public int height { get; set; }
		/// <summary>
		/// Duration of the video in seconds as defined by sender
		/// </summary>
		[DataMember(Name = "duration", IsRequired = true)]
		public int duration { get; set; }
		/// <summary>
		/// Optional. Animation thumbnail as defined by sender
		/// </summary>
		[DataMember(Name = "thumb", EmitDefaultValue = false)]
		public PhotoSize thumb { get; set; }
		/// <summary>
		/// Optional. Original animation filename as defined by sender
		/// </summary>
		[DataMember(Name = "file_name", EmitDefaultValue = false)]
		public string file_name { get; set; }
		/// <summary>
		/// Optional. MIME type of the file as defined by sender
		/// </summary>
		[DataMember(Name = "mime_type", EmitDefaultValue = false)]
		public string mime_type { get; set; }
		/// <summary>
		/// Optional. File size in bytes. It can be bigger than 2^31 and some programming languages may have difficulty/silent defects in interpreting it. But it has at most 52 significant bits, so a signed 64-bit integer or double-precision float type are safe for storing this value.
		/// </summary>
		[DataMember(Name = "file_size", EmitDefaultValue = false)]
		public long file_size { get; set; }
	}
}
