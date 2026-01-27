#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int b = int.Parse(input[2]);

        int[,] board = new int[n, m];

        for (int y = 0; y < n; y++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            for (int x = 0; x < m; x++)
            {
                board[y, x] = line[x];
            }
        }

        int result = int.MaxValue;
        int height = 0;

        for (int i = 256; i >= 0; i--)
        {
            int time = 0;
            int block = b;

            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < m; x++)
                {
                    if (board[y, x] > i)
                    {
                        int diff = board[y, x] - i;

                        time += diff * 2;
                        block += diff;
                    }
                    else if (board[y, x] < i)
                    {
                        int diff = i - board[y, x];

                        time += diff;
                        block -= diff;
                    }
                }
            }

            if (block >= 0 && time < result)
            {
                result = time;
                height = i;
            }
        }

        sw.Write($"{result} {height}");
    }
}