#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int start = int.Parse(input[1]);
        int end = int.Parse(input[2]);
        int m = int.Parse(input[3]);

        (int from, int to, int cost)[] edge = new (int, int, int)[m];

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            edge[i] = (line[0], line[1], -line[2]);
        }

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        for (int i = 0; i < m; i++)
        {
            edge[i].cost += arr[edge[i].to]; // 도착지 돈 더해주기
        }

        const long MIN = long.MinValue >> 2;

        long[] money = new long[n];
        Array.Fill(money, MIN);

        money[start] = arr[start];

        for (int i = 1; i < n; i++) // 최단경로는 간선을 최대 n-1번만 사용함. 
        {
            foreach ((int from, int to, int cost) in edge)
            {
                if (money[from] != MIN && money[from] + cost > money[to])
                {
                    money[to] = money[from] + cost;
                }
            }
        }

        if (money[end] == MIN)
        {
            sw.Write("gg");
            return;
        }

        bool[] visited = new bool[n];

        // n번째 갱신이 일어나면 최단경로 갱신이 아니라 음수 싸이클이 존재함.
        foreach ((int from, int to, int cost) in edge)
        {
            if (money[from] != MIN && money[from] + cost > money[to] && Move(to)) // 적어도 to => end 로 갈수있음을 보장해야 도착지와 관련없는 싸이클의 개입을 막음.
            {
                sw.Write("Gee");
                return;
            }
        }

        sw.Write(money[end]);

        bool Move(int start)
        {
            Array.Fill(visited, false);

            Queue<int> queue = new Queue<int>();
            visited[start] = true;
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                if (node == end) return true;

                for (int i = 0; i < m; i++)
                {
                    int from = edge[i].from;
                    int to = edge[i].to;

                    if (node == from && !visited[to])
                    {
                        visited[to] = true;
                        queue.Enqueue(to);
                    }
                }
            }
            return false;
        }
    }
}