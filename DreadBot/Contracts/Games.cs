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
    public class Game
    {
        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "description")]
        public string description { get; set; }

        [DataMember(Name = "photo")]
        public PhotoSize[] photo { get; set; }

        [DataMember(Name = "text", IsRequired = false)]
        public string text { get; set; }

        [DataMember(Name = "text_entities", IsRequired = false)]
        public MessageEntity[] text_entities { get; set; }

        [DataMember(Name = "animation", IsRequired = false)]
        public Animation animation { get; set; }
    }

    [DataContract]
    public class CallbackGame
    {
        //A placeholder, currently holds no information. Use @BotFather to set up your game.
    }

    [DataContract]
    public class GameHighScore
    {
        [DataMember(Name = "position")]
        public int position { get; set; }

        [DataMember(Name = "user")]
        public User user { get; set; }

        [DataMember(Name = "score")]
        public int score { get; set; }
    }
}
