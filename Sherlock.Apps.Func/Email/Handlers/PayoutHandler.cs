using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;
using Sherlock.Apps.Func.Models;
using Sherlock.Apps.Utility;

namespace Sherlock.Apps.Func.Email.Handlers
{
    public class PayoutHandler: AbstractEmailHandler
    {
        private readonly RegexHelper _regexHelper;
        public PayoutHandler(EmailRequestPayload payload, IConfiguration config, 
            RegexHelper regexHelper) : base(payload, config)
        {
            _regexHelper = regexHelper;
        }

        public override void Parse()
        {
            var accountId = _documentNode
                    .GetElementByText("Airbnb Account ID")
                    .GetParentByTag("tr")
                    .GetLastDescendantByTag("td")
                    .InnerText;

            var payout= new Payout
            {
                AccountId = accountId,
                Reservations = GetReservations(_documentNode)
            };
        }

        private List<Reservation> GetReservations(HtmlNode document)
        {
            var tableCells = document.GetElementsByText("Reservation");

            var reservations = new List<Reservation>();
            foreach (var node in tableCells)
            {
                reservations.Add(GetReservationDetails(node.GetParentByTag("tr")));
            }

            return reservations;
        }

        private Reservation GetReservationDetails(HtmlNode tableRow)
        {
            var cells = tableRow.ChildNodes;
            string[] dateFormats = { "MM/dd/yyyy" };
            var details = cells[1].GetDescendantsByTag("span").InnerHtml
                .Replace("<o:p></o:p>", "")
                .Split("<br>");
            var dates = details[0].Split("-");
            var lineTwoItems = details[1].Split("-");

            return new Reservation
            {
                Amount = ExtractAmount(cells[2].InnerText.Replace("£", "")),
                CheckInDate = DateTime.ParseExact(dates[0].Trim(), dateFormats, new CultureInfo("en-US"), DateTimeStyles.None),
                CheckOutDate = DateTime.ParseExact(dates[1].Trim(), dateFormats, new CultureInfo("en-US"), DateTimeStyles.None),
                GuestName = lineTwoItems[1].Trim(),
                ReservationId = lineTwoItems[0].Trim(),
                ListingId = ExtractListingId(details.Last().Trim())
            };
        }

        private string ExtractListingId(string text)
        {
            var pattern = new Regex(@"Listing ID: (?<listingId>\d+)");
            var match = pattern.Match(text);
            return match.Groups["listingId"].Value;
        }

        private decimal ExtractAmount(string text)
        {
            var pattern = new Regex(@"(?<amount>\d+.+\d)");
            var match = pattern.Match(text);
            return decimal.Parse(match.Groups["amount"].Value);
        }
    }
}
