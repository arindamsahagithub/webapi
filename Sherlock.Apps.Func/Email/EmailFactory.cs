using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Sherlock.Apps.Func.Email.Handlers;
using Sherlock.Apps.Func.Models;
using Sherlock.Apps.Utility;

namespace Sherlock.Apps.Func.Email
{
    public class EmailFactory : IEmailFactory
    {
        private readonly IConfiguration _config;
        private readonly RegexHelper _regex;
        public EmailFactory(IConfiguration config, RegexHelper regex)
        {
            _config = config;
            _regex = regex;
        }
        public IEmailHandler GetHandler(EmailRequestPayload payload)
        {
            if (_regex.IsRegexMatch(payload.Subject, _config[AppConstants.PAYOUT_EMAIL_SUBJECT]))
            {
                return new PayoutHandler(payload, _config, _regex);
            }
            else if (_regex.IsRegexMatch(payload.Subject, _config[AppConstants.NEW_RESERVATION_EMAIL_SUBJECT]))
            {
                return new NewReservationHandler(payload, _config, _regex);
            }
            else if (_regex.IsRegexMatch(payload.Subject, _config[AppConstants.RESERVATION_CHANGE_EMAIL_SUBJECT]))
            {
                return new ChangeReservationHandler(payload, _config, _regex);
            }
            return null;
        }
    }
}
