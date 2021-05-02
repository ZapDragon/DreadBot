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
	/// This object represents a point on the map.
	/// </summary>
	[DataContract]
	public class Location
	{
		/// <summary>
		/// Longitude as defined by sender
		/// </summary>
		[DataMember(Name = "longitude", IsRequired = true)]
		public float longitude { get; set; }
		/// <summary>
		/// Latitude as defined by sender
		/// </summary>
		[DataMember(Name = "latitude", IsRequired = true)]
		public float latitude { get; set; }
		/// <summary>
		/// Optional. The radius of uncertainty for the location, measured in meters; 0-1500
		/// </summary>
		[DataMember(Name = "horizontal_accuracy", EmitDefaultValue = false)]
		public float horizontal_accuracy { get; set; }
		/// <summary>
		/// Optional. Time relative to the message sending date, during which the location can be updated, in seconds. For active live locations only.
		/// </summary>
		[DataMember(Name = "live_period", EmitDefaultValue = false)]
		public int live_period { get; set; }
		/// <summary>
		/// Optional. The direction in which user is moving, in degrees; 1-360. For active live locations only.
		/// </summary>
		[DataMember(Name = "heading", EmitDefaultValue = false)]
		public int heading { get; set; }
		/// <summary>
		/// Optional. Maximum distance for proximity alerts about approaching another chat member, in meters. For sent live locations only.
		/// </summary>
		[DataMember(Name = "proximity_alert_radius", EmitDefaultValue = false)]
		public int proximity_alert_radius { get; set; }
	}
}
