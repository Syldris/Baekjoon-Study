#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 20);

        int n = int.Parse(sr.ReadLine());
        char[,] board = new char[n, n];
        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < n; x++)
            {
                board[x, y] = ' ';
            }
        }

        int m = Log3(n);

        Sovle(m, 1, 1);

        void Sovle(int size, int x, int y)
        {
            if (size == 0)
            {
                board[x - 1, y - 1] = '*';
                return;
            }

            int move = Pow3(size - 1);

            for (int dx = 0; dx < 3; dx++)
            {
                for (int dy = 0; dy < 3; dy++)
                {
                    if (dx == 1 && dy == 1) continue;
                    Sovle(size - 1, x + dx * move, y + dy * move);
                }
            }
        }

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < n; x++)
            {
                sw.Write(board[x, y]);
            }
            if (y < n - 1) sw.WriteLine();
        }

        int Pow3(int n)
        {
            int value = 1;
            for (int i = 0; i < n; i++)
            {
                value *= 3;
            }
            return value;
        }

        int Log3(int n)
        {
            int value = 1;
            for (int i = 3; i < n; i *= 3)
            {
                value++;
            }
            return value;
        }
    }
}