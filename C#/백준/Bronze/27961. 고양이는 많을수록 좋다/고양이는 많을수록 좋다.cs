#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        long n = long.Parse(sr.ReadLine());

        for (int i = 63; i >= 0; i--)
        {
            long value = n >> i & 1;
            if (value == 1)
            {
                int result = i + 1;
                while (i-- > 0)
                {
                    bool bit = (n >> i & 1) == 1;
                    if (bit)
                    {
                        sw.Write(result + 1);
                        return;
                    }
                }
                sw.Write(result);
                return;
            }
        }
        sw.Write(0);
    }
}