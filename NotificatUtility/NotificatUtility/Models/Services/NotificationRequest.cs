using System;
using System.Collections.Generic;
using System.Text;

namespace NotificatUtility.Models.Services
{
    /// <summary>
    /// Request object for a notification
    /// </summary>
    public class NotificationRequest
    {
        /// <summary>
        /// Who is notification going
        /// </summary>
        public string Receptient { get; set; }

        /// <summary>
        /// What type of notification is this (verizon text, at&t text, or email
        /// </summary>
        public string NotificationType { get; set; }

        /// <summary>
        /// Contents of notification
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Subject of notification
        /// </summary>
        public string Subject { get; set; }
    }
}
