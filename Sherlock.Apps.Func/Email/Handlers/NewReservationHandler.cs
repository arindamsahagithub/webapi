using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Sherlock.Apps.Func.Models;
using Sherlock.Apps.Utility;

namespace Sherlock.Apps.Func.Email.Handlers
{
    public class NewReservationHandler : AbstractEmailHandler
    {
        private const string NEW_RESERVATION_SUBJECT = "NewReservationSubject";
        private const string LISTING_URL = "ListingURL";
        private const string ZWNJ_SEPARATOR = "\u200c";
        private readonly RegexHelper _regexHelper;

        public NewReservationHandler(EmailRequestPayload payload, IConfiguration config,
            RegexHelper regexHelper) : base(payload, config)
        {
            _regexHelper = regexHelper;
        }

        public override void Parse()
        {
            var newReservation = new NewReservation
            {
                ListingId = _regexHelper.GetRegexMatch(
                    _documentNode.GetAnchorElementByHref("https://www.airbnb.com/rooms").Attributes["href"].Value,
                    _config[LISTING_URL], "listingId"),
                GuestName = _regexHelper.GetRegexMatch(_payload.Subject,
                    _config[NEW_RESERVATION_SUBJECT], "user"),
                ReservationId = _documentNode.GetElementByText("Confirmation code")
                    .ParentNode.NextSibling.InnerText.Trim(),
                CheckInDate = ExtractDate("C‌h‌e‌c‌k‌-‌i‌n‌ ‌A‌f‌t‌e‌r‌"),
                CheckOutDate = ExtractDate("C‌h‌e‌c‌k‌o‌u‌t‌ ‌b‌y‌"),
                GuestCount = int.Parse(_documentNode.GetElementByText("Guests").ParentNode.NextSibling.InnerText)
            };

        }

        private DateTime ExtractDate(string keyword){
            var dateElem = _documentNode.GetElementByText(keyword);
            var time = dateElem.InnerText.Replace(keyword, "").Replace(ZWNJ_SEPARATOR,"").Trim();
            return DateTime.Parse(
                $"{dateElem.GetParentByTag("p").PreviousSibling.InnerText.Replace(ZWNJ_SEPARATOR,"").Trim()} {time}");
        }
    }
}