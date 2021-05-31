namespace framework.Domain
{
    public class EmailConfig
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string SmtpServer { get; set; }
        public string DisplayName { get; set; }
        public bool EnableSsl { get; set; }
    }
}