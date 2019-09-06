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
    public class Sticker
    {
        [DataMember(Name = "file_id")]
        public string file_id { get; set; }

        [DataMember(Name = "width")]
        public int width { get; set; }

        [DataMember(Name = "height")]
        public int height { get; set; }

        [DataMember(Name = "is_animated")]
        public bool is_animated { get; set; }

        [DataMember(Name = "thumb", IsRequired = false)]
        public PhotoSize thumb { get; set; }

        [DataMember(Name = "emoji", IsRequired = false)]
        public string emoji { get; set; }

        [DataMember(Name = "set_name", IsRequired = false)]
        public string set_name { get; set; }

        [DataMember(Name = "mask_position", IsRequired = false)]
        public MaskPosition mask_position { get; set; }

        [DataMember(Name = "file_size", IsRequired = false)]
        public int file_size { get; set; }
    }

    [DataContract]
    public class StickerSet
    {

        [DataMember(Name = "name")]
        public string name { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "is_animated")]
        public bool is_animated { get; set; }

        [DataMember(Name = "contains_masks")]
        public bool contains_masks { get; set; }

        [DataMember(Name = "stickers")]
        public Sticker[] stickers { get; set; }

    }

    [DataContract]
    public class MaskPosition
    {
        [DataMember(Name = "point")]
        public string point { get; set; }

        [DataMember(Name = "x_shift")]
        public float x_shift { get; set; }

        [DataMember(Name = "y_shift")]
        public float y_shift { get; set; }

        [DataMember(Name = "scale")]
        public float scale { get; set; }
    }
}
