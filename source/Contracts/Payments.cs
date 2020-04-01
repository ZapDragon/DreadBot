#region License
//MIT License
//Copyright(c) [2019]
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
    [DataContract]
    public class LabeledPrice
    {
        [DataMember(Name = "label")]
        public string label { get; set; }

        [DataMember(Name = "amount")]
        public int amount { get; set; }
    }

    [DataContract]
    public class Invoice
    {
        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "description")]
        public string description { get; set; }

        [DataMember(Name = "start_parameter")]
        public string start_parameter { get; set; }

        [DataMember(Name = "currency")]
        public string currency { get; set; }

        [DataMember(Name = "total_amount")]
        public int total_amount { get; set; }
    }

    [DataContract]
    public class ShippingAddress
    {
        [DataMember(Name = "country_code")]
        public string country_code { get; set; }

        [DataMember(Name = "state")]
        public string state { get; set; }

        [DataMember(Name = "city")]
        public string city { get; set; }

        [DataMember(Name = "street_line1")]
        public string street_line1 { get; set; }

        [DataMember(Name = "street_line2")]
        public string street_line2 { get; set; }

        [DataMember(Name = "post_code")]
        public string post_code { get; set; }

    }

    [DataContract]
    public class OrderInfo
    {
        [DataMember(Name = "name", IsRequired = false)]
        public string name { get; set; }

        [DataMember(Name = "phone_number", IsRequired = false)]
        public string phone_number { get; set; }

        [DataMember(Name = "email", IsRequired = false)]
        public string email { get; set; }

        [DataMember(Name = "shipping_address", IsRequired = false)]
        public ShippingAddress shipping_address { get; set; }
    }

    [DataContract]
    public class ShippingOption
    {
        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "name")]
        public LabeledPrice[] prices { get; set; }
    }

    [DataContract]
    public class SuccessfulPayment
    {
        [DataMember(Name = "currency")]
        public string currency { get; set; }

        [DataMember(Name = "total_amount")] //This is handled in the smallest currency type, such as cents.
        public int total_amount { get; set; }

        [DataMember(Name = "invoice_payload")]
        public string invoice_payload { get; set; }

        [DataMember(Name = "shipping_option_id", IsRequired = false)]
        public string shipping_option_id { get; set; }

        [DataMember(Name = "order_info", IsRequired = false)]
        public OrderInfo order_info { get; set; }

        [DataMember(Name = "telegram_payment_charge_id")]
        public string telegram_payment_charge_id { get; set; }

        [DataMember(Name = "provider_payment_charge_id")]
        public string provider_payment_charge_id { get; set; }

    }

    [DataContract]
    public class ShippingQuery
    {
        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "from")]
        public User from { get; set; }

        [DataMember(Name = "invoice_payload")]
        public string invoice_payload { get; set; }

        [DataMember(Name = "shipping_address")]
        public ShippingAddress shiping_address { get; set; }

    }

    [DataContract]
    public class PreCheckoutQuery
    {
        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "from")]
        public User from { get; set; }

        [DataMember(Name = "currency")]
        public string currency { get; set; }

        [DataMember(Name = "total_amount")]
        public int total_amount { get; set; }

        [DataMember(Name = "invoice_payload")]
        public string invoice_payload { get; set; }

        [DataMember(Name = "shipping_option_id", IsRequired = false)]
        public string shipping_option_id { get; set; }

        [DataMember(Name = "order_info", IsRequired = false)]
        public OrderInfo order_info { get; set; }
    }
}
