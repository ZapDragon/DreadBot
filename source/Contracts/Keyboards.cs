using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DreadBot
{
    public static class KeyboardExtentions
    {
        [Obsolete("setRowCount is unused. Please update your plugins to not use this method.")]
        public static void SetRowCount(this InlineKeyboardMarkup source, int x)
        {
            source.initRows(x);
        }
        [Obsolete("addButton is deprecated, use one of the available add___Button's instead.")]
        public static void addButton(this InlineKeyboardMarkup source, InlineKeyboardButton button, int row)
        {
            source.initRows(row);
            source.inline_keyboard[row].Add(button);
        }
        public static void addUrlButton(this InlineKeyboardMarkup source, string Text, string Url, int row)
        {
            source.initRows(row);
            InlineKeyboardButton button = new InlineKeyboardButton() { text = Text, url = Url };
            source.inline_keyboard[row].Add(button);
        }
        public static void addLoginButton(this InlineKeyboardMarkup source, string Text, LoginUrl Url, int row)
        {
            source.initRows(row);
            InlineKeyboardButton button = new InlineKeyboardButton() { text = Text, login_url = Url };
            source.inline_keyboard[row].Add(button);
        }
        public static void addCallbackButton(this InlineKeyboardMarkup source, string Text, string Callback, int row)
        {
            source.initRows(row);
            InlineKeyboardButton button = new InlineKeyboardButton() { text = Text, callback_data = Callback };
            source.inline_keyboard[row].Add(button);
        }
        public static void addSIQButton(this InlineKeyboardMarkup source, string Text, string siq, int row)
        {
            source.initRows(row);
            InlineKeyboardButton button = new InlineKeyboardButton() { text = Text, switch_inline_query = siq };
            source.inline_keyboard[row].Add(button);
        }
        public static void addSIQCCButton(this InlineKeyboardMarkup source, string Text, string siq, int row)
        {
            source.initRows(row);
            InlineKeyboardButton button = new InlineKeyboardButton() { text = Text, switch_inline_query_current_chat = siq };
            source.inline_keyboard[row].Add(button);
        }
        public static void addGameButton(this InlineKeyboardMarkup source, string Text, CallbackGame game, int row)
        {
            source.initRows(row);
            InlineKeyboardButton button = new InlineKeyboardButton() { text = Text, callback_game = game };
            source.inline_keyboard[row].Add(button);
        }
        public static void addPayButton(this InlineKeyboardMarkup source, string Text)
        {
            source.initRows(0);
            InlineKeyboardButton button = new InlineKeyboardButton() { text = Text, pay = true };
            source.inline_keyboard[0].Insert(0, button);

        }
        private static void initRows(this InlineKeyboardMarkup source, int row)
        {
            for (int i = ((row - source.inline_keyboard.Count) + 1); i > 0; i--)
            {
                source.inline_keyboard.Add(new List<InlineKeyboardButton>(8));
            }
        }
    }


    [DataContract]
    public class ReplyKeyboardMarkup
    {
        [DataMember(Name = "keyboard")]
        public KeyboardButton[][] keyboard { get; set; }

        [DataMember(Name = "resize_keyboard", IsRequired = false)]
        public bool resize_keyboard { get; set; }

        [DataMember(Name = "one_time_keyboard", IsRequired = false)]
        public bool one_time_keyboard { get; set; }

        [DataMember(Name = "selective", IsRequired = false)]
        public bool selective { get; set; }
    }

    [DataContract]
    public class KeyboardButton
    {
        [DataMember(Name = "text")]
        public string text { get; set; }

        [DataMember(Name = "request_contact", IsRequired = false)]
        public bool request_contact { get; set; }

        [DataMember(Name = "request_location", IsRequired = false)]
        public bool request_location { get; set; }
    }

    [DataContract]
    public class ReplyKeyboardRemove
    {
        [DataMember(Name = "remove_keyboard")]
        public bool remove_keyboard { get; set; }

        [DataMember(Name = "selective", IsRequired = false)]
        public bool selective { get; set; }
    }

    [DataContract]
    public class InlineKeyboardMarkup
    {
        [DataMember(Name = "inline_keyboard")]
        public List<List<InlineKeyboardButton>> inline_keyboard { get; set; } = new List<List<InlineKeyboardButton>>(100);
    }

    [DataContract]
    public class InlineKeyboardButton
    {
        [DataMember(Name = "text")]
        public string text { get; set; }

        [DataMember(Name = "url", EmitDefaultValue = false, IsRequired = false)]
        public string url { get; set; }

        [DataMember(Name = "login_url", EmitDefaultValue = false, IsRequired = false)]
        public LoginUrl login_url { get; set; }

        [DataMember(Name = "callback_data", EmitDefaultValue = false, IsRequired = false)]
        public string callback_data { get; set; }

        [DataMember(Name = "switch_inline_query", EmitDefaultValue = false, IsRequired = false)]
        public string switch_inline_query { get; set; }

        [DataMember(Name = "switch_inline_query_current_chat", EmitDefaultValue = false, IsRequired = false)]
        public string switch_inline_query_current_chat { get; set; }

        [DataMember(Name = "callback_game", EmitDefaultValue = false, IsRequired = false)]
        public CallbackGame callback_game { get; set; }

        [DataMember(Name = "pay", EmitDefaultValue = false, IsRequired = false)]
        public bool pay { get; set; }
    }



}
