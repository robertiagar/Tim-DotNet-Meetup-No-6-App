using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimNetDemoApp.Interfaces;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace TimNetDemoApp.Services
{
    public class StatusNotificationService: IStatusNotificationService
    {
        public async Task SetStatusAsync(string message)
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
                await Task.Delay(0);
            }
        }
    }
}
