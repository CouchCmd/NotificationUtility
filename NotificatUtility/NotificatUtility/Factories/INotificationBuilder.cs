using NotificatUtility.Models.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificatUtility.Factories
{
    /// <summary>
    /// Factory handling building of notification specific objects
    /// </summary>
    internal interface INotificationBuilder
    {
        /// <summary>
        /// Method for building a notifications email recipient
        /// </summary>
        /// <param name="request">request with information on recepient to build</param>
        /// <returns>success with email or list of errors</returns>
        BuildNotificationResponse BuildNotificationEmail(BuildNotifcationRequest request);

        /// <summary>
        /// Method for building notification types
        /// </summary>
        /// <param name="request">request with details on types to build</param>
        /// <returns>success with list of types or error</returns>
        BuildNotificationTypesResponse BuildNotificationTypes(BuildNotificationTypesRequest request);
    }
}
