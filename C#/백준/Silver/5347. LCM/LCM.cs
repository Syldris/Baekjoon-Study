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
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);

            long value = (long)a * b;
            int r = a % b;

            while (r != 0)
            {
                r = a % b;
                a = b;
                b = r;
            }
            sw.WriteLine(value / a);
        }
    }
}