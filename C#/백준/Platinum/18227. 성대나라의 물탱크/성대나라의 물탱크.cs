#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int c = int.Parse(input[1]);

        List<int>[] graph = new List<int>[n + 1];
        for (int i = 1; i <= n; i++)
            graph[i] = new();

        for (int i = 1; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            graph[line[0]].Add(line[1]); // A => B
            graph[line[1]].Add(line[0]); // B => A
        }

        (int start, int end)[] range = new (int, int)[n + 1];
        int[] level = new int[n + 1];
        int rank = 0;

        DFS(c, -1, 1);
        long[] tree = new long[n * 4];
        int q = int.Parse(sr.ReadLine());

        for (int i = 0; i < q; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int node = line[1];
            if (line[0] == 1)
            {
                int index = range[node].start;
                Update(1, 1, n, index); // 물 업데이트 index위치에 +1
            }
            else
            {
                (int left, int right) = range[node]; 
                sw.WriteLine(Query(1, 1, n, left, right) * level[node]); // 물의양 = 서브트리 업데이트 횟수 * 트리에서의 깊이
            }
        }

        /* 오일러 경로 테크닉에서의 역발상을 통해서 해결가능함.
        통상적으로 부모에서 자식으로의 전파는 부모노드의 구간을 lazy세그로 구간 업데이트를 통해서 자식에서도 확인가능함.
        
        그러나 이문제는 자식에서 부모로의 전파를 통해 푸는게 쉬운문제임. 
        물의 양은 본인 자식을 포함한 서브트리내에서 물이 업데이트 된 횟수만 안다면 
        업데이트 1회마다 물을 받는양은 트리에서의 깊이라는걸 관찰하면 해결가능함.
        
        자식에서 부모로 전파는 불가능하지만 자식에서 +1 업데이트로 점업데이트후,
        부모노드에선 그것을 범위쿼리를통해 체크해서 본인 서브트리내에서 몇번 업데이트되었는지 체크가능함!
         */
        
        void DFS(int node, int parent, int depth)
        {
            range[node].start = ++rank;
            level[node] = depth;
            foreach (var child in graph[node])
            {
                if (parent == child) continue;

                DFS(child, node, depth + 1);
            }

            range[node].end = rank;
        }

        void Update(int node, int start, int end, int index)
        {
            if (start == end)
            {
                tree[node]++;
                return;
            }

            int mid = (start + end) / 2;

            if (index <= mid)
            {
                Update(node << 1, start, mid, index);
            }
            else
            {
                Update((node << 1) + 1, mid + 1, end, index);
            }
            tree[node] = tree[node << 1] + tree[(node << 1) + 1];
        }

        long Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
            {
                return 0;
            }

            if (left <= start && end <= right)
            {
                return tree[node];
            }

            int mid = (start + end) / 2;

            return Query(node << 1, start, mid, left, right) + Query((node << 1) + 1, mid + 1, end, left, right);
        }
    }
}