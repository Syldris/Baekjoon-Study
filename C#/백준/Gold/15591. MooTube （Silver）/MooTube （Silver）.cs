#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int q = int.Parse(input[1]);
        List<(int node, int cost)>[] graph = new List<(int, int)>[n + 1];
        bool[] visited = new bool[n + 1];

        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<(int, int)>();
        }

        for (int i = 1; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int start = line[0];
            int end = line[1];
            int cost = line[2];

            graph[start].Add((end, cost));
            graph[end].Add((start, cost));
        }

        for (int i = 0; i < q; i++)
        {
            string[] line = sr.ReadLine().Split();
            int k = int.Parse(line[0]);
            int v = int.Parse(line[1]);

            sw.WriteLine(BFS(v, k));
            Array.Fill(visited, false);
        }

        int BFS(int start, int value)
        {
            int result = -1;

            Queue<int> queue = new();
            queue.Enqueue(start);
            visited[start] = true;
            while (queue.Count > 0)
            {
                result++;
                int node = queue.Dequeue();
                foreach (var pos in graph[node])
                {
                    if (!visited[pos.node] && pos.cost >= value)
                    {
                        queue.Enqueue(pos.node);
                        visited[pos.node] = true;
                    }
                }
            }
            return result;
        }
    }
}