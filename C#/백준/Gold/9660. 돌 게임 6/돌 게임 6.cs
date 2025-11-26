#nullable disable
using System.Numerics;
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        long n = long.Parse(sr.ReadLine());

        sw.WriteLine(n % 7 == 2 || n % 7 == 0 ? "CY" : "SK");
    }
}