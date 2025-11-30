#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int m = int.Parse(input[1]);
        int n = int.Parse(input[0]);

        long[,] arr = new long[m + 1, n + 1];

        for (int y = 1; y <= n; y++)
        {
            string[] line = sr.ReadLine().Split();
            for (int x = 1; x <= m; x++)
            {
                arr[x, y] = int.Parse(line[x - 1]) + arr[x - 1, y] + arr[x, y - 1] - arr[x - 1, y - 1];
            }
        }


        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            string[] line = sr.ReadLine().Split();
            int y1 = int.Parse(line[0]);
            int x1 = int.Parse(line[1]);
            int y2 = int.Parse(line[2]);
            int x2 = int.Parse(line[3]);

            long result = arr[x2, y2] - arr[x1 - 1, y2] - arr[x2, y1 - 1] + arr[x1 - 1, y1 - 1];
            sw.WriteLine(result);
        }

    }
}