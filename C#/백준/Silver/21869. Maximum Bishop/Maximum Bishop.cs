#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 20);

        int n = int.Parse(sr.ReadLine());

        sw.WriteLine(n + Math.Max(0, n - 2));
        for (int i = 1; i <= n; i++)
        {
            sw.WriteLine($"{i} {1}");
        }
        for (int i = 2; i < n; i++)
        {
            sw.WriteLine($"{i} {n}");
        }
    }
}