#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        bool[,] board = new bool[101, 101];
        for (int q = 0; q < 4; q++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int leftX = line[0];
            int downY = line[1];
            int rightX = line[2] - 1;
            int upY = line[3] - 1;

            for (int y = downY; y <= upY; y++)
            {
                for (int x = leftX; x <= rightX; x++)
                {
                    board[x, y] = true;
                }
            }
        }

        int result = 0;
        for (int y = 1; y <= 100; y++)
        {
            for (int x = 1; x <= 100; x++)
            {
                if (board[x, y]) result++;
            }
        }

        sw.Write(result);
    }
}