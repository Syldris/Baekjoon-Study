using System;
using System.Text;
class Program
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);
        List<(int pos, int cost)>[] graph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<(int, int)>();
        }

        for (int i = 0; i < m; i++)
        {
            string[] line = Console.ReadLine().Split();
            int u = int.Parse(line[0]);
            int v = int.Parse(line[1]);
            int cost = int.Parse(line[2]);

            graph[u].Add((v, cost));
            graph[v].Add((u, cost));
        }
        string[] input = Console.ReadLine().Split();
        int v1Pos = int.Parse(input[0]);
        int v2Pos = int.Parse(input[1]);

        bool[,,] visited = new bool[n + 1, 2, 2];

        PriorityQueue<(int pos, int cost, bool v1, bool v2), int> queue = new();
        queue.Enqueue((1, 0, 1 == v1Pos ? true : false, false), 0);

        while (queue.Count > 0)
        {
            (int pos, int cost, bool v1, bool v2) = queue.Dequeue();

            if(pos == n && v1 && v2)
            {
                Console.WriteLine(cost);
                return;
            }

            if (visited[pos, v1 ? 1 : 0, v2 ? 1 : 0])
                continue;
            visited[pos, v1 ? 1 : 0, v2 ? 1 : 0] = true;

            foreach (var next in graph[pos])
            {
                int curcost = cost + next.cost;
                bool isv1 = false;
                bool isv2 = false;
                isv1 = v1 || next.pos == v1Pos;
                isv2 = v2 || next.pos == v2Pos;
                if(!visited[next.pos, v1 ? 1 : 0, v2 ? 1 : 0])
                    queue.Enqueue((next.pos, curcost, isv1, isv2), curcost);
            }
        }
        Console.WriteLine(-1);
    }
}