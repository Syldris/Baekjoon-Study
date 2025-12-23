#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int result = 0;
        (int start, int end)[] pos = new (int, int)[n];
        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            pos[i] = (int.Parse(line[0]), int.Parse(line[1]));
        }
        Array.Sort(pos);

        (int start, int end) = pos[0];
        for (int i = 1; i < n; i++)
        {
            if (pos[i].start > end)
            {
                result += (end - start);
                (start, end) = pos[i];
            }
            else if (pos[i].end > end)
            {
                end = pos[i].end;
            }
        }

        result += (end - start);
        sw.Write(result);
    }
}