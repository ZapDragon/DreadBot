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
	/// Describes the options used for link preview generation.
	/// </summary>
	[DataContract]
	public class LinkPreviewOptions
	{
		/// <summary>
		/// Optional. True, if the link preview is disabled
		/// </summary>
		[DataMember(Name = "is_disabled", EmitDefaultValue = false)]
		public bool is_disabled { get; set; }
		/// <summary>
		/// Optional. URL to use for the link preview. If empty, then the first URL found in the message text will be used
		/// </summary>
		[DataMember(Name = "url", EmitDefaultValue = false)]
		public string url { get; set; }
		/// <summary>
		/// Optional. True, if the media in the link preview is supposed to be shrunk; ignored if the URL isn't explicitly specified or media size change isn't supported for the preview
		/// </summary>
		[DataMember(Name = "prefer_small_media", EmitDefaultValue = false)]
		public bool prefer_small_media { get; set; }
		/// <summary>
		/// Optional. True, if the media in the link preview is supposed to be enlarged; ignored if the URL isn't explicitly specified or media size change isn't supported for the preview
		/// </summary>
		[DataMember(Name = "prefer_large_media", EmitDefaultValue = false)]
		public bool prefer_large_media { get; set; }
		/// <summary>
		/// Optional. True, if the link preview must be shown above the message text; otherwise, the link preview will be shown below the message text
		/// </summary>
		[DataMember(Name = "show_above_text", EmitDefaultValue = false)]
		public bool show_above_text { get; set; }
	}
}
