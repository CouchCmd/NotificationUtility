using System;
using System.Collections.Generic;
using System.Text;

namespace NotificatUtility.Models.Services
{
    /// <summary>
    /// Response for getting notifications
    /// </summary>
    public class NotificationTypeResponse : Response
    {
        /// <summary>
        /// List of notification types available
        /// </summary>
        public List<string> Types { get; set; }
    }
}
