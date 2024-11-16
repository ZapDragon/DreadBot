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
		/// Optional. The chat that changed the answer to the poll, if the voter is anonymous
		/// </summary>
		[DataMember(Name = "voter_chat", EmitDefaultValue = false)]
		public Chat voter_chat { get; set; }
		/// <summary>
		/// Optional. The user that changed the answer to the poll, if the voter isn't anonymous
		/// </summary>
		[DataMember(Name = "user", EmitDefaultValue = false)]
		public User user { get; set; }
		/// <summary>
		/// 0-based identifiers of chosen answer options. May be empty if the vote was retracted.
		/// </summary>
		[DataMember(Name = "option_ids", IsRequired = true)]
		public Array<int> option_ids { get; set; }
	}
}
