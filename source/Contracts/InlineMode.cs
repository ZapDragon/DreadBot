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
    public class InlineQuery
    {
        [DataMember(Name = "id")]
        public string id { get; set; }

        [DataMember(Name = "from")]
        public User from { get; set; }

        [DataMember(Name = "location", IsRequired = false)]
        public Location location { get; set; }

        [DataMember(Name = "query")]
        public string query { get; set; }

        [DataMember(Name = "offset")]
        public string offset { get; set; }
    }

    
    #region Inline Query Result Types
    [DataContract]
    public class InlineQueryResult
    {
        [DataMember(Name = "type")]
        public string type { get; set; }

        [DataMember(Name = "id")]
        public string id { get; set; }
    }

    [DataContract]
    public class InlineQueryResultArticle : InlineQueryResult
    {


        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "input_message_content")]
        public InputMessageContent input_message_content { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "url", IsRequired = false)]
        public string url { get; set; }

        [DataMember(Name = "hide_url", IsRequired = false)]
        public bool hide_url { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "thumb_url", IsRequired = false)]
        public string thumb_url { get; set; }

        [DataMember(Name = "thumb_width", IsRequired = false)]
        public int thumb_width { get; set; }

        [DataMember(Name = "thumb_height", IsRequired = false)]
        public int thumb_height { get; set; }
    }

    [DataContract]
    public class InlineQueryResultPhoto : InlineQueryResult
    {
        [DataMember(Name = "photo_url")]
        public string photo_url { get; set; }

        [DataMember(Name = "thumb_url")]
        public string thumb_url { get; set; }

        [DataMember(Name = "photo_width", IsRequired = false)]
        public int photo_width { get; set; }

        [DataMember(Name = "photo_height", IsRequired = false)]
        public int photo_height { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        public string title { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultGif : InlineQueryResult
    {

        [DataMember(Name = "gif_url")]
        public string gif_url { get; set; }

        [DataMember(Name = "gif_width", IsRequired = false)] //InlineQueryResultCachedMpeg4Gif
        public int gif_width { get; set; }

        [DataMember(Name = "gif_height", IsRequired = false)]
        public int gif_height { get; set; }

        [DataMember(Name = "gif_duration", IsRequired = false)]
        public int gif_duration { get; set; }

        [DataMember(Name = "thumb_url")]
        public string thumb_url { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        public string title { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultMpeg4Gif : InlineQueryResult
    {
        public string id { get; set; }

        [DataMember(Name = "mpeg4_url")]
        public string mpeg4_url { get; set; }

        [DataMember(Name = "mpeg4_width", IsRequired = false)] //InlineQueryResultCachedMpeg4Gif
        public int mpeg4_width { get; set; }

        [DataMember(Name = "mpeg4_height", IsRequired = false)]
        public int mpeg4_height { get; set; }

        [DataMember(Name = "mpeg4_duration", IsRequired = false)]
        public int mpeg4_duration { get; set; }

        [DataMember(Name = "thumb_url")]
        public string thumb_url { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        public string title { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultVideo : InlineQueryResult
    {

        [DataMember(Name = "video_url")]
        public string video_url { get; set; }

        [DataMember(Name = "mime_type")]
        public string mime_type { get; set; }

        [DataMember(Name = "thumb_url")]
        public string thumb_url { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "video_width", IsRequired = false)]
        public int video_width { get; set; }

        [DataMember(Name = "video_height", IsRequired = false)]
        public int video_height { get; set; }

        [DataMember(Name = "video_duration", IsRequired = false)]
        public int video_duration { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultAudio : InlineQueryResult
    {
        [DataMember(Name = "audio_url")]
        public string audio_url { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "performer", IsRequired = false)]
        public string performer { get; set; }

        [DataMember(Name = "audio_duration", IsRequired = false)]
        public int audio_duration { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultVoice : InlineQueryResult
    {
        [DataMember(Name = "voice_url")]
        public string voice_url { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "voice_duration", IsRequired = false)]
        public int voice_duration { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultDocument : InlineQueryResult
    {

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "document_url")]
        public string document_url { get; set; }

        [DataMember(Name = "mime_type")]
        public string mime_type { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }

        [DataMember(Name = "thumb_url", IsRequired = false)]
        public string thumb_url { get; set; }

        [DataMember(Name = "thumb_width", IsRequired = false)]
        public int thumb_width { get; set; }

        [DataMember(Name = "thumb_height", IsRequired = false)]
        public int thumb_height { get; set; }
    }

    [DataContract]
    public class InlineQueryResultLocation : InlineQueryResult
    {

        [DataMember(Name = "latitude")]
        public float latitude { get; set; }

        [DataMember(Name = "longitude")]
        public float longitude { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "live_period", IsRequired = false)]
        public int live_period { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }

        [DataMember(Name = "thumb_url", IsRequired = false)]
        public string thumb_url { get; set; }

        [DataMember(Name = "thumb_width", IsRequired = false)]
        public int thumb_width { get; set; }

        [DataMember(Name = "thumb_height", IsRequired = false)]
        public int thumb_height { get; set; }
    }

    [DataContract]
    public class InlineQueryResultVenue : InlineQueryResult
    {
        [DataMember(Name = "latitude")]
        public float latitude { get; set; }

        [DataMember(Name = "longitude")]
        public float longitude { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "address")]
        public string address { get; set; }

        [DataMember(Name = "foursquare_id", IsRequired = false)]
        public string foursquare_id { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }

        [DataMember(Name = "thumb_url", IsRequired = false)]
        public string thumb_url { get; set; }

        [DataMember(Name = "thumb_width", IsRequired = false)]
        public int thumb_width { get; set; }

        [DataMember(Name = "thumb_height", IsRequired = false)]
        public int thumb_height { get; set; }
    }

    [DataContract]
    public class InlineQueryResultContact : InlineQueryResult
    {

        [DataMember(Name = "phone_number")]
        public string phone_number { get; set; }

        [DataMember(Name = "first_name")]
        public string first_name { get; set; }

        [DataMember(Name = "last_name", IsRequired = false)]
        public string last_name { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }

        [DataMember(Name = "thumb_url", IsRequired = false)]
        public string thumb_url { get; set; }

        [DataMember(Name = "thumb_width", IsRequired = false)]
        public int thumb_width { get; set; }

        [DataMember(Name = "thumb_height", IsRequired = false)]
        public int thumb_height { get; set; }
    }

    [DataContract]
    public class InlineQueryResultGame : InlineQueryResult
    {
        [DataMember(Name = "game_short_name")]
        public string game_short_name { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }
    }

    [DataContract]
    public class InlineQueryResultCachedPhoto : InlineQueryResult
    {
        [DataMember(Name = "photo_file_id")]
        public string photo_file_id { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        public string title { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultCachedGif : InlineQueryResult
    {
        [DataMember(Name = "gif_file_id")]
        public string gif_file_id { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        public string title { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultCachedMpeg4Gif : InlineQueryResult
    {
        [DataMember(Name = "mpeg4_file_id")]
        public string mpeg4_file_id { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        public string title { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultCachedSticker : InlineQueryResult
    {
        [DataMember(Name = "sticker_file_id")]
        public string sticker_file_id { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }


    }

    [DataContract]
    public class InlineQueryResultCachedDocument : InlineQueryResult
    {
        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "document_file_id")]
        public string document_file_id { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultCachedVideo : InlineQueryResult
    {
        [DataMember(Name = "video_file_id")]
        public string video_file_id { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "description", IsRequired = false)]
        public string description { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultCachedVoice : InlineQueryResult
    {
        [DataMember(Name = "voice_file_id")]
        public string voice_file_id { get; set; }

        [DataMember(Name = "title")]
        public string title { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }

    [DataContract]
    public class InlineQueryResultCachedAudio : InlineQueryResult
    {
        [DataMember(Name = "audio_file_id")]
        public string audio_file_id { get; set; }

        [DataMember(Name = "caption", IsRequired = false)]
        public string caption { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "reply_markup", IsRequired = false)]
        public InlineKeyboardMarkup reply_markup { get; set; }

        [DataMember(Name = "input_message_content", IsRequired = false)]
        public InputMessageContent input_message_content { get; set; }
    }


    #endregion

    //TO DO: Figure This BS out. Not touched after consolidation.
    #region InputMessageContent Types

    [DataContract]
    public class InputMessageContent
    {
        //This is a mess.
        // No fields are specified in the documentation for this, but is allegedly supposed to be an array of results which can be one or several differnet Types entirely.
    }

    [DataContract]
    public class InputTextMessageContent
    {
        [DataMember(Name = "message_text")]
        public string message_text { get; set; }

        [DataMember(Name = "parse_mode", IsRequired = false)]
        public string parse_mode { get; set; }

        [DataMember(Name = "disable_web_page_preview", IsRequired = false)]
        public bool disable_web_page_preview { get; set; }
    }

    [DataContract]
    public class InputLocationMessageContent
    {
        [DataMember(Name = "latitude")]
        public float latitude { get; set; }

        [DataMember(Name = "longitude")]
        public float longitude { get; set; }

        [DataMember(Name = "live_period", IsRequired = false)]
        public int live_period { get; set; }
    }

    [DataContract]
    public class InputVenueMessageContent
    {
        [DataMember(Name = "latitude")]
        public float latitude { get; set; }

        [DataMember(Name = "longitude")]
        public float longitude { get; set; }

        [DataMember(Name = "title", IsRequired = false)]
        public string title { get; set; }

        [DataMember(Name = "address")]
        public string address { get; set; }

        [DataMember(Name = "foursquare_id", IsRequired = false)]
        public string foursquare_id { get; set; }
    }

    [DataContract]
    public class InputContactMessageContent
    {
        [DataMember(Name = "phone_number")]
        public string phone_number { get; set; }

        [DataMember(Name = "first_name")]
        public string first_name { get; set; }

        [DataMember(Name = "last_name", IsRequired = false)]
        public string last_name { get; set; }
    }

    #endregion

    [DataContract]
    public class ChosenInlineResult
    {
        [DataMember(Name = "result_id")]
        public string result_id { get; set; }

        [DataMember(Name = "from")]
        public User from { get; set; }

        [DataMember(Name = "location", IsRequired = false)]
        public Location location { get; set; }

        [DataMember(Name = "inline_message_id", IsRequired = false)]
        public string inline_message_id { get; set; }

        [DataMember(Name = "query")]
        public string query { get; set; }
    }
}
