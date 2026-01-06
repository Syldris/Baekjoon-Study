#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int testcase = int.Parse(sr.ReadLine());

        for (int t = 0; t < testcase; t++)
        {
            int n = int.Parse(sr.ReadLine());

            long exp = (n * (long)(n + 1)) / 2;

            int start = 1, end = 1000000000;
            while (start < end)
            {
                int mid = (start + end) / 2;
                long levelUpExp = (long)mid * (mid + 1);

                if (exp >= levelUpExp)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid;
                }
            }
            sw.WriteLine(start);
        }
    }
}