using mitoSoft.SolarInverter.SMA;
using mitoSoft.SolarInverter.SMA.Eums;

Console.WriteLine($"Read values form SMA inverter with");

var sma = new SMAInterface("192.168.2.140", 502, 3);

sma.Connect();

var status = sma.ReadStatus().ToString();
var action = sma.ReadRecommendedActionOnError();
var actionText = action != RecommendedAction.Keine_empfohlene_Aktion
    ? $"({action})"
    : string.Empty;

var total = sma.ReadTotalInWattHours();
var today = sma.ReadTodayInWattHours();
var actual = sma.ReadActualProducedValueInWatt();

sma.Disconnect();

Console.WriteLine($"Status: {status} {actionText}");
Console.WriteLine($"Total: {total} Wh");
Console.WriteLine($"Today: {today} Wh");
Console.WriteLine($"Actual: {actual} W");

Console.Write("Press any key to continue . . . ");
Console.ReadKey(true);