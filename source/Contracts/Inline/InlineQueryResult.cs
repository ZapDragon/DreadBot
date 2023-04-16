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
	/// This object represents one result of an inline query. Telegram clients currently support results of the following 20 types:
	/// </summary>
	[KnownType(typeof(InlineQueryResultArticle))]
	[KnownType(typeof(InlineQueryResultPhoto))]
	[KnownType(typeof(InlineQueryResultGif))]
	[KnownType(typeof(InlineQueryResultMpeg4Gif))]
	[KnownType(typeof(InlineQueryResultVideo))]
	[KnownType(typeof(InlineQueryResultAudio))]
	[KnownType(typeof(InlineQueryResultVoice))]
	[KnownType(typeof(InlineQueryResultDocument))]
	[KnownType(typeof(InlineQueryResultLocation))]
	[KnownType(typeof(InlineQueryResultVenue))]
	[KnownType(typeof(InlineQueryResultContact))]
	[KnownType(typeof(InlineQueryResultGame))]
	[KnownType(typeof(InlineQueryResultCachedPhoto))]
	[KnownType(typeof(InlineQueryResultCachedGif))]
	[KnownType(typeof(InlineQueryResultCachedMpeg4Gif))]
	[KnownType(typeof(InlineQueryResultCachedSticker))]
	[KnownType(typeof(InlineQueryResultCachedDocument))]
	[KnownType(typeof(InlineQueryResultCachedVideo))]
	[KnownType(typeof(InlineQueryResultCachedVoice))]
	[KnownType(typeof(InlineQueryResultCachedAudio))]
	[DataContract]
	public class InlineQueryResult
	{
		/// <summary>
		/// Type of the result, must be article
		/// </summary>
		[DataMember(Name = "type", IsRequired = true)]
		public string type { get; set; }
		/// <summary>
		/// Unique identifier for this result, 1-64 Bytes
		/// </summary>
		[DataMember(Name = "id", IsRequired = true)]
		public string id { get; set; }
		/// <summary>
		/// Optional. Inline keyboard attached to the message
		/// </summary>
		[DataMember(Name = "reply_markup", EmitDefaultValue = false)]
		public InlineKeyboardMarkup reply_markup { get; set; }
	}
}
