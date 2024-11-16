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
	/// This object represents a forum topic.
	/// </summary>
	[DataContract]
	public class ForumTopic
	{
		/// <summary>
		/// Unique identifier of the forum topic
		/// </summary>
		[DataMember(Name = "message_thread_id", IsRequired = true)]
		public int message_thread_id { get; set; }
		/// <summary>
		/// Name of the topic
		/// </summary>
		[DataMember(Name = "name", IsRequired = true)]
		public string name { get; set; }
		/// <summary>
		/// Color of the topic icon in RGB format
		/// </summary>
		[DataMember(Name = "icon_color", IsRequired = true)]
		public int icon_color { get; set; }
		/// <summary>
		/// Optional. Unique identifier of the custom emoji shown as the topic icon
		/// </summary>
		[DataMember(Name = "icon_custom_emoji_id", EmitDefaultValue = false)]
		public string icon_custom_emoji_id { get; set; }
	}
}
