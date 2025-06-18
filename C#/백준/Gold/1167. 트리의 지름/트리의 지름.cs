#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        List<(int node, int cost)>[] tree = new List<(int node, int cost)>[n + 1];
        int[] distance = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            tree[i] = new List<(int node, int cost)>();
            distance[i] = int.MaxValue;
        }
        distance[1] = 0;
        for (int i = 1; i <= n; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int from = line[0];
            int index = 1;
            while (line[index] != -1)
            {
                tree[from].Add((line[index++], line[index++]));
            }
        }
        
        PriorityQueue<(int node, int cost), int> queue = new();
        queue.Enqueue((1, 0), 0);

        BFS();
        int maxdist = 0;
        int maxnode = 0;
        for (int i = 1; i <= n; i++)
        {
            if (distance[i] > maxdist)
            {
                maxdist = distance[i];
                maxnode = i;
            }
            distance[i] = int.MaxValue;
        }

        distance[maxnode] = 0;
        queue.Enqueue((maxnode, 0), 0);
        BFS();
        sw.WriteLine(distance.Max());

        void BFS()
        {
            while (queue.Count > 0)
            {
                (int node, int cost) = queue.Dequeue();
                if (cost > distance[node])
                    continue;

                foreach (var next in tree[node])
                {
                    int curcost = cost + next.cost;
                    if (curcost < distance[next.node])
                    {
                        distance[next.node] = curcost;
                        queue.Enqueue((next.node, curcost), curcost);
                    }
                }
            }
        }
    }
}