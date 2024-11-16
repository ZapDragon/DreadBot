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
	/// This object contains information about one answer option in a poll to be sent.
	/// </summary>
	[DataContract]
	public class InputPollOption
	{
		/// <summary>
		/// Option text, 1-100 characters
		/// </summary>
		[DataMember(Name = "text", IsRequired = true)]
		public string text { get; set; }
		/// <summary>
		/// Optional. Mode for parsing entities in the text. See formatting options for more details. Currently, only custom emoji entities are allowed
		/// </summary>
		[DataMember(Name = "text_parse_mode", EmitDefaultValue = false)]
		public string text_parse_mode { get; set; }
		/// <summary>
		/// Optional. A JSON-serialized list of special entities that appear in the poll option text. It can be specified instead of text_parse_mode
		/// </summary>
		[DataMember(Name = "text_entities", EmitDefaultValue = false)]
		public Array<MessageEntity> text_entities { get; set; }
	}
}
