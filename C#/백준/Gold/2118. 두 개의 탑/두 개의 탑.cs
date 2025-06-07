#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        int[] dist = new int[n];
        for (int i = 0; i < n; i++)
        {
            dist[i] = int.Parse(sr.ReadLine());
        }

        int[] prefix = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            prefix[i] = prefix[i - 1] + dist[i - 1];
        }

        int start = 0, end = 0;
        int maxdist = 0;
        while (start < n && end < n)
        {
            int curdist = prefix[end + 1] - prefix[start];
            int mindist = Math.Min(curdist, prefix[n] - curdist);
            maxdist = Math.Max(maxdist, mindist);
            if (curdist > prefix[n] / 2)
            {
                start++;
                if (end < start)
                    end = start;
            }
            else
            {
                end++;
            }
        }
        sw.Write(maxdist);
    }
}