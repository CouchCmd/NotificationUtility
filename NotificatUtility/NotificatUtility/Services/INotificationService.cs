using NotificatUtility.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificatUtility.Services
{
    /// <summary>
    /// Service for handling interaction with notifications
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Method for sending a notification
        /// </summary>
        /// <param name="request">request with details on what notification to send</param>
        /// <returns>success or list of errors</returns>
        NotificationResponse SendNotification(NotificationRequest request);

        /// <summary>
        /// Request for getting availabile notification types
        /// </summary>
        /// <param name="request">request with information on what types to get</param>
        /// <returns>success with list of types or error</returns>
        NotificationTypeResponse GetNotificationTypes(NotificationTypeRequest request);
    }
}
