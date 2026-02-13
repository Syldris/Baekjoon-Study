#nullable disable
public readonly struct Node
{
    public readonly int pos;
    public readonly int cost;
    public readonly int time;

    public Node(int pos, int cost, int time)
    {
        this.pos = pos;
        this.cost = cost;
        this.time = time;
    }
}

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int testcase = int.Parse(sr.ReadLine());

        for (int t = 0; t < testcase; t++)
        {
            string[] input = sr.ReadLine().Split();

            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            int k = int.Parse(input[2]);

            List<Node>[] graph = new List<Node>[n + 1];
            for (int i = 1; i <= n; i++)
                graph[i] = new();

            for (int i = 0; i < k; i++)
            {
                int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

                graph[line[0]].Add(new Node(line[1], line[2], line[3])); // 출발지역 => (도착지점, 비용, 시간)
            }

            for (int i = 1; i <= n; i++)
            {
                graph[i].Sort((a, b) => a.time.CompareTo(b.time)); // 효율적 탐색을 위해 시간순으로 정렬
            }

            int[,] visited = new int[n + 1, m + 1]; // [지역, 현재 비용] => 시간
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    visited[i, j] = int.MaxValue;
                }
            }

            PriorityQueue<Node, int> queue = new();
            queue.Enqueue(new Node(1, 0, 0), 0);
            visited[1, 0] = 0;

            bool find = false;

            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();

                if (node.time > visited[node.pos, node.cost]) continue;

                if (node.pos == n)
                {
                    sw.WriteLine(node.time);
                    find = true;
                    break;
                }

                foreach (var next in graph[node.pos])
                {
                    int nextCost = node.cost + next.cost;
                    int nextTime = node.time + next.time;

                    if (nextCost > m) // 총 비용이 돈을 넘으면 못감
                        continue;

                    if (nextTime < visited[next.pos, nextCost])
                    {
                        visited[next.pos, nextCost] = nextTime;

                        queue.Enqueue(new Node(next.pos, nextCost, nextTime), nextTime);
                    }
                }
            }

            if (!find)
                sw.WriteLine("Poor KCM");
        }
    }
}