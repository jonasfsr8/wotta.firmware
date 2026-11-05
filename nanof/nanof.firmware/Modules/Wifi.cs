using nanof.Settings;
using nanoFramework.Networking;
using System;
using System.Diagnostics;
using System.Threading;

namespace nanof.Modules
{
    public static class Wifi
    {
        public static bool Connect()
        {
            Debug.WriteLine("Connecting to Wi-Fi...");

            using var cancellation = new CancellationTokenSource(NetworkSettings.WifiSleepTime);

            bool success = WifiNetworkHelper.ConnectDhcp(
                NetworkSettings.Ssid,
                NetworkSettings.Password,
                requiresDateTime: true,
                token: cancellation.Token);

            if (!success)
            {
                Debug.WriteLine($"Wi-Fi connection failed: {WifiNetworkHelper.Status}");

                if (WifiNetworkHelper.HelperException != null)
                {
                    Debug.WriteLine(WifiNetworkHelper.HelperException.Message);
                }

                return false;
            }

            Debug.WriteLine($"IP: {System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()[0].IPv4Address}");
            Debug.WriteLine($"UTC: {DateTime.UtcNow}");

            return true;
        }
    }
}
