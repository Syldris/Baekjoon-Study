#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        List<(int x, int y)> house = new();
        List<(int x, int y)> chicken = new();

        for (int y = 0; y < n; y++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int x = 0; x < n; x++)
            {
                if (line[x] == 1)
                {
                    house.Add((x, y));
                }
                else if (line[x] == 2)
                {
                    chicken.Add((x, y));
                }
            }
        }
        int[] arr = new int[m];

        int result = int.MaxValue;

        BackTrack(0,0);

        sw.Write(result);

        void BackTrack(int start, int depth)
        {
            if (depth == m)
            {
                int value = 0;

                for (int i = 0; i < house.Count; i++)
                {
                    int min = int.MaxValue;
                    for (int j = 0; j < m; j++)
                    {
                        int num = arr[j];
                        min = Math.Min(min, Math.Abs(house[i].x - chicken[num].x) + Math.Abs(house[i].y - chicken[num].y));
                    }
                    value += min;
                }
                result = Math.Min(result, value);
                return;
            }

            for (int i = start; i < chicken.Count; i++)
            {
                arr[depth] = i;
                BackTrack(i + 1, depth + 1);
            }
        }
    }
}