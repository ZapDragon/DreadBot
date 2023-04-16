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
	/// This object represents an incoming update.At most one of the optional parameters can be present in any given update.
	/// </summary>
	[DataContract]
	public class Update
	{
		/// <summary>
		/// The update's unique identifier. Update identifiers start from a certain positive number and increase sequentially. This ID becomes especially handy if you're using webhooks, since it allows you to ignore repeated updates or to restore the correct update sequence, should they get out of order. If there are no new updates for at least a week, then identifier of the next update will be chosen randomly instead of sequentially.
		/// </summary>
		[DataMember(Name = "update_id", IsRequired = true)]
		public long update_id { get; set; }
		/// <summary>
		/// Optional. New incoming message of any kind - text, photo, sticker, etc.
		/// </summary>
		[DataMember(Name = "message", EmitDefaultValue = false)]
		public Message message { get; set; }
		/// <summary>
		/// Optional. New version of a message that is known to the bot and was edited
		/// </summary>
		[DataMember(Name = "edited_message", EmitDefaultValue = false)]
		public Message edited_message { get; set; }
		/// <summary>
		/// Optional. New incoming channel post of any kind - text, photo, sticker, etc.
		/// </summary>
		[DataMember(Name = "channel_post", EmitDefaultValue = false)]
		public Message channel_post { get; set; }
		/// <summary>
		/// Optional. New version of a channel post that is known to the bot and was edited
		/// </summary>
		[DataMember(Name = "edited_channel_post", EmitDefaultValue = false)]
		public Message edited_channel_post { get; set; }
		/// <summary>
		/// Optional. New incoming inline query
		/// </summary>
		[DataMember(Name = "inline_query", EmitDefaultValue = false)]
		public InlineQuery inline_query { get; set; }
		/// <summary>
		/// Optional. The result of an inline query that was chosen by a user and sent to their chat partner. Please see our documentation on the feedback collecting for details on how to enable these updates for your bot.
		/// </summary>
		[DataMember(Name = "chosen_inline_result", EmitDefaultValue = false)]
		public ChosenInlineResult chosen_inline_result { get; set; }
		/// <summary>
		/// Optional. New incoming callback query
		/// </summary>
		[DataMember(Name = "callback_query", EmitDefaultValue = false)]
		public CallbackQuery callback_query { get; set; }
		/// <summary>
		/// Optional. New incoming shipping query. Only for invoices with flexible price
		/// </summary>
		[DataMember(Name = "shipping_query", EmitDefaultValue = false)]
		public ShippingQuery shipping_query { get; set; }
		/// <summary>
		/// Optional. New incoming pre-checkout query. Contains full information about checkout
		/// </summary>
		[DataMember(Name = "pre_checkout_query", EmitDefaultValue = false)]
		public PreCheckoutQuery pre_checkout_query { get; set; }
		/// <summary>
		/// Optional. New poll state. Bots receive only updates about stopped polls and polls, which are sent by the bot
		/// </summary>
		[DataMember(Name = "poll", EmitDefaultValue = false)]
		public Poll poll { get; set; }
		/// <summary>
		/// Optional. A user changed their answer in a non-anonymous poll. Bots receive new votes only in polls that were sent by the bot itself.
		/// </summary>
		[DataMember(Name = "poll_answer", EmitDefaultValue = false)]
		public PollAnswer poll_answer { get; set; }
		/// <summary>
		/// Optional. The bot's chat member status was updated in a chat. For private chats, this update is received only when the bot is blocked or unblocked by the user.
		/// </summary>
		[DataMember(Name = "my_chat_member", EmitDefaultValue = false)]
		public ChatMemberUpdated my_chat_member { get; set; }
		/// <summary>
		/// Optional. A chat member's status was updated in a chat. The bot must be an administrator in the chat and must explicitly specify “chat_member” in the list of allowed_updates to receive these updates.
		/// </summary>
		[DataMember(Name = "chat_member", EmitDefaultValue = false)]
		public ChatMemberUpdated chat_member { get; set; }
		/// <summary>
		/// Optional. A request to join the chat has been sent. The bot must have the can_invite_users administrator right in the chat to receive these updates.
		/// </summary>
		[DataMember(Name = "chat_join_request", EmitDefaultValue = false)]
		public ChatJoinRequest chat_join_request { get; set; }
	}
}
