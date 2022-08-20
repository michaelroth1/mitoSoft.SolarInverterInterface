using EasyModbus;
using mitoSoft.SolarInverter.Extensions;
using mitoSoft.SolarInverter.Interfaces;
using mitoSoft.SolarInverter.SMA.Eums;
using System.Collections;

namespace mitoSoft.SolarInverter.SMA
{
    public class SMAInterface : IInverterInterface
    {
        private readonly ModbusClient _modbusClient;

        public SMAInterface(string ip, int port, byte id)
        {
            _modbusClient = new ModbusClient(ip, port)
            {
                ConnectionTimeout = 5000,
                UnitIdentifier = id,
            };
        }

        public bool Connected => _modbusClient.Connected;

        public void Connect() => _modbusClient.Connect();

        public void Disconnect() => _modbusClient.Disconnect();

        public OverallStatus ReadStatus()
        {
            var status = ReadWord(30201);

            return (OverallStatus)status;
        }

        public RecommendedAction ReadRecommendedActionOnError()
        {
            var action = ReadWord(30211);

            return (RecommendedAction)action;
        }

        /// <summary>
        /// Produced value in watt
        /// </summary>
        public int Actual => this.ReadWord(30775);

        /// <summary>
        /// Todays yield in watt hours
        /// </summary>
        public int Today => int.Parse(this.ReadDoubleWord(30517).ToString());

        /// <summary>
        /// Total yield in watt hours
        /// </summary>
        public long Total => this.ReadDoubleWord(30513);

        public long ReadDoubleWord(int address)
        {
            BitArray bits = ToBitArray(address, 4);

            return bits.ToInt64();
        }

        public int ReadWord(int address)
        {
            BitArray bits = ToBitArray(address, 2);

            return bits.ToInt32();
        }

        private BitArray ToBitArray(int address, int length)
        {
            CheckConnection();

            int[] registers = _modbusClient.ReadHoldingRegisters(address, length);    //Read 10 Holding Registers from Server, starting with Address 1

            var total = "";
            for (int i = 0; i < length; i++)
            {
                var s = registers[i].ToWordString();
                total = $"{total}{s}";
            }

            var bits = total.ToBitArray();
            return bits;
        }

        private void CheckConnection()
        {
            if (!Connected)
            {
                throw new InvalidOperationException("Not connected to SMA inverter.");
            }
        }
    }
}