#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        const int mod = 1000000007;

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        long result = 1;

        result = result * Pow3(m - 1);
        for (int i = 1; i < n; i++)
        {
            result = (result * Pow3(m - 1)) % mod;
            result = (result * Pow3(m)) % mod;
        }


        sw.Write(result);

        long Pow3(long x)
        {
            long value = 1;
            for (int i = 0; i < x; i++)
            {
                value = (value * 3) % mod;
            }

            return value;
        }
    }
}