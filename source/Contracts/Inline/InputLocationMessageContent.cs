#region License 
//MIT License
//Copyright(c) [2023]
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
	/// Represents the content of a location message to be sent as the result of an inline query.
	/// </summary>
	[DataContract]
	public class InputLocationMessageContent
	{
		/// <summary>
		/// Latitude of the location in degrees
		/// </summary>
		[DataMember(Name = "latitude", IsRequired = true)]
		public float latitude { get; set; }
		/// <summary>
		/// Longitude of the location in degrees
		/// </summary>
		[DataMember(Name = "longitude", IsRequired = true)]
		public float longitude { get; set; }
		/// <summary>
		/// Optional. The radius of uncertainty for the location, measured in meters; 0-1500
		/// </summary>
		[DataMember(Name = "horizontal_accuracy", EmitDefaultValue = false)]
		public float horizontal_accuracy { get; set; }
		/// <summary>
		/// Optional. Period in seconds for which the location can be updated, should be between 60 and 86400.
		/// </summary>
		[DataMember(Name = "live_period", EmitDefaultValue = false)]
		public int live_period { get; set; }
		/// <summary>
		/// Optional. For live locations, a direction in which the user is moving, in degrees. Must be between 1 and 360 if specified.
		/// </summary>
		[DataMember(Name = "heading", EmitDefaultValue = false)]
		public int heading { get; set; }
		/// <summary>
		/// Optional. For live locations, a maximum distance for proximity alerts about approaching another chat member, in meters. Must be between 1 and 100000 if specified.
		/// </summary>
		[DataMember(Name = "proximity_alert_radius", EmitDefaultValue = false)]
		public int proximity_alert_radius { get; set; }
	}
}
