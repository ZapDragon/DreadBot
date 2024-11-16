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
	/// Represents a link to an MP3 audio file. By default, this audio file will be sent by the user. Alternatively, you can use input_message_content to send a message with the specified content instead of the audio.
	/// </summary>
	[DataContract]
	public class InlineQueryResultAudio : InlineQueryResult
	{
		/// <summary>
		/// A valid URL for the audio file
		/// </summary>
		[DataMember(Name = "audio_url", IsRequired = true)]
		public string audio_url { get; set; }
		/// <summary>
		/// Title
		/// </summary>
		[DataMember(Name = "title", IsRequired = true)]
		public string title { get; set; }
		/// <summary>
		/// Optional. Caption, 0-1024 characters after entities parsing
		/// </summary>
		[DataMember(Name = "caption", EmitDefaultValue = false)]
		public string caption { get; set; }
		/// <summary>
		/// Optional. Mode for parsing entities in the audio caption. See formatting options for more details.
		/// </summary>
		[DataMember(Name = "parse_mode", EmitDefaultValue = false)]
		public string parse_mode { get; set; }
		/// <summary>
		/// Optional. List of special entities that appear in the caption, which can be specified instead of parse_mode
		/// </summary>
		[DataMember(Name = "caption_entities", EmitDefaultValue = false)]
		public Array<MessageEntity> caption_entities { get; set; }
		/// <summary>
		/// Optional. Performer
		/// </summary>
		[DataMember(Name = "performer", EmitDefaultValue = false)]
		public string performer { get; set; }
		/// <summary>
		/// Optional. Audio duration in seconds
		/// </summary>
		[DataMember(Name = "audio_duration", EmitDefaultValue = false)]
		public int audio_duration { get; set; }
		/// <summary>
		/// Optional. Content of the message to be sent instead of the audio
		/// </summary>
		[DataMember(Name = "input_message_content", EmitDefaultValue = false)]
		public InputMessageContent input_message_content { get; set; }
	}
}
