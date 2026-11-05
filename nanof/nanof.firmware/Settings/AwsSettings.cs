namespace nanof.Settings
{
    public static class AwsSettings
    {
        public static string IotBrokerAddress = "[..]-ats.iot.us-east-1.amazonaws.com";
        public static string Topic = "bme280";

        // certificate.pem.crt
        public static string DeviceCertificate = @"-----BEGIN CERTIFICATE-----

-----END CERTIFICATE-----";

        // private.pem.key
        public static string PrivateKey = @"-----BEGIN RSA PRIVATE KEY-----

-----END RSA PRIVATE KEY-----";

        // RootCA1.pem
        public static string RootCA = @"-----BEGIN CERTIFICATE-----

-----END CERTIFICATE-----";
    }
}
