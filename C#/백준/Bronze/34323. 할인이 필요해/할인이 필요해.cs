#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        long s = long.Parse(input[2]);

        long value1 = s * (m + 1) * (100 - n) / 100;
        long value2 = m * s;

        sw.Write(Math.Min(value1, value2));

    }
}