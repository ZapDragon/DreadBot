using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreadBot
{
    //Telegram Bot Method Enums
    #region Method Enums

    public enum Method : byte
    {
        #region Getting Updates

        getUpdates,
        setWebhook,
        deleteWebhook,
        getWebhookInfo,

        #endregion

        #region Base Methods

        getMe,
        sendMessage,
        forwardMessage,
        sendPhoto,
        sendAudio,
        sendDocument,
        sendVideo,
        sendAnimation,
        sendVoice,
        sendVideoNote,
        sendMediaGroup,
        sendLocation,
        editMessageLiveLocation,
        stopMessageLiveLocation,
        sendVenue,
        sendContact,
        sendPoll,
        sendChatAction,
        getUserProfilePhotos,
        getFile,
        kickChatMember,
        unbanChatMember,
        restrictChatMember,
        promoteChatMember,
        setChatPermissions,
        exportChatInviteLink,
        setChatPhoto,
        deleteChatPhoto,
        setChatTitle,
        setChatDescription,
        pinChatMessage,
        unpinChatMessage,
        leaveChat,
        getChat,
        getChatAdministrators,
        getChatMembersCount,
        getChatMember,
        setChatStickerSet,
        deleteChatStickerSet,
        answerCallbackQuery,

        #endregion

        #region Updating Messages

        editMessageText,
        editMessageCaption,
        editMessageMedia,
        editMessageReplyMarkup,
        stopPoll,
        deleteMessage,

        #endregion

        #region Stickers

        sendSticker,
        getStickerSet,
        uploadStickerFile,
        createNewStickerSet,
        addStickerToSet,
        setStickerPositionInSet,
        deleteStickerFromSet,

        #endregion

        #region Inline Mode

        answerInlineQuery,

        #endregion

        #region Payments

        sendInvoice,
        answerShippingQuery,
        answerPreCheckoutQuery,

        #endregion

        #region Passport

        setPassportDataErrors,

        #endregion

        #region Games

        sendGame,
        setGameScore,
        getGameHighScores

        #endregion
    }
    #endregion
}
