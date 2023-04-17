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
	/// This object defines the criteria used to request a suitable chat. The identifier of the selected chat will be shared with the bot when the corresponding button is pressed.
	/// </summary>
	[DataContract]
	public class KeyboardButtonRequestChat
	{
		/// <summary>
		/// Signed 32-bit identifier of the request, which will be received back in the ChatShared object. Must be unique within the message
		/// </summary>
		[DataMember(Name = "request_id", IsRequired = true)]
		public int request_id { get; set; }
		/// <summary>
		/// Pass True to request a channel chat, pass False to request a group or a supergroup chat.
		/// </summary>
		[DataMember(Name = "chat_is_channel", IsRequired = true)]
		public bool chat_is_channel { get; set; }
		/// <summary>
		/// Optional. Pass True to request a forum supergroup, pass False to request a non-forum chat. If not specified, no additional restrictions are applied.
		/// </summary>
		[DataMember(Name = "chat_is_forum", EmitDefaultValue = false)]
		public bool chat_is_forum { get; set; }
		/// <summary>
		/// Optional. Pass True to request a supergroup or a channel with a username, pass False to request a chat without a username. If not specified, no additional restrictions are applied.
		/// </summary>
		[DataMember(Name = "chat_has_username", EmitDefaultValue = false)]
		public bool chat_has_username { get; set; }
		/// <summary>
		/// Optional. Pass True to request a chat owned by the user. Otherwise, no additional restrictions are applied.
		/// </summary>
		[DataMember(Name = "chat_is_created", EmitDefaultValue = false)]
		public bool chat_is_created { get; set; }
		/// <summary>
		/// Optional. A JSON-serialized object listing the required administrator rights of the user in the chat. The rights must be a superset of bot_administrator_rights. If not specified, no additional restrictions are applied.
		/// </summary>
		[DataMember(Name = "user_administrator_rights", EmitDefaultValue = false)]
		public ChatAdministratorRights user_administrator_rights { get; set; }
		/// <summary>
		/// Optional. A JSON-serialized object listing the required administrator rights of the bot in the chat. The rights must be a subset of user_administrator_rights. If not specified, no additional restrictions are applied.
		/// </summary>
		[DataMember(Name = "bot_administrator_rights", EmitDefaultValue = false)]
		public ChatAdministratorRights bot_administrator_rights { get; set; }
		/// <summary>
		/// Optional. Pass True to request a chat with the bot as a member. Otherwise, no additional restrictions are applied.
		/// </summary>
		[DataMember(Name = "bot_is_member", EmitDefaultValue = false)]
		public bool bot_is_member { get; set; }
	}
}
