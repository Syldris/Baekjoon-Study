#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();

        int value = int.Parse(input[0]) * 60 + int.Parse(input[1]);

        bool[] bus = new bool[1440];
        int n = int.Parse(sr.ReadLine());

        for (int t = 0; t < n; t++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int start = line[0] * 60 + line[1];
            int interval = line[2];
            for (int i = start; i < 1440; i += interval)
            {
                bus[i] = true;
            }
        }

        for (int i = value; i < 1440; i++)
        {
            if (bus[i])
            {
                sw.Write($"{i / 60:D2}:{i % 60:D2}");
                return;
            }
        }

        for (int i = 1; i < 1440; i++)
        {
            if (bus[i])
            {
                sw.Write($"{i / 60:D2}:{i % 60:D2}");
                return;
            }
        }
    }
}