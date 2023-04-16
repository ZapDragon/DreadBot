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
    public class Result<T>
    {
        [DataMember(Name = "ok")]
        public bool ok { get; set; }

        [DataMember(Name = "error_code", IsRequired = false)]
        public int errorCode { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "parameters", IsRequired = false)]
        public ResponseParameters parameters { get; set; }

        [DataMember(Name = "result", IsRequired = false)]
        public T result { get; set; }

        public static explicit operator Result<T>(Result<object> v)
        {
            return new Result<T>() { ok = v.ok, description = v.description, errorCode = v.errorCode, parameters = v.parameters, result = (T)v.result };
        }
    }

    #region DreadBot Plugin Service Objects

    [DataContract]
    public class PluginInfo
    {
        [DataMember(Name = "PluginName", IsRequired = true)]
        public string PluginName { get; set; }

        [DataMember(Name = "Description", IsRequired = true)]
        public string Description { get; set; }

        [DataMember(Name = "Tags", IsRequired = true)]
        public string[] Tags { get; set; }

        [DataMember(Name = "Dependencies", IsRequired = true)]
        public string[] Dependencies { get; set; }
    }

    #endregion
}
