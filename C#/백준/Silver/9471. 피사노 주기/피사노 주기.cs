#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 1; t <= testcase; t++)
        {
            string[] input = sr.ReadLine().Split();
            int value = int.Parse(input[1]);
            sw.WriteLine($"{t} {Pisano(value)}");
        }

        int Pisano(int mod)
        {
            int prev = 0;
            int cur = 1;
            for (int i = 2; i <= 500000; i++)
            {
                int next = (prev + cur) % mod;
                prev = cur;
                cur = next;

                if (cur == 0 && prev == 1)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}