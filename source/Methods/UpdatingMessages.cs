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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreadBot
{
    public partial class Methods
    {
        /// <summary>
        /// Edit a message within a Chat, Group, Channel, or User. Returns the Result<Message> object on success, or Result<bool> if the edited message was the bot's</bool>.
        /// </summary>
        /// <param name="chat_id">The id number of the chat where the message to edit is. Can be a User, Channel, Or group. Cannot be a bot.</param>
        /// <param name="message_id">Identifier of the message to edit. Can be a User, Channel, Or group. Cannot be a bot.</param>
        /// <param name="inline_message_id">Required if chat_id and message_id are not specified. Identifier of the inline message.</param>
        /// <param name="text">The new text to of the Message. Character Limit of 4096.</param>
        /// <param name="parse_mode">Makrkdown, HTML, or Empty. Tells telegram how to parse special markdown flags in the text. Makrdown by default.</param>
        /// <param name="disable_web_page_preview">Disables link previews for links in this message.</param>
        /// <param name="keyboard">InlineKeyboardMarkup Object. Pass a built Keyboard object in here to include it in your messages.</param>
        /// <returns></returns>
        public static async Task<Result<object>> editMessageText(long chat_id, long message_id, string text, string parse_mode = "markdown", InlineKeyboardMarkup keyboard = null) //Can apprently return a bool as well. 
        {
            EditMessageTextRequest emr = new EditMessageTextRequest()
            {
                chat_id = chat_id,
                message_id = message_id,
                text = text,
                parse_mode = parse_mode
            };

            if (keyboard != null) { emr.reply_markup = keyboard; }
            try { return await sendRequest<object>(Method.editMessageText, buildRequest<EditMessageTextRequest>(emr)); }
            catch { Logger.LogWarn("Failed to Parse wrong datatype 1 EditMessageText()"); }
            return null;
        }
        /// <summary>
        /// Edit a photo caption within a Chat, Group, Channel, or User. Returns the Result<Message> object on success, or Result<bool> if the edited message was the bot's</bool>.
        /// </summary>
        /// <param name="chat_id">The Id number of the chat where the message to be edited is. Can be a User, Channel, Or group. Cannot be a bot.</param>
        /// <param name="message_id">Identifier of the caption to edit. Can be a User, Channel, Or group. Cannot be a bot.</param>
        /// <param name="inline_message_id">Required if chat_id and message_id are not specified. Identifier of the inline message.</param>
        /// <param name="caption">The new caption for the Image. Character Limit of 1024.</param>
        /// <param name="parse_mode">Makrkdown, HTML, or Empty. Tells telegram how to parse special markdown flags in the text. Makrdown by default.</param>
        /// <param name="keyboard">InlineKeyboardMarkup Object. Pass a built Keyboard object in here to include it in your messages.</param>
        /// <returns></returns>
        public static async Task<Result<object>> editMessageCaption(long chat_id, long message_id, string caption, string parse_mode = "markdown", InlineKeyboardMarkup keyboard = null) //Can apprently return a bool as well. 
        {
            EditMessageCaptionRequest emr = new EditMessageCaptionRequest()
            {
                chat_id = chat_id,
                message_id = message_id,
                caption = caption,
                parse_mode = parse_mode
            };

            if (keyboard != null) { emr.reply_markup = keyboard; }
            try { return await sendRequest<object>(Method.editMessageCaption, buildRequest<EditMessageCaptionRequest>(emr)); }
            catch { Logger.LogWarn("Failed to Parse wrong datatype 1 EditMessageText()"); }
            return null;
        }
        /// <summary>
        /// Use this method to edit animation, audio, document, photo, or video messages. If a message is a part of a message album, then it can be edited only to a photo or a video. Otherwise, message type can be changed arbitrarily. When inline message is edited, new file can't be uploaded. Use previously uploaded file via its file_id or specify a URL. On success, if the edited message was sent by the bot, returns Result<Message> object otherwise returns Result<bool> = true
        /// </summary>
        /// <param name="chat_id">The Id number od the chat where the image was sent. Can be a User, Channel, Or group. Cannot be a bot.</param>
        /// <param name="message_id">The id number of the Message containing the Photo to edit. Can be a User, Channel, Or group. Cannot be a bot.</param>
        /// <param name="inline_message_id">Required if chat_id and message_id are not specified. Identifier of the inline message.</param>
        /// <param name="caption">The new caption for the Image. Character Limit of 1024.</param>
        /// <param name="parse_mode">Makrkdown, HTML, or Empty. Tells telegram how to parse special markdown flags in the text. Makrdown by default.</param>
        /// <param name="keyboard">InlineKeyboardMarkup Object. Pass a built Keyboard object in here to include it in your messages.</param>
        /// <returns></returns>
        public static Result<Message> editMessageMedia() //Can apprently return a bool as well. 
        {
            return null;
        }

        public static async Task<Result<object>> editMessageReplyMarkup(long chat_id, long message_id, string inline_message_id = "", InlineKeyboardMarkup keyboard = null) //Can apprently return a bool as well. 
        {
            EditReplyMarkupRequest ermr = new EditReplyMarkupRequest()
            {
                chat_id = chat_id,
                message_id = message_id,
                //inline_message_id = inline_message_id,
                reply_markup = keyboard
            };

            try { return await sendRequest<object>(Method.editMessageReplyMarkup, buildRequest<EditReplyMarkupRequest>(ermr)); }
            catch { Logger.LogWarn("Edit Keyboard Failed " + chat_id); }
            return null;
        }

        public static Result<Poll> stopPoll() //Can apprently return a bool as well. 
        {
            return null;
        }

        public static async Task<Result<bool>> deleteMessage(long chat_id, long msg_id)
        {
            DeleteMessageRequest dmr = new DeleteMessageRequest(){ chat_id = chat_id, msg_id = msg_id };
            return await sendRequest<bool>(Method.deleteMessage, buildRequest<DeleteMessageRequest>(dmr));
        }
    }
}
