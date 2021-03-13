using System;
using System.Collections.Generic;
using System.Text;

namespace NotificatUtility.Models.Factories
{
    /// <summary>
    /// Response for building notification types
    /// </summary>
    internal class BuildNotificationTypesResponse : Response
    {
        /// <summary>
        /// Dictionary contain notification types with caluse assocaited
        /// </summary>
        public Dictionary<string, string> TypeValuePairs { get; set; }
    }
}
