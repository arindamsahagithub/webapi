using System;
using System.Collections.Generic;
using System.Text;
using Sherlock.Apps.Func.Models;
using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;

namespace Sherlock.Apps.Func.Email.Handlers
{
    public abstract class AbstractEmailHandler : IEmailHandler
    {
        public readonly EmailRequestPayload _payload;
        public readonly IConfiguration _config;
        public readonly HtmlNode _documentNode;
        public AbstractEmailHandler(EmailRequestPayload payload, IConfiguration config)
        {
            _payload = payload;
            _documentNode = new HTMLParser(_payload.Body).Document;
            _config = config;
        }

        private string GetUTF8Html(string html){
            return Encoding.GetEncoding("UTF-16").GetString(Encoding.Default.GetBytes(html));
        }

        public abstract void Parse();
    }
}
