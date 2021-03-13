using NotificatUtility.Models.Services;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace NotificatUtility.Services
{
    /// <inheritdoc/>
    internal class SmtpService : ISmtpService
    {
        /// <inheritdoc/>
        public SendMailResponse SendMail(SendMailRequest request)
        {
            SendMailResponse response = new SendMailResponse()
            {
                Errors = new List<string>(),
                Success = false
            };

            try
            {
                if (request == null)
                {
                    throw new Exception("Null request sent for sending email" +
                        "In Class: " + nameof(SmtpService) +
                        "In Method: " + nameof(SendMail));
                }
                else if (string.IsNullOrEmpty(request.EmailBody) ||
                    string.IsNullOrEmpty(request.EmailRecipient) ||
                    string.IsNullOrEmpty(request.EmailSubject))
                {
                    throw new Exception("Invalid request sent for sending email." +
                        "In Class: " + nameof(SmtpService) +
                        "In Method: " + nameof(SendMail) +
                        "With Request EmailRecipient: " + request.EmailRecipient +
                        "And Request EmailBody: " + request.EmailBody +
                        "And Request EmailSubject: " + request.EmailSubject);
                }

                // create message
                MailMessage mail = new MailMessage();

                // assign message details
                mail.From = new MailAddress("ReplacewithYourUser");
                mail.To.Add(request.EmailRecipient);
                mail.Subject = request.EmailSubject;
                mail.Body = request.EmailBody;
                mail.IsBodyHtml = false;

                // create smtp server
                SmtpClient smtp = new SmtpClient("Replacewithyoursmtp info");
                smtp.Port =  0; // Replacewithyoursmtp info
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("Replace with your user", "Replace with your password");
                smtp.EnableSsl = true;

                smtp.Send(mail);

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.ToString());
            }

            return response;
        }
    }
}
