#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        (int start, int end)[] range = new (int, int)[n];
        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            range[i] = (line[0], line[1]);
        }

        bool win = false;

        Queue<(int pos, int hp, int game)> queue = new();
        int[,] visited = new int[1001, n + 1];

        for (int i = 0; i <= 1000; i++)
        {
            queue.Enqueue((i, 2, 0));
        }
        while (queue.Count > 0)
        {
            (int pos, int hp, int game) = queue.Dequeue();
            if (hp == 0) continue;

            if (game == n)
            {
                win = true;
                break;
            }

            for (int move = -1; move <= 1; move++)
            {
                int curPos = pos + move;
                int nextGame = game + 1;

                if (curPos < 0 || curPos > 1000)
                    continue;

                if (range[game].start <= curPos && curPos <= range[game].end)
                {
                    if (hp > visited[curPos, nextGame])
                    {
                        visited[curPos, nextGame] = hp;
                        queue.Enqueue((curPos, hp, nextGame));
                    }
                }
                else
                {
                    if (hp - 1 > visited[curPos, nextGame])
                    {
                        visited[curPos, nextGame] = hp - 1;
                        queue.Enqueue((curPos, hp - 1, nextGame));
                    }
                }
            }
        }
        sw.WriteLine(win ? "World Champion" : "Surrender");
    }
}