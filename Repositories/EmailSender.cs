using System.Net.Mail;
using System.Net;

namespace Bhutawala_Traders_API.Repositories
{
    public class EmailSender
    {
        public bool SendEmail(string recipientEmail, string subject, string body)
        {
            try
            {
                string senderEmail = "patelzainab541@gmail.com";  // Your Gmail ID
                string senderPassword = "gzch xfnh bnpu bbdz"; // Use App Password, NOT your Gmail password

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(recipientEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                mail.Headers.Add("X-Priority", "3"); // Normal priority
                mail.Headers.Add("X-MSMail-Priority", "Normal");
                mail.Headers.Add("Importance", "Normal");


                // Configure SMTP Client for Gmail
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtp.EnableSsl = true;  // Gmail requires SSL encryption

                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error sending email: {ex.Message}");
                return false;
            }
        }

    }
}
