#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        bool[,] board = new bool[n, n];
        for (int y = 0; y < n; y++)
        {
            string[] line = sr.ReadLine().Split();
            for (int x = 0; x < n; x++)
            {
                if (line[x] == "1")
                    board[x, y] = true;
            }
        }

        int white = 0;
        int blue = 0;

        Solve(n, 0, 0);

        void Solve(int size, int x, int y)
        {
            bool coloring = true;
            bool color = board[x, y];

            for (int col = y; col < y + size; col++)
            {
                if (!coloring) break;
                for (int row = x; row < x + size; row++)
                {
                    if (board[row, col] != color)
                    {
                        coloring = false;
                        break;
                    }
                }
            }

            if (coloring)
            {
                if (color) blue++;
                else white++;
            }
            else
            {
                int half = size / 2;
                Solve(half, x, y);
                Solve(half, x + half, y);
                Solve(half, x, y + half);
                Solve(half, x + half, y + half);
            }
        }

        sw.WriteLine(white);
        sw.WriteLine(blue);
    }
}