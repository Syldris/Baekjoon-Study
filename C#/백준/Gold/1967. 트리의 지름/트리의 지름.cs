#nullable disable
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        if (n == 1)
        {
            sw.Write(0);
            return;
        }

        List<(int node, int cost)>[] tree = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            tree[i] = new List<(int, int)>();
        }

        for (int i = 1; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            int a = int.Parse(line[0]);
            int b = int.Parse(line[1]);
            int cost = int.Parse(line[2]);

            tree[a].Add((b, cost));
            tree[b].Add((a, cost));
        }

        int maxDist = 0;
        int endPoint = -1;
        DFS(1, -1, 0);

        DFS(endPoint, -1, 0);
        sw.WriteLine(maxDist);

        void DFS(int node, int parent, int dist)
        {
            if (dist > maxDist)
            {
                maxDist = dist;
                endPoint = node;
            }
            foreach (var child in tree[node])
            {
                if (child.node == parent)
                    continue;
                DFS(child.node, node, dist + child.cost);
            }
        }
    }
}