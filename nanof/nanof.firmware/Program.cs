using nanof.Modules;
using nanof.Settings;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace nanof.firmware
{
    public class Program
    {
        public static void Main()
        {
            Led.InitializeLeds();

            if (!Wifi.Connect()) return;

            Device.InitializeSensor();

            var mqttAwsClient = Mqtt.Connect();

            while (true)
            {
                var payload = Device.ReadSensorTelemetry();

                Led.TurnOnBlue();

                Debug.WriteLine("|");
                Debug.WriteLine("Publishing data to AWS IoT...");

                mqttAwsClient.Publish(
                    AwsSettings.Topic,
                    Encoding.UTF8.GetBytes(payload));

                Thread.Sleep(4000);
                Debug.WriteLine("Published");

                Led.TurnOffLeds();

                Thread.Sleep(10000);
            }
        }
    }
}
