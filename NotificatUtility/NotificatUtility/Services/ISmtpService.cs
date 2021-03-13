using NotificatUtility.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificatUtility.Services
{
    /// <summary>
    /// Service handling sending of notifications 
    /// </summary>
    internal interface ISmtpService
    {
        /// <summary>
        /// Method for sending mail message
        /// </summary>
        /// <param name="request">request with details on message to send</param>
        /// <returns>success or list of errors</returns>
        SendMailResponse SendMail(SendMailRequest request);
    }
}
