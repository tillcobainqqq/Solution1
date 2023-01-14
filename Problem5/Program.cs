using System.Globalization;

string? fDate = Console.ReadLine();
string? sDate = Console.ReadLine();

DateModifier dateModifier = new DateModifier(fDate, sDate);
var daysDifference = DateModifier.CalculatesDifferenceDays();

Console.WriteLine((int)daysDifference);

public class DateModifier
{
    private static string fDate;
    private static string sDate;
    
    public static string FirstDate { get { return fDate; } set { fDate = value; } }
    public static string SecondDate { get { return sDate; } set { sDate = value; }  }
    public DateModifier(string fDate, string sDate)
    {
        FirstDate = fDate;
        SecondDate = sDate;
    }
    public static double CalculatesDifferenceDays()
    {
        var firstDate = DateTime.ParseExact(FirstDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        var secondDate = DateTime.ParseExact(SecondDate, "yyyy MM dd", CultureInfo.InvariantCulture);

        double daysDifference = Math.Abs((firstDate - secondDate).TotalDays);
        return daysDifference;
    }
}