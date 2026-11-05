using System.Device.Gpio;

namespace nanof.Modules
{
    public static class Led
    {
        private const int _greenLedPin = 18;
        private const int _blueLedPin = 19;
        private static readonly GpioController _pin = new();

        public static void InitializeLeds()
        {
            _pin.OpenPin(_greenLedPin, PinMode.Output);
            _pin.OpenPin(_blueLedPin, PinMode.Output);

            TurnOffLeds();
        }

        public static void TurnOnGreen()
        {
            _pin.Write(_greenLedPin, PinValue.High);
            _pin.Write(_blueLedPin, PinValue.Low);
        }

        public static void TurnOnBlue()
        {
            _pin.Write(_greenLedPin, PinValue.Low);
            _pin.Write(_blueLedPin, PinValue.High);
        }

        public static void TurnOffLeds()
        {
            _pin.Write(_greenLedPin, PinValue.Low);
            _pin.Write(_blueLedPin, PinValue.Low);
        }
    }
}
