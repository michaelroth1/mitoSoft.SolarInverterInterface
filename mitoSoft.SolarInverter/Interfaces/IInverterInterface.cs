namespace mitoSoft.SolarInverter.Interfaces
{
    public interface IInverterInterface
    {
        public void Connect();

        public void Disconnect();

        public bool Connected { get; }

        public int Actual { get; }

        public int Today { get; }

        public long Total { get; }
    }
}