#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        List<int>[] graph = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            graph[i] = new List<int>();
        }
        int[] indegree = new int[n + 1];
        int[] buildtime = new int[n + 1];
        int[] resulttime = new int[n + 1];
        for(int i = 1; i <= n; i++)
        {
            int[] inputs = sr.ReadLine().Split().Select(int.Parse).ToArray();
            buildtime[i] = inputs[0];
            for (int j = 1; j < inputs.Length - 1; j++)
            {
                indegree[i]++;
                graph[inputs[j]].Add(i);
            }
        }
        Queue<(int node, int time)> queue = new Queue<(int, int)>();
        for (int i = 1; i <= n; i++)
        {
            resulttime[i] = buildtime[i];
            if(indegree[i] == 0)
                queue.Enqueue((i, buildtime[i]));
        }
        while (queue.Count > 0)
        {
            var (node, time) = queue.Dequeue();
            foreach (var next in graph[node])
            {
                resulttime[next] = Math.Max(resulttime[next], time + buildtime[next]);
                indegree[next]--;
                if (indegree[next] == 0)
                    queue.Enqueue((next, resulttime[next]));
            }
        }
        for (int i = 1; i <= n; i++)
        {
            sw.WriteLine(resulttime[i]);
        }
    }
}