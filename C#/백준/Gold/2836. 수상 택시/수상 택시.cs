#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 17);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 17);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        List<(int start, int end)> line = new List<(int, int)>();

        for (int i = 0; i < n; i++)
        {
            int[] lineinput = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int a = lineinput[0];
            int b = lineinput[1];
            if (a > b)
            {
                line.Add((b, a));
            }
        }
        line.Sort();

        long distance = m;

        int start = 0, end = 0;
        for (int i = 0; i < line.Count; i++)
        {
            if (line[i].start > end)
            {
                distance += (end - start) * 2;
                (start, end) = line[i];
            }
            else
            {
                end = Math.Max(line[i].end, end);
            }
        }

        distance += (end - start) * 2;
        sw.Write(distance);
    }
}