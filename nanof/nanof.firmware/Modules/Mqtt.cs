using nanof.Settings;
using nanoFramework.M2Mqtt;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace nanof.Modules
{
    internal class Mqtt
    {
        public static MqttClient Connect()
        {
            Debug.WriteLine("--------------------------------");
            Debug.WriteLine("Connecting to AWS IoT...");

            var caCert = new X509Certificate2(AwsSettings.RootCA);

            var clientCert = new X509Certificate2(
                AwsSettings.DeviceCertificate,
                AwsSettings.PrivateKey,
                "");

            var mqttClient = new MqttClient(
                AwsSettings.IotBrokerAddress,
                8883,
                true,
                caCert,
                clientCert,
                MqttSslProtocols.TLSv1_2);

            mqttClient.Connect(ESP32Settings.Code);

            return mqttClient;
        }
    }
}
