#region License 
//MIT License
//Copyright(c) [2024]
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
using System.Runtime.Serialization;
namespace DreadBot
{
	/// <summary>
	/// This object contains information about a message that is being replied to, which may come from another chat or forum topic.
	/// </summary>
	[DataContract]
	public class ExternalReplyInfo
	{
		/// <summary>
		/// Origin of the message replied to by the given message
		/// </summary>
		[DataMember(Name = "origin", IsRequired = true)]
		public MessageOrigin origin { get; set; }
		/// <summary>
		/// Optional. Chat the original message belongs to. Available only if the chat is a supergroup or a channel.
		/// </summary>
		[DataMember(Name = "chat", EmitDefaultValue = false)]
		public Chat chat { get; set; }
		/// <summary>
		/// Optional. Unique message identifier inside the original chat. Available only if the original chat is a supergroup or a channel.
		/// </summary>
		[DataMember(Name = "message_id", EmitDefaultValue = false)]
		public long message_id { get; set; }
		/// <summary>
		/// Optional. Options used for link preview generation for the original message, if it is a text message
		/// </summary>
		[DataMember(Name = "link_preview_options", EmitDefaultValue = false)]
		public LinkPreviewOptions link_preview_options { get; set; }
		/// <summary>
		/// Optional. Message is an animation, information about the animation
		/// </summary>
		[DataMember(Name = "animation", EmitDefaultValue = false)]
		public Animation animation { get; set; }
		/// <summary>
		/// Optional. Message is an audio file, information about the file
		/// </summary>
		[DataMember(Name = "audio", EmitDefaultValue = false)]
		public Audio audio { get; set; }
		/// <summary>
		/// Optional. Message is a general file, information about the file
		/// </summary>
		[DataMember(Name = "document", EmitDefaultValue = false)]
		public Document document { get; set; }
		/// <summary>
		/// Optional. Message contains paid media; information about the paid media
		/// </summary>
		[DataMember(Name = "paid_media", EmitDefaultValue = false)]
		public PaidMediaInfo paid_media { get; set; }
		/// <summary>
		/// Optional. Message is a photo, available sizes of the photo
		/// </summary>
		[DataMember(Name = "photo", EmitDefaultValue = false)]
		public Array<PhotoSize> photo { get; set; }
		/// <summary>
		/// Optional. Message is a sticker, information about the sticker
		/// </summary>
		[DataMember(Name = "sticker", EmitDefaultValue = false)]
		public Sticker sticker { get; set; }
		/// <summary>
		/// Optional. Message is a forwarded story
		/// </summary>
		[DataMember(Name = "story", EmitDefaultValue = false)]
		public Story story { get; set; }
		/// <summary>
		/// Optional. Message is a video, information about the video
		/// </summary>
		[DataMember(Name = "video", EmitDefaultValue = false)]
		public Video video { get; set; }
		/// <summary>
		/// Optional. Message is a video note, information about the video message
		/// </summary>
		[DataMember(Name = "video_note", EmitDefaultValue = false)]
		public VideoNote video_note { get; set; }
		/// <summary>
		/// Optional. Message is a voice message, information about the file
		/// </summary>
		[DataMember(Name = "voice", EmitDefaultValue = false)]
		public Voice voice { get; set; }
		/// <summary>
		/// Optional. True, if the message media is covered by a spoiler animation
		/// </summary>
		[DataMember(Name = "has_media_spoiler", EmitDefaultValue = false)]
		public bool has_media_spoiler { get; set; }
		/// <summary>
		/// Optional. Message is a shared contact, information about the contact
		/// </summary>
		[DataMember(Name = "contact", EmitDefaultValue = false)]
		public Contact contact { get; set; }
		/// <summary>
		/// Optional. Message is a dice with random value
		/// </summary>
		[DataMember(Name = "dice", EmitDefaultValue = false)]
		public Dice dice { get; set; }
		/// <summary>
		/// Optional. Message is a game, information about the game. More about games »
		/// </summary>
		[DataMember(Name = "game", EmitDefaultValue = false)]
		public Game game { get; set; }
		/// <summary>
		/// Optional. Message is a scheduled giveaway, information about the giveaway
		/// </summary>
		[DataMember(Name = "giveaway", EmitDefaultValue = false)]
		public Giveaway giveaway { get; set; }
		/// <summary>
		/// Optional. A giveaway with public winners was completed
		/// </summary>
		[DataMember(Name = "giveaway_winners", EmitDefaultValue = false)]
		public GiveawayWinners giveaway_winners { get; set; }
		/// <summary>
		/// Optional. Message is an invoice for a payment, information about the invoice. More about payments »
		/// </summary>
		[DataMember(Name = "invoice", EmitDefaultValue = false)]
		public Invoice invoice { get; set; }
		/// <summary>
		/// Optional. Message is a shared location, information about the location
		/// </summary>
		[DataMember(Name = "location", EmitDefaultValue = false)]
		public Location location { get; set; }
		/// <summary>
		/// Optional. Message is a native poll, information about the poll
		/// </summary>
		[DataMember(Name = "poll", EmitDefaultValue = false)]
		public Poll poll { get; set; }
		/// <summary>
		/// Optional. Message is a venue, information about the venue
		/// </summary>
		[DataMember(Name = "venue", EmitDefaultValue = false)]
		public Venue venue { get; set; }
	}
}
