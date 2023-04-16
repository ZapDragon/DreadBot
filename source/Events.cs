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

namespace DreadBot
{
    public static class Events
    {
        #region Update Parsing & Event Firing

        #region Update Type
        public static void ParseUpdate(Update update) //Evaluating which Update this is, and assigning local variables for further evaluation.
        {
            if (update.message != null) {
                if (update.message.text != null) { 
                    if (CommandParser(update)) { return; }
                }
                ParseMessage(update.message);
            }
            else if (update.edited_message != null) { ParseMessage(update.edited_message, true); }
            else if (update.channel_post != null) { ParseMessage(update.channel_post, false, true); }
            else if (update.edited_channel_post != null) { ParseMessage(update.edited_channel_post, true, true); }
            else if (update.inline_query != null) { Events.OnInlineQuery(update.inline_query); }
            else if (update.chosen_inline_result != null) { Events.OnChosenInline(update.chosen_inline_result); }
            else if (update.callback_query != null)
            {
                if (update.callback_query.data.Contains("dreadbot"))
                {
                    Menus.ButtonPush(update.callback_query); //All DreadBot specific Menus are to be ignored by Plugins.
                    return;
                }
                else if (update.callback_query.data.StartsWith("config:"))
                {
                    Menus.ConfigMenu(update.callback_query);
                }
                Events.OnCallback(update.callback_query);
            }
            else if (update.shipping_query != null) { OnShippingQuery(update.shipping_query); }
            else if (update.pre_checkout_query != null) { Events.OnPreCheckout(update.pre_checkout_query); }
            else if (update.poll != null) { Events.OnPoll(update.poll, null, true, false); }
            else if (update.poll_answer != null) { Events.OnPoll(update.poll, null, false, true); }
        }
        #endregion

        #region Message Events 

        private static void ParseMessage(Message msg, bool isEdited = false, bool isChannel = false)
        {
            if (msg.forward_from != null) { Events.OnForward(msg); }
            else if (!String.IsNullOrEmpty(msg.text))
            {
                if (isChannel) { OnChannelPost(msg, isEdited); return; }
                if (Utilities.isAdminCommand(msg.text) != "") {
                    if (Utilities.AdminCommand(msg)) { return; }
                }
                else if (Utilities.isCommand(msg.text) != "")
                {
                    if (Utilities.Commands(msg)) { return; }
                }
                Events.OnText(msg, isEdited);
            }
            else if (msg.sticker != null) { Events.OnSticker(msg); }
            else if (msg.photo != null) { Events.OnImage(msg, isEdited); }
            else if (msg.video_note != null) { Events.OnVideoNote(msg, isEdited); }
            else if (msg.new_chat_members != null)
            {
                foreach (User user in msg.new_chat_members)
                {
                    if (user.id == Configs.Me.id)
                    {
                        ChatCache cChat = ChatCaching.GetCache(msg.chat.id);
                        ChatCaching.UpdateCache(cChat);
                        break;
                    }
                }
                Events.OnJoin(msg);
            }
            else if (msg.left_chat_member != null) { Events.OnPart(msg); }
            else if (msg.animation != null) { Events.OnAnimation(msg, isEdited); }
            else if (msg.audio != null) { Events.OnAudio(msg, isEdited); }
            else if (msg.video != null) { Events.OnVideo(msg, isEdited); }
            else if (msg.game != null) { Events.OnGame(msg, isEdited); }
            else if (msg.poll != null) { Events.OnPoll(msg.poll, msg); }
            else if (msg.dice != null) { Events.OnDice(msg); }
            else if (msg.voice != null) { Events.OnVoiceClip(msg, isEdited); }
            else if (msg.venue != null) { Events.OnVenueClip(msg, isEdited); }
            else if (msg.pinned_message != null)
            {
                ChatCaching.UpdatePinnedMsg(msg);
                Events.OnPinnedMessage(msg, isEdited);
            }
            else if (msg.new_chat_title != null)
            {
                ChatCaching.UpdateTitle(msg);
                Events.OnTitleChange(msg);
            }
            else if (msg.new_chat_photo != null || (msg.delete_chat_photo))
            {
                ChatCaching.UpdatePhoto(msg);
                Events.OnChatPhoto(msg);
            }
            else if (msg.location != null) { Events.OnLocation(msg); }
            else if (msg.group_chat_created)
            {
                ChatCache cChat = ChatCaching.GetCache(msg.chat.id);
                ChatCaching.UpdateCache(cChat);
                Events.OnNewGroup(msg);
            }
            else if (msg.passport_data != null) { Events.OnPassportData(msg); }
            else if (msg.migrate_from_chat_id != 0)
            {
                ChatCaching.ChatUpgrade(msg.migrate_from_chat_id, msg.chat.id);
                Events.OnGroupUpgrade(msg);
            }
        }


        #endregion

        #region Command Parser

        private static bool CommandParser(Update update)
        {
            string[] args = update.message.text.Trim().Split(' ');
            string cmd = Utilities.isAdminCommand(args[0]);
            if (cmd != "")
            {
                if (!Utilities.isBotAdmin(update.message.from)) { return false; }
                else { return Utilities.AdminCommand(update.message); }
            }
            cmd = Utilities.isCommand(args[0]);
            if (cmd != "")
            {
                if (Utilities.isBlacklisted(update.message.from)) { return false; }
                else { return Utilities.Commands(update.message); }
            }
            return false;
        }

        #endregion

        #region Events

        //Telegram Event Providers
        public static event Action<MessageEventArgs> ForwardEvent;
        public static event Action<MessageEventArgs> StickerEvent;
        public static event Action<MessageEventArgs> ImageEvent;
        public static event Action<MessageEventArgs> VideoNoteEvent;
        public static event Action<SystemMsgEventArgs> JoinEvent;
        public static event Action<SystemMsgEventArgs> PartEvent;
        public static event Action<MessageEventArgs> AnimationEvent;
        public static event Action<MessageEventArgs> AudioEvent;
        public static event Action<MessageEventArgs> VideoEvent;
        public static event Action<MessageEventArgs> GameEvent;
        public static event Action<PollEventArgs> PollEvent;
        public static event Action<MessageEventArgs> DiceEvent;
        public static event Action<MessageEventArgs> VoiceClipEvent;
        public static event Action<MessageEventArgs> VenueClipEvent;
        public static event Action<MessageEventArgs> PinnedMessageEvent;
        public static event Action<SystemMsgEventArgs> TitleChangeEvent;
        public static event Action<SystemMsgEventArgs> ChatPhotoEvent;
        public static event Action<SystemMsgEventArgs> LocationEvent;
        public static event Action<SystemMsgEventArgs> NewGroupEvent;
        public static event Action<SystemMsgEventArgs> GroupUpgradeEvent;
        public static event Action<CallbackEventArgs> CallbackEvent;
        public static event Action<ShippingQueryEventArgs> ShippingQueryEvent;
        public static event Action<ChosenInlineEventArgs> ChosenInlineEvent;
        public static event Action<InlineQueryEventArgs> InlineQueryEvent;
        public static event Action<PreCheckoutEventArgs> PreCheckoutEvent;
        public static event Action<MessageEventArgs> PassportDataEvent;
        public static event Action<MessageEventArgs> TextEvent;
        public static event Action<MessageEventArgs> ChannelPostEvent;

        //Internal Event Providers
        public static event Action<DatabaseExportEventArgs> DatabaseExport;
        public static event Func<long, CallbackButtonRequestArgs> PluginConfigKeyboardRequest;

        #endregion

        #region Telegram Event Triggers
        private static void OnForward(Message msg) { ForwardEvent?.Invoke(new MessageEventArgs() { msg = msg }); }
        private static void OnSticker(Message msg) { StickerEvent?.Invoke(new MessageEventArgs() { msg = msg }); }
        private static void OnImage(Message msg, bool isEdited) { ImageEvent?.Invoke(new MessageEventArgs() { msg = msg, isEdited = isEdited }); }
        private static void OnVideoNote(Message msg, bool isEdited) { VideoNoteEvent?.Invoke(new MessageEventArgs() { msg = msg, isEdited = isEdited }); }
        private static void OnJoin(Message msg) { JoinEvent?.Invoke(new SystemMsgEventArgs() { msg = msg }); }
        private static void OnPart(Message msg) { PartEvent?.Invoke(new SystemMsgEventArgs() { msg = msg }); }
        private static void OnAnimation(Message msg, bool isEdited) { AnimationEvent?.Invoke(new MessageEventArgs() { msg = msg, isEdited = isEdited }); }
        private static void OnAudio(Message msg, bool isEdited) { AudioEvent?.Invoke(new MessageEventArgs() { msg = msg, isEdited = isEdited }); }
        private static void OnVideo(Message msg, bool isEdited) { VideoEvent?.Invoke(new MessageEventArgs() { msg = msg, isEdited = isEdited }); }
        private static void OnGame(Message msg, bool isEdited) { GameEvent?.Invoke(new MessageEventArgs() { msg = msg, isEdited = isEdited }); }
        private static void OnPoll(Poll poll, Message msg = null, bool isUpdate = false, bool isAnswer = false) { PollEvent?.Invoke(new PollEventArgs() { poll = poll, msg = msg, isUpdate = isUpdate, isAnswer = isAnswer }); }
        private static void OnDice(Message msg) { DiceEvent?.Invoke(new MessageEventArgs() { msg = msg }); }
        private static void OnVoiceClip(Message msg, bool isEdited) { VoiceClipEvent?.Invoke(new MessageEventArgs() { msg = msg, isEdited = isEdited }); }
        private static void OnVenueClip(Message msg, bool isEdited) { VenueClipEvent?.Invoke(new MessageEventArgs() { msg = msg, isEdited = isEdited }); }
        private static void OnPinnedMessage(Message msg, bool isEdited) { PinnedMessageEvent?.Invoke(new MessageEventArgs() { msg = msg, isEdited = isEdited }); }
        private static void OnTitleChange(Message msg) { TitleChangeEvent?.Invoke(new SystemMsgEventArgs() { msg = msg }); }
        private static void OnChatPhoto(Message msg) { ChatPhotoEvent?.Invoke(new SystemMsgEventArgs() { msg = msg }); }
        private static void OnLocation(Message msg) { LocationEvent?.Invoke(new SystemMsgEventArgs() { msg = msg }); }
        private static void OnNewGroup(Message msg) { NewGroupEvent?.Invoke(new SystemMsgEventArgs() { msg = msg }); }
        private static void OnGroupUpgrade(Message msg) { GroupUpgradeEvent?.Invoke(new SystemMsgEventArgs() { msg = msg }); }
        private static void OnCallback(CallbackQuery callback) { CallbackEvent?.Invoke(new CallbackEventArgs() { callbackQuery = callback }); }
        private static void OnShippingQuery(ShippingQuery shippingQuery) { ShippingQueryEvent?.Invoke(new ShippingQueryEventArgs() { shippingQuery = shippingQuery }); }
        private static void OnChosenInline(ChosenInlineResult inlineResult) { ChosenInlineEvent?.Invoke(new ChosenInlineEventArgs() { chosenResult = inlineResult }); }
        private static void OnInlineQuery(InlineQuery inlineQuery) { InlineQueryEvent?.Invoke(new InlineQueryEventArgs() { inlineQuery = inlineQuery }); }
        private static void OnPreCheckout(PreCheckoutQuery checkoutQuery) { PreCheckoutEvent?.Invoke(new PreCheckoutEventArgs() { preCheckoutQuery = checkoutQuery }); }
        private static void OnPassportData(Message msg) { PassportDataEvent?.Invoke(new MessageEventArgs() { msg = msg }); }
        private static void OnText(Message msg, bool isEdited) { TextEvent?.Invoke(new MessageEventArgs() { msg = msg, isEdited = isEdited }); }
        private static void OnChannelPost(Message msg, bool isEdited) { ChannelPostEvent?.Invoke(new MessageEventArgs() { msg = msg, isEdited = isEdited }); }

        #endregion

        #endregion

        #region Non-Telegram Event Triggers

        //private static void OnDatabaseExport(string[] args) { DatabaseExport?.Invoke(new DatabaseExportEventArgs() { Args = args }); }
        internal static void OnPluginConfigKeyboardRequest(ref InlineKeyboardMarkup keyboard, long chatID) {
            int row = 0;
            foreach (Func<long, CallbackButtonRequestArgs> item in PluginConfigKeyboardRequest.GetInvocationList())
            {
                CallbackButtonRequestArgs args = item(chatID);
                keyboard.addCallbackButton(args.text, args.callback, row++);
            }
        }
        #endregion
    }

    #region Event Args

    #region DreadBot Internal Event Args

    public class DatabaseExportEventArgs : EventArgs
    {
        string args { get; set; } = "all";
    }
    public class CallbackButtonRequestArgs : EventArgs
    {
        public string text { get; set; }
        public string callback { get; set; }
    }

    #endregion

    #region Message Event Args

    public class MessageEventArgs : EventArgs
    {
        public Message msg { get; set; }
        public bool isEdited { get; set; }
    }



    #endregion

    #region System Message Event Args

    public class SystemMsgEventArgs : EventArgs
    {
        public Message msg { get; set; }
    }


    #endregion

    #region Specific Event Args 
    public class CallbackEventArgs : EventArgs
    {
        public CallbackQuery callbackQuery { get; set; }
    }
    public class ShippingQueryEventArgs : EventArgs
    {
        public ShippingQuery shippingQuery { get; set; }
    }
    public class ChosenInlineEventArgs : EventArgs
    {
        public ChosenInlineResult chosenResult { get; set; }
    }
    public class InlineQueryEventArgs : EventArgs
    {
        public InlineQuery inlineQuery { get; set; }
    }
    public class PreCheckoutEventArgs : EventArgs
    {
        public PreCheckoutQuery preCheckoutQuery { get; set; }
    }
    public class PollEventArgs : EventArgs
    {
        public Poll poll { get; set; }
        public Message msg { get; set; } = null;
        public bool isUpdate { get; set; }
        public bool isAnswer { get; set; }
    }

    #endregion

    #endregion
}