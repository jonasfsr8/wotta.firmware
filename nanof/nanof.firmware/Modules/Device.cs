using Iot.Device.Bmxx80;
using Iot.Device.Bmxx80.PowerMode;
using nanof.Settings;
using nanoFramework.Hardware.Esp32;
using System;
using System.Device.I2c;
using System.Diagnostics;
using System.Threading;

namespace nanof.Modules
{
    public sealed class Device
    {
        private static Bme280 _sensor;

        public static void InitializeSensor()
        {
            Debug.WriteLine("--------------------------------");
            Debug.WriteLine("Sensor communication...");
            Configuration.SetPinFunction(21, DeviceFunction.I2C1_DATA);
            Configuration.SetPinFunction(22, DeviceFunction.I2C1_CLOCK);

            var settings = new I2cConnectionSettings(1, 0x76);
            var device = I2cDevice.Create(settings);

            _sensor = new Bme280(device);
        }

        public static string ReadSensorTelemetry()
        {
            Led.TurnOnGreen();
            _sensor.SetPowerMode(Bmx280PowerMode.Forced);

            Thread.Sleep(100);

            var result = _sensor.Read();

            Debug.WriteLine("--------------------------------");
            Debug.WriteLine($"pressure    : {result.Pressure.Hectopascals:F1} hPa");
            Debug.WriteLine($"temperature : {result.Temperature.DegreesCelsius:F1}°C");
            Debug.WriteLine($"humidity    : {result.Humidity.Percent:F1}%");

            Thread.Sleep(4000);

            return $@"{{
                ""deviceId"": ""{ESP32Settings.Code}"",
                ""temperature"": {result.Temperature.DegreesCelsius},
                ""humidity"": {result.Humidity.Percent},
                ""pressure"": {result.Pressure.Hectopascals},
                ""timestamp"": ""{DateTime.UtcNow:yyyy-MM-ddTHH:mm:ssZ}""
            }}";
        }
    }
}
