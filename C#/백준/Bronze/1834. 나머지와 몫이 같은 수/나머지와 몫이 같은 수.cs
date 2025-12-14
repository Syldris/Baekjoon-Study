#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        long n = long.Parse(sr.ReadLine());
        long result = 0;
        for (int i = 1; i < n; i++)
        {
            result += n * i + i;
        }
        sw.Write(result);
    }
}