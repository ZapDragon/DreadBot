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
	/// This object represents a game. Use BotFather to create and edit games, their short names will act as unique identifiers.
	/// </summary>
	[DataContract]
	public class Game
	{
		/// <summary>
		/// Title of the game
		/// </summary>
		[DataMember(Name = "title", IsRequired = true)]
		public string title { get; set; }
		/// <summary>
		/// Description of the game
		/// </summary>
		[DataMember(Name = "description", IsRequired = true)]
		public string description { get; set; }
		/// <summary>
		/// Photo that will be displayed in the game message in chats.
		/// </summary>
		[DataMember(Name = "photo", IsRequired = true)]
		public PhotoSize[] photo { get; set; }
		/// <summary>
		/// Optional. Brief description of the game or high scores included in the game message. Can be automatically edited to include current high scores for the game when the bot calls setGameScore, or manually edited using editMessageText. 0-4096 characters.
		/// </summary>
		[DataMember(Name = "text", EmitDefaultValue = false)]
		public string text { get; set; }
		/// <summary>
		/// Optional. Special entities that appear in text, such as usernames, URLs, bot commands, etc.
		/// </summary>
		[DataMember(Name = "text_entities", EmitDefaultValue = false)]
		public MessageEntity[] text_entities { get; set; }
		/// <summary>
		/// Optional. Animation that will be displayed in the game message in chats. Upload via BotFather
		/// </summary>
		[DataMember(Name = "animation", EmitDefaultValue = false)]
		public Animation animation { get; set; }
	}
}
