#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        int n = int.Parse(sr.ReadLine());
        List<(int node, int cost)>[] tree = new List<(int node, int cost)>[n + 1];
        for (int i = 1; i <= n; i++)
            tree[i] = new();

        for (int i = 1; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int from = line[0];
            int to = line[1];
            int cost = line[2];

            tree[from].Add((to, cost));
            tree[to].Add((from, cost));
        }

        int maxDist = 0;
        int leftPoint = 0;
        int rightPoint = 0;

        PointDFS(1, 0, 0, ref leftPoint);
        maxDist = 0;
        PointDFS(leftPoint, 0, 0, ref rightPoint);

        int[] leftDist = new int[n + 1];
        int[] rightDist = new int[n + 1];

        DistDFS(leftPoint, 0, 0, leftDist);
        DistDFS(rightPoint, 0, 0, rightDist);

        for (int i = 1; i <= n; i++)
        {
            sw.WriteLine(Math.Max(leftDist[i], rightDist[i]));
        }

        void PointDFS(int node, int parent, int dist, ref int point)
        {
            if (dist > maxDist)
            {
                point = node;
                maxDist = dist;
            }

            foreach (var child in tree[node])
            {
                if (child.node == parent) continue;
                PointDFS(child.node, node, dist + child.cost, ref point);
            }
        }

        void DistDFS(int node, int parent, int dist, int[] distArray)
        {
            distArray[node] = dist;
            foreach (var child in tree[node])
            {
                if (child.node == parent) continue;
                DistDFS(child.node, node, dist + child.cost, distArray);
            }
        }
    }
}