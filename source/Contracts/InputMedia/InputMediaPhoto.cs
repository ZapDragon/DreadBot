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
	/// Represents a photo to be sent.
	/// </summary>
	[DataContract]
	public class InputMediaPhoto : InputMedia
	{
		/// <summary>
		/// Optional. Pass True, if the caption must be shown above the message media
		/// </summary>
		[DataMember(Name = "show_caption_above_media", EmitDefaultValue = false)]
		public bool show_caption_above_media { get; set; }
		/// <summary>
		/// Optional. Pass True if the photo needs to be covered with a spoiler animation
		/// </summary>
		[DataMember(Name = "has_spoiler", EmitDefaultValue = false)]
		public bool has_spoiler { get; set; }
	}
}
