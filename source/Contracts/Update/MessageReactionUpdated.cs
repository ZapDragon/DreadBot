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
	/// This object represents a change of a reaction on a message performed by a user.
	/// </summary>
	[DataContract]
	public class MessageReactionUpdated
	{
		/// <summary>
		/// The chat containing the message the user reacted to
		/// </summary>
		[DataMember(Name = "chat", IsRequired = true)]
		public Chat chat { get; set; }
		/// <summary>
		/// Unique identifier of the message inside the chat
		/// </summary>
		[DataMember(Name = "message_id", IsRequired = true)]
		public long message_id { get; set; }
		/// <summary>
		/// Optional. The user that changed the reaction, if the user isn't anonymous
		/// </summary>
		[DataMember(Name = "user", EmitDefaultValue = false)]
		public User user { get; set; }
		/// <summary>
		/// Optional. The chat on behalf of which the reaction was changed, if the user is anonymous
		/// </summary>
		[DataMember(Name = "actor_chat", EmitDefaultValue = false)]
		public Chat actor_chat { get; set; }
		/// <summary>
		/// Date of the change in Unix time
		/// </summary>
		[DataMember(Name = "date", IsRequired = true)]
		public long date { get; set; }
		/// <summary>
		/// Previous list of reaction types that were set by the user
		/// </summary>
		[DataMember(Name = "old_reaction", IsRequired = true)]
		public Array<ReactionType> old_reaction { get; set; }
		/// <summary>
		/// New list of reaction types that have been set by the user
		/// </summary>
		[DataMember(Name = "new_reaction", IsRequired = true)]
		public Array<ReactionType> new_reaction { get; set; }
	}
}