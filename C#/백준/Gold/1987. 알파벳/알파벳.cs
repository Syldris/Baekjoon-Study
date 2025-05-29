#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs = sr.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);

        char[,] board = new char[m, n];
        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < m; x++)
            {
                board[x, y] = line[x];
            }
        }

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        int maxCount = 0;
        int startbit = 1 << (board[0, 0] - 'A');

        Backtrack(0, 0, startbit, 1);

        void Backtrack(int x,int y, int bit, int count)
        {
            maxCount = Math.Max(maxCount, count);
            if(maxCount == 26) return;

            for (int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];

                if(px < 0 || py < 0 || px >= m || py >= n)
                    continue;
                int newbit = 1 << (board[px, py] - 'A');
                if((bit & newbit) == 0)
                {
                    Backtrack(px, py, bit | newbit, count + 1);
                }
            }
        }
        sw.Write(maxCount);
    }
}