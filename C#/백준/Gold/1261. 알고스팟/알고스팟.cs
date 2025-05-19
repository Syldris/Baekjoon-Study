using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs = sr.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);
        int[,] arr = new int[n,m];

        for (int y = 0; y < m; y++)
        {
            string line = sr.ReadLine();
            for (int x = 0; x < n; x++)
            {
                arr[x, y] = line[x] - '0';
            }
        }

        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        int[,] visited = new int[n,m];
        for (int y = 0; y < m; y++)
        {
            for (int x = 0; x < n; x++)
            {
                visited[x, y] = int.MaxValue;
            }
        }
        visited[0,0] = 0;
        PriorityQueue<(int x, int y, int cost), int> queue = new();
        queue.Enqueue((0, 0, 0), 0);

        while (queue.Count > 0)
        {
            var (x, y, cost) = queue.Dequeue();
            if(x == n-1 &&  y == m-1)
            {
                sw.Write(cost);
                return;
            }
            for(int i = 0; i < 4; i++)
            {
                int px = x + dx[i];
                int py = y + dy[i];
                if (px < 0 || py < 0 || px >= n || py >= m)
                    continue;

                if(arr[px, py] == 0)
                {
                    if(cost < visited[px, py])
                    {
                        visited[px,py] = cost;
                        queue.Enqueue((px,py,cost), cost);
                    }
                }
                else
                {
                    if (cost+1 < visited[px, py])
                    {
                        visited[px, py] = cost+1;
                        queue.Enqueue((px, py, cost+1), cost+1);
                    }
                }
            }
        }
    }
}