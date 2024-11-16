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
	/// The boost was obtained by the creation of a Telegram Premium giveaway. This boosts the chat 4 times for the duration of the corresponding Telegram Premium subscription.
	/// </summary>
	[DataContract]
	public class ChatBoostSourceGiveaway
	{
		/// <summary>
		/// Source of the boost, always “giveaway”
		/// </summary>
		[DataMember(Name = "source", IsRequired = true)]
		public string source { get; set; }
		/// <summary>
		/// Identifier of a message in the chat with the giveaway; the message could have been deleted already. May be 0 if the message isn't sent yet.
		/// </summary>
		[DataMember(Name = "giveaway_message_id", IsRequired = true)]
		public int giveaway_message_id { get; set; }
		/// <summary>
		/// Optional. User that won the prize in the giveaway if any
		/// </summary>
		[DataMember(Name = "user", EmitDefaultValue = false)]
		public User user { get; set; }
		/// <summary>
		/// Optional. True, if the giveaway was completed, but there was no user to win the prize
		/// </summary>
		[DataMember(Name = "is_unclaimed", EmitDefaultValue = false)]
		public bool is_unclaimed { get; set; }
	}
}
