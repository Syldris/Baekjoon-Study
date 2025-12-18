#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        int c = int.Parse(input[2]);

        if (c < Math.Abs(a) + Math.Abs(b))
        {
            sw.Write("NO");
            return;
        }

        sw.Write(Math.Abs(a + b) % 2 == c % 2 ? "YES" : "NO");
    }
}