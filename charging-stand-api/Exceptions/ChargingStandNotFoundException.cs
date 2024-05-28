namespace charging_stand_api.Exceptions
{
    public class ChargingStandNotFoundException : Exception
    {
        public ChargingStandNotFoundException() { }

        public ChargingStandNotFoundException(string message) : base(message){ }

        public ChargingStandNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
