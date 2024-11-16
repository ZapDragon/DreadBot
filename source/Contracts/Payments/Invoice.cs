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
	/// This object contains basic information about an invoice.
	/// </summary>
	[DataContract]
	public class Invoice
	{
		/// <summary>
		/// Product name
		/// </summary>
		[DataMember(Name = "title", IsRequired = true)]
		public string title { get; set; }
		/// <summary>
		/// Product description
		/// </summary>
		[DataMember(Name = "description", IsRequired = true)]
		public string description { get; set; }
		/// <summary>
		/// Unique bot deep-linking parameter that can be used to generate this invoice
		/// </summary>
		[DataMember(Name = "start_parameter", IsRequired = true)]
		public string start_parameter { get; set; }
		/// <summary>
		/// Three-letter ISO 4217 currency code, or “XTR” for payments in Telegram Stars
		/// </summary>
		[DataMember(Name = "currency", IsRequired = true)]
		public string currency { get; set; }
		/// <summary>
		/// Total price in the smallest units of the currency (integer, not float/double). For example, for a price of US$ 1.45 pass amount = 145. See the exp parameter in currencies.json, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies).
		/// </summary>
		[DataMember(Name = "total_amount", IsRequired = true)]
		public int total_amount { get; set; }
	}
}
