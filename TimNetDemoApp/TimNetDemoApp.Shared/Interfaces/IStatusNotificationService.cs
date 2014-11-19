using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TimNetDemoApp.Interfaces
{
    public interface IStatusNotificationService
    {
        Task SetStatusAsync(string message);
    }
}
