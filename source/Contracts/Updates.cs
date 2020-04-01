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
    public class Update
    {
        //Required
        [DataMember(Name = "update_id")]
        public long update_id { get; set; }
        //Optionals
        [DataMember(Name = "message", IsRequired = false)]
        public Message message { get; set; }

        [DataMember(Name = "edited_message", IsRequired = false)]
        public Message edited_message { get; set; }

        [DataMember(Name = "channel_post", IsRequired = false)]
        public Message channel_post { get; set; }

        [DataMember(Name = "edited_channel_post", IsRequired = false)]
        public Message edited_channel_post { get; set; }

        [DataMember(Name = "inline_query", IsRequired = false)]
        public InlineQuery inline_query { get; set; }

        [DataMember(Name = "chosen_inline_result", IsRequired = false)]
        public ChosenInlineResult chosen_inline_result { get; set; }

        [DataMember(Name = "callback_query", IsRequired = false)]
        public CallbackQuery callback_query { get; set; }

        [DataMember(Name = "shipping_query", IsRequired = false)]
        public ShippingQuery shipping_query { get; set; }

        [DataMember(Name = "pre_checkout_query", IsRequired = false)]
        public PreCheckoutQuery pre_checkout_query { get; set; }

        [DataMember(Name = "poll", IsRequired = false)]
        public Poll poll { get; set; }

    }

    [DataContract]
    public class WebhookInfo
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "has_custom_certificate")]
        public bool hasCertificate { get; set; }

        [DataMember(Name = "pending_update_count")]
        public int pendingUpdateCount { get; set; }

        [DataMember(Name = "last_error_date", IsRequired = false)]
        public int lastErrorEpoch { get; set; }

        [DataMember(Name = "last_error_message", IsRequired = false)]
        public string lastError { get; set; }

        [DataMember(Name = "max_connections", IsRequired = false)]
        public int maxConnections { get; set; }

        [DataMember(Name = "allowed_updates", IsRequired = false)]
        public string[] allowedUpdates { get; set; }
    }
}
