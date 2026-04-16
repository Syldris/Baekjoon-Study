#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int n = line[0];
            int m = line[1];

            int result = 0;

            for (int b = 2; b < n; b++)
            {
                for (int a = 1; a < b; a++)
                {
                    int value = a * a + b * b + m;

                    if (value % (a * b) == 0)
                        result++;
                }
            }

            sw.WriteLine(result);
        }
    }
}