namespace Sherlock.Apps.Func.Models
{
    public class EmailRequestPayload
    {
        public string Body { get; set; }
        public string Subject { get; set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
    }
}