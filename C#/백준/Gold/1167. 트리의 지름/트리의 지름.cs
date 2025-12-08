#nullable disable
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        List<(int node, int cost)>[] tree = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
        {
            tree[i] = new List<(int, int)>();
        }

        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int from = line[0];
            int index = 1;
            while (line[index] != -1)
            {
                tree[from].Add((line[index++], line[index++]));
            }
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