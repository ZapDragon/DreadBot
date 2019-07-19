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

namespace DreadBot
{
    public static class Events
  {
    #region Update Parsing & Event Firing

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
      if (update.shipping_query != null) { OnShippingQuery(update.shipping_query); }
      else if (update.chosen_inline_result != null) { Events.OnChosenInline(update.chosen_inline_result); }
      else if (update.inline_query != null) { Events.OnInlineQuery(update.inline_query); }
      else if (update.pre_checkout_query != null) { Events.OnPreCheckout(update.pre_checkout_query); }
      else if (update.callback_query != null) {
        if (update.callback_query.data.Contains("dreadbot")) {
          Menus.ButtonPush(update.callback_query); //All DreadBot specific Menus are to be ignored by Plugins.
          return;
        }
        Events.OnCallback(update.callback_query);
      }


      #endregion

      //Evaluating Message based Events.
      #region Specific Event
      if (msg != null)
      {
        if (msg.text != null)
        {
          if (Utilities.isCommand(msg.text) != "") { Args = msg.text.Split(' '); }
          else if (Utilities.isAdminCommand(msg.text[0])) { Utilities.AdminCommand(msg, msg.text.Split(' ')); return; }
        }
        if (msg.forward_from != null) { Events.OnForward(msg, Args); }
        else if (msg.sticker != null) { Events.OnSticker(msg); }
        else if (msg.photo != null) { Events.OnImage(msg, Args, isEdited); }
        else if (msg.video_note != null) { Events.OnVideoNote(msg, Args, isEdited); }
        else if (msg.new_chat_members != null) { Events.OnJoin(msg); }
        else if (msg.left_chat_member != null) { Events.OnPart(msg); }
        else if (msg.animation != null) { Events.OnAnimation(msg, Args, isEdited); }
        else if (msg.audio != null) { Events.OnAudio(msg, Args, isEdited); }
        else if (msg.video != null) { Events.OnVideo(msg, Args, isEdited); }
        else if (msg.game != null) { Events.OnGame(msg, Args, isEdited); }
        else if (msg.voice != null) { Events.OnVoiceClip(msg, Args, isEdited); }
        else if (msg.venue != null) { Events.OnVenueClip(msg, Args, isEdited); }
        else if (msg.pinned_message != null) { Events.OnPinnedMessage(msg, Args, isEdited); }
        else if (msg.new_chat_title != null) { Events.OnTitleChange(msg, Args); }
        else if (msg.new_chat_photo != null || (msg.delete_chat_photo)) { Events.OnChatPhoto(msg); }
        else if (msg.location != null) { Events.OnLocation(msg); }
        else if (msg.group_chat_created) { Events.OnNewGroup(msg); }
        else if (msg.passport_data != null) { Events.OnPassportData(msg); }
        else if (msg.migrate_to_chat_id > 0 || msg.migrate_to_chat_id < 0) { Events.OnGroupUpgrade(msg); }
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
                  Methods.sendReply(msg.chat.id, (int)msg.message_id, "Dread Bot v4.1-764a\n\nUptime: " + answer);
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

                      Database.FlushConfig();
                      Logger.LogDebug("Flushed Database to Disk.");

                    }

                    //else if (Utilities.AdminTokens.Contains(Args[2]))
                    //{
                    //
                    //}

                    else
                    {
                      Methods.sendReply(msg.from.id, (int)msg.message_id, "The token you have specified does not exist. This error has been logged.");
                      Result<Message> res = Methods.sendMessage(Configs.RunningConfig.AdminChat, "The token command was attempted by ([" + msg.from.id + "](tg://user?id=" + msg.from.id + ")) using the token " + Args[1]);
                      if (!res.ok) { Logger.LogError("Error contacting the admin Chat: " + res.description); }
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
                  Result<Message> res = Methods.sendMessage(msg.from.id, "*DreadBot Administration Menu*\n\n`DreadBot Managment`\nUsed to fine tune the bot, plus other senstive, and powerful options.\n\n`DataBase Management`\nConfigure Specific Database options, and backup as needed.\n\n`Plugin Manager`\nAdd, Remove and Configure plugins to give DreadBot its purpose.", "Markdown", Menus.AdminMenu());
                  if (!res.ok) { Logger.LogError("Error contacting the admin Chat: " + res.description); }
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
                    Result<Message> res = Methods.sendReply(msg.chat.id, msg.message_id, "You can only assign a Group or Supergroup to be the Debug Chat.\nIf you want to reset it back to PM, please use the admin menu.");
                    if (!res.ok) { Logger.LogError("Error contacting the admin Chat: " + res.description); }
                    return;
                  }
                  else
                  {
                    if (msg.chat.id == Configs.RunningConfig.AdminChat)
                    {
                      Result<Message> res = Methods.sendReply(msg.chat.id, msg.message_id, "Debug Chat is already set to this group.");
                      if (!res.ok) { Logger.LogError("Error contacting the admin Chat: " + res.description); }
                      return;
                    }
                    else
                    {
                      Configs.RunningConfig.AdminChat = msg.chat.id;
                      Result<Message> res = Methods.sendReply(msg.chat.id, msg.message_id, "Debug Chat is now set to this group.");
                      if (!res.ok) { Logger.LogError("Error contacting the admin Chat: " + res.description); }
                      Logger.LogAdmin("Debug Chat has been set to: " + msg.chat.id);
                      return;
                    }
                  }
                }
            }
          }
          Events.OnText(msg, Args, isEdited);
        }
      }
      #endregion
    }
        #endregion


        #region Events and Delegetes

        // Delegates
        public delegate void DreadBotEventHandler(EventArgs eventArgs);

        //Event Providers
        public static event DreadBotEventHandler ForwardEvent;
        public static event DreadBotEventHandler StickerEvent;
        public static event DreadBotEventHandler ImageEvent;
        public static event DreadBotEventHandler VideoNoteEvent;
        public static event DreadBotEventHandler JoinEvent;
        public static event DreadBotEventHandler PartEvent;
        public static event DreadBotEventHandler AnimationEvent;
        public static event DreadBotEventHandler AudioEvent;
        public static event DreadBotEventHandler VideoEvent;
        public static event DreadBotEventHandler GameEvent;
        public static event DreadBotEventHandler VoiceClipEvent;
        public static event DreadBotEventHandler VenueClipEvent;
        public static event DreadBotEventHandler PinnedMessageEvent;
        public static event DreadBotEventHandler TitleChangeEvent;
        public static event DreadBotEventHandler ChatPhotoEvent;
        public static event DreadBotEventHandler LocationEvent;
        public static event DreadBotEventHandler NewGroupEvent;
        public static event DreadBotEventHandler GroupUpgradeEvent;
        public static event DreadBotEventHandler CallbackEvent;
        public static event DreadBotEventHandler ShippingQueryEvent;
        public static event DreadBotEventHandler ChosenInlineEvent;
        public static event DreadBotEventHandler InlineQueryEvent;
        public static event DreadBotEventHandler PreCheckoutEvent;
        public static event DreadBotEventHandler PassportDataEvent;
        public static event DreadBotEventHandler TextEvent;

        #endregion

        #region Event Triggers
        public static void OnForward(Message msg, string[] args) { ForwardEvent?.Invoke(new MessageEventArgs() { msg = msg, Args = args }); }
        public static void OnSticker(Message msg) { StickerEvent?.Invoke(new MessageEventArgs() { msg = msg }); }
        public static void OnImage(Message msg, string[] args, bool isEdited) { ImageEvent?.Invoke(new MessageEventArgs() { msg = msg, Args = args, isEdited = isEdited }); }
        public static void OnVideoNote(Message msg, string[] args, bool isEdited) { VideoNoteEvent?.Invoke(new MessageEventArgs() { msg = msg, Args = args, isEdited = isEdited }); }
        public static void OnJoin(Message msg) { JoinEvent?.Invoke(new SystemMsgEventArgs() { msg = msg }); }
        public static void OnPart(Message msg) { PartEvent?.Invoke(new SystemMsgEventArgs() { msg = msg }); }
        public static void OnAnimation(Message msg, string[] args, bool isEdited) { AnimationEvent?.Invoke(new MessageEventArgs() { msg = msg, Args = args, isEdited = isEdited }); }
        public static void OnAudio(Message msg, string[] args, bool isEdited) { AudioEvent?.Invoke(new MessageEventArgs() { msg = msg, Args = args, isEdited = isEdited }); }
        public static void OnVideo(Message msg, string[] args, bool isEdited) { VideoEvent?.Invoke(new MessageEventArgs() { msg = msg, Args = args, isEdited = isEdited }); }
        public static void OnGame(Message msg, string[] args, bool isEdited) { GameEvent?.Invoke(new MessageEventArgs() { msg = msg, Args = args, isEdited = isEdited }); }
        public static void OnVoiceClip(Message msg, string[] args, bool isEdited) { VoiceClipEvent?.Invoke(new MessageEventArgs() { msg = msg, Args = args, isEdited = isEdited }); }
        public static void OnVenueClip(Message msg, string[] args, bool isEdited) { VenueClipEvent?.Invoke(new MessageEventArgs() { msg = msg, Args = args, isEdited = isEdited }); }
        public static void OnPinnedMessage(Message msg, string[] args, bool isEdited) { PinnedMessageEvent?.Invoke(new MessageEventArgs() { msg = msg, Args = args, isEdited = isEdited }); }
        public static void OnTitleChange(Message msg, string[] args) { TitleChangeEvent?.Invoke(new SystemMsgEventArgs() { msg = msg }); }
        public static void OnChatPhoto(Message msg) { ChatPhotoEvent?.Invoke(new SystemMsgEventArgs() { msg = msg }); }
        public static void OnLocation(Message msg) { LocationEvent?.Invoke(new SystemMsgEventArgs() { msg = msg }); }
        public static void OnNewGroup(Message msg) { NewGroupEvent?.Invoke(new SystemMsgEventArgs() { msg = msg }); }
        public static void OnGroupUpgrade(Message msg) { GroupUpgradeEvent?.Invoke(new SystemMsgEventArgs() { msg = msg }); }
        public static void OnCallback(CallbackQuery callback) { CallbackEvent?.Invoke(new CallbackEventArgs() { callbackQuery = callback }); }
        public static void OnShippingQuery(ShippingQuery shippingQuery) { ShippingQueryEvent?.Invoke(new ShippingQueryEventArgs() { shippingQuery = shippingQuery }); }
        public static void OnChosenInline(ChosenInlineResult inlineResult) { ChosenInlineEvent?.Invoke(new ChosenInlineEventArgs() { chosenResult = inlineResult }); }
        public static void OnInlineQuery(InlineQuery inlineQuery) { InlineQueryEvent?.Invoke(new InlineQueryEventArgs() { inlineQuery = inlineQuery }); }
        public static void OnPreCheckout(PreCheckoutQuery checkoutQuery) { PreCheckoutEvent?.Invoke(new PreCheckoutEventArgs() { preCheckoutQuery = checkoutQuery }); }
        public static void OnPassportData(Message msg) { PassportDataEvent?.Invoke(new MessageEventArgs() { msg = msg }); }
        public static void OnText(Message Msg, string[] args, bool isEdited) { TextEvent?.Invoke(new MessageEventArgs() { msg = Msg, Args = args, isEdited = isEdited }); }

        #endregion
    }

    #region Event Args

    #region Message Event Args

    public class MessageEventArgs : EventArgs
    {
        public Message msg { get; set; }
        public string[] Args { get; set; }
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
    #endregion

    #endregion
}

