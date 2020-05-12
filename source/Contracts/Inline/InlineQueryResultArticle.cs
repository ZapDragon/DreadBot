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
	/// Represents a link to an article or web page.
	/// </summary>
	[DataContract]
	public class InlineQueryResultArticle : InlineQueryResult
	{
		/// <summary>
		/// Title of the result
		/// </summary>
		[DataMember(Name = "title", IsRequired = true)]
		public string title { get; set; }
		/// <summary>
		/// Content of the message to be sent
		/// </summary>
		[DataMember(Name = "input_message_content", IsRequired = true)]
		public InputMessageContent input_message_content { get; set; }
		/// <summary>
		/// Optional. URL of the result
		/// </summary>
		[DataMember(Name = "url", EmitDefaultValue = false)]
		public string url { get; set; }
		/// <summary>
		/// Optional. Pass True, if you don't want the URL to be shown in the message
		/// </summary>
		[DataMember(Name = "hide_url", EmitDefaultValue = false)]
		public bool hide_url { get; set; }
		/// <summary>
		/// Optional. Short description of the result
		/// </summary>
		[DataMember(Name = "description", EmitDefaultValue = false)]
		public string description { get; set; }
		/// <summary>
		/// Optional. Url of the thumbnail for the result
		/// </summary>
		[DataMember(Name = "thumb_url", EmitDefaultValue = false)]
		public string thumb_url { get; set; }
		/// <summary>
		/// Optional. Thumbnail width
		/// </summary>
		[DataMember(Name = "thumb_width", EmitDefaultValue = false)]
		public int thumb_width { get; set; }
		/// <summary>
		/// Optional. Thumbnail height
		/// </summary>
		[DataMember(Name = "thumb_height", EmitDefaultValue = false)]
		public int thumb_height { get; set; }
	}
}
