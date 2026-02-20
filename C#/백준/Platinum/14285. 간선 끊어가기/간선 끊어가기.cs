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

        List<(int node, int cost)>[] graph = new List<(int, int)>[n + 1];
        int[,] visited = new int[n + 1, 2];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new();
            visited[i, 0] = int.MaxValue;
            visited[i, 1] = int.MaxValue;
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

        PriorityQueue<(int node, int cost, bool isRemove), int> queue = new();
        queue.Enqueue((startPos, 0, false), 0);
        visited[startPos, 0] = 0;

        int removeCost = 0;

        while (queue.Count > 0)
        {
            (int node, int cost, bool isRemove) = queue.Dequeue();

            if (node == endPos)
            {
                removeCost = cost; // 남겨야 하는 간선들의 가중치 합
                break;
            }

            foreach (var next in graph[node])
            {
                int nextCost = cost + next.cost;

                if (!isRemove) // 아직 제거 안했을때
                {
                    if (cost < visited[next.node, 1]) // 제거하면서 가는 경우
                    {
                        visited[next.node, 1] = cost; // 이번 간선은 더하지 않고 그대로 감
                        queue.Enqueue((next.node, cost, true), cost);
                    }
                    if (nextCost < visited[next.node, 0]) // 제거 안하고 그대로 두는 경우
                    {
                        visited[next.node, 0] = nextCost;
                        queue.Enqueue((next.node, nextCost, false), nextCost);
                    }
                }
                else // 이미 제거 했을때
                {
                    if (nextCost < visited[next.node, 1])
                    {
                        visited[next.node, 1] = nextCost;
                        queue.Enqueue((next.node, nextCost, isRemove), nextCost);
                    }
                }
            }
        }
        sw.Write(totalCost - removeCost);
    }
}