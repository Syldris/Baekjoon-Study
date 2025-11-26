#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        long n = long.Parse(sr.ReadLine());
        bool[] arr = new bool[20] { false, true, false, true, true, false, true, false, true, true, false, true, false, true, true, false, true, false, true, true };

        sw.Write(arr[n % 20] ? "SK" : "CY");
    }
}