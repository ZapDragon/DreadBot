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
	/// This object represents a boost removed from a chat.
	/// </summary>
	[DataContract]
	public class ChatBoostRemoved
	{
		/// <summary>
		/// Chat which was boosted
		/// </summary>
		[DataMember(Name = "chat", IsRequired = true)]
		public Chat chat { get; set; }
		/// <summary>
		/// Unique identifier of the boost
		/// </summary>
		[DataMember(Name = "boost_id", IsRequired = true)]
		public string boost_id { get; set; }
		/// <summary>
		/// Point in time (Unix timestamp) when the boost was removed
		/// </summary>
		[DataMember(Name = "remove_date", IsRequired = true)]
		public int remove_date { get; set; }
		/// <summary>
		/// Source of the removed boost
		/// </summary>
		[DataMember(Name = "source", IsRequired = true)]
		public ChatBoostSource source { get; set; }
	}
}
