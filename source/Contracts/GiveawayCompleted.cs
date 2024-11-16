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
	/// This object represents a service message about the completion of a giveaway without public winners.
	/// </summary>
	[DataContract]
	public class GiveawayCompleted
	{
		/// <summary>
		/// Number of winners in the giveaway
		/// </summary>
		[DataMember(Name = "winner_count", IsRequired = true)]
		public int winner_count { get; set; }
		/// <summary>
		/// Optional. Number of undistributed prizes
		/// </summary>
		[DataMember(Name = "unclaimed_prize_count", EmitDefaultValue = false)]
		public int unclaimed_prize_count { get; set; }
		/// <summary>
		/// Optional. Message with the giveaway that was completed, if it wasn't deleted
		/// </summary>
		[DataMember(Name = "giveaway_message", EmitDefaultValue = false)]
		public Message giveaway_message { get; set; }
	}
}
