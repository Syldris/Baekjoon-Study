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

        List<int>[] graph = new List<int>[n];
        bool[] visited = new bool[n];
        for (int i = 0; i < n; i++)
        {
            graph[i] = new();
        }

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int a = line[0];
            int b = line[1];
            graph[a].Add(b);
            graph[b].Add(a);
        }

        bool find = false;

        for (int i = 0; i < n; i++)
        {
            DFS(i, 1);
            if (find) break;

            Array.Fill(visited, false);
        }

        if (!find)
            sw.Write(0);

        void DFS(int node, int value)
        {
            if (find) return;
            if (value >= 5)
            {
                sw.Write(1);
                find = true;
                return;
            }

            visited[node] = true;
            foreach (var next in graph[node])
            {
                if (!visited[next])
                {
                    DFS(next, value + 1);
                }
            }
            visited[node] = false;
        }
    }
}