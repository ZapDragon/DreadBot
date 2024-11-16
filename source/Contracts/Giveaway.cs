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
	/// This object represents a message about a scheduled giveaway.
	/// </summary>
	[DataContract]
	public class Giveaway
	{
		/// <summary>
		/// The list of chats which the user must join to participate in the giveaway
		/// </summary>
		[DataMember(Name = "chats", IsRequired = true)]
		public Array<Chat> chats { get; set; }
		/// <summary>
		/// Point in time (Unix timestamp) when winners of the giveaway will be selected
		/// </summary>
		[DataMember(Name = "winners_selection_date", IsRequired = true)]
		public int winners_selection_date { get; set; }
		/// <summary>
		/// The number of users which are supposed to be selected as winners of the giveaway
		/// </summary>
		[DataMember(Name = "winner_count", IsRequired = true)]
		public int winner_count { get; set; }
		/// <summary>
		/// Optional. True, if only users who join the chats after the giveaway started should be eligible to win
		/// </summary>
		[DataMember(Name = "only_new_members", EmitDefaultValue = false)]
		public bool only_new_members { get; set; }
		/// <summary>
		/// Optional. True, if the list of giveaway winners will be visible to everyone
		/// </summary>
		[DataMember(Name = "has_public_winners", EmitDefaultValue = false)]
		public bool has_public_winners { get; set; }
		/// <summary>
		/// Optional. Description of additional giveaway prize
		/// </summary>
		[DataMember(Name = "prize_description", EmitDefaultValue = false)]
		public string prize_description { get; set; }
		/// <summary>
		/// Optional. A list of two-letter ISO 3166-1 alpha-2 country codes indicating the countries from which eligible users for the giveaway must come. If empty, then all users can participate in the giveaway. Users with a phone number that was bought on Fragment can always participate in giveaways.
		/// </summary>
		[DataMember(Name = "country_codes", EmitDefaultValue = false)]
		public Array<string> country_codes { get; set; }
		/// <summary>
		/// Optional. The number of months the Telegram Premium subscription won from the giveaway will be active for
		/// </summary>
		[DataMember(Name = "premium_subscription_month_count", EmitDefaultValue = false)]
		public int premium_subscription_month_count { get; set; }
	}
}
