using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreadBot
{
    public class Events
    {
        #region Update Parsing & Event Firing

        public static Event events = new Event();

        public static void ParseUpdate(Update update)
        {
            //Evaluating which Update this is, and asigning local variables for further evaluation.
            #region Update Type
            Message msg = null;
            string[] Args = null;
            bool isEdited = false;

            //Message Events
            if (update.message != null)
            {
                msg = update.message;
                if (msg.text != null) { Args = msg.text.Split(' '); }
            }
            else if (update.edited_message != null)
            {
                isEdited = true;
                msg = update.edited_message;
                if (msg.text != null) { Args = msg.text.Split(' '); }
            }
            else if (update.channel_post != null)
            {
                msg = update.channel_post;
                if (msg.text != null) { Args = msg.text.Split(' '); }
            }
            else if (update.edited_channel_post != null)
            {
                isEdited = true;
                msg = update.edited_channel_post;
                if (msg.text != null) { Args = msg.text.Split(' '); }
            }

            //Callback Event
            if (update.shipping_query != null) { events.ShippingQueryCall(update.shipping_query); }
            else if (update.chosen_inline_result != null) { events.ChosenInlineCall(update.chosen_inline_result); }
            else if (update.inline_query != null) { events.InlineQueryCall(update.inline_query); }
            else if (update.pre_checkout_query != null) { events.PreCheckoutCall(update.pre_checkout_query); }
            else if (update.callback_query != null) {
                if (update.callback_query.data.Contains("dreadbot")) {
                    Menus.ButtonPush(update.callback_query); //All DreadBot specific Menus are to be ignored by Plugins.
                    return;
                }
                events.CallbackCall(update.callback_query);
            }


            #endregion

            //Evaluating Message based events.
            #region Specific Event
            if (msg != null)
            {
                if (msg.text != null)
                {
                    if (Utilities.isCommand(msg.text[0])) { Args = msg.text.Split(' '); }
                    else if (Utilities.isAdminCommand(msg.text[0])) { Utilities.AdminCommand(msg, msg.text.Split(' ')); return; }
                }
                if (msg.forward_from != null) { events.ForwardCall(msg, Args); }
                else if (msg.sticker != null) { events.StickerCall(msg); }
                else if (msg.photo != null) { events.ImageCall(msg, Args, isEdited); }
                else if (msg.video_note != null) { events.VideoNoteCall(msg, Args, isEdited); }
                else if (msg.new_chat_members != null)
                {
                    if (msg.new_chat_members.Length == 1)
                    {
                        if (msg.new_chat_members[0].id == Configs.Me.id) { events.MeJoinCall(msg); }
                        else { events.JoinCall(msg); }
                        return;
                    }
                    else if (msg.new_chat_members.Length == 2)
                    {
                        
                        if (msg.new_chat_members[0].id == Configs.Me.id)
                        {
                            //newUsers = new List<User>(1);
                            User[] newUsers = { msg.new_chat_members[1] };
                            msg.new_chat_members = newUsers;
                            events.MeJoinCall(msg);
                            events.JoinCall(msg);
                            return;
                        }
                        else if (msg.new_chat_members[1].id == Configs.Me.id)
                        {
                            User[] newUsers = { msg.new_chat_members[0] };
                            msg.new_chat_members = newUsers;
                            events.MeJoinCall(msg);
                            events.JoinCall(msg);
                            return;
                        }
                        else { events.MassAddCall(msg); }
                        return;
                    }
                    else
                    {
                        List<User> newUsers = new List<User>(msg.new_chat_members.Length);
                        foreach (User newUser in msg.new_chat_members)
                        {
                            if (newUser.id == Configs.Me.id)
                            {
                                events.MeJoinCall(msg);
                                continue;
                            }
                            else { newUsers.Add(newUser); }
                        }

                        msg.new_chat_members = newUsers.ToArray();
                        if (msg.new_chat_members.Length > 1) { events.MassAddCall(msg); }
                        return;
                    }
                }
                else if (msg.left_chat_member != null) { events.PartCall(msg); }
                else if (msg.animation != null) { events.AnimationCall(msg, Args, isEdited); }
                else if (msg.audio != null) { events.AudioCall(msg, Args, isEdited); }
                else if (msg.video != null) { events.VideoCall(msg, Args, isEdited); }
                else if (msg.game != null) { events.GameCall(msg, Args, isEdited); }
                else if (msg.voice != null) { events.VoiceClipCall(msg, Args, isEdited); }
                else if (msg.venue != null) { events.VenueClipCall(msg, Args, isEdited); }
                else if (msg.pinned_message != null) { events.PinnedMessageCall(msg, Args, isEdited); }
                else if (msg.new_chat_title != null) { events.TitleChangeCall(msg, Args); }
                else if (msg.new_chat_photo != null || (msg.delete_chat_photo)) { events.ChatPhotoCall(msg); }
                else if (msg.location != null) { events.LocationCall(msg); }
                else if (msg.group_chat_created) {
                    events.MeJoinCall(msg);
                    events.NewGroupCall(msg);
                }
                else if (msg.passport_data != null) { events.PassportDataCall(msg); }
                else if (msg.migrate_to_chat_id > 0 || msg.migrate_to_chat_id < 0) { events.GroupUpgradeCall(msg); }
                else if (msg.text != null)
                {
                    if (Args != null)
                    {
                        string command = Args[0].Substring(1);
                        switch (command)
                        {
                            case "version":
                                {
                                    TimeSpan t = TimeSpan.FromSeconds(Utilities.EpochTime() - MainClass.LauchTime);

                                    string answer = string.Format("{0:D3} Days, {1:D2} Hours, {2:D2} Minutes, {3:D2} Seconds", t.Days, t.Hours, t.Minutes, t.Seconds);
                                    Methods.sendReply(msg.chat.id, (int)msg.message_id, "Dread Bot v0.0.4a\n\nUptime: " + answer);
                                    return;
                                }

                            case "token":
                                {
                                    if (msg.chat.type != "private") { return; }
                                    if (Args.Length == 2)
                                    {
                                        if (Utilities.OwnerToken == Args[1])
                                        {
                                            Configs.RunningConfig.Owner = msg.from.id;

                                            Console.WriteLine("Ownership of this bot has been claimed.");
                                            Console.WriteLine("Owner ID: " + Configs.RunningConfig.Owner);
                                            Console.WriteLine("Username: " + msg.from.username); //username can be null

                                            Methods.sendReply(msg.from.id, (int)msg.message_id, "You have claimed ownership over this bot.\nPlease check out the Wiki on getting me setup.\n\nFrom this point on, please use /adminmenu for DreadBot specific configuration.");

                                            Configs.RunningConfig.GULimit = 20;
                                            Configs.RunningConfig.AdminChat = msg.from.id;
                                        }

                                        //else if (Utilities.AdminTokens.Contains(Args[2]))
                                        //{
                                        //
                                        //}

                                        else
                                        {
                                            Methods.sendReply(msg.from.id, (int)msg.message_id, "The token you have specified does not exist. This error has been logged.");
                                            Methods.sendMessage(Configs.RunningConfig.AdminChat, "The token command was attempted by ([" + msg.from.id + "](tg://user?id=" + msg.from.id + ")) using the token " + Args[1]);
                                        }
                                    }
                                    return;
                                }
                            case "adminmenu":
                                {
                                    if (msg.from.id != Configs.RunningConfig.Owner)
                                    {
                                        Logger.LogWarn("User attempted to use /adminmenu command: " + msg.from.id);
                                        return;
                                    }
                                    Logger.LogAdmin("Admin Menu Called: " + msg.from.id);
                                    Methods.sendMessage(msg.from.id, "*DreadBot Administration Menu*\n\n`DreadBot Managment`\nUsed to fine tune the bot, plus other senstive, and powerful options.\n\n`DataBase Management`\nConfigure Specific Database options, and backup as needed.\n\n`Plugin Manager`\nAdd, Remove and Configure plugins to give DreadBot its purpose.", "Markdown", Menus.AdminMenu());
                                    return;
                                }

                            case "setdebug":
                                {
                                    if (msg.from.id != Configs.RunningConfig.Owner) {
                                        Logger.LogWarn("User attempted to use /setdebug command: " + msg.from.id);
                                        return;
                                    }
                                    if (msg.chat.type == "private" || msg.chat.type == "channel")
                                    {
                                        Methods.sendReply(msg.chat.id, msg.message_id, "You can only assign a Group or Supergroup to be the Debug Chat.\nIf you want to reset it back to PM, please use the admin menu.");
                                        return;
                                    }
                                    else
                                    {
                                        if (msg.chat.id == Configs.RunningConfig.AdminChat)
                                        {
                                            Methods.sendReply(msg.chat.id, msg.message_id, "Debug Chat is already set to this group.");
                                            return;
                                        }
                                        else
                                        {
                                            Configs.RunningConfig.AdminChat = msg.chat.id;
                                            Methods.sendReply(msg.chat.id, msg.message_id, "Debug Chat is now set to this group.");
                                            Logger.LogAdmin("Debug Chat has been set to: " + msg.chat.id);
                                            return;
                                        }
                                    }
                                }
                        }
                    }
                    events.TextCall(msg, Args, isEdited);
                }
            }
            #endregion
        }
        #endregion
    }

    public class Event
    {
        #region Events and Delegetes

        // Delegates
        public delegate void DreadBotEventHandler(object o, EventArgs e);

        //Event Providers
        public event DreadBotEventHandler MeJoinEvent;
        public event DreadBotEventHandler MeKickEvent;
        public event DreadBotEventHandler ForwardEvent;
        public event DreadBotEventHandler StickerEvent;
        public event DreadBotEventHandler ImageEvent;
        public event DreadBotEventHandler VideoNoteEvent;
        public event DreadBotEventHandler JoinEvent;
        public event DreadBotEventHandler MassAddEvent;
        public event DreadBotEventHandler PartEvent;
        public event DreadBotEventHandler AnimationEvent;
        public event DreadBotEventHandler AudioEvent;
        public event DreadBotEventHandler VideoEvent;
        public event DreadBotEventHandler GameEvent;
        public event DreadBotEventHandler VoiceClipEvent;
        public event DreadBotEventHandler VenueClipEvent;
        public event DreadBotEventHandler PinnedMessageEvent;
        public event DreadBotEventHandler TitleChangeEvent;
        public event DreadBotEventHandler ChatPhotoEvent;
        public event DreadBotEventHandler LocationEvent;
        public event DreadBotEventHandler NewGroupEvent;
        public event DreadBotEventHandler GroupUpgradeEvent;
        public event DreadBotEventHandler CallbackEvent;
        public event DreadBotEventHandler ShippingQueryEvent;
        public event DreadBotEventHandler ChosenInlineEvent;
        public event DreadBotEventHandler InlineQueryEvent;
        public event DreadBotEventHandler ChippingQueryEvent;
        public event DreadBotEventHandler PreCheckoutEvent;
        public event DreadBotEventHandler PassportDataEvent;
        public event DreadBotEventHandler TextEvent;

        #endregion

        #region Event Calls
        public void MeJoinCall(Message Msg) { OnMeJoin(Msg); }
        public void MeKickCall(Message Msg) { OnMeKick(Msg); }
        public void ForwardCall(Message Msg, string[] args) { OnForward(Msg, args); }
        public void StickerCall(Message Msg) { OnSticker(Msg); }
        public void ImageCall(Message Msg, string[] args, bool isEdited) { OnImage(Msg, args, isEdited); }
        public void VideoNoteCall(Message Msg, string[] args, bool isEdited) { OnVideoNote(Msg, args, isEdited); }
        public void JoinCall(Message Msg) { OnJoin(Msg); }
        public void MassAddCall(Message Msg) { OnMassAdd(Msg); }
        public void PartCall(Message Msg) { OnPart(Msg); }
        public void AnimationCall(Message Msg, string[] args, bool isEdited) { OnAnimation(Msg, args, isEdited); }
        public void AudioCall(Message Msg, string[] args, bool isEdited) { OnAudio(Msg, args, isEdited); }
        public void VideoCall(Message Msg, string[] args, bool isEdited) { OnVideo(Msg, args, isEdited); }
        public void GameCall(Message Msg, string[] args, bool isEdited) { OnGame(Msg, args, isEdited); }
        public void VoiceClipCall(Message Msg, string[] args, bool isEdited) { OnVoiceClip(Msg, args, isEdited); }
        public void VenueClipCall(Message Msg, string[] args, bool isEdited) { OnVenueClip(Msg, args, isEdited); }
        public void PinnedMessageCall(Message Msg, string[] args, bool isEdited) { OnPinnedMessage(Msg, args, isEdited); }
        public void TitleChangeCall(Message Msg, string[] args) { OnTitleChange(Msg, args); }
        public void ChatPhotoCall(Message Msg) { OnChatPhoto(Msg); }
        public void LocationCall(Message Msg) { OnLocation(Msg); }
        public void NewGroupCall(Message Msg) { OnNewGroup(Msg); }
        public void GroupUpgradeCall(Message Msg) { OnGroupUpgrade(Msg); }
        public void CallbackCall(CallbackQuery callbackQuery) { OnCallback(callbackQuery); }
        public void ShippingQueryCall(ShippingQuery shippingQuery) { OnShippingQuery(shippingQuery); }
        public void ChosenInlineCall(ChosenInlineResult chosenResult) { OnChosenInline(chosenResult); }
        public void InlineQueryCall(InlineQuery inlineQuery) { OnInlineQuery(inlineQuery); }
        public void PreCheckoutCall(PreCheckoutQuery checkoutQuery) { OnPreCheckout(checkoutQuery); }
        public void PassportDataCall(Message Msg) { OnPassportData(Msg); }
        public void TextCall(Message Msg, string[] args, bool isEdited) { OnText(Msg, args, isEdited); }
        #endregion

        #region Event Triggers
        protected virtual void OnMeJoin(Message msg) { MeJoinEvent?.Invoke(this, new MeJoinEventArgs() { msg = msg }); }
        protected virtual void OnMeKick(Message msg) { MeKickEvent?.Invoke(this, new MeKickEventArgs() { msg = msg }); }
        protected virtual void OnForward(Message msg, string[] args) { ForwardEvent?.Invoke(this, new ForwardEventArgs() { msg = msg, Args = args } ); }
        protected virtual void OnSticker(Message msg) { StickerEvent?.Invoke(this, new StickerEventArgs() { msg = msg } ); }
        protected virtual void OnImage(Message msg, string[] args, bool isEdited) { ImageEvent?.Invoke(this, new ImageEventArgs() { msg = msg, Args = args, isEdited = isEdited } ); }
        protected virtual void OnVideoNote(Message msg, string[] args, bool isEdited) { VideoNoteEvent?.Invoke(this, new VideoNoteEventArgs() { msg = msg, Args = args, isEdited = isEdited }); }
        protected virtual void OnJoin(Message msg) { JoinEvent?.Invoke(this, new JoinEventArgs() { msg = msg }); }
        protected virtual void OnMassAdd(Message msg) { MassAddEvent?.Invoke(this, new MassAddEventArgs() { msg = msg }); }
        protected virtual void OnPart(Message msg) { PartEvent?.Invoke(this, new PartEventArgs() { msg = msg }); }
        protected virtual void OnAnimation(Message msg, string[] args, bool isEdited) { AnimationEvent?.Invoke(this, new AnimationEventArgs() { msg = msg, Args = args, isEdited = isEdited } ); }
        protected virtual void OnAudio(Message msg, string[] args, bool isEdited) { AudioEvent?.Invoke(this, new AudioEventArgs() { msg = msg, Args = args, isEdited = isEdited }); }
        protected virtual void OnVideo(Message msg, string[] args, bool isEdited) { VideoEvent?.Invoke(this, new VideoEventArgs() { msg = msg, Args = args, isEdited = isEdited }); }
        protected virtual void OnGame(Message msg, string[] args, bool isEdited) { GameEvent?.Invoke(this, new GameEventArgs() { msg = msg, Args = args, isEdited = isEdited }); }
        protected virtual void OnVoiceClip(Message msg, string[] args, bool isEdited) { VoiceClipEvent?.Invoke(this, new VoiceClipEventArgs() { msg = msg, Args = args, isEdited = isEdited }); }
        protected virtual void OnVenueClip(Message msg, string[] args, bool isEdited) { VenueClipEvent?.Invoke(this, new VenueClipEventArgs() { msg = msg, Args = args, isEdited = isEdited }); }
        protected virtual void OnPinnedMessage(Message msg, string[] args, bool isEdited) { PinnedMessageEvent?.Invoke(this, new PinnedMessageEventArgs() { msg = msg, Args = args, isEdited = isEdited }); }
        protected virtual void OnTitleChange(Message msg, string[] args) { TitleChangeEvent?.Invoke(this, new TitleChangeEventArgs() { msg = msg }); }
        protected virtual void OnChatPhoto(Message msg) { ChatPhotoEvent?.Invoke(this, new ChatPhotoEventArgs() { msg = msg }); }
        protected virtual void OnLocation(Message msg) { LocationEvent?.Invoke(this, new LocationEventArgs() { msg = msg }); }
        protected virtual void OnNewGroup(Message msg) { NewGroupEvent?.Invoke(this, new NewGroupEventArgs() { msg = msg } ); }
        protected virtual void OnGroupUpgrade(Message msg) { GroupUpgradeEvent?.Invoke(this, new GroupUpgradeEventArgs() { msg = msg } ); }
        protected virtual void OnCallback(CallbackQuery callback) { CallbackEvent?.Invoke(this, new CallbackEventArgs() { callbackQuery = callback } ); }
        protected virtual void OnShippingQuery(ShippingQuery shippingQuery) { ShippingQueryEvent?.Invoke(this, new ShippingQueryEventArgs() { shippingQuery = shippingQuery } ); }
        protected virtual void OnChosenInline(ChosenInlineResult inlineResult) { ChosenInlineEvent?.Invoke(this, new ChosenInlineEventArgs() { chosenResult = inlineResult } ); }
        protected virtual void OnInlineQuery(InlineQuery inlineQuery) { InlineQueryEvent?.Invoke(this, new InlineQueryEventArgs() { inlineQuery = inlineQuery } ); }
        protected virtual void OnPreCheckout(PreCheckoutQuery checkoutQuery) { PreCheckoutEvent?.Invoke(this, new PreCheckoutEventArgs() { preCheckoutQuery = checkoutQuery } ); }
        protected virtual void OnPassportData(Message msg) { PassportDataEvent?.Invoke(this, new PassportEventArgs() { msg = msg }); }
        public void OnText(Message Msg, string[] args, bool isEdited) { TextEvent?.Invoke(this, new TextEventArgs() { msg = Msg, Args = args, isEdited = isEdited }); }

        #endregion
    }

    #region Event Args
    public class MeJoinEventArgs : EventArgs
    {
        public Message msg { get; set; }
    }
    public class MeKickEventArgs : EventArgs
    {
        public Message msg { get; set; }
    }
    public class ForwardEventArgs : EventArgs
    {
        public Message msg { get; set; }
        public string[] Args { get; set; }
    }
    public class StickerEventArgs : EventArgs
    {
        public Message msg { get; set; }
    }
    public class ImageEventArgs : EventArgs
    {
        public Message msg { get; set; }
        public string[] Args { get; set; }
        public bool isEdited { get; set; }
    }
    public class VideoNoteEventArgs : EventArgs
    {
        public Message msg { get; set; }
        public string[] Args { get; set; }
        public bool isEdited { get; set; }
    }
    public class JoinEventArgs : EventArgs {
        public Message msg { get; set; }
    }
    public class MassAddEventArgs : EventArgs
    {
        public Message msg { get; set; }
    }
    public class PartEventArgs : EventArgs {
        public Message msg { get; set; }
    }
    public class AnimationEventArgs : EventArgs {
        public Message msg { get; set; }
        public string[] Args { get; set; }
        public bool isEdited { get; set; }
    }
    public class AudioEventArgs : EventArgs {
        public Message msg { get; set; }
        public string[] Args { get; set; }
        public bool isEdited { get; set; }
    }
    public class VideoEventArgs : EventArgs {
        public Message msg { get; set; }
        public string[] Args { get; set; }
        public bool isEdited { get; set; }
    }
    public class GameEventArgs : EventArgs { //Cant determine if text is involved or if it can be edited.
        public Message msg { get; set; }
        public string[] Args { get; set; }
        public bool isEdited { get; set; }
    }
    public class VoiceClipEventArgs : EventArgs {
        public Message msg { get; set; }
        public string[] Args { get; set; }
        public bool isEdited { get; set; }
    }
    public class VenueClipEventArgs : EventArgs { //Untested
        public Message msg { get; set; }
        public string[] Args { get; set; }
        public bool isEdited { get; set; }
    }
    public class PinnedMessageEventArgs : EventArgs {
        public Message msg { get; set; }
        public string[] Args { get; set; }
        public bool isEdited { get; set; }
    }
    public class TitleChangeEventArgs : EventArgs {
        public Message msg { get; set; }
    }
    public class ChatPhotoEventArgs : EventArgs {
        public Message msg { get; set; }
    }
    public class LocationEventArgs : EventArgs {
        public Message msg { get; set; }
    }
    public class NewGroupEventArgs : EventArgs {
        public Message msg { get; set; }
    }
    public class GroupUpgradeEventArgs : EventArgs {
        public Message msg { get; set; }
    }
    public class CallbackEventArgs : EventArgs {
        public CallbackQuery callbackQuery { get; set; }
    }
    public class ShippingQueryEventArgs : EventArgs
    {
        public ShippingQuery shippingQuery { get; set; }
    }
    public class ChosenInlineEventArgs : EventArgs {
        public ChosenInlineResult chosenResult { get; set; }
    }
    public class InlineQueryEventArgs : EventArgs {
        public InlineQuery inlineQuery { get; set; }
    }
    public class PreCheckoutEventArgs : EventArgs {
        public PreCheckoutQuery preCheckoutQuery { get; set; }
    }
    public class PassportEventArgs : EventArgs
    {
        public Message msg { get; set; }
        public string[] Args { get; set; }
        public bool isEdited { get; set; }
    }
    public class TextEventArgs : EventArgs
    {
        public Message msg { get; set; }
        public string[] Args { get; set; }
        public bool isEdited { get; set; }
    }
    #endregion
}
