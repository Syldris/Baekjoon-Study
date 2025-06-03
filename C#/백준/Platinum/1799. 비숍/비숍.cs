#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        bool[] diag1 = new bool[2 * n - 1];
        bool[] diag2 = new bool[2 * n - 1];
        bool[,] board = new bool[n, n];

        List<(int x, int y)> blacks = new List<(int x, int y)>();
        List<(int x, int y)> whites = new List<(int x, int y)>();

        int value = 0;
        int maxValue = 0;
        for (int y = 0; y < n; y++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            for (int x = 0; x < n; x++)
            {
                if (line[x] == 1)
                    board[x, y] = true;
                if ((x + y) % 2 == 0)
                    blacks.Add((x, y));
                else
                    whites.Add((x, y));
            }
        }
        int blackValue = 0;
        int whiteValue = 0;

        DFS(0, blacks);

        blackValue = maxValue;
        value = 0;
        maxValue = 0;

        DFS(0, whites);
        whiteValue = maxValue;
        sw.Write(blackValue + whiteValue);

        void DFS(int index, List<(int x,int y)> list)
        {
            if (index == list.Count)
            {
                maxValue = Math.Max(maxValue, value);
                return;
            }
            if (value + (list.Count - index) <= maxValue)
                return;

            (int x, int y) = list[index];
            if (CanPlace(x, y))
            {
                diag1[x - y + n - 1] = true;
                diag2[x + y] = true;
                value++;
                DFS(index + 1, list);
                diag1[x - y + n - 1] = false;
                diag2[x + y] = false;
                value--;
            }
            DFS(index + 1, list);
        }

        bool CanPlace(int x, int y)
        {
            if (!board[x, y])
                return false;
            else if (diag1[x - y + n - 1])
                return false;
            else if (diag2[x + y])
                return false;
            return true;
        }
    }
}