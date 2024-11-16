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
	/// The message was originally sent on behalf of a chat to a group chat.
	/// </summary>
	[DataContract]
	public class MessageOriginChat
	{
		/// <summary>
		/// Type of the message origin, always “chat”
		/// </summary>
		[DataMember(Name = "type", IsRequired = true)]
		public string type { get; set; }
		/// <summary>
		/// Date the message was sent originally in Unix time
		/// </summary>
		[DataMember(Name = "date", IsRequired = true)]
		public long date { get; set; }
		/// <summary>
		/// Chat that sent the message originally
		/// </summary>
		[DataMember(Name = "sender_chat", IsRequired = true)]
		public Chat sender_chat { get; set; }
		/// <summary>
		/// Optional. For messages originally sent by an anonymous chat administrator, original message author signature
		/// </summary>
		[DataMember(Name = "author_signature", EmitDefaultValue = false)]
		public string author_signature { get; set; }
	}
}
