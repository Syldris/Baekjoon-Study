#nullable disable
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        BigInteger result = 1;
        for (int i = 1; i <= k; i++)
        {
            result = (result * (n - k + i) / i);
        }
        sw.Write(result % 10007);

    }
}