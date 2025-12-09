#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int d = int.Parse(input[1]);
        int k = int.Parse(input[2]);

        int value = k - n;
        if (value % d != 0 || (d > 0 && value < 0) || (d < 0 && value > 0))
        {
            sw.Write("X");
            return;
        }
        sw.Write(value / d + 1);
    }
}