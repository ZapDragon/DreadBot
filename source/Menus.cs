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

namespace DreadBot
{
    class Menus
    {
        private const string CallbackBotManagement = "botadm";
        private const string CallbackDatabaseManagement = "dbadm";
        private const string CallbackPluginManagement = "plugadm";
        private const string CallbackSensitiveOptions = "tunables";
        private const string CallbackBotAdmins = "botadmins";
        private const string CallbackDebugChat = "debugchatcfg";
        private const string CallbackLogLevel = "debugchatlevel";
        private const string CallbackResetDebugChat = "resetdebug";
        private const string CallbackChangeDebugChat = "changedebugchat";
        private const string CallbackOperationMode = "operationmode";
        private const string CallbackWebhookDisable = "disablewebhook";
        private const string CallbackWebhookConfig = "webhookcfg";
        private const string CallbackShowToken = "showtoken";
        private const string CallbackChangeToken = "changetoken";
        private const string CallbackChangeOwner = "changeowner";
        private const string CallbackGetUpdatesLimit = "gulhelp";
        private const string CallbackGetUpdatesPlusSmall = "gula1";
        private const string CallbackGetUpdatesPlusLarge = "gula10";
        private const string CallbackGetUpdatesMinusSmall = "gulm1";
        private const string CallbackGetUpdatesMinusLarge = "gulm10";

        #region Button Event Logic

        internal static void ButtonPush(CallbackQuery callback)
        {
            string arg = callback.data.Split(' ')[1];

            switch (arg)
            {
                case CallbackBotManagement: {
                        Methods.answerCallbackQuery(callback.id);
                        string text = 
                            "*DreadBot Management Options*\n\n" +
                            
                            "These options are for the bot owner only (you) and are critical settings for the " +
                            "operation of your bot. Use these settings with care. All of these settings take " +
                            "immediate effect.\n\n" +
                            
                            "`Sensitive Options`\n" +
                            "These settings control very low level settings. Such as how often the bot will request " +
                            "new messages, setting up webhook, and more!\n\n" +
                            
                            "`Add/Remove Bot Admins`\n" +
                            "In the event you want to grant others control over the bot, manage who can use it, and " +
                            "what control they have over it, you can use this menu.\n\n" +
                            
                            "`Debug Chat Settings`\n" +
                            "By Default, the \"Debug Chat\" is PM between you and the bot. These settings let you " +
                            "use a group instead, as well as control what options can be set from this group. This " +
                            "can really help if you are tired of getting Debug messages in PM.\n\n" +
                            
                            "`System Sounds`\n" +
                            "This allows DreadBot to play custom sounds per events. You send DreadBot WAV/ MP3 Files " +
                            "to play to correlate to specific events.";
                        Methods.editMessageText(callback.from.id, callback.message.message_id, text, "markdown", ManagementMenu());
                        return;
                    }
                case CallbackSensitiveOptions: {

                        if (callback.from.id != Configs.RunningConfig.Owner)
                        {
                            Methods.answerCallbackQuery(callback.id, "You are not allowed to view these options.", true);
                            Logger.LogAdmin("User Attempted to access the Sensitive Options Menu.(" + callback.from.id + ") " + callback.from.first_name);
                            return;
                        }
                        else
                        {
                            Methods.answerCallbackQuery(callback.id);
                            string text = 
                                "*Sensitive Options*\n\n" +
                                
                                "These settings are VERY sensitive and alter how the bot will communicate with " +
                                "Telegram.\n" +
                                "Do not change these settings unless you are familiar with them!\n\n" +
                                
                                "`Show Access Token`\n" +
                                "This will display the access token that the bot is using.\n\n" +
                                
                                "`Change Access Token`\n" +
                                "This will allow you to change the access token and use a different bot account.\n" +
                                "*WARNING!* This can cause harmful side-effects to any database entries which " +
                                "plugins you have added are using.\n" +
                                "USE WITH CAUTION!\n\n" +
                                
                                "`Change Owner`\n" +
                                "This allows you to pass ownership of the bot to another Telegram user. Only the " +
                                "owner can use this button.\n\n" +
                                
                                "`Get Updates Limit`\n" +
                                "Using the + - buttons, you can change the number of updates " +
                                "the bot will ask for when it gets messages from Telegram.\n" +
                                "(Min 1 - Max 100 - Default 20)\n\n" +
                                
                                "`Bot Operation Mode`\n" +
                                "This allows you set change the bot's method of getting updates between getUpdates " +
                                "and WebHook. This can heavily impact the functionality of the bot and you shouldn't " +
                                "use it unless you know what you're doing.\n\n";

                            Methods.editMessageText(callback.from.id, callback.message.message_id, text, "markdown", SensitiveOptionsMenu());
                        }
                        return;
                    }
                case CallbackBotAdmins: { return; }
                case CallbackDebugChat: {
                        Methods.answerCallbackQuery(callback.id);
                        string text = 
                            "*Debug Chat Settings*\n\n" +
                            "Here you can configure the Debug Chat. This is used by the bot as a good testing " +
                            "grounds, somewhere to dump errors for all Bot Admins to see, admin commands and more.\n\n" +
                            "`Toggle Debug Chat Commands`\n" +
                            "Enable Bot Admin commands for use within the Debug Chat. It's very useful for " +
                            "troubleshooting, and testing.\n\n" +
                            "`Change Debug Chat`\n" +
                            "This is what you use to change " +
                            "the Debug Chat to a Group, Supergroup, or back to Private (Bot Owner only).\n\n" +
                            "`Set the Debug Chat Log Level`\n" +
                            "Here you can set how verbose the bot is with its error reporting in the Debug Chat. " +
                            "We recommend at least [Warn] level.";
                        Methods.editMessageText(callback.from.id, callback.message.message_id, text, "markdown", DebugChatCfg());
                        return;
                    }
                case CallbackLogLevel:
                    {
                        Methods.answerCallbackQuery(callback.id);
                        string text = 
                            "*Log Level Configuration*\n\n" +
                            "Here you can set the desired log level of the Console and the Log File.\n\n" +
                            "The right column is for the Console.\n" +
                            "The left side is for the Log File. (it is log.txt and is off by default.)\n\n" +
                            "We strongly recommend the console log level be no lower than *WARN* as some of this " +
                            "information can be important when resolving problems.";
                        Methods.editMessageText(callback.from.id, callback.message.message_id, text, "markdown", LogLevelMenu());
                        return;
                    }
                case CallbackResetDebugChat:
                    {
                        string text = "Debug chat is already set to PM.";
                        if (Configs.RunningConfig.Owner != Configs.RunningConfig.AdminChat)
                        {
                            text = "Debug chat has been reset to PM.";
                            Configs.RunningConfig.AdminChat = callback.from.id;
                        }
                        Methods.answerCallbackQuery(callback.id, text, true);
                        return;
                    }
                case CallbackChangeDebugChat:
                    {
                        Methods.answerCallbackQuery(callback.id);
                        string text = 
                            "*Debug Chat Location Setting*\n\n" +
                            "Here you can restore the settings for where the bot sends Debug messages. To set a " +
                            "Debug Group, add the bot to a group, and perform /setdebug and the bot will use that " +
                            "group for debug output.\n\n" +
                            
                            "`Reset Debug Chat to Private`\n" +
                            "As the buttons states, this will reset the location of debug messages to PM with you.";
                        Methods.editMessageText(callback.from.id, callback.message.message_id, text, "markdown", ChangeDebugChat());
                        return;
                    }
                case CallbackOperationMode:
                    {
                        Methods.answerCallbackQuery(callback.id);
                        string text = 
                            "*Operation Mode Settings*\n\n" +
                            "*WebHook*\n" +
                            "Clicking this will bring you to the menu to enable, configure and test your webhook.\n" +
                            "Please Read [this](http://dreadbot.net/wiki/index.php/WebHook_Explained) page to fully " +
                            "understand what the differences are between Webhook and getUpdates.\n\n" +
                            
                            "`getUpdates`\n" +
                            "This is a Toggle button specifically for Disabling webhook easily. Clicking it while " +
                            "getUpdates is enabled will do nothing.";
                        Methods.editMessageText(callback.from.id, callback.message.message_id, text, "markdown", OperationMenu());
                        return;
                    }
                case CallbackWebhookConfig:
                    {
                        Methods.answerCallbackQuery(callback.id);
                        string text = 
                            "*WebHook Config*\n\n" +
                            "`Test & Go Live!`\n" +
                            "Clicking this will reach out to the DreadBot site to help you test the accessibility " +
                            "of your bot to make sure webhook was setup correctly.\n" +
                            "Once verified, the bot will then offer you the chance to make the switch.\n\n" +
                            "`Set URL`\n" +
                            "Use this to set the Full URL you want telegram to use; " +
                            "Example http://dreadbot.net/bot/ \n\n" +
                            "`Set Certificate`\n" +
                            "Here you can configure the SSL/TLS Certificate the bot will use to encrypt " +
                            "communication between your bot and Telegram.\n\n" +
                            "`Port Cfg`\n" +
                            "You must select a port that the bot will use to listen on for the HTTPS traffic that " +
                            "will be sent by Telegram.";
                        Methods.editMessageText(callback.from.id, callback.message.message_id, text, "markdown", WebhookMenu());
                        return;
                    }

                case CallbackShowToken:
                    {
                        if (callback.from.id == Configs.RunningConfig.Owner)
                        {
                            Methods.answerCallbackQuery(callback.id);
                            Methods.editMessageText(callback.from.id, callback.message.message_id, "`" + Configs.RunningConfig.token + "`", "markdown", BackOnly(CallbackSensitiveOptions));
                            return;
                        }
                        else {
                            Methods.answerCallbackQuery(callback.id, "You are no longer allowed to view these options.", true);
                            Methods.deleteMessage(callback.from.id, callback.message.message_id);
                            Logger.LogAdmin("User attempted to use a sensitive menu option. (" + callback.from.id + ") " + callback.from.first_name);
                        }
                        return;
                    }
                case CallbackChangeToken:
                    {
                        if (callback.from.id == Configs.RunningConfig.Owner)
                        {
                            Methods.answerCallbackQuery(callback.id);
                            Methods.editMessageText(
                                callback.from.id, 
                                callback.message.message_id, 
                                "This is a major change to make. Please read " +
                                "[this](http://dreadbot.net/wiki/index.php/Change_Token) page before proceeding.", 
                                "markdown", 
                                BackOnly(CallbackSensitiveOptions));
                            return;
                        }
                        else
                        {
                            Methods.answerCallbackQuery(callback.id, "You are no longer allowed to view these options.", true);
                            Methods.deleteMessage(callback.from.id, callback.message.message_id);
                            Logger.LogAdmin("User attempted to use a sensitive menu Option. (" + callback.from.id + ") " + callback.from.first_name);
                        }
                        return;
                    }
                case CallbackChangeOwner:
                    {
                        if (callback.from.id == Configs.RunningConfig.Owner)
                        {
                            Methods.answerCallbackQuery(callback.id);
                            Methods.editMessageText(
                                callback.from.id,
                                callback.message.message_id, 
                                "If you do this, you will no longer have ANY ACCESS to this bot's options or " +
                                "administrative tools unless given to you by the new owner after the change has " +
                                "been made.\nPlease read [this](http://dreadbot.net/wiki/index.php/Change_Owner) " +
                                "page before proceeding.", 
                                "markdown", 
                                BackOnly(CallbackSensitiveOptions));
                            return;
                        }
                        else
                        {
                            Methods.answerCallbackQuery(callback.id, "You are no longer allowed to view these options.", true);
                            Methods.deleteMessage(callback.from.id, callback.message.message_id);
                            Logger.LogAdmin("User attempted to use a sensitive menu Option. (" + callback.from.id + ") " + callback.from.first_name);
                        }
                        return;
                    }
                case CallbackGetUpdatesLimit:
                    {
                        Methods.answerCallbackQuery(callback.id, "Changes the Get Updates limit", true);
                        return;
                    }
                case CallbackGetUpdatesPlusSmall: {
                        if (callback.from.id == Configs.RunningConfig.Owner)
                        {
                            if (Configs.RunningConfig.GULimit > 100)
                            {
                                Configs.RunningConfig.GULimit++;
                                Methods.answerCallbackQuery(callback.id);
                            }
                            else if (Configs.RunningConfig.GULimit == 100)
                            {
                                Methods.answerCallbackQuery(callback.id, "Maxed out.", true);
                            }
                            else
                            {
                                Configs.RunningConfig.GULimit = 100;
                                Methods.answerCallbackQuery(callback.id, "Maxed out.", true);
                            }
                            Database.SaveConfig();
                            return;
                        }
                        else
                        {
                            Methods.answerCallbackQuery(callback.id, "You are no longer allowed to view these options.", true);
                            Methods.deleteMessage(callback.from.id, callback.message.message_id);
                            Logger.LogAdmin("User Attempted to use a sensitive menu option. (" + callback.from.id + ") " + callback.from.first_name);
                        }
                        return;
                    }
                case CallbackGetUpdatesPlusLarge:
                    {
                        if (callback.from.id == Configs.RunningConfig.Owner)
                        {
                            if (Configs.RunningConfig.GULimit >= 90)
                            {
                                Configs.RunningConfig.GULimit = Configs.RunningConfig.GULimit + 10;
                                Methods.answerCallbackQuery(callback.id);
                            }
                            else if (Configs.RunningConfig.GULimit == 100)
                            {
                                Methods.answerCallbackQuery(callback.id, "Maxed out.", true);
                            }
                            else if (Configs.RunningConfig.GULimit < 90 && Configs.RunningConfig.GULimit > 100)
                            {
                                Configs.RunningConfig.GULimit = Configs.RunningConfig.GULimit + (100 - Configs.RunningConfig.GULimit);
                                Methods.answerCallbackQuery(callback.id, "Maxed out.", true);
                            }
                            else if (Configs.RunningConfig.GULimit < 100)
                            {
                                Configs.RunningConfig.GULimit = 100;
                                Methods.answerCallbackQuery(callback.id, "Maxed out.", true);
                            }
                            Database.SaveConfig();
                            return;
                        }
                        else
                        {
                            Methods.answerCallbackQuery(callback.id, "You are no longer allowed to view these options.", true);
                            Methods.deleteMessage(callback.from.id, callback.message.message_id);
                            Logger.LogAdmin("User attempted to use a sensitive menu option. (" + callback.from.id + ") " + callback.from.first_name);
                        }
                        return;
                    }
                case CallbackGetUpdatesMinusLarge:
                    {
                        if (callback.from.id == Configs.RunningConfig.Owner)
                        {
                            if (Configs.RunningConfig.GULimit >= 11)
                            {
                                Configs.RunningConfig.GULimit = Configs.RunningConfig.GULimit - 10;
                                Methods.answerCallbackQuery(callback.id);
                            }
                            else if (Configs.RunningConfig.GULimit == 1)
                            {
                                Methods.answerCallbackQuery(callback.id, "Maxed out.", true);
                            }
                            else if (Configs.RunningConfig.GULimit < 11  && Configs.RunningConfig.GULimit > 1)
                            {
                                Configs.RunningConfig.GULimit = Configs.RunningConfig.GULimit - Configs.RunningConfig.GULimit + 1;
                                Methods.answerCallbackQuery(callback.id, "Bottomed out.", true);
                            }
                            else if (Configs.RunningConfig.GULimit <= 0)
                            {
                                Configs.RunningConfig.GULimit = 1;
                                Methods.answerCallbackQuery(callback.id, "Bottomed out.", true);
                            }
                            Database.SaveConfig();
                            return;
                        }
                        else
                        {
                            Methods.answerCallbackQuery(callback.id, "You are no longer allowed to view these options.", true);
                            Methods.deleteMessage(callback.from.id, callback.message.message_id);
                            Logger.LogAdmin("User attempted to use a sensitive menu option. (" + callback.from.id + ") " + callback.from.first_name);
                        }
                        return;
                    }
                case CallbackGetUpdatesMinusSmall:
                    {
                        if (callback.from.id == Configs.RunningConfig.Owner)
                        {
                            if (Configs.RunningConfig.GULimit > 1)
                            {
                                Configs.RunningConfig.GULimit--;
                                Methods.answerCallbackQuery(callback.id);
                            }
                            else if (Configs.RunningConfig.GULimit == 1)
                            {
                                Methods.answerCallbackQuery(callback.id, "Bottomed out.", true);
                            }
                            else
                            {
                                Configs.RunningConfig.GULimit = 1;
                                Methods.answerCallbackQuery(callback.id, "Bottomed out.", true);
                            }
                            Database.SaveConfig();
                            return;
                        }
                        else
                        {
                            Methods.answerCallbackQuery(callback.id, "You are no longer allowed to view these options.", true);
                            Methods.deleteMessage(callback.from.id, callback.message.message_id);
                            Logger.LogAdmin("User attempted to use a sensitive menu option. (" + callback.from.id + ") " + callback.from.first_name);
                        }
                        return;
                    }
            }
        }



        #endregion

        #region Menu Methods

        internal static InlineKeyboardMarkup AdminMenu()
        {
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup();
            
            keyboard.addCallbackButton("🎛 DreadBot Management", $"dreadbot {CallbackBotManagement}", 0);
            keyboard.addCallbackButton("🗄 DataBase Management", $"dreadbot {CallbackDatabaseManagement}", 1);
            keyboard.addCallbackButton("⚡️ Plugin Manager", $"dreadbot {CallbackPluginManagement}", 2);
            return keyboard;
        }

        private static InlineKeyboardMarkup ManagementMenu()
        {
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup();
            
            keyboard.addCallbackButton("🔥 Sensitive Options", $"dreadbot {CallbackSensitiveOptions}", 0);
            keyboard.addCallbackButton("👮‍♂️ Add/Remove Bot Admins", $"dreadbot {CallbackBotAdmins}", 1);
            keyboard.addCallbackButton("🗒 Debug Chat Settings", $"dreadbot {CallbackDebugChat}", 2);
            keyboard.addCallbackButton("🔉 System Sounds", "dreadbot sounds", 3);
            keyboard.addCallbackButton("🔙", "dreadbot adm", 4);
            return keyboard;
        }

        private static InlineKeyboardMarkup ChangeDebugChat()
        {
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup();
            
            keyboard.addCallbackButton("Reset Debug Chat to Private", $"dreadbot {CallbackResetDebugChat}", 0);
            keyboard.addCallbackButton("🔙", $"dreadbot {CallbackDebugChat}", 1);
            return keyboard;
        }

        private static InlineKeyboardMarkup LogLevelMenu()
        {
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup();
            
            keyboard.addCallbackButton("File LogLevel - Debug " + GetLogLevel(LogLevel.Debug, false), "dreadbot fll 6", 0);
            keyboard.addCallbackButton("Console LogLevel - Debug " + GetLogLevel(LogLevel.Debug), "dreadbot cll 6", 0);

            keyboard.addCallbackButton("File LogLevel - Admin " + GetLogLevel(LogLevel.Admin, false), "dreadbot fll 5", 1);
            keyboard.addCallbackButton("Console LogLevel - Admin " + GetLogLevel(LogLevel.Admin), "dreadbot cll 5", 1);

            keyboard.addCallbackButton("File LogLevel - Info " + GetLogLevel(LogLevel.Info, false), "dreadbot fll 4", 2);
            keyboard.addCallbackButton("Console LogLevel - Info " + GetLogLevel(LogLevel.Info), "dreadbot cll 4", 2);

            keyboard.addCallbackButton("File LogLevel - Warn " + GetLogLevel(LogLevel.Warn, false), "dreadbot fll 3", 3);
            keyboard.addCallbackButton("Console LogLevel - Warn " + GetLogLevel(LogLevel.Warn), "dreadbot cll 3", 3);

            keyboard.addCallbackButton("File LogLevel - Error " + GetLogLevel(LogLevel.Error, false), "dreadbot fll 2", 4);
            keyboard.addCallbackButton("Console LogLevel - Error " + GetLogLevel(LogLevel.Error), "dreadbot cll 2", 4);

            keyboard.addCallbackButton("File LogLevel - Fatal " + GetLogLevel(LogLevel.Fatal, false), "dreadbot fll 1", 5);
            keyboard.addCallbackButton("Console LogLevel - Fatal " + GetLogLevel(LogLevel.Fatal), "dreadbot cll 1", 5);

            keyboard.addCallbackButton("File LogLevel - Off " + GetLogLevel(LogLevel.Off, false), "dreadbot fll 0", 6);
            keyboard.addCallbackButton("Console LogLevel - Off " + GetLogLevel(LogLevel.Off), "dreadbot cll 0", 6);

            keyboard.addCallbackButton("🔙", $"dreadbot {CallbackDebugChat}", 7);

            return keyboard;
        }

        private static InlineKeyboardMarkup DebugChatCfg()
        {
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup();
            
            keyboard.addCallbackButton("🧾 Change Debug Chat", $"dreadbot {CallbackChangeDebugChat}", 0);
            keyboard.addCallbackButton("🔕 Set Debug Chat Log Level", $"dreadbot {CallbackLogLevel}", 1);
            keyboard.addCallbackButton("🔙", $"dreadbot {CallbackBotManagement}", 2);
            return keyboard;
        }
        internal static InlineKeyboardMarkup PluginMgr()
        {
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup();

            return keyboard;

        }

        private static InlineKeyboardMarkup OperationMenu()
        {
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup();
            
            string getUpdatesSuffix = Configs.RunningConfig.GetupdatesMode ? " ⬅️" : "";
            string webHooksSuffix = Configs.RunningConfig.GetupdatesMode ? "" : " ⬅️";

            keyboard.addCallbackButton("GetUpdates" + getUpdatesSuffix, $"dreadbot {CallbackWebhookDisable}", 0);
            keyboard.addCallbackButton("WebHook" + webHooksSuffix, $"dreadbot {CallbackWebhookConfig}", 1);
            keyboard.addCallbackButton("🔙", $"dreadbot {CallbackSensitiveOptions}", 2);
            return keyboard;
        }

        private static InlineKeyboardMarkup WebhookMenu()
        {
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup();
            

            keyboard.addCallbackButton("Test & Go Live!", $"dreadbot {CallbackWebhookDisable}", 0);
            keyboard.addCallbackButton("Set URL", $"dreadbot {CallbackWebhookConfig}", 1);
            keyboard.addCallbackButton("Set Certificate", $"dreadbot {CallbackWebhookConfig}", 2);

            keyboard.addCallbackButton("Port Cfg", $"dreadbot {CallbackWebhookConfig}", 3);
            keyboard.addCallbackButton("443", $"dreadbot {CallbackWebhookConfig}", 3);
            keyboard.addCallbackButton("+", $"dreadbot {CallbackWebhookConfig}", 3);

            keyboard.addCallbackButton("🔙", $"dreadbot {CallbackOperationMode}", 4);
            return keyboard;
        }
        
        private static InlineKeyboardMarkup SensitiveOptionsMenu()
        {
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup();
            
            keyboard.addCallbackButton("🔑 Show Access Token", $"dreadbot {CallbackShowToken}", 0);
            keyboard.addCallbackButton("🔑 Change Access Token", $"dreadbot {CallbackChangeToken}", 1);
            keyboard.addCallbackButton("👮‍️ Change Owner", $"dreadbot {CallbackChangeOwner}", 2);

            keyboard.addCallbackButton("+1", $"dreadbot {CallbackGetUpdatesPlusSmall}", 3);
            keyboard.addCallbackButton("+10", $"dreadbot {CallbackGetUpdatesPlusLarge}", 3);
            keyboard.addCallbackButton(Configs.RunningConfig.GULimit.ToString(), $"dreadbot {CallbackGetUpdatesLimit}", 3);
            keyboard.addCallbackButton("-10", $"dreadbot {CallbackGetUpdatesMinusLarge}", 3);
            keyboard.addCallbackButton("-1", $"dreadbot {CallbackGetUpdatesMinusSmall}", 3);

            keyboard.addCallbackButton("⚙️ Bot Operation Mode", $"dreadbot {CallbackOperationMode}", 4);
            keyboard.addCallbackButton("🔙", $"dreadbot {CallbackBotManagement}", 5);
            return keyboard;

        }

        private static InlineKeyboardMarkup BackOnly(string callBack)
        {
            InlineKeyboardMarkup keyboard = new InlineKeyboardMarkup();
            
            keyboard.addCallbackButton("🔙", "dreadbot " + callBack, 0);
            return keyboard;
        }

        #endregion

        private static string GetLogLevel(LogLevel level, bool console = true)
        {
            return "";
        }
    }
}
