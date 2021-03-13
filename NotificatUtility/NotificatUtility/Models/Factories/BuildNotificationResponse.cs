using System;
using System.Collections.Generic;
using System.Text;

namespace NotificatUtility.Models.Factories
{
    /// <summary>
    /// Response for building notification
    /// </summary>
    internal class BuildNotificationResponse : Response
    {
        /// <summary>
        /// Formatted email to send notification to.
        /// </summary>
        internal string Email { get; set; }
    }
}
