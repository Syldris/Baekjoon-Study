using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));
        
        StringBuilder sb = new StringBuilder();

        for (int t = 1; t < int.MaxValue; t++)
        {
            int n = int.Parse(sr.ReadLine());
            if(n == 0)
                break;

            int[,] arr = new int[n, n];
            for(int y = 0; y < n; y++)
            {
                string[] line = sr.ReadLine().Split();
                for(int x = 0; x < n; x++)
                {
                    arr[x,y] = int.Parse(line[x]);
                }
            }

            int[,] visited = new int[n, n];
            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    visited[x,y] = int.MaxValue;
                }
            }
            visited[0, 0] = arr[0, 0];

            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            PriorityQueue<(int x, int y, int totalcost), int> queue = new();
            queue.Enqueue((0, 0, arr[0, 0]), 0);
            while (queue.Count > 0)
            {
                (int x, int y, int totalcost) = queue.Dequeue();
                if(x == n - 1 && y == n-1)
                {
                    sb.AppendLine($"Problem {t}: {totalcost}");
                    break;
                }

                for (int i = 0; i < 4; i++)
                {
                    int px = x + dx[i];
                    int py = y + dy[i];
                    if (px < 0 || py < 0 || px >= n || py >=n)
                        continue;

                    int curcost = arr[px,py] + totalcost;
                    if(curcost < visited[px,py])
                    {
                        visited[px,py] = curcost;
                        queue.Enqueue((px, py, curcost), curcost);
                    }
                }
            }

        }
        sw.Write(sb);
    }
}
