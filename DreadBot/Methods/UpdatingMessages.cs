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
    partial class Methods
    {
        /// <summary>
        /// Sends a message to a Chat, Group, Channel, or User. Returns the Result<Message> object on success.
        /// </summary>
        /// <param name="chat_id">The Id number od the chat to send a message. Can be a User, Channel, Or group. Cannot be a bot.</param>
        /// <param name="message_id">The Id number od the chat to send a message. Required if inline_message_id is not specified. Identifier of the message to edit. Can be a User, Channel, Or group. Cannot be a bot.</param>
        /// <param name="inline_message_id">Required if chat_id and message_id are not specified. Identifier of the inline message.</param>
        /// <param name="text">The new text to of the Message. Character Limit of 4096.</param>
        /// <param name="parse_mode">Makrkdown, HTML, or Empty. Tells telegram how to parse special markdown flags in the text. Makrdown by default.</param>
        /// <param name="disable_web_page_preview">Disables link previews for links in this message.</param>
        /// <param name="keyboard">InlineKeyboardMarkup Object. Pass a built Keyboard object in here to include it in your messages.</param>
        /// <returns></returns>
        public static Result<object> editMessageText(long chat_id, long message_id, string text, string parse_mode = "markdown", InlineKeyboardMarkup keyboard = null) //Can apprently return a bool as well. 
        {
            EditMessageRequest smr = new EditMessageRequest()
            {
                chat_id = chat_id,
                message_id = message_id,
                text = text,
                parse_mode = parse_mode
            };

            if (keyboard != null) { smr.reply_markup = keyboard; }
            Result<object> result = null;
            try
            {
                result = sendRequest<object>(Method.editMessageText, buildRequest<EditMessageRequest>(smr));
                isOk(result);
                return result;
            }
            catch { Logger.LogWarn("Failed to Parse wrong datatype 1"); }
            return null;
        }

        public static Result<Message> editMessageCaption() //Can apprently return a bool as well. 
        {
            return null;
        }

        public static Result<Message> editMessageMedia() //Can apprently return a bool as well. 
        {
            return null;
        }

        public static Result<Message> editMessageReplyMarkup() //Can apprently return a bool as well. 
        {
            return null;
        }

        public static Result<Poll> stopPoll() //Can apprently return a bool as well. 
        {
            return null;
        }

        public static Result<bool> deleteMessage(long chat_id, long msg_id)
        {
            DeleteMessageRequest dmr = new DeleteMessageRequest()
            {
                chat_id = chat_id,
                msg_id = msg_id
            };

            Result<bool> result = null;

            result = sendRequest<bool>(Method.deleteMessage, buildRequest<DeleteMessageRequest>(dmr));
            isOk(result);
            return result;
        }
    }
}
