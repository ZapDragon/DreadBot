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
	/// This object represents an incoming callback query from a callback button in an inline keyboard. If the button that originated the query was attached to a message sent by the bot, the field message will be present. If the button was attached to a message sent via the bot (in inline mode), the field inline_message_id will be present. Exactly one of the fields data or game_short_name will be present.
	/// </summary>
	[DataContract]
	public class CallbackQuery
	{
		/// <summary>
		/// Unique identifier for this query
		/// </summary>
		[DataMember(Name = "id", IsRequired = true)]
		public string id { get; set; }
		/// <summary>
		/// Sender
		/// </summary>
		[DataMember(Name = "from", IsRequired = true)]
		public User from { get; set; }
		/// <summary>
		/// Optional. Message with the callback button that originated the query. Note that message content and message date will not be available if the message is too old
		/// </summary>
		[DataMember(Name = "message", EmitDefaultValue = false)]
		public Message message { get; set; }
		/// <summary>
		/// Optional. Identifier of the message sent via the bot in inline mode, that originated the query.
		/// </summary>
		[DataMember(Name = "inline_message_id", EmitDefaultValue = false)]
		public string inline_message_id { get; set; }
		/// <summary>
		/// Global identifier, uniquely corresponding to the chat to which the message with the callback button was sent. Useful for high scores in games.
		/// </summary>
		[DataMember(Name = "chat_instance", IsRequired = true)]
		public string chat_instance { get; set; }
		/// <summary>
		/// Optional. Data associated with the callback button. Be aware that a bad client can send arbitrary data in this field.
		/// </summary>
		[DataMember(Name = "data", EmitDefaultValue = false)]
		public string data { get; set; }
		/// <summary>
		/// Optional. Short name of a Game to be returned, serves as the unique identifier for the game
		/// </summary>
		[DataMember(Name = "game_short_name", EmitDefaultValue = false)]
		public string game_short_name { get; set; }
	}
}
