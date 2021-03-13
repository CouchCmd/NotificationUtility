using System;
using System.Collections.Generic;
using System.Text;

namespace NotificatUtility.Models.Services
{
    /// <summary>
    /// Request for sending an email
    /// </summary>
    internal class SendMailRequest
    {
        /// <summary>
        /// Who email is being sent to
        /// </summary>
        internal string EmailRecipient { get; set; }

        /// <summary>
        /// Contents of email
        /// </summary>
        internal string EmailBody { get; set; }

        /// <summary>
        /// Subject of email
        /// </summary>
        internal string EmailSubject { get; set; }
    }
}
