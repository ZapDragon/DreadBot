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
	/// This object represents a sticker.
	/// </summary>
	[DataContract]
	public class Sticker
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
		/// Sticker width
		/// </summary>
		[DataMember(Name = "width", IsRequired = true)]
		public int width { get; set; }
		/// <summary>
		/// Sticker height
		/// </summary>
		[DataMember(Name = "height", IsRequired = true)]
		public int height { get; set; }
		/// <summary>
		/// True, if the sticker is animated
		/// </summary>
		[DataMember(Name = "is_animated", IsRequired = true)]
		public bool is_animated { get; set; }
		/// <summary>
		/// Optional. Sticker thumbnail in the .WEBP or .JPG format
		/// </summary>
		[DataMember(Name = "thumb", EmitDefaultValue = false)]
		public PhotoSize thumb { get; set; }
		/// <summary>
		/// Optional. Emoji associated with the sticker
		/// </summary>
		[DataMember(Name = "emoji", EmitDefaultValue = false)]
		public string emoji { get; set; }
		/// <summary>
		/// Optional. Name of the sticker set to which the sticker belongs
		/// </summary>
		[DataMember(Name = "set_name", EmitDefaultValue = false)]
		public string set_name { get; set; }
		/// <summary>
		/// Optional. For mask stickers, the position where the mask should be placed
		/// </summary>
		[DataMember(Name = "mask_position", EmitDefaultValue = false)]
		public MaskPosition mask_position { get; set; }
		/// <summary>
		/// Optional. File size
		/// </summary>
		[DataMember(Name = "file_size", EmitDefaultValue = false)]
		public int file_size { get; set; }
	}
}
