#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        sw.WriteLine(new string('*', 2 * n - 1));
        for (int i = 1; i < n; i++)
        {
            sw.Write(new string(' ', i));
            sw.WriteLine(new string('*', 2 * n - (2 * i + 1)));
        }
    }
}