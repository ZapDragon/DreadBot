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
	/// This object represents one button of an inline keyboard. You must use exactly one of the optional fields.
	/// </summary>
	[DataContract]
	public class InlineKeyboardButton
	{
		/// <summary>
		/// Label text on the button
		/// </summary>
		[DataMember(Name = "text", IsRequired = true)]
		public string text { get; set; }
		/// <summary>
		/// Optional. HTTP or tg:// url to be opened when button is pressed
		/// </summary>
		[DataMember(Name = "url", EmitDefaultValue = false)]
		public string url { get; set; }
		/// <summary>
		/// Optional. An HTTP URL used to automatically authorize the user. Can be used as a replacement for the Telegram Login Widget.
		/// </summary>
		[DataMember(Name = "login_url", EmitDefaultValue = false)]
		public LoginUrl login_url { get; set; }
		/// <summary>
		/// Optional. Data to be sent in a callback query to the bot when button is pressed, 1-64 bytes
		/// </summary>
		[DataMember(Name = "callback_data", EmitDefaultValue = false)]
		public string callback_data { get; set; }
		/// <summary>
		/// Optional. If set, pressing the button will prompt the user to select one of their chats, open that chat and insert the bot‘s username and the specified inline query in the input field. Can be empty, in which case just the bot’s username will be inserted.Note: This offers an easy way for users to start using your bot in inline mode when they are currently in a private chat with it. Especially useful when combined with switch_pm… actions – in this case the user will be automatically returned to the chat they switched from, skipping the chat selection screen.
		/// </summary>
		[DataMember(Name = "switch_inline_query", EmitDefaultValue = false)]
		public string switch_inline_query { get; set; }
		/// <summary>
		/// Optional. If set, pressing the button will insert the bot‘s username and the specified inline query in the current chat’s input field. Can be empty, in which case only the bot's username will be inserted.This offers a quick way for the user to open your bot in inline mode in the same chat – good for selecting something from multiple options.
		/// </summary>
		[DataMember(Name = "switch_inline_query_current_chat", EmitDefaultValue = false)]
		public string switch_inline_query_current_chat { get; set; }
		/// <summary>
		/// Optional. Description of the game that will be launched when the user presses the button.NOTE: This type of button must always be the first button in the first row.
		/// </summary>
		[DataMember(Name = "callback_game", EmitDefaultValue = false)]
		public CallbackGame callback_game { get; set; }
		/// <summary>
		/// Optional. Specify True, to send a Pay button.NOTE: This type of button must always be the first button in the first row.
		/// </summary>
		[DataMember(Name = "pay", EmitDefaultValue = false)]
		public bool pay { get; set; }
	}
}
