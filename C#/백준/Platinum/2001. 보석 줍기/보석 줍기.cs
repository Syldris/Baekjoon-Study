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

        uint[] jewel = new uint[n + 1];
        for (int i = 0; i < k; i++)
        {
            int pos = int.Parse(sr.ReadLine());
            jewel[pos] = (uint)1 << i;
        }

        bool[,] visited = new bool[n + 1, 1 << k]; // k = 3이면 0~7까지 표현해야하니 크기8 필요 즉 1<<k 만큼

        List<(int node, int weight)>[] graph = new List<(int, int)>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new();

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            graph[line[0]].Add((line[1], line[2]));
            graph[line[1]].Add((line[0], line[2]));
        }

        Queue<(int node, uint curJewel)> queue = new();

        uint startJewel = jewel[1];
        if (startJewel > 0) // 시작지점에 보석이 있는경우
        {
            visited[1, startJewel] = true;
            queue.Enqueue((1, startJewel));
        }

        visited[1, 0] = true;
        queue.Enqueue((1, 0));

        while (queue.Count > 0)
        {
            (int node, uint curJewel) = queue.Dequeue();
            foreach (var next in graph[node])
            {
                /*int weight = 0;
                for (int i = 0; i < k; i++)
                {
                    bool bit = ((curJewel >> i) & 1) == 1;
                    if (bit) weight++;
                }*/

                int weight = BitOperations.PopCount(curJewel); // 켜진 비트기 몇개인지 핀뱔히는 메소드다.

                if (weight <= next.weight) // 현재 들고있는 무게가 다리보다 무겁지 않아야 이동가능.
                {
                    uint nextJewel = curJewel | jewel[next.node]; // 보석은 이동하고나서 줍는다.

                    if (!visited[next.node, nextJewel]) // 줍고 지나갈때
                    {
                        visited[next.node, nextJewel] = true;
                        queue.Enqueue((next.node, nextJewel));
                    }
                    if (!visited[next.node, curJewel]) // 안줍고 지나갈때
                    {
                        visited[next.node, curJewel] = true;
                        queue.Enqueue((next.node, curJewel));
                    }
                }

            }
        }

        int result = 0;
        int size = 1 << k;
        for (uint i = 0; i < size; i++)
        {
            if (visited[1, i])
                result = Math.Max(result, BitOperations.PopCount(i));
        }

        sw.Write(result);
    }
}