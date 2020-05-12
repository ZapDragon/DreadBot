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
	/// This object represents an answer of a user in a non-anonymous poll.
	/// </summary>
	[DataContract]
	public class PollAnswer
	{
		/// <summary>
		/// Unique poll identifier
		/// </summary>
		[DataMember(Name = "poll_id", IsRequired = true)]
		public string poll_id { get; set; }
		/// <summary>
		/// The user, who changed the answer to the poll
		/// </summary>
		[DataMember(Name = "user", IsRequired = true)]
		public User user { get; set; }
		/// <summary>
		/// 0-based identifiers of answer options, chosen by the user. May be empty if the user retracted their vote.
		/// </summary>
		[DataMember(Name = "option_ids", IsRequired = true)]
		public int[] option_ids { get; set; }
	}
}
