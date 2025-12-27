#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput(),65536));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        long[] arr = new long[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = long.Parse(sr.ReadLine());
        }

        long start = 0, end = long.MaxValue;

        while (start + 1 < end)
        {
            long mid = (start + end) / 2;
            long value = 0;

            for (int i = 0; i < n; i++)
            {
                value += arr[i] / mid;
            }
            if (value >= k)
            {
                start = mid;
            }
            else
            {
                end = mid;
            }
        }

        sw.Write(start);
    }
}