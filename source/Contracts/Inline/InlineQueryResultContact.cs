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
	/// Represents a contact with a phone number. By default, this contact will be sent by the user. Alternatively, you can use input_message_content to send a message with the specified content instead of the contact.
	/// </summary>
	[DataContract]
	public class InlineQueryResultContact : InlineQueryResult
	{
		/// <summary>
		/// Contact's phone number
		/// </summary>
		[DataMember(Name = "phone_number", IsRequired = true)]
		public string phone_number { get; set; }
		/// <summary>
		/// Contact's first name
		/// </summary>
		[DataMember(Name = "first_name", IsRequired = true)]
		public string first_name { get; set; }
		/// <summary>
		/// Optional. Contact's last name
		/// </summary>
		[DataMember(Name = "last_name", EmitDefaultValue = false)]
		public string last_name { get; set; }
		/// <summary>
		/// Optional. Additional data about the contact in the form of a vCard, 0-2048 bytes
		/// </summary>
		[DataMember(Name = "vcard", EmitDefaultValue = false)]
		public string vcard { get; set; }
		/// <summary>
		/// Optional. Content of the message to be sent instead of the contact
		/// </summary>
		[DataMember(Name = "input_message_content", EmitDefaultValue = false)]
		public InputMessageContent input_message_content { get; set; }
		/// <summary>
		/// Optional. Url of the thumbnail for the result
		/// </summary>
		[DataMember(Name = "thumb_url", EmitDefaultValue = false)]
		public string thumb_url { get; set; }
		/// <summary>
		/// Optional. Thumbnail width
		/// </summary>
		[DataMember(Name = "thumb_width", EmitDefaultValue = false)]
		public int thumb_width { get; set; }
		/// <summary>
		/// Optional. Thumbnail height
		/// </summary>
		[DataMember(Name = "thumb_height", EmitDefaultValue = false)]
		public int thumb_height { get; set; }
	}
}
