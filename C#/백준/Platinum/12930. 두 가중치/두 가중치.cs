#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        List<(int node, int cost)>[] graph1 = new List<(int, int)>[n];
        List<(int node, int cost)>[] graph2 = new List<(int, int)>[n];
        int[,,] visited = new int[n, 181, 181];
        for (int i = 0; i < n; i++)
        {
            graph1[i] = new();
            graph2[i] = new();
            for (int j = 0; j <= 180; j++)
            {
                for (int k = 0; k <= 180; k++)
                {
                    visited[i, j, k] = int.MaxValue;
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            string line = sr.ReadLine();
            for (int j = 0; j < n; j++)
            {
                if (line[j] != '.')
                {
                    graph1[i].Add((j, line[j] - '0'));
                }
            }
        }
        for (int i = 0; i < n; i++)
        {
            string line = sr.ReadLine();
            for (int j = 0; j < n; j++)
            {
                if (line[j] != '.')
                {
                    graph2[i].Add((j, line[j] - '0'));
                }
            }
        }


        PriorityQueue<(int node, int costA, int costB), int> queue = new();
        queue.Enqueue((0, 0, 0), 0);
        visited[0, 0, 0] = 0;

        while (queue.Count > 0)
        {
            (int node, int costA, int costB) = queue.Dequeue();
            if (node == 1)
            {
                sw.Write(costA * costB);
                return;
            }

            for (int i = 0; i < graph1[node].Count; i++)
            {
                int nextNode = graph1[node][i].node;

                int curCostA = graph1[node][i].cost + costA;
                int curCostB = graph2[node][i].cost + costB;

                int cost = curCostA * curCostB;
                if (cost < visited[nextNode, curCostA, curCostB])
                {
                    visited[nextNode, curCostA, curCostB] = cost;
                    queue.Enqueue((nextNode, curCostA, curCostB), cost);
                }
            }
        }

        sw.Write(-1);
    }
}