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
	/// Describes the current status of a webhook.
	/// </summary>
	[DataContract]
	public class WebhookInfo
	{
		/// <summary>
		/// Webhook URL, may be empty if webhook is not set up
		/// </summary>
		[DataMember(Name = "url", IsRequired = true)]
		public string url { get; set; }
		/// <summary>
		/// True, if a custom certificate was provided for webhook certificate checks
		/// </summary>
		[DataMember(Name = "has_custom_certificate", IsRequired = true)]
		public bool has_custom_certificate { get; set; }
		/// <summary>
		/// Number of updates awaiting delivery
		/// </summary>
		[DataMember(Name = "pending_update_count", IsRequired = true)]
		public int pending_update_count { get; set; }
		/// <summary>
		/// Optional. Currently used webhook IP address
		/// </summary>
		[DataMember(Name = "ip_address", EmitDefaultValue = false)]
		public string ip_address { get; set; }
		/// <summary>
		/// Optional. Unix time for the most recent error that happened when trying to deliver an update via webhook
		/// </summary>
		[DataMember(Name = "last_error_date", EmitDefaultValue = false)]
		public long last_error_date { get; set; }
		/// <summary>
		/// Optional. Error message in human-readable format for the most recent error that happened when trying to deliver an update via webhook
		/// </summary>
		[DataMember(Name = "last_error_message", EmitDefaultValue = false)]
		public string last_error_message { get; set; }
		/// <summary>
		/// Optional. Unix time of the most recent error that happened when trying to synchronize available updates with Telegram datacenters
		/// </summary>
		[DataMember(Name = "last_synchronization_error_date", EmitDefaultValue = false)]
		public int last_synchronization_error_date { get; set; }
		/// <summary>
		/// Optional. The maximum allowed number of simultaneous HTTPS connections to the webhook for update delivery
		/// </summary>
		[DataMember(Name = "max_connections", EmitDefaultValue = false)]
		public int max_connections { get; set; }
		/// <summary>
		/// Optional. A list of update types the bot is subscribed to. Defaults to all update types except chat_member
		/// </summary>
		[DataMember(Name = "allowed_updates", EmitDefaultValue = false)]
		public Array<string> allowed_updates { get; set; }
	}
}
