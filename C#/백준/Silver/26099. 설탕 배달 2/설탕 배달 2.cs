#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        long n = long.Parse(sr.ReadLine());

        for (int i = 0; i <= 2; i++)
        {
            for (int j = 0; j <= 4; j++)
            {
                long value = n - i * 5 - j * 3;
                if (value < 0)
                {
                    continue;
                }
                if (value % 5 == 0)
                {
                    sw.Write(value / 5 + i + j);
                    return;
                }
            }
        }
        sw.Write(-1);
    }
}