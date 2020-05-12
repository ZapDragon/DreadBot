using System;
using System.Collections.Generic;
using System.Linq;
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
}
