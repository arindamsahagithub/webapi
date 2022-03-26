using System;
using Microsoft.Extensions.Configuration;
using Sherlock.Apps.Func.Models;
using Sherlock.Apps.Utility;

namespace Sherlock.Apps.Func.Email.Handlers
{
    public class ChangeReservationHandler : AbstractEmailHandler
    {
        private const string RESERVATION_CHANGE_URL_REGEX = "https://www.airbnb.com/reservation_alterations/show/(?<listingId>\\w+).*confirmation_code=(?<confirmationCode>\\w+).*";
        private readonly RegexHelper _regexHelper;
        public ChangeReservationHandler(EmailRequestPayload payload, IConfiguration config, 
            RegexHelper regexHelper) : base(payload, config)
        {
            _regexHelper = regexHelper;

        }
        
        public override void Parse()
        {
            ExtractReservation();
        }

        private Reservation ExtractReservation(){
            var reservationChangeUrl = _documentNode
                .GetAnchorElementByHref("https://www.airbnb.com/reservation_alterations/show")
                .Attributes["href"].Value;
            
            var requestedDatesList = _documentNode.GetElementByText("Requested Dates")
                .GetParentByTag("table")
                .ParentNode
                .GetLastDescendantByTag("table")
                .InnerText
                .Split("-");

            return new Reservation
            {
                ReservationId = _regexHelper.GetRegexMatch(reservationChangeUrl,
                    RESERVATION_CHANGE_URL_REGEX, "confirmationCode"),
                GuestName = _regexHelper.GetRegexMatch(_payload.Subject,
                    _config[AppConstants.RESERVATION_CHANGE_EMAIL_SUBJECT], "userName"),
                ListingId = _regexHelper.GetRegexMatch(reservationChangeUrl,
                    RESERVATION_CHANGE_URL_REGEX, "listingId"),
                CheckInDate = DateTime.Parse(requestedDatesList[0].Trim()),
                CheckOutDate = DateTime.Parse(requestedDatesList[1].Trim())
            };
        }
    }
}