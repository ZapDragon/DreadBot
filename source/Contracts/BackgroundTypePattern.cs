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
	/// The background is a PNG or TGV (gzipped subset of SVG with MIME type “application/x-tgwallpattern”) pattern to be combined with the background fill chosen by the user.
	/// </summary>
	[DataContract]
	public class BackgroundTypePattern
	{
		/// <summary>
		/// Type of the background, always “pattern”
		/// </summary>
		[DataMember(Name = "type", IsRequired = true)]
		public string type { get; set; }
		/// <summary>
		/// Document with the pattern
		/// </summary>
		[DataMember(Name = "document", IsRequired = true)]
		public Document document { get; set; }
		/// <summary>
		/// The background fill that is combined with the pattern
		/// </summary>
		[DataMember(Name = "fill", IsRequired = true)]
		public BackgroundFill fill { get; set; }
		/// <summary>
		/// Intensity of the pattern when it is shown above the filled background; 0-100
		/// </summary>
		[DataMember(Name = "intensity", IsRequired = true)]
		public int intensity { get; set; }
		/// <summary>
		/// Optional. True, if the background fill must be applied only to the pattern itself. All other pixels are black in this case. For dark themes only
		/// </summary>
		[DataMember(Name = "is_inverted", EmitDefaultValue = false)]
		public bool is_inverted { get; set; }
		/// <summary>
		/// Optional. True, if the background moves slightly when the device is tilted
		/// </summary>
		[DataMember(Name = "is_moving", EmitDefaultValue = false)]
		public bool is_moving { get; set; }
	}
}
