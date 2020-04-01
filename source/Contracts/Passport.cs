#region License
//MIT License
//Copyright(c) [2019]
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
    [DataContract]
    public class PassportData
    {
        [DataMember(Name = "data")]
        public EncryptedPassportElement[] data { get; set; }

        [DataMember(Name = "credentials")]
        public EncryptedCredentials credentials { get; set; }

    }

    [DataContract]
    public class PassportFile
    {
        [DataMember(Name = "file_id")]
        public string file_id { get; set; }

        [DataMember(Name = "file_size")]
        public int file_size { get; set; }

        [DataMember(Name = "file_date")]
        public int file_date { get; set; }
    }

    [DataContract]
    public class EncryptedPassportElement
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "data", IsRequired = false)]
        public string data { get; set; }

        [DataMember(Name = "phone_number", IsRequired = false)]
        public string phone_number { get; set; }

        [DataMember(Name = "email", IsRequired = false)]
        public string email { get; set; }

        [DataMember(Name = "files", IsRequired = false)]
        public PassportFile[] files { get; set; }

        [DataMember(Name = "front_side", IsRequired = false)]
        public PassportFile front_side { get; set; }

        [DataMember(Name = "reverse_side", IsRequired = false)]
        public PassportFile reverse_side { get; set; }

        [DataMember(Name = "selfie", IsRequired = false)]
        public PassportFile selfie { get; set; }

        [DataMember(Name = "translation", IsRequired = false)]
        public PassportFile[] translation { get; set; }

        [DataMember(Name = "hash")]
        public string hash { get; set; }
    }

    [DataContract]
    public class EncryptedCredentials
    {
        [DataMember(Name = "data")]
        public string data { get; set; }

        [DataMember(Name = "hash")]
        public string hash { get; set; }

        [DataMember(Name = "secret")]
        public string secret { get; set; }
    }

    [DataContract]
    public class PassportScope
    {
        [DataMember(Name = "data")]
        public PassportScopeElement[] data { get; set; }

        [DataMember(Name = "v")]
        public int v { get; set; }
    }

    [DataContract]
    public class PassportScopeElement
    {

        [DataMember(Name = "selfie", IsRequired = false)]
        public bool selfie { get; set; }
        [DataMember(Name = "translation", IsRequired = false)]
        public bool translation { get; set; }
    }

    [DataContract]
    public class PassportScopeElementOneOfSeveral : PassportScopeElement
    {

        [DataMember(Name = "one_of")]
        public PassportScopeElementOne[] one_of { get; set; }
    }

    [DataContract]
    public class PassportScopeElementOne
    {

        [DataMember(Name = "type")]
        public string type { get; set; }
        [DataMember(Name = "native_names", IsRequired = false)]
        public bool native_names { get; set; }
    }

    [DataContract]
    public class PersonalDetails
    {
        [DataMember(Name = "first_name")]
        public string first_name { get; set; }

        [DataMember(Name = "last_name")]
        public string last_name { get; set; }

        [DataMember(Name = "middle_name")]
        public string middle_name { get; set; }

        [DataMember(Name = "birth_date")]
        public string birth_date { get; set; }

        [DataMember(Name = "gender")]
        public string gender { get; set; }

        [DataMember(Name = "country_code")]
        public string country_code { get; set; }

        [DataMember(Name = "residence_country_code")]
        public string residence_country_code { get; set; }

        [DataMember(Name = "first_name_native")]
        public string first_name_native { get; set; }

        [DataMember(Name = "last_name_native")]
        public string last_name_native { get; set; }

        [DataMember(Name = "middle_name_native")]
        public string middle_name_native { get; set; }
    }

    [DataContract]
    public class IdDocumentData
    {
        [DataMember(Name = "document_no")]
        public string document_no { get; set; }

        [DataMember(Name = "expiry_date")]
        public string expiry_date { get; set; }

    }

    [DataContract]
    public class ResidentialAddress
    {

        [DataMember(Name = "street_line1")]
        public string street_line1 { get; set; }

        [DataMember(Name = "street_line2")]
        public string street_line2 { get; set; }

        [DataMember(Name = "city")]
        public string city { get; set; }

        [DataMember(Name = "state")]
        public string state { get; set; }

        [DataMember(Name = "country_code")]
        public string country_code { get; set; }

        [DataMember(Name = "post_code")]
        public string post_code { get; set; }
    }

    [DataContract]
    public class Credentials
    {
        [DataMember(Name = "secure_data")]
        public SecureData secure_data { get; set; }

        [DataMember(Name = "nonce")]
        public string nonce { get; set; }
    }

    [DataContract]
    public class SecureData
    {
        [DataMember(Name = "personal_details")]
        public SecureValue personal_details { get; set; }

        [DataMember(Name = "passport")]
        public SecureValue passport { get; set; }

        [DataMember(Name = "internal_passport")]
        public SecureValue internal_passport { get; set; }

        [DataMember(Name = "driver_license")]
        public SecureValue driver_license { get; set; }

        [DataMember(Name = "identity_card")]
        public SecureValue identity_card { get; set; }

        [DataMember(Name = "address")]
        public SecureValue address { get; set; }

        [DataMember(Name = "utility_bill")]
        public SecureValue utility_bill { get; set; }

        [DataMember(Name = "bank_statement")]
        public SecureValue bank_statement { get; set; }

        [DataMember(Name = "rental_agreement")]
        public SecureValue rental_agreement { get; set; }

        [DataMember(Name = "passport_registration")]
        public SecureValue passport_registration { get; set; }

        [DataMember(Name = "temporary_registration")]
        public SecureValue temporary_registration { get; set; }
    }

    [DataContract]
    public class SecureValue
    {

        [DataMember(Name = "data")]
        public DataCredentials data { get; set; }

        [DataMember(Name = "front_side")]
        public FileCredentials front_side { get; set; }

        [DataMember(Name = "reverse_side")]
        public FileCredentials reverse_side { get; set; }

        [DataMember(Name = "selfie")]
        public FileCredentials selfie { get; set; }

        [DataMember(Name = "translation")]
        public FileCredentials[] translation { get; set; }

        [DataMember(Name = "files")]
        public FileCredentials[] files { get; set; }
    }

    [DataContract]
    public class DataCredentials
    {
        [DataMember(Name = "data_hash")]
        public string data_hash { get; set; }

        [DataMember(Name = "secret")]
        public string secret { get; set; }
    }

    [DataContract]
    public class FileCredentials
    {
        [DataMember(Name = "file_hash")]
        public string file_hash { get; set; }

        [DataMember(Name = "secret")]
        public string secret { get; set; }
    }
}
