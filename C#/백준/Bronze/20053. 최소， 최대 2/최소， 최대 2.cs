#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int tastcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < tastcase; t++)
        {
            int n = int.Parse(sr.ReadLine());
            int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
            sw.WriteLine($"{arr.Min()} {arr.Max()}");
        }
    }
}