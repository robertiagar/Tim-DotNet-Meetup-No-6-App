using System;
using System.Collections.Generic;
using System.Text;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace TimNetDemoApp
{
    public class ToastService
    {
        public static void ShowToast(string message)
        {
            if (message != null)
            {
                var xmlFormat = @"<toast>
                                    <visual>
                                        <binding template=""ToastText01"">
                                            <text id=""1"">{0}</text>
                                        </binding>  
                                    </visual>
                                </toast>";

                var notificationText = string.Format(xmlFormat, message);
                var toastXml = new XmlDocument();
                toastXml.LoadXml(notificationText);

                var notification = new ToastNotification(toastXml);

                var notifier = ToastNotificationManager.CreateToastNotifier();
                notifier.Show(notification);
            }
        }
    }
}
