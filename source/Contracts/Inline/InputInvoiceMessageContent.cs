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
	/// Represents the content of an invoice message to be sent as the result of an inline query.
	/// </summary>
	[DataContract]
	public class InputInvoiceMessageContent
	{
		/// <summary>
		/// Product name, 1-32 characters
		/// </summary>
		[DataMember(Name = "title", IsRequired = true)]
		public string title { get; set; }
		/// <summary>
		/// Product description, 1-255 characters
		/// </summary>
		[DataMember(Name = "description", IsRequired = true)]
		public string description { get; set; }
		/// <summary>
		/// Bot-defined invoice payload, 1-128 bytes. This will not be displayed to the user, use for your internal processes.
		/// </summary>
		[DataMember(Name = "payload", IsRequired = true)]
		public string payload { get; set; }
		/// <summary>
		/// Optional. Payment provider token, obtained via @BotFather. Pass an empty string for payments in Telegram Stars.
		/// </summary>
		[DataMember(Name = "provider_token", EmitDefaultValue = false)]
		public string provider_token { get; set; }
		/// <summary>
		/// Three-letter ISO 4217 currency code, see more on currencies. Pass “XTR” for payments in Telegram Stars.
		/// </summary>
		[DataMember(Name = "currency", IsRequired = true)]
		public string currency { get; set; }
		/// <summary>
		/// Price breakdown, a JSON-serialized list of components (e.g. product price, tax, discount, delivery cost, delivery tax, bonus, etc.). Must contain exactly one item for payments in Telegram Stars.
		/// </summary>
		[DataMember(Name = "prices", IsRequired = true)]
		public Array<LabeledPrice> prices { get; set; }
		/// <summary>
		/// Optional. The maximum accepted amount for tips in the smallest units of the currency (integer, not float/double). For example, for a maximum tip of US$ 1.45 pass max_tip_amount = 145. See the exp parameter in currencies.json, it shows the number of digits past the decimal point for each currency (2 for the majority of currencies). Defaults to 0. Not supported for payments in Telegram Stars.
		/// </summary>
		[DataMember(Name = "max_tip_amount", EmitDefaultValue = false)]
		public int max_tip_amount { get; set; }
		/// <summary>
		/// Optional. A JSON-serialized array of suggested amounts of tip in the smallest units of the currency (integer, not float/double). At most 4 suggested tip amounts can be specified. The suggested tip amounts must be positive, passed in a strictly increased order and must not exceed max_tip_amount.
		/// </summary>
		[DataMember(Name = "suggested_tip_amounts", EmitDefaultValue = false)]
		public Array<int> suggested_tip_amounts { get; set; }
		/// <summary>
		/// Optional. A JSON-serialized object for data about the invoice, which will be shared with the payment provider. A detailed description of the required fields should be provided by the payment provider.
		/// </summary>
		[DataMember(Name = "provider_data", EmitDefaultValue = false)]
		public string provider_data { get; set; }
		/// <summary>
		/// Optional. URL of the product photo for the invoice. Can be a photo of the goods or a marketing image for a service.
		/// </summary>
		[DataMember(Name = "photo_url", EmitDefaultValue = false)]
		public string photo_url { get; set; }
		/// <summary>
		/// Optional. Photo size in bytes
		/// </summary>
		[DataMember(Name = "photo_size", EmitDefaultValue = false)]
		public int photo_size { get; set; }
		/// <summary>
		/// Optional. Photo width
		/// </summary>
		[DataMember(Name = "photo_width", EmitDefaultValue = false)]
		public int photo_width { get; set; }
		/// <summary>
		/// Optional. Photo height
		/// </summary>
		[DataMember(Name = "photo_height", EmitDefaultValue = false)]
		public int photo_height { get; set; }
		/// <summary>
		/// Optional. Pass True if you require the user's full name to complete the order. Ignored for payments in Telegram Stars.
		/// </summary>
		[DataMember(Name = "need_name", EmitDefaultValue = false)]
		public bool need_name { get; set; }
		/// <summary>
		/// Optional. Pass True if you require the user's phone number to complete the order. Ignored for payments in Telegram Stars.
		/// </summary>
		[DataMember(Name = "need_phone_number", EmitDefaultValue = false)]
		public bool need_phone_number { get; set; }
		/// <summary>
		/// Optional. Pass True if you require the user's email address to complete the order. Ignored for payments in Telegram Stars.
		/// </summary>
		[DataMember(Name = "need_email", EmitDefaultValue = false)]
		public bool need_email { get; set; }
		/// <summary>
		/// Optional. Pass True if you require the user's shipping address to complete the order. Ignored for payments in Telegram Stars.
		/// </summary>
		[DataMember(Name = "need_shipping_address", EmitDefaultValue = false)]
		public bool need_shipping_address { get; set; }
		/// <summary>
		/// Optional. Pass True if the user's phone number should be sent to the provider. Ignored for payments in Telegram Stars.
		/// </summary>
		[DataMember(Name = "send_phone_number_to_provider", EmitDefaultValue = false)]
		public bool send_phone_number_to_provider { get; set; }
		/// <summary>
		/// Optional. Pass True if the user's email address should be sent to the provider. Ignored for payments in Telegram Stars.
		/// </summary>
		[DataMember(Name = "send_email_to_provider", EmitDefaultValue = false)]
		public bool send_email_to_provider { get; set; }
		/// <summary>
		/// Optional. Pass True if the final price depends on the shipping method. Ignored for payments in Telegram Stars.
		/// </summary>
		[DataMember(Name = "is_flexible", EmitDefaultValue = false)]
		public bool is_flexible { get; set; }
	}
}
