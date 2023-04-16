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
	/// This object represents an incoming inline query. When the user sends an empty query, your bot could return some default or trending results.
	/// </summary>
	[DataContract]
	public class InlineQuery
	{
		/// <summary>
		/// Unique identifier for this query
		/// </summary>
		[DataMember(Name = "id", IsRequired = true)]
		public string id { get; set; }
		/// <summary>
		/// Sender
		/// </summary>
		[DataMember(Name = "from", IsRequired = true)]
		public User from { get; set; }
		/// <summary>
		/// Text of the query (up to 256 characters)
		/// </summary>
		[DataMember(Name = "query", IsRequired = true)]
		public string query { get; set; }
		/// <summary>
		/// Offset of the results to be returned, can be controlled by the bot
		/// </summary>
		[DataMember(Name = "offset", IsRequired = true)]
		public string offset { get; set; }
		/// <summary>
		/// Optional. Type of the chat from which the inline query was sent. Can be either “sender” for a private chat with the inline query sender, “private”, “group”, “supergroup”, or “channel”. The chat type should be always known for requests sent from official clients and most third-party clients, unless the request was sent from a secret chat
		/// </summary>
		[DataMember(Name = "chat_type", EmitDefaultValue = false)]
		public string chat_type { get; set; }
		/// <summary>
		/// Optional. Sender location, only for bots that request user location
		/// </summary>
		[DataMember(Name = "location", EmitDefaultValue = false)]
		public Location location { get; set; }
	}
}
