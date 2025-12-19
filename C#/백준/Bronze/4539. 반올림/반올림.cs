#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            int value = int.Parse(sr.ReadLine());
            int pow = 0;
            while (value >= 10)
            {
                if (value % 10 >= 5)
                {
                    value /= 10;
                    value++;
                }
                else
                {
                    value /= 10;
                }
                pow++;
            }

            int result = (int)(value * Math.Pow(10, pow));

            sw.WriteLine(result);
        }
    }
}