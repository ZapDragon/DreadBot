#region License 
//MIT License
//Copyright(c) [2023]
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
	/// This object contains information about an incoming shipping query.
	/// </summary>
	[DataContract]
	public class ShippingQuery
	{
		/// <summary>
		/// Unique query identifier
		/// </summary>
		[DataMember(Name = "id", IsRequired = true)]
		public string id { get; set; }
		/// <summary>
		/// User who sent the query
		/// </summary>
		[DataMember(Name = "from", IsRequired = true)]
		public User from { get; set; }
		/// <summary>
		/// Bot specified invoice payload
		/// </summary>
		[DataMember(Name = "invoice_payload", IsRequired = true)]
		public string invoice_payload { get; set; }
		/// <summary>
		/// User specified shipping address
		/// </summary>
		[DataMember(Name = "shipping_address", IsRequired = true)]
		public ShippingAddress shipping_address { get; set; }
	}
}
