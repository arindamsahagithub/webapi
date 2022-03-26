using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Sherlock.Apps.Func.Models;
using Sherlock.Apps.Func.Email;

namespace Sherlock.Apps.Func
{
    public class EmailParser
    {
        private readonly IEmailFactory _emailFactory;
        public EmailParser(IEmailFactory emailFactory)
        {
            _emailFactory = emailFactory;
        }

        [FunctionName("EmailParser")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"{this.GetType().Name} function started.");

            var reqJson = await new StreamReader(req.Body).ReadToEndAsync();

            log.LogInformation($"Email Request Body = {reqJson}");

            var emailReq = JsonSerializer.Deserialize<EmailRequestPayload>(reqJson, 
                new JsonSerializerOptions{PropertyNameCaseInsensitive= true});

            var emailHandler = _emailFactory.GetHandler(emailReq);

            if(emailHandler == null)
                log.LogError("Did not find an email handler.");
            else
                emailHandler.Parse();

            return new OkObjectResult("");
        }
    }
}
