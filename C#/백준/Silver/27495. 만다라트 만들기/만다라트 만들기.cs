#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[,] board = new string[9, 9];
        for (int y = 0; y < 9; y++)
        {
            string[] line = sr.ReadLine().Split();
            for (int x = 0; x < 9; x++)
            {
                board[x, y] = line[x];
            }
        }

        List<(string text, int x, int y)> list = new();

        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                if (x == 1 && y == 1) continue;
                int px = x * 3 + 1;
                int py = y * 3 + 1;

                list.Add((board[px, py], px, py));
            }
        }

        list.Sort();

        for (int i = 0; i < 8; i++)
        {
            sw.WriteLine($"#{i + 1}. {list[i].text}");
            int dx = list[i].x;
            int dy = list[i].y;

            int index = 0;
            string[] arr = new string[8];
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if (x == 0 && y == 0) continue;
                    int px = dx + x;
                    int py = dy + y;

                    arr[index++] = board[px, py];
                }
            }

            Array.Sort(arr);
            index = 0;

            for (int j = 0; j < 8; j++)
            {
                sw.WriteLine($"#{i + 1}-{index + 1}. {arr[index++]}");
            }
        }
    }
}