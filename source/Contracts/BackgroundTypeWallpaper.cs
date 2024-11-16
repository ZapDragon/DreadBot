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
	/// The background is a wallpaper in the JPEG format.
	/// </summary>
	[DataContract]
	public class BackgroundTypeWallpaper
	{
		/// <summary>
		/// Type of the background, always “wallpaper”
		/// </summary>
		[DataMember(Name = "type", IsRequired = true)]
		public string type { get; set; }
		/// <summary>
		/// Document with the wallpaper
		/// </summary>
		[DataMember(Name = "document", IsRequired = true)]
		public Document document { get; set; }
		/// <summary>
		/// Dimming of the background in dark themes, as a percentage; 0-100
		/// </summary>
		[DataMember(Name = "dark_theme_dimming", IsRequired = true)]
		public int dark_theme_dimming { get; set; }
		/// <summary>
		/// Optional. True, if the wallpaper is downscaled to fit in a 450x450 square and then box-blurred with radius 12
		/// </summary>
		[DataMember(Name = "is_blurred", EmitDefaultValue = false)]
		public bool is_blurred { get; set; }
		/// <summary>
		/// Optional. True, if the background moves slightly when the device is tilted
		/// </summary>
		[DataMember(Name = "is_moving", EmitDefaultValue = false)]
		public bool is_moving { get; set; }
	}
}
