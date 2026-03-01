#nullable disable
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);
        int k = int.Parse(input[2]);

        int[] jewel = new int[n + 1];
        for (int i = 0; i < k; i++)
        {
            int pos = int.Parse(sr.ReadLine());
            jewel[pos] = 1 << i;
        }

        bool[,] visited = new bool[n + 1, 1 << k];

        List<(int node, int weight)>[] graph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new();

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            graph[line[0]].Add((line[1], line[2]));
            graph[line[1]].Add((line[0], line[2]));
        }

        Queue<(int node, int curJewel)> queue = new();

        int startJewel = jewel[1];
        if (startJewel > 0)
        {
            visited[1, startJewel] = true;
            queue.Enqueue((1, startJewel));
        }

        visited[1, 0] = true;
        queue.Enqueue((1, 0));

        while (queue.Count > 0)
        {
            (int node, int curJewel) = queue.Dequeue();
            foreach (var next in graph[node])
            {
                int nextJewel = curJewel | jewel[next.node];

                int curWeight = 0; 
                for (int i = 0; i < k; i++)
                {
                    bool bit = ((curJewel >> i) & 1) == 1;
                    if (bit) curWeight++;
                }

                if (curWeight <= next.weight)
                {
                    if (!visited[next.node, curJewel]) // 안줍고 지나갈때
                    {
                        visited[next.node, curJewel] = true;
                        queue.Enqueue((next.node, curJewel));
                    }
                    if (!visited[next.node, nextJewel]) // 줍고 지나갈때
                    {
                        visited[next.node, nextJewel] = true;
                        queue.Enqueue((next.node, nextJewel));
                    }

                }

            }
        }

        int result = 0;
        int size = 1 << k;
        for (int i = 0; i < size; i++)
        {
            if (visited[1, i])
            {
                result = Math.Max(result, BitOperations.PopCount((uint)i));
            }
        }

        sw.Write(result);
    }
}