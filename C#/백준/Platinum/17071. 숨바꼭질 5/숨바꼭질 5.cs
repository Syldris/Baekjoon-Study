#nullable disable
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        const int max = 500001;

        int[,] visited = new int[max, 2];
        for (int i = 0; i < max; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                visited[i, j] = int.MaxValue;
            }
        }
        visited[n, 0] = 0;

        Queue<(int pos, int time)> queue = new();
        queue.Enqueue((n, 0));

        while (queue.Count > 0)
        {
            (int pos, int time) = queue.Dequeue();

            int mod = (time + 1) % 2;

            if (pos * 2 < max && time + 1 < visited[pos * 2,mod])
            {
                visited[pos * 2, mod] = time + 1;
                queue.Enqueue((pos * 2, time + 1));
            }
            if (pos + 1 < max && time + 1 < visited[pos + 1, mod])
            {
                visited[pos + 1, mod] = time + 1;
                queue.Enqueue((pos + 1, time + 1));
            }
            if (pos > 0 && time + 1 < visited[pos - 1, mod])
            {
                visited[pos - 1, mod] = time + 1;
                queue.Enqueue((pos - 1, time + 1));
            }
        }

        int second = 0;
        for (int i = k; i < max; i += second)
        {
            if (visited[i, second % 2] <= second)
            {
                sw.Write(second);
                return;
            }
            second++;
        }

        sw.Write(-1);
    }
}