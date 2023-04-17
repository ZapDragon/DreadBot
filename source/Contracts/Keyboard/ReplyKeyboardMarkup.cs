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
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace DreadBot
{
	/// <summary>
	/// This object represents a custom keyboard with reply options (see Introduction to bots for details and examples).
	/// </summary>
	[DataContract]
	public class ReplyKeyboardMarkup : KeyboardMarkup
	{
		/// <summary>
		/// Array of button rows, each represented by an Array of KeyboardButton objects
		/// </summary>
		[DataMember(Name = "keyboard", IsRequired = true)]
		public List<List<InlineKeyboardButton>> keyboard { get { return Keyboard; } set { Keyboard = value; } }
		/// <summary>
		/// Optional. Requests clients to always show the keyboard when the regular keyboard is hidden. Defaults to false, in which case the custom keyboard can be hidden and opened with a keyboard icon.
		/// </summary>
		[DataMember(Name = "is_persistent", EmitDefaultValue = false)]
		public bool is_persistent { get; set; }
		/// <summary>
		/// Optional. Requests clients to resize the keyboard vertically for optimal fit (e.g., make the keyboard smaller if there are just two rows of buttons). Defaults to false, in which case the custom keyboard is always of the same height as the app's standard keyboard.
		/// </summary>
		[DataMember(Name = "resize_keyboard", EmitDefaultValue = false)]
		public bool resize_keyboard { get; set; }
		/// <summary>
		/// Optional. Requests clients to hide the keyboard as soon as it's been used. The keyboard will still be available, but clients will automatically display the usual letter-keyboard in the chat - the user can press a special button in the input field to see the custom keyboard again. Defaults to false.
		/// </summary>
		[DataMember(Name = "one_time_keyboard", EmitDefaultValue = false)]
		public bool one_time_keyboard { get; set; }
		/// <summary>
		/// Optional. The placeholder to be shown in the input field when the keyboard is active; 1-64 characters
		/// </summary>
		[DataMember(Name = "input_field_placeholder", EmitDefaultValue = false)]
		public string input_field_placeholder { get; set; }
		/// <summary>
		/// Optional. Use this parameter if you want to show the keyboard to specific users only. Targets: 1) users that are @mentioned in the text of the Message object; 2) if the bot's message is a reply (has reply_to_message_id), sender of the original message.Example: A user requests to change the bot's language, bot replies to the request with a keyboard to select the new language. Other users in the group don't see the keyboard.
		/// </summary>
		[DataMember(Name = "selective", EmitDefaultValue = false)]
		public bool selective { get; set; }
	}
}
