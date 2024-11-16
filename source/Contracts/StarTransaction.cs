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
	/// Describes a Telegram Star transaction.
	/// </summary>
	[DataContract]
	public class StarTransaction
	{
		/// <summary>
		/// Unique identifier of the transaction. Coincides with the identifer of the original transaction for refund transactions. Coincides with SuccessfulPayment.telegram_payment_charge_id for successful incoming payments from users.
		/// </summary>
		[DataMember(Name = "id", IsRequired = true)]
		public string id { get; set; }
		/// <summary>
		/// Number of Telegram Stars transferred by the transaction
		/// </summary>
		[DataMember(Name = "amount", IsRequired = true)]
		public int amount { get; set; }
		/// <summary>
		/// Date the transaction was created in Unix time
		/// </summary>
		[DataMember(Name = "date", IsRequired = true)]
		public long date { get; set; }
		/// <summary>
		/// Optional. Source of an incoming transaction (e.g., a user purchasing goods or services, Fragment refunding a failed withdrawal). Only for incoming transactions
		/// </summary>
		[DataMember(Name = "source", EmitDefaultValue = false)]
		public TransactionPartner source { get; set; }
		/// <summary>
		/// Optional. Receiver of an outgoing transaction (e.g., a user for a purchase refund, Fragment for a withdrawal). Only for outgoing transactions
		/// </summary>
		[DataMember(Name = "receiver", EmitDefaultValue = false)]
		public TransactionPartner receiver { get; set; }
	}
}
