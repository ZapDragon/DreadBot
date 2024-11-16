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
	/// This object represents a message about the completion of a giveaway with public winners.
	/// </summary>
	[DataContract]
	public class GiveawayWinners
	{
		/// <summary>
		/// The chat that created the giveaway
		/// </summary>
		[DataMember(Name = "chat", IsRequired = true)]
		public Chat chat { get; set; }
		/// <summary>
		/// Identifier of the message with the giveaway in the chat
		/// </summary>
		[DataMember(Name = "giveaway_message_id", IsRequired = true)]
		public int giveaway_message_id { get; set; }
		/// <summary>
		/// Point in time (Unix timestamp) when winners of the giveaway were selected
		/// </summary>
		[DataMember(Name = "winners_selection_date", IsRequired = true)]
		public int winners_selection_date { get; set; }
		/// <summary>
		/// Total number of winners in the giveaway
		/// </summary>
		[DataMember(Name = "winner_count", IsRequired = true)]
		public int winner_count { get; set; }
		/// <summary>
		/// List of up to 100 winners of the giveaway
		/// </summary>
		[DataMember(Name = "winners", IsRequired = true)]
		public Array<User> winners { get; set; }
		/// <summary>
		/// Optional. The number of other chats the user had to join in order to be eligible for the giveaway
		/// </summary>
		[DataMember(Name = "additional_chat_count", EmitDefaultValue = false)]
		public int additional_chat_count { get; set; }
		/// <summary>
		/// Optional. The number of months the Telegram Premium subscription won from the giveaway will be active for
		/// </summary>
		[DataMember(Name = "premium_subscription_month_count", EmitDefaultValue = false)]
		public int premium_subscription_month_count { get; set; }
		/// <summary>
		/// Optional. Number of undistributed prizes
		/// </summary>
		[DataMember(Name = "unclaimed_prize_count", EmitDefaultValue = false)]
		public int unclaimed_prize_count { get; set; }
		/// <summary>
		/// Optional. True, if only users who had joined the chats after the giveaway started were eligible to win
		/// </summary>
		[DataMember(Name = "only_new_members", EmitDefaultValue = false)]
		public bool only_new_members { get; set; }
		/// <summary>
		/// Optional. True, if the giveaway was canceled because the payment for it was refunded
		/// </summary>
		[DataMember(Name = "was_refunded", EmitDefaultValue = false)]
		public bool was_refunded { get; set; }
		/// <summary>
		/// Optional. Description of additional giveaway prize
		/// </summary>
		[DataMember(Name = "prize_description", EmitDefaultValue = false)]
		public string prize_description { get; set; }
	}
}
