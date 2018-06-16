using System.Net;
using System.Net.Mail;

namespace RedTopDev.EmailHelper
{
    /// <summary>
    /// Email helper
    /// </summary>
    public class Email
    {
        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="mail">The mail.</param>
        public void SendEmail(Mail mail)
        {
            try
            {
                MailMessage emailMessage = new MailMessage();
                emailMessage.From = mail.From;
                foreach (var item in mail.To)
                {
                    emailMessage.To.Add(item);
                }
                if (null != mail.CC)
                {
                    foreach (var item in mail.CC)
                    {
                        emailMessage.CC.Add(item);
                    }
                }
                if (null != mail.BCC)
                {
                    foreach (var item in mail.BCC)
                    {
                        emailMessage.Bcc.Add(item);
                    }
                }
                using (SmtpClient client = new SmtpClient())
                {
                    client.Port = mail.Port;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = mail.Authenticate;
                    client.Host = mail.Host;
                    emailMessage.Subject = mail.Subject;
                    emailMessage.Body = mail.Body;
                    emailMessage.IsBodyHtml = mail.IsBodyHtml;
                    if (mail.Authenticate)
                        client.Credentials = new NetworkCredential(mail.UserName, mail.Password);
                    if (null != mail.Attachments)
                    {
                        foreach (var item in mail.Attachments)
                        {
                            emailMessage.Attachments.Add(new Attachment(item));
                        }
                    }
                    if(mail.EnableSSL)
                    client.EnableSsl = true;
                    client.Send(emailMessage);
                }

            }
            catch
            {
                throw;
            }
        }
    }
}
