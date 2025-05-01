using System.Net;
using System.Net.Mail;

namespace Project.Presentation.Utilities
{
    public static class EmailSettings
    {
        public static void SendEmail(Email email)
        {
            var client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("medo12345883@gmail.com", "ywlkfbxyniladhkd");
            client.Send("medo12345883@gmail.com", email.To, email.Subject, email.Body);
        }
    }
}
