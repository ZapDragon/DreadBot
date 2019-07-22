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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreadBot
{
    class Menus
    {
        internal static void ButtonPush(CallbackQuery callback)
        {
            string arg = callback.data.Split(' ')[1];

            switch (arg)
            {
                case "botadm": {
                        Methods.answerCallbackQuery(callback.id);
                        string text = "*DreadBot Managment Options*\n\nThese options are for the bot owner only (you) and are critical settings for the operation of your bot. Use these settings with care. All of these settings take immediate effect.\n\n`Sensitive Options`\nThese settings control very low level settings. Such as how often the bot will request new messages, how long it should wait when asking for new messages, and even setting up webhook, and more!\n\n`Add/Remove Bot Admins`\nIn the event you want to grant others control voer the bot, manage who can use it, and what control they have over it, you can use this menu.\n\n`Debug Chat Settings`\nBy Default, the \"Debug Chat\" is PM between you and the bot. These settings let you use a group instead, as well as control what options can be set from this group. This can really help if you are tired of getting Debug messages in PM.";
                        Methods.editMessageText(callback.from.id, callback.message.message_id, text, "markdown", ManagmentMenu());
                        return;
                    }
                case "dbadm": { return; }
                case "plugadm": {
                        Methods.answerCallbackQuery(callback.id);
                        InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup();
                        int r = 0; //Row number counter
                        string text = "*Plugin Manager*\n\nSeems you dont have any plugins.\nCheck the online DreadBot Respository to see whats availible!";
                        if (PluginManager.plugins.Count == 0) { keyboard.SetRowCount(2); }
                        else if (PluginManager.plugins.Count == 1)
                        {
                            keyboard.SetRowCount(3);
                            string pluginId = PluginManager.plugins.First().Key;
                            keyboard.addButton(new InlineKeyboardButton() { text = pluginId, callback_data = pluginId + " info" }, 0);
                            keyboard.addButton(new InlineKeyboardButton() { text = "Manage Plugin", callback_data = pluginId + " manage" }, 0);
                            r++;
                        }
                        else if (PluginManager.plugins.Count > 1)
                        {
                            keyboard.SetRowCount(PluginManager.plugins.Count + 2);
                            foreach (string pluginId in PluginManager.plugins.Keys)
                            {
                                keyboard.addButton(new InlineKeyboardButton() { text = pluginId, callback_data = pluginId + " info" }, r);
                                keyboard.addButton(new InlineKeyboardButton() { text = "Manage Plugin", callback_data = pluginId + " manage" }, r);
                                r++;
                            }

                        }

                        keyboard.addButton(new InlineKeyboardButton() { text = "📡 Browse Plugin Repo", callback_data = "dreadbot plugrepo" }, r);
                        r++;
                        keyboard.addButton(new InlineKeyboardButton() { text = "🔙", callback_data = "dreadbot adm" }, r);
                        if (r > 1) { text = "*Plugin Manager*\n\nHere you manage your current plugins.\nClick the name of the plugin for basic info about it.\nOr click manage to configure it."; }
                        Result<object> res = Methods.editMessageText(callback.from.id, callback.message.message_id, text, "markdown", keyboard);
                        if (!res.ok) { Logger.LogError("Message failed to edit: " + res.description); }
                        return;
                    }
                case "adm": {
                        Methods.answerCallbackQuery(callback.id);
                        //OldMenus(arg, callback.from.id, callback.message.message_id);
                        return;
                    }
                case "tuneables": { return; }
                case "botadmins": { return; }
                case "debugchatcfg": {
                        Methods.answerCallbackQuery(callback.id);
                        string text = "*Debug Chat Settings*\n\nHere you can configure the Debug Chat. This is used by the bot as a good testing grounds, somewhere to dump errors for all Bot Admins to see, admin commands and more.\n\n`Toggle Debug Chat Commands`\nEnable Bot Admin commands for use within the Debug Chat. Its very useful for troubleshooting, and testing.\n\n`Change Debug Chat`\nThis is what you use to change the Debug to a Group, Supergroup, or back to Private (Bot Owner only).\n\n`Set the Debug Chat Log Level`\nHere you can set how verbose the bot is with its error reporting in the Debug Chat. We recommend atleast [Warn] Level.";
                        Methods.editMessageText(callback.from.id, callback.message.message_id, text, "markdown", DebugChatCfg());
                        return;
                    }
                case "debugchatlevel":
                    {
                        Methods.answerCallbackQuery(callback.id);
                        string text = "*Log Level Configuration*\n\nHere you can set the desired log level of the Console and the Log File.\n\nThe right column is for the Console.\nThe left side is for the log File. (it is log.txt and is off by default.)\n\nWe strongly recommend the console log level be no lower than *WARN* as some of this information can be important to resolve problems.";
                        Methods.editMessageText(callback.from.id, callback.message.message_id, text, "markdown", LogLevelMenu());
                        return;
                    }
                case "resetdebug": {

                        string text = "";
                        if (Configs.RunningConfig.Owner != Configs.RunningConfig.AdminChat)
                        {
                            text = "Debug chat has been reset to PM.";
                            Configs.RunningConfig.AdminChat = callback.from.id;
                        }
                        else { text = "Debug chat is already set to PM."; }
                        Methods.answerCallbackQuery(callback.id, text, true);
                        return;

                    }
                case "changedebugchat":
                    {
                        Methods.answerCallbackQuery(callback.id);
                        string text = "*Debug Chat Location Setting*\n\nHere you can resttore the settings for where the bot sends Debug messages. To set a Debug Group, add me to a group, and perform /setdebug and I will use that group for debug output.\n\n`Reset Debug Chat to Private`\nAs the buttons states, this will reset the location of debug messages to PM with you.";
                        Methods.editMessageText(callback.from.id, callback.message.message_id, text, "markdown", ChangeDebugChat());
                        return;
                    }
            }
        }

        #region Menu Methods

        internal static InlineKeyboardMarkup AdminMenu()
        {
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup();
            keyboard.SetRowCount(3);
            keyboard.addButton(new InlineKeyboardButton() { text = "🎛 DreadBot Managment", callback_data = "dreadbot botadm" }, 0);
            keyboard.addButton(new InlineKeyboardButton() { text = "🗄 DataBase Managment", callback_data = "dreadbot dbadm" }, 1);
            keyboard.addButton(new InlineKeyboardButton() { text = "⚡️ Plugin Manager", callback_data = "dreadbot plugadm" }, 2);
            return keyboard;
        }

        internal static InlineKeyboardMarkup ManagmentMenu()
        {
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup();
            keyboard.SetRowCount(4);
            keyboard.addButton(new InlineKeyboardButton() { text = "🔥 Sensitive Options", callback_data = "dreadbot tuneables" }, 0);
            keyboard.addButton(new InlineKeyboardButton() { text = "👮‍♂️ Add/Remove Bot Admins", callback_data = "dreadbot botadmins" }, 1);
            keyboard.addButton(new InlineKeyboardButton() { text = "🗒 Debug Chat Settings", callback_data = "dreadbot debugchatcfg" }, 2);
            keyboard.addButton(new InlineKeyboardButton() { text = "🔙", callback_data = "dreadbot adm" }, 3);
            return keyboard;
        }

        internal static InlineKeyboardMarkup ChangeDebugChat()
        {
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup();
            keyboard.SetRowCount(2);
            keyboard.addButton(new InlineKeyboardButton() { text = "Reset Debug Chat to Private", callback_data = "dreadbot resetdebug" }, 0);
            keyboard.addButton(new InlineKeyboardButton() { text = "🔙", callback_data = "dreadbot debugchatcfg" }, 1);
            return keyboard;
        }

        internal static InlineKeyboardMarkup LogLevelMenu()
        {
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup();
            keyboard.SetRowCount(8);
            keyboard.addButton(new InlineKeyboardButton() { text = "File LogLevel - Debug " + GetLogLevel(LogLevel.Debug, false), callback_data = "dreadbot fll 6" }, 0);
            keyboard.addButton(new InlineKeyboardButton() { text = "Console LogLevel - Debug " + GetLogLevel(LogLevel.Debug), callback_data = "dreadbot cll 6" }, 0);

            keyboard.addButton(new InlineKeyboardButton() { text = "File LogLevel - Admin " + GetLogLevel(LogLevel.Admin, false), callback_data = "dreadbot fll 5" }, 1);
            keyboard.addButton(new InlineKeyboardButton() { text = "Console LogLevel - Admin " + GetLogLevel(LogLevel.Admin), callback_data = "dreadbot cll 5" }, 1);

            keyboard.addButton(new InlineKeyboardButton() { text = "File LogLevel - Info " + GetLogLevel(LogLevel.Info, false), callback_data = "dreadbot fll 4" }, 2);
            keyboard.addButton(new InlineKeyboardButton() { text = "Console LogLevel - Info " + GetLogLevel(LogLevel.Info), callback_data = "dreadbot cll 4" }, 2);

            keyboard.addButton(new InlineKeyboardButton() { text = "File LogLevel - Warn " + GetLogLevel(LogLevel.Warn, false), callback_data = "dreadbot fll 3" }, 3);
            keyboard.addButton(new InlineKeyboardButton() { text = "Console LogLevel - Warn " + GetLogLevel(LogLevel.Warn), callback_data = "dreadbot cll 3" }, 3);

            keyboard.addButton(new InlineKeyboardButton() { text = "File LogLevel - Error " + GetLogLevel(LogLevel.Error, false), callback_data = "dreadbot fll 2" }, 4);
            keyboard.addButton(new InlineKeyboardButton() { text = "Console LogLevel - Error " + GetLogLevel(LogLevel.Error), callback_data = "dreadbot cll 2" }, 4);

            keyboard.addButton(new InlineKeyboardButton() { text = "File LogLevel - Fatal " + GetLogLevel(LogLevel.Fatal, false), callback_data = "dreadbot fll 1" }, 5);
            keyboard.addButton(new InlineKeyboardButton() { text = "Console LogLevel - Fatal " + GetLogLevel(LogLevel.Fatal), callback_data = "dreadbot cll 1" }, 5);

            keyboard.addButton(new InlineKeyboardButton() { text = "File LogLevel - Off " + GetLogLevel(LogLevel.Off, false), callback_data = "dreadbot fll 0" }, 6);
            keyboard.addButton(new InlineKeyboardButton() { text = "Console LogLevel - Off " + GetLogLevel(LogLevel.Off), callback_data = "dreadbot cll 0" }, 6);

            keyboard.addButton(new InlineKeyboardButton() { text = "🔙", callback_data = "dreadbot debugchatcfg" }, 7);

            return keyboard;
        }

        internal static InlineKeyboardMarkup DebugChatCfg()
        {
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup();
            keyboard.SetRowCount(3);
            keyboard.addButton(new InlineKeyboardButton() { text = "🧾 Change Debug Chat", callback_data = "dreadbot changedebugchat" }, 0);
            keyboard.addButton(new InlineKeyboardButton() { text = "🔕 Set Debug Chat Log Level", callback_data = "dreadbot debugchatlevel" }, 1);
            keyboard.addButton(new InlineKeyboardButton() { text = "🔙", callback_data = "dreadbot botadm" }, 2);
            return keyboard;
        }
        internal static InlineKeyboardMarkup PluginMgr()
        {
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup();

            return keyboard;

        }

        #endregion

        internal static string GetLogLevel(LogLevel level, bool console = true)
        {
            if (console)
            {
                if (Logger.CurrentConsoleLevel == level) { return "⬅️"; }
            }
            else
            {
                if (Logger.CurrentLogLevel == level) { return "⬅️"; }
            }
            return "";
        }
    }
}
