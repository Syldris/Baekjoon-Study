#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        while (true)
        {
            int n = int.Parse(sr.ReadLine());

            if (n == 0)
                break;

            List<(int node, int dist)>[] tree = new List<(int, int)>[n];
            for (int i = 0; i < n; i++)
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

            int[] treeSize = new int[n];
            long rootDistance = 0;

            DFS(0, -1, 0);

            long minDistance = rootDistance;
            DistanceDFS(0, -1, rootDistance);

            sw.WriteLine(minDistance);

            void DistanceDFS(int node, int parent, long dist)
            {
                minDistance = Math.Min(minDistance, dist);
                foreach (var child in tree[node])
                {
                    if(child.node == parent)
                        continue;

                    long Childdist = dist + (long)(treeSize[0] - treeSize[child.node]) * child.dist;
                    Childdist -= treeSize[child.node] * child.dist;

                    DistanceDFS(child.node, node, Childdist);
                }
            }

            void DFS(int node, int parent, int dist)
            {
                treeSize[node] = 1;
                rootDistance += dist;
                foreach (var child in tree[node])
                {
                    if(child.node == parent)
                        continue;

                    DFS(child.node, node, dist + child.dist);
                    treeSize[node] += treeSize[child.node];
                }
            }
        }
    }
}