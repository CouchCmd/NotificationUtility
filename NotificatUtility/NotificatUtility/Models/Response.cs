using System;
using System.Collections.Generic;
using System.Text;

namespace NotificatUtility.Models
{
    /// <summary>
    /// Parent response object
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Gets or sets an indicator whether or not the notification was a success
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// In the event response is not a success a list of errors indicating what went wrong
        /// </summary>
        public List<string> Errors { get; set; }
    }
}
