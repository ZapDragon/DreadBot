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
	/// This object represents a file ready to be downloaded. The file can be downloaded via the link https://api.telegram.org/file/bot<token>/<file_path>. It is guaranteed that the link will be valid for at least 1 hour. When the link expires, a new one can be requested by calling getFile.
	/// </summary>
	[DataContract]
	public class File
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
		/// Optional. File size in bytes. It can be bigger than 2^31 and some programming languages may have difficulty/silent defects in interpreting it. But it has at most 52 significant bits, so a signed 64-bit integer or double-precision float type are safe for storing this value.
		/// </summary>
		[DataMember(Name = "file_size", EmitDefaultValue = false)]
		public long file_size { get; set; }
		/// <summary>
		/// Optional. File path. Use https://api.telegram.org/file/bot<token>/<file_path> to get the file.
		/// </summary>
		[DataMember(Name = "file_path", EmitDefaultValue = false)]
		public string file_path { get; set; }
	}
}
