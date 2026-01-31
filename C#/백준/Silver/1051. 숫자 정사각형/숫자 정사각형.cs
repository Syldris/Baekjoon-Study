#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);


        int[,] board = new int[m, n];

        int result = 0;

        for (int y = 0; y < n; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < m; x++)
            {
                board[x, y] = line[x] - '0';
            }
        }

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < m; x++)
            {
                int num = board[x, y];
                int size = Math.Max(m - x, n - y);

                for (int i = result; i < size; i++)
                {
                    if (SquereCheck(x, y, i, num))
                    {
                        result = i;
                    }
                }
            }
        }

        result++;
        sw.Write(result * result);

        bool SquereCheck(int x, int y, int dist, int num)
        {
            int dx = x + dist;
            int dy = y + dist;
            if(dx >= m || dy >= n) return false;

            if (board[dx, y] == num && board[x, dy] == num && board[dx, dy] == num)
            {
                return true;
            }

            return false;
        }
    }
}