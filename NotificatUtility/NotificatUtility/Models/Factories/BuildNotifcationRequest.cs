using System;
using System.Collections.Generic;
using System.Text;

namespace NotificatUtility.Models.Factories
{
    /// <summary>
    /// Request to build notification
    /// </summary>
    internal class BuildNotifcationRequest
    {
        /// <summary>
        /// Who notification is for
        /// </summary>
        internal string Recipient { get; set; }

        /// <summary>
        /// Notification type of receipient 
        /// </summary>
        internal string NotificationType { get; set; }
    }
}
