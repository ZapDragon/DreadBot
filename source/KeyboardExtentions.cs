using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreadBot
{
    static class KeyboardExtentions
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
}
