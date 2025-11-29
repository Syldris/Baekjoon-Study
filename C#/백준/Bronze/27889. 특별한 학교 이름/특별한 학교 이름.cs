#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

       string text = sr.ReadLine();
       string result = text switch
       {
           "NLCS" => "North London Collegiate School",
           "BHA" => "Branksome Hall Asia",
           "KIS" => "Korea International School",
           "SJA" => "St. Johnsbury Academy",
       };
        sw.WriteLine(result);
    }
}