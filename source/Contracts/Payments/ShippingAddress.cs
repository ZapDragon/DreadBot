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
	/// This object represents a shipping address.
	/// </summary>
	[DataContract]
	public class ShippingAddress
	{
		/// <summary>
		/// ISO 3166-1 alpha-2 country code
		/// </summary>
		[DataMember(Name = "country_code", IsRequired = true)]
		public string country_code { get; set; }
		/// <summary>
		/// State, if applicable
		/// </summary>
		[DataMember(Name = "state", IsRequired = true)]
		public string state { get; set; }
		/// <summary>
		/// City
		/// </summary>
		[DataMember(Name = "city", IsRequired = true)]
		public string city { get; set; }
		/// <summary>
		/// First line for the address
		/// </summary>
		[DataMember(Name = "street_line1", IsRequired = true)]
		public string street_line1 { get; set; }
		/// <summary>
		/// Second line for the address
		/// </summary>
		[DataMember(Name = "street_line2", IsRequired = true)]
		public string street_line2 { get; set; }
		/// <summary>
		/// Address post code
		/// </summary>
		[DataMember(Name = "post_code", IsRequired = true)]
		public string post_code { get; set; }
	}
}
