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
	/// Describes a transaction with a user.
	/// </summary>
	[DataContract]
	public class TransactionPartnerUser
	{
		/// <summary>
		/// Type of the transaction partner, always “user”
		/// </summary>
		[DataMember(Name = "type", IsRequired = true)]
		public string type { get; set; }
		/// <summary>
		/// Information about the user
		/// </summary>
		[DataMember(Name = "user", IsRequired = true)]
		public User user { get; set; }
		/// <summary>
		/// Optional. Bot-specified invoice payload
		/// </summary>
		[DataMember(Name = "invoice_payload", EmitDefaultValue = false)]
		public string invoice_payload { get; set; }
		/// <summary>
		/// Optional. Information about the paid media bought by the user
		/// </summary>
		[DataMember(Name = "paid_media", EmitDefaultValue = false)]
		public Array<PaidMedia> paid_media { get; set; }
	}
}
