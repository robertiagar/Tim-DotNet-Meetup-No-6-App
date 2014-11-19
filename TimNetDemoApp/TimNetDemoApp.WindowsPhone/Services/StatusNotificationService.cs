using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimNetDemoApp.Interfaces;
using Windows.Foundation.Metadata;
using Windows.UI.ViewManagement;

namespace TimNetDemoApp.Services
{
    public class StatusNotificationService : IStatusNotificationService
    {
        public async Task SetStatusAsync(string message)
        {
            var statusBar = StatusBar.GetForCurrentView();
            if (message != null)
            {
                statusBar.ProgressIndicator.Text = message;
                await statusBar.ProgressIndicator.ShowAsync();
            }
            else
            {
                await statusBar.ProgressIndicator.HideAsync();
            }
        }
    }
}
