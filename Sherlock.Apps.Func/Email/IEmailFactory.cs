using System;
using Sherlock.Apps.Func.Email.Handlers;
using Sherlock.Apps.Func.Models;

namespace Sherlock.Apps.Func.Email
{
    public interface IEmailFactory
    {
        IEmailHandler GetHandler(EmailRequestPayload payload);
    }
}
