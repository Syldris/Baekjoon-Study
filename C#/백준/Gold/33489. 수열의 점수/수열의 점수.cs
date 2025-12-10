#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int testcase = int.Parse(sr.ReadLine());

        int[] point = new int[31];
        point[0] = 0;
        point[1] = 1;
        for (int i = 2; i < 31; i++)
        {
            point[i] = point[i - 1] + point[i - 2];
        }

        for (int t = 0; t < testcase; t++)
        {
            string[] input = sr.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);

            int indexA = -1;
            int indexB = -1;

            for (int i = 30; i >= 0; i--)
            {
                if (a >= point[i])
                {
                    indexA = i;
                    break;
                }
            }

            for (int i = indexA - 1; i >= 0; i--)
            {
                if (b >= point[i])
                {
                    indexB = i;
                    break;
                }
            }

            sw.WriteLine($"{point[indexB + 1]} {point[indexB]}");
        }
    }
}
