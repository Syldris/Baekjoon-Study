#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 20);

        int n = int.Parse(sr.ReadLine());
        int m = int.Parse(sr.ReadLine());

        List<(long start, long end, int index)> bus = new List<(long, long, int)>();
        for (int i = 1; i <= m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            long a = line[0];
            long b = line[1];

            if (a > b)
            {
                bus.Add((a, b + n, i));
                bus.Add((a + n, b + 2 * n, i));
            }
            else
            {
                bus.Add((a + n, b + n, i));
            }
        }

        bus = bus.OrderBy(x => x.start).ThenByDescending(x => x.end).ToList();

        long start = bus[0].start, end = bus[0].end;

        for (int i = 1; i < bus.Count; i++)
        {
            (long curStart, long curEnd, int index) = bus[i];
            if (curStart > end)
            {
                start = curStart;
                end = curEnd;
            }
            else if (curEnd > end)
            {
                start = curStart;
                end = curEnd;
            }
            else
            {
                bus[i] = (curStart, curEnd, -1);
            }
        }

        SortedSet<int> hash = new SortedSet<int>();
        for (int i = 0; i < bus.Count; i++)
        {
            int index = bus[i].index;
            if (index != -1 && !(hash.Contains(index)))
            {
                hash.Add(index);
            }
        }
        sw.Write(string.Join(' ',hash));
    }
}