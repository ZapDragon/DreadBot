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
	/// This object describes a sticker to be added to a sticker set.
	/// </summary>
	[DataContract]
	public class InputSticker
	{
		/// <summary>
		/// The added sticker. Pass a file_id as a String to send a file that already exists on the Telegram servers, pass an HTTP URL as a String for Telegram to get a file from the Internet, upload a new one using multipart/form-data, or pass “attach://<file_attach_name>” to upload a new one using multipart/form-data under <file_attach_name> name. Animated and video stickers can't be uploaded via HTTP URL. More information on Sending Files »
		/// </summary>
		[DataMember(Name = "sticker", IsRequired = true)]
		public object sticker { get; set; }
		/// <summary>
		/// Format of the added sticker, must be one of “static” for a .WEBP or .PNG image, “animated” for a .TGS animation, “video” for a WEBM video
		/// </summary>
		[DataMember(Name = "format", IsRequired = true)]
		public string format { get; set; }
		/// <summary>
		/// List of 1-20 emoji associated with the sticker
		/// </summary>
		[DataMember(Name = "emoji_list", IsRequired = true)]
		public Array<string> emoji_list { get; set; }
		/// <summary>
		/// Optional. Position where the mask should be placed on faces. For “mask” stickers only.
		/// </summary>
		[DataMember(Name = "mask_position", EmitDefaultValue = false)]
		public MaskPosition mask_position { get; set; }
		/// <summary>
		/// Optional. List of 0-20 search keywords for the sticker with total length of up to 64 characters. For “regular” and “custom_emoji” stickers only.
		/// </summary>
		[DataMember(Name = "keywords", EmitDefaultValue = false)]
		public Array<string> keywords { get; set; }
	}
}
