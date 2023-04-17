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
	/// This object represents one button of the reply keyboard. For simple text buttons, String can be used instead of this object to specify the button text. The optional fields web_app, request_user, request_chat, request_contact, request_location, and request_poll are mutually exclusive.
	/// </summary>
	[DataContract]
	public class KeyboardButton
	{
		/// <summary>
		/// Text of the button. If none of the optional fields are used, it will be sent as a message when the button is pressed
		/// </summary>
		[DataMember(Name = "text", IsRequired = true)]
		public string text { get; set; }
		/// <summary>
		/// Optional. If specified, pressing the button will open a list of suitable users. Tapping on any user will send their identifier to the bot in a “user_shared” service message. Available in private chats only.
		/// </summary>
		[DataMember(Name = "request_user", EmitDefaultValue = false)]
		public KeyboardButtonRequestUser request_user { get; set; }
		/// <summary>
		/// Optional. If specified, pressing the button will open a list of suitable chats. Tapping on a chat will send its identifier to the bot in a “chat_shared” service message. Available in private chats only.
		/// </summary>
		[DataMember(Name = "request_chat", EmitDefaultValue = false)]
		public KeyboardButtonRequestChat request_chat { get; set; }
		/// <summary>
		/// Optional. If True, the user's phone number will be sent as a contact when the button is pressed. Available in private chats only.
		/// </summary>
		[DataMember(Name = "request_contact", EmitDefaultValue = false)]
		public bool request_contact { get; set; }
		/// <summary>
		/// Optional. If True, the user's current location will be sent when the button is pressed. Available in private chats only.
		/// </summary>
		[DataMember(Name = "request_location", EmitDefaultValue = false)]
		public bool request_location { get; set; }
		/// <summary>
		/// Optional. If specified, the user will be asked to create a poll and send it to the bot when the button is pressed. Available in private chats only.
		/// </summary>
		[DataMember(Name = "request_poll", EmitDefaultValue = false)]
		public KeyboardButtonPollType request_poll { get; set; }
		/// <summary>
		/// Optional. If specified, the described Web App will be launched when the button is pressed. The Web App will be able to send a “web_app_data” service message. Available in private chats only.
		/// </summary>
		[DataMember(Name = "web_app", EmitDefaultValue = false)]
		public WebAppInfo web_app { get; set; }
	}
}
