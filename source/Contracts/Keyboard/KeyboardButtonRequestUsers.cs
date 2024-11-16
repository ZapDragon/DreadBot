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
	/// This object defines the criteria used to request suitable users. Information about the selected users will be shared with the bot when the corresponding button is pressed. More about requesting users »
	/// </summary>
	[DataContract]
	public class KeyboardButtonRequestUsers
	{
		/// <summary>
		/// Signed 32-bit identifier of the request that will be received back in the UsersShared object. Must be unique within the message
		/// </summary>
		[DataMember(Name = "request_id", IsRequired = true)]
		public int request_id { get; set; }
		/// <summary>
		/// Optional. Pass True to request bots, pass False to request regular users. If not specified, no additional restrictions are applied.
		/// </summary>
		[DataMember(Name = "user_is_bot", EmitDefaultValue = false)]
		public bool user_is_bot { get; set; }
		/// <summary>
		/// Optional. Pass True to request premium users, pass False to request non-premium users. If not specified, no additional restrictions are applied.
		/// </summary>
		[DataMember(Name = "user_is_premium", EmitDefaultValue = false)]
		public bool user_is_premium { get; set; }
		/// <summary>
		/// Optional. The maximum number of users to be selected; 1-10. Defaults to 1.
		/// </summary>
		[DataMember(Name = "max_quantity", EmitDefaultValue = false)]
		public int max_quantity { get; set; }
		/// <summary>
		/// Optional. Pass True to request the users' first and last names
		/// </summary>
		[DataMember(Name = "request_name", EmitDefaultValue = false)]
		public bool request_name { get; set; }
		/// <summary>
		/// Optional. Pass True to request the users' usernames
		/// </summary>
		[DataMember(Name = "request_username", EmitDefaultValue = false)]
		public bool request_username { get; set; }
		/// <summary>
		/// Optional. Pass True to request the users' photos
		/// </summary>
		[DataMember(Name = "request_photo", EmitDefaultValue = false)]
		public bool request_photo { get; set; }
	}
}
