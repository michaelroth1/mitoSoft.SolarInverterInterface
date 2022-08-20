using DoenaSoft.UnitsOfMeasurement.SimpleUnits.Energies;
using DoenaSoft.UnitsOfMeasurement.Values;
using mitoSoft.SolarInverter.SMA;
using mitoSoft.SolarInverter.SMA.Eums;

Console.WriteLine($"Read values form SMA inverter with");

var sma = new SMAInterface("192.168.2.140", 502, 3);

sma.Connect();

var status = sma.ReadStatus().ToString();
var action = sma.ReadRecommendedActionOnError();
var actionText = action != RecommendedAction.No_Action_Recommended
    ? $"({action})"
    : string.Empty;

var total = new Value((decimal)sma.Total, "Wh");
var today = new Value((decimal)sma.Today, "Wh");
var actual = new Value((decimal)sma.Actual, "W");
total = ValueConverter.Convert<KiloWattHour>(total);
today = ValueConverter.Convert<KiloWattHour>(today);

sma.Disconnect();

Console.WriteLine($"Status: {status} {actionText}");
Console.WriteLine($"Total: {total.Scalar.ToString("0.##")} {total.Unit}");
Console.WriteLine($"Today: {today.Scalar.ToString("0.##")} {today.Unit}");
Console.WriteLine($"Actual: {actual.Scalar.ToString("0.##")} {actual.Unit}");

Console.Write("Press any key to continue . . . ");
Console.ReadKey(true);