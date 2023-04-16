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
	/// Represents the content of a venue message to be sent as the result of an inline query.
	/// </summary>
	[DataContract]
	public class InputVenueMessageContent
	{
		/// <summary>
		/// Latitude of the venue in degrees
		/// </summary>
		[DataMember(Name = "latitude", IsRequired = true)]
		public float latitude { get; set; }
		/// <summary>
		/// Longitude of the venue in degrees
		/// </summary>
		[DataMember(Name = "longitude", IsRequired = true)]
		public float longitude { get; set; }
		/// <summary>
		/// Name of the venue
		/// </summary>
		[DataMember(Name = "title", IsRequired = true)]
		public string title { get; set; }
		/// <summary>
		/// Address of the venue
		/// </summary>
		[DataMember(Name = "address", IsRequired = true)]
		public string address { get; set; }
		/// <summary>
		/// Optional. Foursquare identifier of the venue, if known
		/// </summary>
		[DataMember(Name = "foursquare_id", EmitDefaultValue = false)]
		public string foursquare_id { get; set; }
		/// <summary>
		/// Optional. Foursquare type of the venue, if known. (For example, “arts_entertainment/default”, “arts_entertainment/aquarium” or “food/icecream”.)
		/// </summary>
		[DataMember(Name = "foursquare_type", EmitDefaultValue = false)]
		public string foursquare_type { get; set; }
		/// <summary>
		/// Optional. Google Places identifier of the venue
		/// </summary>
		[DataMember(Name = "google_place_id", EmitDefaultValue = false)]
		public string google_place_id { get; set; }
		/// <summary>
		/// Optional. Google Places type of the venue. (See supported types.)
		/// </summary>
		[DataMember(Name = "google_place_type", EmitDefaultValue = false)]
		public string google_place_type { get; set; }
	}
}
