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
	/// This object represents a sticker set.
	/// </summary>
	[DataContract]
	public class StickerSet
	{
		/// <summary>
		/// Sticker set name
		/// </summary>
		[DataMember(Name = "name", IsRequired = true)]
		public string name { get; set; }
		/// <summary>
		/// Sticker set title
		/// </summary>
		[DataMember(Name = "title", IsRequired = true)]
		public string title { get; set; }
		/// <summary>
		/// True, if the sticker set contains animated stickers
		/// </summary>
		[DataMember(Name = "is_animated", IsRequired = true)]
		public bool is_animated { get; set; }
		/// <summary>
		/// True, if the sticker set contains masks
		/// </summary>
		[DataMember(Name = "contains_masks", IsRequired = true)]
		public bool contains_masks { get; set; }
		/// <summary>
		/// List of all set stickers
		/// </summary>
		[DataMember(Name = "stickers", IsRequired = true)]
		public Sticker[] stickers { get; set; }
		/// <summary>
		/// Optional. Sticker set thumbnail in the .WEBP or .TGS format
		/// </summary>
		[DataMember(Name = "thumb", EmitDefaultValue = false)]
		public PhotoSize thumb { get; set; }
	}
}
