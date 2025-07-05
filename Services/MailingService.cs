using System.Net;
using System.Net.Mail;
using WeddingRSVP.Models;

namespace WeddingRSVP.Services
{
    public class MailingService(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;

        public void SendEmail(GuestRsvp form)
        {
            var isAttending = form.IsAttending ? "will be attending!" : "will not be able to attend";

            var subject = $"New Guest RSVP Recieved - {form.FirstName} {form.LastName}";

            var senderPassword = _configuration.GetValue<string>("Passwords:senderPassword");

            var email = _configuration.GetValue<string>("Passwords:email") ?? "email@gmail.com";

            var body =
                $"{form.FirstName} {form.LastName} {isAttending}" + Environment.NewLine +
                $"Phone Number: {form.PhoneNumber}" + Environment.NewLine +
                $"Dietary Requirements: {form.DietaryRequirements}" + Environment.NewLine +
                $"Notes: {form.Notes}";

            SmtpClient smtpClient = new()
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(email, senderPassword)
            };
      
            smtpClient.Send(email, email, subject, body);
        }
    }
}
