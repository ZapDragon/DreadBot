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
	/// This object contains information about a poll.
	/// </summary>
	[DataContract]
	public class Poll
	{
		/// <summary>
		/// Unique poll identifier
		/// </summary>
		[DataMember(Name = "id", IsRequired = true)]
		public string id { get; set; }
		/// <summary>
		/// Poll question, 1-255 characters
		/// </summary>
		[DataMember(Name = "question", IsRequired = true)]
		public string question { get; set; }
		/// <summary>
		/// List of poll options
		/// </summary>
		[DataMember(Name = "options", IsRequired = true)]
		public PollOption[] options { get; set; }
		/// <summary>
		/// Total number of users that voted in the poll
		/// </summary>
		[DataMember(Name = "total_voter_count", IsRequired = true)]
		public int total_voter_count { get; set; }
		/// <summary>
		/// True, if the poll is closed
		/// </summary>
		[DataMember(Name = "is_closed", IsRequired = true)]
		public bool is_closed { get; set; }
		/// <summary>
		/// True, if the poll is anonymous
		/// </summary>
		[DataMember(Name = "is_anonymous", IsRequired = true)]
		public bool is_anonymous { get; set; }
		/// <summary>
		/// Poll type, currently can be “regular” or “quiz”
		/// </summary>
		[DataMember(Name = "type", IsRequired = true)]
		public string type { get; set; }
		/// <summary>
		/// True, if the poll allows multiple answers
		/// </summary>
		[DataMember(Name = "allows_multiple_answers", IsRequired = true)]
		public bool allows_multiple_answers { get; set; }
		/// <summary>
		/// Optional. 0-based identifier of the correct answer option. Available only for polls in the quiz mode, which are closed, or was sent (not forwarded) by the bot or to the private chat with the bot.
		/// </summary>
		[DataMember(Name = "correct_option_id", EmitDefaultValue = false)]
		public int correct_option_id { get; set; }
		/// <summary>
		/// Optional. Text that is shown when a user chooses an incorrect answer or taps on the lamp icon in a quiz-style poll, 0-200 characters
		/// </summary>
		[DataMember(Name = "explanation", EmitDefaultValue = false)]
		public string explanation { get; set; }
		/// <summary>
		/// Optional. Special entities like usernames, URLs, bot commands, etc. that appear in the explanation
		/// </summary>
		[DataMember(Name = "explanation_entities", EmitDefaultValue = false)]
		public MessageEntity[] explanation_entities { get; set; }
		/// <summary>
		/// Optional. Amount of time in seconds the poll will be active after creation
		/// </summary>
		[DataMember(Name = "open_period", EmitDefaultValue = false)]
		public int open_period { get; set; }
		/// <summary>
		/// Optional. Point in time (Unix timestamp) when the poll will be automatically closed
		/// </summary>
		[DataMember(Name = "close_date", EmitDefaultValue = false)]
		public int close_date { get; set; }
	}
}
