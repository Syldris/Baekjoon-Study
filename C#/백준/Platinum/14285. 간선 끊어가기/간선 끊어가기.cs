#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        List<(int node, int cost)>[] graph = new List<(int, int)>[n + 1];
        int[] visited = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new();
            visited[i] = int.MaxValue;
        }

        int totalCost = 0;

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            graph[line[0]].Add((line[1], line[2]));
            graph[line[1]].Add((line[0], line[2]));
            totalCost += line[2];
        }

        string[] input2 = sr.ReadLine().Split();
        int startPos = int.Parse(input2[0]);
        int endPos = int.Parse(input2[1]);

        PriorityQueue<(int node, int cost, int maxCost), int> queue = new();
        queue.Enqueue((startPos, 0, int.MinValue), 0);
        visited[startPos] = 0;

        int removeCost = int.MaxValue; 

        while (queue.Count > 0)
        {
            (int node, int cost, int maxCost) = queue.Dequeue();

            if (node == endPos)
            {
                removeCost = Math.Min(cost - maxCost, removeCost);
                continue;
            }

            foreach (var next in graph[node])
            {
                int nextCost = cost + next.cost;
                int nextMaxCost = Math.Max(next.cost, maxCost);

                int nextRemoveCost = nextCost - nextMaxCost; // 경로중에서 가중치가 가장 큰 간선 하나만 제거
                
                if (nextRemoveCost < visited[next.node]) // 이 노드까지 왔을때 이득이 최대만 남께끔
                {
                    visited[next.node] = nextRemoveCost;
                    queue.Enqueue((next.node, nextCost, nextMaxCost), nextRemoveCost);
                }
            }
        }
        sw.Write(totalCost - removeCost);
    }
}