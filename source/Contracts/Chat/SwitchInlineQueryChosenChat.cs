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
	/// This object represents an inline button that switches the current user to inline mode in a chosen chat, with an optional default inline query.
	/// </summary>
	[DataContract]
	public class SwitchInlineQueryChosenChat
	{
		/// <summary>
		/// Optional. The default inline query to be inserted in the input field. If left empty, only the bot's username will be inserted
		/// </summary>
		[DataMember(Name = "query", EmitDefaultValue = false)]
		public string query { get; set; }
		/// <summary>
		/// Optional. True, if private chats with users can be chosen
		/// </summary>
		[DataMember(Name = "allow_user_chats", EmitDefaultValue = false)]
		public bool allow_user_chats { get; set; }
		/// <summary>
		/// Optional. True, if private chats with bots can be chosen
		/// </summary>
		[DataMember(Name = "allow_bot_chats", EmitDefaultValue = false)]
		public bool allow_bot_chats { get; set; }
		/// <summary>
		/// Optional. True, if group and supergroup chats can be chosen
		/// </summary>
		[DataMember(Name = "allow_group_chats", EmitDefaultValue = false)]
		public bool allow_group_chats { get; set; }
		/// <summary>
		/// Optional. True, if channel chats can be chosen
		/// </summary>
		[DataMember(Name = "allow_channel_chats", EmitDefaultValue = false)]
		public bool allow_channel_chats { get; set; }
	}
}
