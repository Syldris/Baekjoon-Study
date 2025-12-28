#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput(), 65535));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int q = int.Parse(input[1]);

        int[] parent = new int[n + 1];
        int[] size = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            parent[i] = i;
            size[i] = 1;
        }

        (int a, int b, int r)[] link = new (int, int, int)[n - 1];
        (int k, int video, int index)[] query = new (int, int, int)[q];

        for (int i = 0; i < n - 1; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            link[i] = (line[0], line[1], line[2]);
        }

        for (int i = 0; i < q; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            query[i] = (line[0], line[1], i);
        }

        link = link.OrderByDescending(x => x.r).ToArray();
        query = query.OrderByDescending(x => x.k).ToArray();

        int[] result = new int[q];

        int update = 0;
        for (int i = 0; i < q; i++)
        {
            (int k, int video, int index) = query[i];

            while (update < n - 1 && k <= link[update].r)
            {
                (int a, int b, int r) = link[update];
                Union(a, b);
                update++;
            }

            int rootVideo = Find(video);
            result[index] = size[rootVideo] - 1;
        }

        for (int i = 0; i < q; i++)
        {
            sw.WriteLine(result[i]);
        }

        int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }

        void Union(int a, int b)
        {
            int rootA = Find(a);
            int rootB = Find(b);

            if (rootA != rootB)
            {
                if (size[rootA] < size[rootB])
                {
                    parent[rootA] = parent[rootB];
                    size[rootB] += size[rootA];
                }
                else
                {
                    parent[rootB] = parent[rootA];
                    size[rootA] += size[rootB];
                }
            }
        }
    }
}