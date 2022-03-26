namespace Sherlock.Apps.Model
{
    public class EmailRequest : Base
    {
        public string Subject { get; set; }
        public string ReceivedDate { get; set; }
        public string ProcessingStatus { get; set; }
        public string ExtractedDate { get; set; }
        public string FromEmail { get; set; }
    }
}