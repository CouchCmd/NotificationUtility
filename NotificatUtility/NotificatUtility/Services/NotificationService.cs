using NotificatUtility.Factories;
using NotificatUtility.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotificatUtility.Services
{
    /// <inheritdoc/>
    internal class NotificationService : INotificationService
    {
        /// <summary>
        /// Instance of the ISmtpService
        /// </summary>
        private readonly ISmtpService _smtp;

        /// <summary>
        /// Instance of the INotificationBuilder
        /// </summary>
        private readonly INotificationBuilder _builder;

        /// <summary>
        /// Constructor for NotificationService
        /// </summary>
        /// <param name="smtp">Passing in dependency for ISmtpService</param>
        /// <param name="builder">Passing in dependency for INotificationBuilder</param>
        public NotificationService(ISmtpService smtp, INotificationBuilder builder)
        {
            _smtp = smtp;
            _builder = builder;
        }

        /// <inheritdoc/>
        public NotificationTypeResponse GetNotificationTypes(NotificationTypeRequest request)
        {
            NotificationTypeResponse response = new NotificationTypeResponse()
            {
                Errors = new List<string>(),
                Success = false,
                Types = new List<string>()
            };

            try
            {
                var buildResp = _builder.BuildNotificationTypes(new Models.Factories.BuildNotificationTypesRequest());

                if (buildResp == null)
                {
                    throw new Exception("Null return from builder for types" +
                        "In Class: " + nameof(NotificationService) +
                        "In Method: " + nameof(GetNotificationTypes));
                }
                else if (buildResp.Success == false ||
                    (buildResp.Errors != null && buildResp.Errors.Count > 0))
                {
                    throw new Exception("Invalid return from builder for types. Errors: " + string.Join(", ",buildResp.Errors) +
                        "In Class: " + nameof(NotificationService) +
                        "In Method: " + nameof(GetNotificationTypes));
                }

                response.Types = buildResp.TypeValuePairs.Select(y => y.Key).ToList();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.ToString());
            }

            return response;
        }

        /// <inheritdoc/>
        public NotificationResponse SendNotification(NotificationRequest request)
        {
            NotificationResponse response = new NotificationResponse()
            {
                Errors = new List<string>(),
                Success = false
            };

            try
            {
                if (request == null)
                {
                    throw new Exception("Null request for sending notification" +
                         "In Class: " + nameof(NotificationService) +
                         "In Method: " + nameof(SendNotification));
                }
                else if (string.IsNullOrEmpty(request.Body) ||
                    string.IsNullOrEmpty(request.Subject) ||
                    string.IsNullOrEmpty(request.NotificationType) ||
                    string.IsNullOrEmpty(request.Receptient))
                {
                    throw new Exception("Invalid request for sending notification" +
                        "In Class: " + nameof(NotificationService) +
                        "In Method: " + nameof(SendNotification) +
                        "Request Body:" + request.Body +
                        "Request Subject:" + request.Subject +
                        "Request NotificationType:" + request.NotificationType +
                        "Request Receptient:" + request.Receptient);
                }

                var buildResp = _builder.BuildNotificationEmail(new Models.Factories.BuildNotifcationRequest()
                {
                    NotificationType = request.NotificationType,
                    Recipient = request.Receptient
                });

                if (buildResp == null)
                {
                    throw new Exception("Null return from builder for email" +
                        "In Class: " + nameof(NotificationService) +
                        "In Method: " + nameof(SendNotification));
                }
                else if (buildResp.Success == false ||
                    (buildResp.Errors != null && buildResp.Errors.Count > 0))
                {
                    throw new Exception("Invalid return from builder for email. Errors: " + string.Join(", ", buildResp.Errors) +
                        "In Class: " + nameof(NotificationService) +
                        "In Method: " + nameof(SendNotification));
                }

                var sendResp = _smtp.SendMail(new SendMailRequest()
                {
                    EmailBody = request.Body,
                    EmailRecipient = buildResp.Email,
                    EmailSubject = request.Subject,
                });

                if (sendResp == null)
                {
                    throw new Exception("Null return from email sender" +
                        "In Class: " + nameof(NotificationService) +
                        "In Method: " + nameof(SendNotification));
                }
                else if (sendResp.Success == false ||
                    (buildResp.Errors != null && buildResp.Errors.Count > 0))
                {
                    throw new Exception("Invalid eturn from email sender. Errors: " + string.Join(", ", buildResp.Errors) +
                        "In Class: " + nameof(NotificationService) +
                        "In Method: " + nameof(SendNotification));
                }

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
