using NotificatUtility.Models.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificatUtility.Factories
{
    /// <inheritdoc/>
    internal class NotificationBuilder : INotificationBuilder
    {
        /// <inheritdoc/>
        public BuildNotificationResponse BuildNotificationEmail(BuildNotifcationRequest request)
        {
            BuildNotificationResponse response = new BuildNotificationResponse()
            {
                Errors = new List<string>(),
                Success = false
            };

            try
            {
                if (request == null)
                {
                    throw new Exception("Null request sent for building a notification email." +
                        "In Class: " + nameof(NotificationBuilder) +
                        "In Method: " + nameof(BuildNotificationEmail));
                }
                else if (string.IsNullOrEmpty(request.NotificationType) ||
                    string.IsNullOrEmpty(request.Recipient))
                {
                    throw new Exception("Invalid request for building a notification email." +
                        "In Class: " + nameof(NotificationBuilder) +
                        "In Method: " + nameof(BuildNotificationEmail) +
                        "With Request Recipient: " + request.Recipient +
                        "And Request NotificaitonType: " + request.NotificationType);
                }

                var typeResponse = BuildNotificationTypes(new BuildNotificationTypesRequest());

                if (typeResponse == null || 
                    typeResponse.Success == false ||
                    (typeResponse.Errors != null && typeResponse.Errors.Count > 0))
                {
                    throw new Exception("Invalid response from BuildNotificationTypes");
                }

                // get types
                var pair = typeResponse.TypeValuePairs.Where(y => y.Key.Equals(request.NotificationType, StringComparison.InvariantCultureIgnoreCase));

                if (pair == null)
                {
                    throw new Exception("No notification type found for passed in values");
                }

                // build email from type
                response.Email = request.Recipient + pair.First().Value;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.ToString());
            }

            return response;
        }

        /// <inheritdoc/>
        public BuildNotificationTypesResponse BuildNotificationTypes(BuildNotificationTypesRequest request)
        {
            BuildNotificationTypesResponse response = new BuildNotificationTypesResponse()
            {
                Success = false,
                Errors = new List<string>(),
                TypeValuePairs = new Dictionary<string, string>()
            };

            try
            {
                // hard coding possible types
                string rawValues = "AlaskaCommunications,@msg.acsalaska.com;";
                rawValues += "AT&T,@mms.att.net;";
                rawValues += "BellMobility,@txt.bell.ca;";
                rawValues += "BoostMobile,@myboostmobile.com;";
                rawValues += "T-Mobile,@tmomail.net;";
                rawValues += "Cricket,@mms.cricketwireless.net;";
                rawValues += "GoogleFi,@msg.fi.google.com;";
                rawValues += "MetroPCS,@mymetropcs.com;";
                rawValues += "MintMobile,@tmomail.net;";
                rawValues += "Sprint,@messaging.sprintpcs.com;";
                rawValues += "USCellular,@email.uscc.net;";
                rawValues += "Verizon,@vtext.com;";
                rawValues += "Viaero,@viaerosms.com;";
                rawValues += "VirginMobile,@vmobl.com;";
                rawValues += "XfinityMobile,@vtext.com;";
                rawValues += "UnionWireless,@mms.unionwireless.com;";
                rawValues += "Email,";

                // constructing dictionaries from types
                Parallel.ForEach(rawValues.Split(';'), keyValue =>
                {
                    string key = keyValue.Split(',').First();
                    string value = keyValue.Split(',').Last();

                    lock (response.TypeValuePairs)
                    {
                        response.TypeValuePairs.Add(key, value);
                    }
                });

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.ToString());
            }

            return response;
        }
    }
}
