#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        for (int i = 0; i < testcase; i++)
        {
            string[] input = sr.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);

            int value = a * b;

            while (b != 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }
            sw.WriteLine($"{value / a} {a}");
        }
    }
}