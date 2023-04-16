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
	/// Describes documents or other Telegram Passport elements shared with the bot by the user.
	/// </summary>
	[DataContract]
	public class EncryptedPassportElement
	{
		/// <summary>
		/// Element type. One of “personal_details”, “passport”, “driver_license”, “identity_card”, “internal_passport”, “address”, “utility_bill”, “bank_statement”, “rental_agreement”, “passport_registration”, “temporary_registration”, “phone_number”, “email”.
		/// </summary>
		[DataMember(Name = "type", IsRequired = true)]
		public string type { get; set; }
		/// <summary>
		/// Optional. Base64-encoded encrypted Telegram Passport element data provided by the user, available for “personal_details”, “passport”, “driver_license”, “identity_card”, “internal_passport” and “address” types. Can be decrypted and verified using the accompanying EncryptedCredentials.
		/// </summary>
		[DataMember(Name = "data", EmitDefaultValue = false)]
		public string data { get; set; }
		/// <summary>
		/// Optional. User's verified phone number, available only for “phone_number” type
		/// </summary>
		[DataMember(Name = "phone_number", EmitDefaultValue = false)]
		public string phone_number { get; set; }
		/// <summary>
		/// Optional. User's verified email address, available only for “email” type
		/// </summary>
		[DataMember(Name = "email", EmitDefaultValue = false)]
		public string email { get; set; }
		/// <summary>
		/// Optional. Array of encrypted files with documents provided by the user, available for “utility_bill”, “bank_statement”, “rental_agreement”, “passport_registration” and “temporary_registration” types. Files can be decrypted and verified using the accompanying EncryptedCredentials.
		/// </summary>
		[DataMember(Name = "files", EmitDefaultValue = false)]
		public Array<PassportFile> files { get; set; }
		/// <summary>
		/// Optional. Encrypted file with the front side of the document, provided by the user. Available for “passport”, “driver_license”, “identity_card” and “internal_passport”. The file can be decrypted and verified using the accompanying EncryptedCredentials.
		/// </summary>
		[DataMember(Name = "front_side", EmitDefaultValue = false)]
		public PassportFile front_side { get; set; }
		/// <summary>
		/// Optional. Encrypted file with the reverse side of the document, provided by the user. Available for “driver_license” and “identity_card”. The file can be decrypted and verified using the accompanying EncryptedCredentials.
		/// </summary>
		[DataMember(Name = "reverse_side", EmitDefaultValue = false)]
		public PassportFile reverse_side { get; set; }
		/// <summary>
		/// Optional. Encrypted file with the selfie of the user holding a document, provided by the user; available for “passport”, “driver_license”, “identity_card” and “internal_passport”. The file can be decrypted and verified using the accompanying EncryptedCredentials.
		/// </summary>
		[DataMember(Name = "selfie", EmitDefaultValue = false)]
		public PassportFile selfie { get; set; }
		/// <summary>
		/// Optional. Array of encrypted files with translated versions of documents provided by the user. Available if requested for “passport”, “driver_license”, “identity_card”, “internal_passport”, “utility_bill”, “bank_statement”, “rental_agreement”, “passport_registration” and “temporary_registration” types. Files can be decrypted and verified using the accompanying EncryptedCredentials.
		/// </summary>
		[DataMember(Name = "translation", EmitDefaultValue = false)]
		public Array<PassportFile> translation { get; set; }
		/// <summary>
		/// Base64-encoded element hash for using in PassportElementErrorUnspecified
		/// </summary>
		[DataMember(Name = "hash", IsRequired = true)]
		public string hash { get; set; }
	}
}
