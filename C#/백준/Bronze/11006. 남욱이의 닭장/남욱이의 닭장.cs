#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int testcase  = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int a = line[0];
            int b = line[1];

            int c = b * 2 - a;
            sw.WriteLine($"{c} {b - c}");
        }
    }
}