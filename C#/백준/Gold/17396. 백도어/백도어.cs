#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs = sr.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);

        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        long[] visited = new long[n];
        List<(int node, int cost)>[] graph = new List<(int node, int cost)>[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = new List<(int node, int cost)>();
            visited[i] = long.MaxValue;
        }

        for (int i = 0; i < m; i++)
        {
            string[] input = sr.ReadLine().Split();
            int start = int.Parse(input[0]);
            int end = int.Parse(input[1]);
            int cost = int.Parse(input[2]);
            graph[start].Add((end, cost));
            graph[end].Add((start, cost));
        }

        PriorityQueue<(int node, long cost), long> queue = new();
        queue.Enqueue((0, 0), 0);
        while (queue.Count > 0)
        {
            (int node, long cost) = queue.Dequeue();
            if (visited[node] < cost)
                continue;
            if (node == n-1)
            {
                sw.Write(cost);
                return;
            }
            foreach (var next in graph[node])
            {
                long curcost = cost + next.cost;
                if(curcost < visited[next.node] && (arr[next.node] == 0 || next.node == n-1))
                {
                    visited[next.node] = curcost;
                    queue.Enqueue((next.node, curcost), curcost);
                }
            }
        }
        sw.Write(-1);
    }
}