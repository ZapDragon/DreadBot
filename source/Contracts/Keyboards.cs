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
        public static void SetRowCount(this KeyboardMarkup source, int x)
        {
            source.initRows(x);
        }
        [Obsolete("addButton is deprecated, use one of the available add___Button's instead.")]
        public static void addButton(this KeyboardMarkup source, InlineKeyboardButton button, int row)
        {
            source.initRows(row);
            source.Keyboard[row].Add(button);
        }
        public static void addUrlButton(this KeyboardMarkup source, string Text, string Url, int row)
        {
            source.initRows(row);
            InlineKeyboardButton button = new InlineKeyboardButton() { text = Text, url = Url };
            source.Keyboard[row].Add(button);
        }
        public static void addLoginButton(this KeyboardMarkup source, string Text, LoginUrl Url, int row)
        {
            source.initRows(row);
            InlineKeyboardButton button = new InlineKeyboardButton() { text = Text, login_url = Url };
            source.Keyboard[row].Add(button);
        }
        public static void addCallbackButton(this KeyboardMarkup source, string Text, string Callback, int row)
        {
            source.initRows(row);
            InlineKeyboardButton button = new InlineKeyboardButton() { text = Text, callback_data = Callback };
            source.Keyboard[row].Add(button);
        }
        public static void addSIQButton(this KeyboardMarkup source, string Text, string siq, int row)
        {
            source.initRows(row);
            InlineKeyboardButton button = new InlineKeyboardButton() { text = Text, switch_inline_query = siq };
            source.Keyboard[row].Add(button);
        }
        public static void addSIQCCButton(this KeyboardMarkup source, string Text, string siq, int row)
        {
            source.initRows(row);
            InlineKeyboardButton button = new InlineKeyboardButton() { text = Text, switch_inline_query_current_chat = siq };
            source.Keyboard[row].Add(button);
        }
        public static void addGameButton(this KeyboardMarkup source, string Text, CallbackGame game, int row)
        {
            source.initRows(row);
            InlineKeyboardButton button = new InlineKeyboardButton() { text = Text, callback_game = game };
            source.Keyboard[row].Add(button);
        }
        public static void addPayButton(this KeyboardMarkup source, string Text)
        {
            source.initRows(0);
            InlineKeyboardButton button = new InlineKeyboardButton() { text = Text, pay = true };
            source.Keyboard[0].Insert(0, button);

        }
        private static void initRows(this KeyboardMarkup source, int row)
        {
            for (int i = ((row - source.Keyboard.Count) + 1); i > 0; i--)
            {
                source.Keyboard.Add(new List<InlineKeyboardButton>(8));
            }
        }
    }
    [KnownType(typeof(ReplyKeyboardMarkup))]
    [KnownType(typeof(InlineKeyboardMarkup))]
    [DataContract]
    public class KeyboardMarkup
    {
        public List<List<InlineKeyboardButton>> Keyboard { get; set; }
    }

    [DataContract]
    public class ReplyKeyboardMarkup : KeyboardMarkup
    {
        [DataMember(Name = "keyboard")]
        public List<List<InlineKeyboardButton>> keyboard { get { return Keyboard; } set { Keyboard = value; } }

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
    public class InlineKeyboardMarkup : KeyboardMarkup
    {
        [DataMember(Name = "inline_keyboard")]
        public List<List<InlineKeyboardButton>> inline_keyboard { get { return Keyboard; } set { Keyboard = value; } }
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
