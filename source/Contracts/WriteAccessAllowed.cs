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
	/// This object represents a service message about a user allowing a bot to write messages after adding it to the attachment menu, launching a Web App from a link, or accepting an explicit request from a Web App sent by the method requestWriteAccess.
	/// </summary>
	[DataContract]
	public class WriteAccessAllowed
	{
		/// <summary>
		/// Optional. True, if the access was granted after the user accepted an explicit request from a Web App sent by the method requestWriteAccess
		/// </summary>
		[DataMember(Name = "from_request", EmitDefaultValue = false)]
		public bool from_request { get; set; }
		/// <summary>
		/// Optional. Name of the Web App, if the access was granted when the Web App was launched from a link
		/// </summary>
		[DataMember(Name = "web_app_name", EmitDefaultValue = false)]
		public string web_app_name { get; set; }
		/// <summary>
		/// Optional. True, if the access was granted when the bot was added to the attachment or side menu
		/// </summary>
		[DataMember(Name = "from_attachment_menu", EmitDefaultValue = false)]
		public bool from_attachment_menu { get; set; }
	}
}
